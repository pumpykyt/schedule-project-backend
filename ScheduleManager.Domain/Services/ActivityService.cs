using System.Net;
using Microsoft.EntityFrameworkCore;
using ScheduleManager.Contracts.Requests;
using ScheduleManager.Contracts.Responses;
using ScheduleManager.Data;
using ScheduleManager.Domain.Exceptions;
using ScheduleManager.Domain.Interfaces;
using ScheduleManager.Domain.Mapping;

namespace ScheduleManager.Domain.Services;


public class ActivityService : IActivityService
{
    private readonly DataContext _context;

    public ActivityService(DataContext context) => _context = context;

    public async Task CreateActivityAsync(ActivityCreateRequest model)
    {
        var entity = model.MapToEntity();
        entity.Id = Guid.NewGuid().ToString();
        await _context.Activities.AddAsync(entity);
        var result = await _context.SaveChangesAsync();
        if (result == 0) throw new HttpException(HttpStatusCode.InternalServerError, "Server error");
    }

    public async Task<ActivityResponse> GetActivityAsync(string id)
    {
        var entity = await _context.Activities.AsNoTracking().SingleOrDefaultAsync(t => t.Id == id);
        return entity.MapToResponse();
    }

    public async Task<List<ActivityResponse>> GetActivitiesAsync(int pageNumber, int pageSize)
    {
        var entities = await _context.Activities.AsNoTracking()
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return entities.MapToResponseList();
    }
    
}