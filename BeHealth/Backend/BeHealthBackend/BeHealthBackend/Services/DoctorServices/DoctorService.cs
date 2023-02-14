using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using BeHealthBackend.Authorization;
using BeHealthBackend.Configurations.Exceptions;
using BeHealthBackend.DataAccess.DbContexts;
using BeHealthBackend.DataAccess.Entities;
using BeHealthBackend.DataAccess.Repositories.Interfaces;
using BeHealthBackend.DTOs.AccountDtoFolder;
using BeHealthBackend.DTOs.DoctorDtoFolder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace BeHealthBackend.Services.DoctorServices;
public class DoctorService : IDoctorService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IPasswordHasher<Doctor> _passwordHasher;
    private readonly BeHealthContext _context;
    private readonly AuthenticationSettings _authenticationSettings;
    private readonly IAuthorizationService _authorizationService;

    public DoctorService(IUnitOfWork unitOfWork, IMapper mapper, IPasswordHasher<Doctor> passwordHasher,
        BeHealthContext context, AuthenticationSettings authenticationSettings, IAuthorizationService authorizationService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _passwordHasher = passwordHasher;
        _context = context;
        _authenticationSettings = authenticationSettings;
        _authorizationService = authorizationService;
    }

    public async Task<IEnumerable<DoctorDto>> GetDoctorsAsync()
    {
        var doctors = await _unitOfWork.DoctorRepository
            .GetAllAsync(includeProperties: "Address");

        var doctorsDto = _mapper.Map<List<DoctorDto>>(doctors);

        return doctorsDto;
    }

    public async Task<DoctorDto> GetIdAsync(int id)
    {
        var doctor = await _unitOfWork.DoctorRepository
            .GetAsync(d => d.Id == id, includeProperties: "Address");

        if (doctor is null)
            throw new NotFoundApiException(nameof(DoctorDto), id.ToString());

        var doctorDto = _mapper.Map<DoctorDto>(doctor);

        return doctorDto;
    }

    public async Task<(int, CreateDoctorDto)> CreateAsync(CreateDoctorDto dto)
    {
        var doctor = _mapper.Map<Doctor>(dto);
        var hashedPassword = _passwordHasher.HashPassword(doctor, dto.PasswordHash);
        doctor.PasswordHash = hashedPassword;

        await _unitOfWork.DoctorRepository.AddAsync(doctor);
        await _unitOfWork.SaveAsync();

        return (doctor.Id, _mapper.Map<CreateDoctorDto>(doctor));
    }

    public async Task UpdateAsync(int id, UpdateDoctorDto dto, ClaimsPrincipal user)
    {
        var doctor = await _unitOfWork.DoctorRepository
            .GetAsync(id);

        if (doctor is null)
            throw new NotFoundApiException(nameof(DoctorDto), id.ToString());

        var authorizationResult = _authorizationService.AuthorizeAsync(user, doctor,
            new ResourceOperationRequirement(ResourceOperation.Update)).Result;

        if (!authorizationResult.Succeeded)
            throw new ForbidException("You are not a owner!");

        _mapper.Map(dto, doctor);
        await _unitOfWork.SaveAsync();
    }

    public async Task DeleteAsync(int id, ClaimsPrincipal user)
    {
        var doctor = await _unitOfWork.DoctorRepository
            .GetAsync(id);

        if (doctor is null)
            throw new NotFoundApiException(nameof(DoctorDto), id.ToString());

        var authorizationResult = _authorizationService.AuthorizeAsync(user, doctor,
            new ResourceOperationRequirement(ResourceOperation.Delete)).Result;

        if (!authorizationResult.Succeeded)
            throw new ForbidException("You are not a owner!");

        _unitOfWork.DoctorRepository.Remove(doctor);
        await _unitOfWork.SaveAsync();
    }

    public string GenerateJwt(LoginDto dto)
    {
        var user = _context.Doctors.FirstOrDefault(d => d.Email == dto.Email);

        if (user is null)
            throw new BadRequestException("Invalid username or password");

        var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);

        if (result == PasswordVerificationResult.Failed)
            throw new BadRequestException("Invalid username or password");

        var claims = new List<Claim>()
        {
            new (ClaimTypes.NameIdentifier, user.Id.ToString()),
            new (ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
            new (ClaimTypes.Role, $"{user.Role}")
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
        var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

        var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer, _authenticationSettings.JwtIssuer, claims,
            expires: expires, signingCredentials: cred);

        var tokenHandler = new JwtSecurityTokenHandler();

        return tokenHandler.WriteToken(token);
    }
}