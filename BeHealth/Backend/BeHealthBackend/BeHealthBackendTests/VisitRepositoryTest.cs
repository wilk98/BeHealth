using BeHealthBackend.DataAccess.DbContexts;
using BeHealthBackend.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BeHealthBackendTests;

/*
    That is not unit testing. That's integration
    testing. The whole point of unit testing is remove
    dependencies from unit test. So using the
    InMemory database is just another dependency.
 */

public class VisitRepositoryTest
{
    [Fact]
    public async Task GetDoctorVisitForDate_ReturnsNull_WhenNoVisits()
    {
        var options = new DbContextOptionsBuilder<BeHealthContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        var startDate = new DateTime();
        var endDate = new DateTime();
        var doctorId = 0;

        using var context = new BeHealthContext(options);
        var systemUnderTest = new VisitRepository(context);
        var visit = await systemUnderTest.GetDoctorVisitForDate(doctorId, startDate, endDate);

        Assert.Null(visit);
    }


    [Fact]
    public async Task GetDoctorVisitForDate_ReturnsVisit_WhenVisitStartedBeforeAndContinues()
    {
        var options = new DbContextOptionsBuilder<BeHealthContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        var plannedVisitStartDate = new DateTime(2010, 1, 1, 12, 30, 0);
        var visitName = "Test";
        int duration = 60;
        var doctorId = 1;

        using (var context = new BeHealthContext(options))
        {
            context.Visits.Add(new BeHealthBackend.DataAccess.Entities.Visit
            {
                Name = visitName,
                DoctorId = doctorId,
                VisitDate = plannedVisitStartDate,
                Duration = duration
            });
            context.SaveChanges();
        }

        var newVisitStartDate = new DateTime(2010, 1, 1, 13, 00, 0); // Last one hour
        var newVisitEndDate = new DateTime(2010, 1, 1, 14, 00, 0);

        using (var context = new BeHealthContext(options))
        {
            var systemUnderTest = new VisitRepository(context);
            var visit = await systemUnderTest.GetDoctorVisitForDate(doctorId, newVisitStartDate, newVisitEndDate);

            Assert.NotNull(visit);
            Assert.Equal(visitName, visit.Name);
            Assert.Equal(plannedVisitStartDate, visit.VisitDate);
        }
    }

    [Fact]
    public async Task GetDoctorVisitForDate_ReturnsVisit_WhenVisitStartsInDurationOfThatBeingAdded()
    {
        var options = new DbContextOptionsBuilder<BeHealthContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        var plannedVisitStartDate = new DateTime(2010, 1, 1, 12, 30, 0);
        int duration = 60;
        var doctorId = 1;
        var visitName = "Test 2";

        using (var context = new BeHealthContext(options))
        {
            context.Visits.Add(new BeHealthBackend.DataAccess.Entities.Visit
            {
                Name = visitName,
                DoctorId = doctorId,
                VisitDate = plannedVisitStartDate,
                Duration = duration
            });
            context.SaveChanges();
        }

        var newVisitStartDate = new DateTime(2010, 1, 1, 12, 00, 0); // Last one hour - intersects with that one at 12:30
        var newVisitEndDate = new DateTime(2010, 1, 1, 13, 00, 0);

        using (var context = new BeHealthContext(options))
        {
            var systemUnderTest = new VisitRepository(context);
            var visit = await systemUnderTest.GetDoctorVisitForDate(doctorId, newVisitStartDate, newVisitEndDate);

            Assert.NotNull(visit);
            Assert.Equal(visitName, visit.Name);
            Assert.Equal(plannedVisitStartDate, visit.VisitDate);
        }
    }

    [Fact]
    public async Task GetDoctorVisitForDate_ReturnsVisit_WhenInBetweenTwoVisits()
    {
        var options = new DbContextOptionsBuilder<BeHealthContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        var plannedVisitStartDate = new DateTime(2010, 1, 1, 12, 30, 0);
        int duration = 60;
        var doctorId = 1;
        var visitName = "Test 1";


        var secondPlannedVisitStartDate = new DateTime(2010, 1, 1, 13, 45, 0);
        int secondDuration = 60;
        var secondVisitName = "Test 2";

        using (var context = new BeHealthContext(options))
        {
            context.Visits.Add(new BeHealthBackend.DataAccess.Entities.Visit
            {
                Name = visitName,
                DoctorId = doctorId,
                VisitDate = plannedVisitStartDate,
                Duration = duration
            });
            context.Visits.Add(new BeHealthBackend.DataAccess.Entities.Visit
            {
                Name = secondVisitName,
                DoctorId = doctorId,
                VisitDate = secondPlannedVisitStartDate,
                Duration = secondDuration
            });
            context.SaveChanges();
        }

        var newVisitStartDate = new DateTime(2010, 1, 1, 13, 30, 0); // Last one hour - intersects with that one at 12:30
        var newVisitEndDate = new DateTime(2010, 1, 1, 14, 00, 0);


        using (var context = new BeHealthContext(options))
        {
            var systemUnderTest = new VisitRepository(context);
            var visit = await systemUnderTest.GetDoctorVisitForDate(doctorId, newVisitStartDate, newVisitEndDate);

            Assert.NotNull(visit);
        }
    }

    [Fact]
    public async Task GetDoctorVisitForDate_ReturnsNull_WhenNewVisitIsAfterPlanned()
    {
        var options = new DbContextOptionsBuilder<BeHealthContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        var plannedVisitStartDate = new DateTime(2010, 1, 1, 12, 30, 0);
        var visitName = "Test";
        int duration = 60;
        var doctorId = 1;

        using (var context = new BeHealthContext(options))
        {
            context.Visits.Add(new BeHealthBackend.DataAccess.Entities.Visit
            {
                Name = visitName,
                DoctorId = doctorId,
                VisitDate = plannedVisitStartDate,
                Duration = duration
            });
            context.SaveChanges();
        }

        var newVisitStartDate = new DateTime(2010, 1, 1, 13, 30, 0); // Starts right after end of already planned
        var newVisitEndDate = new DateTime(2010, 1, 1, 14, 00, 0);

        using (var context = new BeHealthContext(options))
        {
            var systemUnderTest = new VisitRepository(context);
            var visit = await systemUnderTest.GetDoctorVisitForDate(doctorId, newVisitStartDate, newVisitEndDate);

            Assert.Null(visit);
        }
    }

    [Fact]
    public async Task GetDoctorVisitForDate_ReturnsNull_WhenNewVisitEndsRightBeforePlanned()
    {
        var options = new DbContextOptionsBuilder<BeHealthContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        var plannedVisitStartDate = new DateTime(2010, 1, 1, 14, 00, 0);
        var visitName = "Test";
        int duration = 60;
        var doctorId = 1;

        using (var context = new BeHealthContext(options))
        {
            context.Visits.Add(new BeHealthBackend.DataAccess.Entities.Visit
            {
                Name = visitName,
                DoctorId = doctorId,
                VisitDate = plannedVisitStartDate,
                Duration = duration
            });
            context.SaveChanges();
        }

        var newVisitStartDate = new DateTime(2010, 1, 1, 13, 30, 0); // Starts right after end of already planned
        var newVisitEndDate = new DateTime(2010, 1, 1, 14, 00, 0);

        using (var context = new BeHealthContext(options))
        {
            var systemUnderTest = new VisitRepository(context);
            var visit = await systemUnderTest.GetDoctorVisitForDate(doctorId, newVisitStartDate, newVisitEndDate);

            Assert.Null(visit);
        }
    }
    [Fact]
    public async Task GetDoctorVisitForDate_ReturnsNull_WhenInBetweenTwoVisitsNotIntersecting()
    {
        var options = new DbContextOptionsBuilder<BeHealthContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        var plannedVisitStartDate = new DateTime(2010, 1, 1, 12, 00, 0);
        int duration = 60;
        var doctorId = 1;
        var visitName = "Test 1";


        var secondPlannedVisitStartDate = new DateTime(2010, 1, 1, 14, 00, 0);
        int secondDuration = 60;
        var secondVisitName = "Test 2";

        using (var context = new BeHealthContext(options))
        {
            context.Visits.Add(new BeHealthBackend.DataAccess.Entities.Visit
            {
                Name = visitName,
                DoctorId = doctorId,
                VisitDate = plannedVisitStartDate,
                Duration = duration
            });
            context.Visits.Add(new BeHealthBackend.DataAccess.Entities.Visit
            {
                Name = secondVisitName,
                DoctorId = doctorId,
                VisitDate = secondPlannedVisitStartDate,
                Duration = secondDuration
            });
            context.SaveChanges();
        }

        var newVisitStartDate = new DateTime(2010, 1, 1, 13, 00, 0); // 1st ends in 13:00 this is between 13:00 - 14:00 2nd starts 14:00
        var newVisitEndDate = new DateTime(2010, 1, 1, 14, 00, 0);

        using (var context = new BeHealthContext(options))
        {
            var systemUnderTest = new VisitRepository(context);
            var visit = await systemUnderTest.GetDoctorVisitForDate(doctorId, newVisitStartDate, newVisitEndDate);

            Assert.Null(visit);
        }
    }
}
