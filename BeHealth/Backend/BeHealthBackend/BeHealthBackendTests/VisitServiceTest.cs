using AutoMapper;
using BeHealthBackend.DataAccess.Entities;
using BeHealthBackend.DataAccess.Repositories.Interfaces;
using BeHealthBackend.DTOs.VisitDtoFolder;
using BeHealthBackend.Services.VisitServices;
using Moq;

namespace BeHealthBackendTests;

public class VisitServiceTest
{
    private readonly VisitsService _sut;
    private readonly Mock<IUnitOfWork> _unitOfWork = new();
    private readonly Mock<IMapper> _mapper = new();

    public VisitServiceTest()
    {
        _sut = new VisitsService(_unitOfWork.Object, _mapper.Object);
    }

    [Fact]
    public async Task CreateAsync_ShouldAddVisit_WhenDoctorAndPatientExist()
    {
        // Arrange
        var createVisitDto = new CreateVisitDto
        {
            DoctorId = 1,
            PatientId = 1,
            Duration = 30,
            Name = "Test",
            VisitDate = DateTime.UtcNow,
        };
        var visitMock = new Visit
        {
            DoctorId = createVisitDto.DoctorId,
            PatientId = createVisitDto.PatientId,
            Duration = createVisitDto.Duration,
            Name = createVisitDto.Name,
            VisitDate = createVisitDto.VisitDate,
        };
        var patientMock = new Patient
        {
            Id = createVisitDto.PatientId,
            FirstName = "Test",
            LastName = "Test",
        };
        var doctorMock = new Doctor
        {
            Id = createVisitDto.DoctorId,
            FirstName = "Test",
            LastName = "Test",
        };

        _mapper.Setup(mapper => mapper.Map<Visit>(createVisitDto))
            .Returns(visitMock);

        _unitOfWork.Setup(unitOfWork => unitOfWork.PatientRepository.GetAsync(createVisitDto.PatientId))
            .ReturnsAsync(patientMock);

        _unitOfWork.Setup(unitOfWork => unitOfWork.DoctorRepository.GetAsync(createVisitDto.DoctorId))
            .ReturnsAsync(doctorMock);

        _unitOfWork.Setup(unitOfWork => unitOfWork.VisitRepository.AddAsync(visitMock));

        _unitOfWork.Setup(unitOfWork => unitOfWork.SaveAsync());

        // Act

        var (_, visit) = await _sut.CreateAsync(createVisitDto);

        // Assert

        Assert.NotNull(visit);

        Assert.Equal(createVisitDto.Name, visit.Name);
        Assert.Equal(createVisitDto.PatientId, visit.PatientId);
        Assert.Equal(createVisitDto.DoctorId, visit.DoctorId);
        Assert.Equal(createVisitDto.Duration, visit.Duration);
    }

    [Fact]
    public async Task CreateAsync_ShouldReturnNull_WhenDoctorDoesntExist()
    {
        // Arrange
        var createVisitDto = new CreateVisitDto
        {
            DoctorId = 1,
            PatientId = 1,
            Duration = 30,
            Name = "Test",
            VisitDate = DateTime.UtcNow,
        };
        var visitMock = new Visit
        {
            DoctorId = createVisitDto.DoctorId,
            PatientId = createVisitDto.PatientId,
            Duration = createVisitDto.Duration,
            Name = createVisitDto.Name,
            VisitDate = createVisitDto.VisitDate,
        };
        var patientMock = new Patient
        {
            Id = createVisitDto.PatientId,
            FirstName = "Test",
            LastName = "Test",
        };

        _mapper.Setup(mapper => mapper.Map<Visit>(createVisitDto))
            .Returns(visitMock);

        _unitOfWork.Setup(unitOfWork => unitOfWork.PatientRepository.GetAsync(createVisitDto.PatientId))
            .ReturnsAsync(patientMock);

        _unitOfWork.Setup(unitOfWork => unitOfWork.DoctorRepository.GetAsync(createVisitDto.DoctorId))
            .ReturnsAsync(() => null);

        _unitOfWork.Setup(unitOfWork => unitOfWork.VisitRepository.AddAsync(visitMock));

        _unitOfWork.Setup(unitOfWork => unitOfWork.SaveAsync());

        // Act

        var (_, visit) = await _sut.CreateAsync(createVisitDto);

        // Assert

        Assert.Null(visit);
    }

    [Fact]
    public async Task CreateAsync_ShouldReturnNull_WhenPatientDoesntExist()
    {
        // Arrange
        var createVisitDto = new CreateVisitDto
        {
            DoctorId = 1,
            PatientId = 1,
            Duration = 30,
            Name = "Test",
            VisitDate = DateTime.UtcNow,
        };
        var visitMock = new Visit
        {
            DoctorId = createVisitDto.DoctorId,
            PatientId = createVisitDto.PatientId,
            Duration = createVisitDto.Duration,
            Name = createVisitDto.Name,
            VisitDate = createVisitDto.VisitDate,
        };

        var doctorMock = new Doctor
        {
            Id = createVisitDto.DoctorId,
            FirstName = "Test",
            LastName = "Test",
        };

        _mapper.Setup(mapper => mapper.Map<Visit>(createVisitDto))
            .Returns(visitMock);

        _unitOfWork.Setup(unitOfWork => unitOfWork.PatientRepository.GetAsync(createVisitDto.PatientId))
            .ReturnsAsync(() => null);

        _unitOfWork.Setup(unitOfWork => unitOfWork.DoctorRepository.GetAsync(createVisitDto.DoctorId))
            .ReturnsAsync(doctorMock);

        _unitOfWork.Setup(unitOfWork => unitOfWork.VisitRepository.AddAsync(visitMock));

        _unitOfWork.Setup(unitOfWork => unitOfWork.SaveAsync());

        // Act

        var (_, visit) = await _sut.CreateAsync(createVisitDto);

        // Assert

        Assert.Null(visit);
    }

    [Fact]
    public async Task CreateAsync_ShouldAddVisit_When_NoOtherVisits()
    {
        // Arrange
        var createVisitDto = new CreateVisitDto
        {
            DoctorId = 1,
            PatientId = 1,
            Duration = 30,
            Name = "Test",
            VisitDate = DateTime.UtcNow,
        };
        var visitMock = new Visit
        {
            DoctorId = createVisitDto.DoctorId,
            PatientId = createVisitDto.PatientId,
            Duration = createVisitDto.Duration,
            Name = createVisitDto.Name,
            VisitDate = createVisitDto.VisitDate,
        };
        var patientMock = new Patient
        {
            Id = createVisitDto.PatientId,
            FirstName = "TestPatient",
            LastName = "TestPatient",
        };
        var doctorMock = new Doctor
        {
            Id = createVisitDto.DoctorId,
            FirstName = "TestDoctor",
            LastName = "TestDoctor",
        };

        _mapper.Setup(mapper => mapper.Map<Visit>(createVisitDto))
            .Returns(visitMock);

        _unitOfWork.Setup(unitOfWork => unitOfWork.PatientRepository.GetAsync(createVisitDto.PatientId))
            .ReturnsAsync(patientMock);

        _unitOfWork.Setup(unitOfWork => unitOfWork.DoctorRepository.GetAsync(createVisitDto.DoctorId))
            .ReturnsAsync(doctorMock);

        _unitOfWork.Setup(unitOfWork => unitOfWork.VisitRepository.AddAsync(visitMock));
        _unitOfWork.Setup(unitOfWork => unitOfWork.SaveAsync());

        _unitOfWork.Setup(unitOfWork => unitOfWork.VisitRepository
                          .GetDoctorVisitForDate(doctorMock.Id,
                                                 visitMock.VisitDate,
                                                 visitMock.VisitDate.AddMinutes(visitMock.Duration)))
            .ReturnsAsync(() => null);

        _unitOfWork.Setup(unitOfWork => unitOfWork.VisitRepository
                          .GetPatientVisitForDate(patientMock.Id,
                                                 visitMock.VisitDate,
                                                 visitMock.VisitDate.AddMinutes(visitMock.Duration)))
            .ReturnsAsync(() => null);

        // Act

        var (_, visit) = await _sut.CreateAsync(createVisitDto);

        // Assert
        //
        Assert.NotNull(visit);
    }

    [Fact]
    public async Task CreateAsync_ShouldReturnNull_When_AnotherVisitHadBeenAppointedAtThatTime()
    {
        // Arrange
        var createVisitDto = new CreateVisitDto
        {
            DoctorId = 1,
            PatientId = 1,
            Duration = 30,
            Name = "Test",
            VisitDate = DateTime.UtcNow,
        };
        var visitMock = new Visit
        {
            DoctorId = createVisitDto.DoctorId,
            PatientId = createVisitDto.PatientId,
            Duration = createVisitDto.Duration,
            Name = createVisitDto.Name,
            VisitDate = createVisitDto.VisitDate,
        };
        var appointedVisit = visitMock;
        var patientMock = new Patient
        {
            Id = createVisitDto.PatientId,
            FirstName = "TestPatient",
            LastName = "TestPatient",
        };
        var doctorMock = new Doctor
        {
            Id = createVisitDto.DoctorId,
            FirstName = "TestDoctor",
            LastName = "TestDoctor",
        };

        _mapper.Setup(mapper => mapper.Map<Visit>(createVisitDto))
            .Returns(visitMock);

        _unitOfWork.Setup(unitOfWork => unitOfWork.PatientRepository.GetAsync(createVisitDto.PatientId))
            .ReturnsAsync(patientMock);

        _unitOfWork.Setup(unitOfWork => unitOfWork.DoctorRepository.GetAsync(createVisitDto.DoctorId))
            .ReturnsAsync(doctorMock);

        _unitOfWork.Setup(unitOfWork => unitOfWork.VisitRepository.AddAsync(visitMock));
        _unitOfWork.Setup(unitOfWork => unitOfWork.SaveAsync());

        _unitOfWork.Setup(unitOfWork => unitOfWork.VisitRepository
                          .GetDoctorVisitForDate(doctorMock.Id,
                                                 visitMock.VisitDate,
                                                 visitMock.VisitDate.AddMinutes(visitMock.Duration)))
            .ReturnsAsync(() => appointedVisit);

        _unitOfWork.Setup(unitOfWork => unitOfWork.VisitRepository
                          .GetPatientVisitForDate(patientMock.Id,
                                                 visitMock.VisitDate,
                                                 visitMock.VisitDate.AddMinutes(visitMock.Duration)))
            .ReturnsAsync(() => appointedVisit);

        // Act

        var (_, visit) = await _sut.CreateAsync(createVisitDto);

        // Assert
        //
        Assert.Null(visit);
    }

    [Fact]
    public async Task CreateAsync_ShouldReturnNull_WhenVisitBeforeIsNotFinished()
    {
        // Arrange
        var createVisitDto = new CreateVisitDto
        {
            DoctorId = 1,
            PatientId = 1,
            Duration = 30,
            Name = "Test",
            VisitDate = DateTime.UtcNow,
        };
        var visitMock = new Visit
        {
            DoctorId = createVisitDto.DoctorId,
            PatientId = createVisitDto.PatientId,
            Duration = createVisitDto.Duration,
            Name = createVisitDto.Name,
            VisitDate = createVisitDto.VisitDate,
        };
        var appointedVisit = visitMock;
        appointedVisit.VisitDate = appointedVisit.VisitDate.AddMinutes(-10);

        var patientMock = new Patient
        {
            Id = createVisitDto.PatientId,
            FirstName = "TestPatient",
            LastName = "TestPatient",
        };
        var doctorMock = new Doctor
        {
            Id = createVisitDto.DoctorId,
            FirstName = "TestDoctor",
            LastName = "TestDoctor",
        };

        _mapper.Setup(mapper => mapper.Map<Visit>(createVisitDto))
            .Returns(visitMock);

        _unitOfWork.Setup(unitOfWork => unitOfWork.PatientRepository.GetAsync(createVisitDto.PatientId))
            .ReturnsAsync(patientMock);

        _unitOfWork.Setup(unitOfWork => unitOfWork.DoctorRepository.GetAsync(createVisitDto.DoctorId))
            .ReturnsAsync(doctorMock);

        _unitOfWork.Setup(unitOfWork => unitOfWork.VisitRepository.AddAsync(visitMock));
        _unitOfWork.Setup(unitOfWork => unitOfWork.SaveAsync());

        _unitOfWork.Setup(unitOfWork => unitOfWork.VisitRepository
                          .GetDoctorVisitForDate(doctorMock.Id,
                                                 visitMock.VisitDate,
                                                 visitMock.VisitDate.AddMinutes(visitMock.Duration)))
            .ReturnsAsync(() => appointedVisit);

        _unitOfWork.Setup(unitOfWork => unitOfWork.VisitRepository
                          .GetPatientVisitForDate(patientMock.Id,
                                                 visitMock.VisitDate,
                                                 visitMock.VisitDate.AddMinutes(visitMock.Duration)))
            .ReturnsAsync(() => appointedVisit);

        // Act

        var (_, visit) = await _sut.CreateAsync(createVisitDto);

        // Assert
        //
        Assert.Null(visit);
    }

    [Fact]
    public async Task CreateAsync_ShouldReturnNull_WhenVisitVisitStartsAfterThatBeingAdded()
    {
        // Arrange
        var createVisitDto = new CreateVisitDto
        {
            DoctorId = 1,
            PatientId = 1,
            Duration = 30,
            Name = "Test",
            VisitDate = DateTime.UtcNow,
        };
        var visitMock = new Visit
        {
            DoctorId = createVisitDto.DoctorId,
            PatientId = createVisitDto.PatientId,
            Duration = createVisitDto.Duration,
            Name = createVisitDto.Name,
            VisitDate = createVisitDto.VisitDate,
        };
        var appointedVisit = visitMock;
        appointedVisit.VisitDate = appointedVisit.VisitDate.AddMinutes(10);

        var patientMock = new Patient
        {
            Id = createVisitDto.PatientId,
            FirstName = "TestPatient",
            LastName = "TestPatient",
        };
        var doctorMock = new Doctor
        {
            Id = createVisitDto.DoctorId,
            FirstName = "TestDoctor",
            LastName = "TestDoctor",
        };

        _mapper.Setup(mapper => mapper.Map<Visit>(createVisitDto))
            .Returns(visitMock);

        _unitOfWork.Setup(unitOfWork => unitOfWork.PatientRepository.GetAsync(createVisitDto.PatientId))
            .ReturnsAsync(patientMock);

        _unitOfWork.Setup(unitOfWork => unitOfWork.DoctorRepository.GetAsync(createVisitDto.DoctorId))
            .ReturnsAsync(doctorMock);

        _unitOfWork.Setup(unitOfWork => unitOfWork.VisitRepository.AddAsync(visitMock));
        _unitOfWork.Setup(unitOfWork => unitOfWork.SaveAsync());

        _unitOfWork.Setup(unitOfWork => unitOfWork.VisitRepository
                          .GetDoctorVisitForDate(doctorMock.Id,
                                                 visitMock.VisitDate,
                                                 visitMock.VisitDate.AddMinutes(visitMock.Duration)))
            .ReturnsAsync(() => appointedVisit);

        _unitOfWork.Setup(unitOfWork => unitOfWork.VisitRepository
                          .GetPatientVisitForDate(patientMock.Id,
                                                 visitMock.VisitDate,
                                                 visitMock.VisitDate.AddMinutes(visitMock.Duration)))
            .ReturnsAsync(() => appointedVisit);

        // Act

        var (_, visit) = await _sut.CreateAsync(createVisitDto);

        // Assert
        //
        Assert.Null(visit);
    }
}
