using Moq;
using BeHealthBackend.DataAccess.Entities;
using BeHealthBackend.DataAccess.DbContexts;
using Moq.EntityFrameworkCore;
using BeHealthBackend.DataAccess.Repositories;

namespace BeHealthBackendTests;

public class ClinicRepositoryTests
{
    [Fact]
    public async Task GetByDoctorIdAsync_ShouldReturnEmptyList_WhenThereAreNoClinics()
    {
        // Arrange
        var beHealthContextMock = new Mock<BeHealthContext>();
        beHealthContextMock.Setup(c => c.Clinics).ReturnsDbSet(new List<Clinic>());
        // Act
        var clinicRepository = new ClinicRepository(beHealthContextMock.Object);
        // Assert
        var result = await clinicRepository.GetByDoctorIdAsync(1);
        Assert.Empty(result);
    }

    [Fact]
    public async Task GetByDoctorIdAsync_ShouldReturnOneClinicWithDoctor_WhenThereAreClinicWithThatDoctor()
    {
        // Arrange
        var doctor = new Doctor { Id = 1 };
        var clinic = new Clinic { Id = 1, Doctors = new List<Doctor> { doctor } };
        var beHealthContextMock = new Mock<BeHealthContext>();
        beHealthContextMock.Setup(c => c.Clinics).ReturnsDbSet(new List<Clinic> { clinic });
        // Act
        var clinicRepository = new ClinicRepository(beHealthContextMock.Object);
        // Assert
        var result = await clinicRepository.GetByDoctorIdAsync(1);
        Assert.Single(result);
        Assert.Equal(1, result[0].Id);
        Assert.Equal(1, result[0].Doctors[0].Id);
    }

    [Fact]
    public async Task GetByDoctorIdAsync_ShouldReturnOneClinicWithDoctor_WhenThereAreClinicWithThatDoctorAndOthers()
    {
        // Arrange
        var doctor = new Doctor { Id = 1 };
        var clinic = new Clinic { Id = 1, Doctors = new List<Doctor> { doctor } };
        var clinic2 = new Clinic { Id = 2, Doctors = new List<Doctor>() };
        var beHealthContextMock = new Mock<BeHealthContext>();
        beHealthContextMock.Setup(c => c.Clinics).ReturnsDbSet(new List<Clinic> { clinic, clinic2 });
        // Act
        var clinicRepository = new ClinicRepository(beHealthContextMock.Object);
        // Assert
        var result = await clinicRepository.GetByDoctorIdAsync(1);
        Assert.Single(result);
        Assert.Equal(1, result[0].Id);
        Assert.Equal(1, result[0].Doctors[0].Id);
    }

    [Fact]
    public async Task GetByDoctorIdAsync_ShouldReturnTwoClinicsWithDoctor_WhenThereAreClinicWithThatDoctorAndOthers()
    {
        // Arrange
        var doctor = new Doctor { Id = 1 };
        var doctor2 = new Doctor { Id = 2 };
        var clinic = new Clinic { Id = 1, Doctors = new List<Doctor> { doctor } };
        var clinic2 = new Clinic { Id = 2, Doctors = new List<Doctor> { doctor } };
        var clinic3 = new Clinic { Id = 3, Doctors = new List<Doctor> { doctor2 } };
        var beHealthContextMock = new Mock<BeHealthContext>();
        beHealthContextMock.Setup(c => c.Clinics).ReturnsDbSet(new List<Clinic> { clinic, clinic2, clinic3 });
        // Act
        var clinicRepository = new ClinicRepository(beHealthContextMock.Object);
        // Assert
        var result = await clinicRepository.GetByDoctorIdAsync(1);
        Assert.Equal(2, result.Count);
        Assert.Equal(1, result[0].Id);
        Assert.Equal(1, result[0].Doctors[0].Id);
        Assert.Equal(2, result[1].Id);
        Assert.Equal(1, result[1].Doctors[0].Id);
    }
}