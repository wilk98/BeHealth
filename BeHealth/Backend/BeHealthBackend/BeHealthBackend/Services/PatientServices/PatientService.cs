using AutoMapper;
using BeHealthBackend.Configurations.Exceptions;
using BeHealthBackend.DataAccess.DbContexts;
using BeHealthBackend.DataAccess.Entities;
using BeHealthBackend.DataAccess.Repositories.Interfaces;
using BeHealthBackend.DTOs.AccountDtoFolder;
using BeHealthBackend.DTOs.PatientDtoFolder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BeHealthBackend.Authorization;

namespace BeHealthBackend.Services.PatientServices;
public class PatientService : IPatientService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IPasswordHasher<Patient> _passwordHasher;
    private readonly BeHealthContext _context;
    private readonly AuthenticationSettings _authenticationSettings;
    private readonly IAuthorizationService _authorizationService;

    public PatientService(IUnitOfWork unitOfWork, IMapper mapper, IPasswordHasher<Patient> passwordHasher,
        BeHealthContext context, AuthenticationSettings authenticationSettings, IAuthorizationService authorizationService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _passwordHasher = passwordHasher;
        _context = context;
        _authenticationSettings = authenticationSettings;
        _authorizationService = authorizationService;
    }

    public async Task<IEnumerable<PatientDto>> GetPatientsAsync()
    {
        var patients = await _unitOfWork.PatientRepository
            .GetAllAsync(includeProperties: "Address");

        var patientsDto = _mapper.Map<List<PatientDto>>(patients);

        return patientsDto;
    }

    public async Task<PatientDto> GetIdAsync(int id)
    {
        var patient = await _unitOfWork.PatientRepository
            .GetAsync(p => p.Id == id, includeProperties: "Address");

        if (patient is null)
            throw new NotFoundApiException(nameof(PatientDto), id.ToString());

        var patientDto = _mapper.Map<PatientDto>(patient);

        return patientDto;
    }

    public async Task<(int, CreatePatientDto)> CreateAsync(CreatePatientDto dto)
    {
        var patient = _mapper.Map<Patient>(dto);
        var hashedPassword = _passwordHasher.HashPassword(patient, dto.PasswordHash);
        patient.PasswordHash = hashedPassword;

        await _unitOfWork.PatientRepository.AddAsync(patient);
        await _unitOfWork.SaveAsync();

        return (patient.Id, _mapper.Map<CreatePatientDto>(patient));
    }

    public async Task UpdateAsync(int id, UpdatePatientDto dto, ClaimsPrincipal user)
    {
        var patient = await _unitOfWork.PatientRepository
            .GetAsync(id);

        if (patient is null)
            throw new NotFoundApiException(nameof(PatientDto), id.ToString());

        var authorizationResult = _authorizationService.AuthorizeAsync(user, patient,
            new ResourceOperationRequirement(ResourceOperation.Update)).Result;

        if (!authorizationResult.Succeeded)
            throw new ForbidException("You are not a owner!");

        _mapper.Map(dto, patient);
        await _unitOfWork.SaveAsync();
    }

    public async Task DeleteAsync(int id, ClaimsPrincipal user)
    {
        var patient = await _unitOfWork.PatientRepository
            .GetAsync(id);

        if (patient is null)
            throw new NotFoundApiException(nameof(PatientDto), id.ToString());

        var authorizationResult = _authorizationService.AuthorizeAsync(user, patient,
            new ResourceOperationRequirement(ResourceOperation.Update)).Result;

        if (!authorizationResult.Succeeded)
            throw new ForbidException("You are not a owner!");

        _unitOfWork.PatientRepository.Remove(patient);
        await _unitOfWork.SaveAsync();
    }

    public string GenerateJwt(LoginDto dto)
    {
        var user = _context.Patients.FirstOrDefault(d => d.Email == dto.Email);

        if (user is null)
            throw new BadRequestException("Invalid username or password!");

        var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);

        if (result == PasswordVerificationResult.Failed)
            throw new BadRequestException("Invalid username or password!");

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
