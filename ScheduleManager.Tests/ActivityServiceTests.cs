using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ScheduleManager.Contracts.Requests;
using ScheduleManager.Data;
using ScheduleManager.Data.Entities;
using ScheduleManager.Domain.Interfaces;
using ScheduleManager.Domain.Services;
using Xunit;

namespace ScheduleManager.Tests;

public class ActivityServiceTests
{
    private readonly DataContext _context;
    private readonly IActivityService _activityService;
    
    public ActivityServiceTests()
    {
        var dbOptions = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase("ActivityServiceTestsDb")
            .Options;
        _context = new DataContext(dbOptions);
        _activityService = new ActivityService(_context);
    }
    
    [Fact]
    public async Task GetActivityTest()
    {
        //Arrange
        await _context.Activities.AddAsync(new Activity
        {
            Id = "1",
            Name = "Test",
            TeacherEmail = "test@gmail.com",
            TeacherName = "Test"
        });
        await _context.SaveChangesAsync();
        //Act
        var result = await _activityService.GetActivityAsync("1");
        //Assert
        Assert.NotNull(result);
        Assert.Equal("1", result.Id);
    }

    [Fact]
    public async Task CreateActivityTest()
    {
        //Arrange
        var model = new ActivityCreateRequest
        {
            Name = "testUnique",
            TeacherEmail = "test@gmail.com",
            TeacherName = "test"
        };
        //Act
        await _activityService.CreateActivityAsync(model);
        //Assert
        var result = await _context.Activities.SingleOrDefaultAsync(t => t.Name == model.Name);
        Assert.NotNull(result);
        Assert.Equal(model.Name, result.Name);
    }
    
}