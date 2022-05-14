using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ScheduleManager.Contracts.Requests;
using ScheduleManager.Data;
using ScheduleManager.Data.Entities;
using ScheduleManager.Domain.Interfaces;
using ScheduleManager.Domain.Services;
using Xunit;

namespace ScheduleManager.Tests;

public class ScheduleServiceTests
{
    private readonly DataContext _context;
    private readonly IScheduleService _scheduleService;
    
    public ScheduleServiceTests()
    {
        var dbOptions = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase("ActivityServiceTestsDb")
            .Options;
        _context = new DataContext(dbOptions);
        _scheduleService = new ScheduleService(_context);
    }

    [Fact]
    public async Task GetScheduleTest()
    {
        //Arrange
        await _context.Schedules.AddAsync(new Schedule
        {
            Id = "1",
            Name = "Test"
        });
        await _context.SaveChangesAsync();
        //Act
        var result = await _scheduleService.GetScheduleByIdAsync("1");
        //Assert
        Assert.NotNull(result);
        Assert.Equal("1", result.Id);
    }

    [Fact]
    public async Task CreateScheduleTest()
    {
        //Arrange
        var model = new ScheduleCreateRequest
        {
            Name = "Test"
        };
        //Act
        await _scheduleService.CreateScheduleAsync(model);
        //Assert
        var result = await _context.Schedules.SingleOrDefaultAsync(t => t.Name == model.Name);
        Assert.NotNull(result);
        Assert.Equal("Test", result.Name);
    }

    [Fact]
    public async Task UpdateScheduleTask()
    {
        //Arrange
        await _context.Schedules.AddAsync(new Schedule
        {
            Id = "123",
            Name = "Test"
        });
        var model = new ScheduleUpdateRequest
        {
            Id = "123",
            Name = "Updated"
        };
        await _context.SaveChangesAsync();
        //Act
        await _scheduleService.UpdateScheduleAsync(model);
        //Assert
        var result = await _context.Schedules.SingleOrDefaultAsync(t => t.Name == model.Name);
        Assert.NotNull(result);
        Assert.Equal(model.Name, result.Name);
    }

    [Fact]
    public async Task DeleteSchedule()
    {
        //Arrange
        await _context.Schedules.AddAsync(new Schedule
        {
            Id = "222",
            Name = "Test"
        });
        await _context.SaveChangesAsync();
        //Act
        await _scheduleService.DeleteScheduleAsync("222");
        //Assert
        var entity = await _context.Schedules.SingleOrDefaultAsync(t => t.Id == "222");
        Assert.Null(entity);
    }
}