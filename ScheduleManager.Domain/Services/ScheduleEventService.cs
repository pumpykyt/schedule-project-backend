using System.Net;
using Microsoft.EntityFrameworkCore;
using ScheduleManager.Contracts.Requests;
using ScheduleManager.Contracts.Responses;
using ScheduleManager.Data;
using ScheduleManager.Domain.Exceptions;
using ScheduleManager.Domain.Interfaces;
using ScheduleManager.Domain.Mapping;

namespace ScheduleManager.Domain.Services;

public class ScheduleEventService : IScheduleEventService
{
    private readonly DataContext _context;
    
    public ScheduleEventService(DataContext context)
    {
        _context = context;
    }

    public async Task CreateScheduleEventAsync(ScheduleEventCreateRequest model)
    {
        var newScheduleEvent = model.MapToEntity();
        newScheduleEvent.Id = Guid.NewGuid().ToString();
        await _context.ScheduleEvents.AddAsync(newScheduleEvent);
        var result = await _context.SaveChangesAsync();
        if (result == 0) throw new HttpException(HttpStatusCode.InternalServerError, "Server error");
    }

    public async Task<ScheduleEventResponse> GetScheduleEventByIdAsync(string id)
    {
        var entity = await _context.ScheduleEvents.AsNoTracking().SingleOrDefaultAsync(t => t.Id == id);
        return entity.MapToResponse();
    }

    public async Task<List<ScheduleEventResponse>> GetScheduleEventsAsync(int pageNumber, int pageSize)
    {
        var entities = await _context.ScheduleEvents.AsNoTracking()
                                                    .Skip((pageNumber - 1) * pageSize)
                                                    .Take(pageSize)
                                                    .ToListAsync();
        return entities.MapToResponseList();
    }

    public async Task UpdateScheduleEventAsync(ScheduleEventUpdateRequest model)
    {
        var oldEntity = await _context.ScheduleEvents.AsNoTracking().SingleOrDefaultAsync(t => t.Id == model.Id);
        var newEntity = model.MapToEntity();
        _context.Entry(oldEntity).CurrentValues.SetValues(newEntity);
        var result = await _context.SaveChangesAsync();
        if (result == 0) throw new HttpException(HttpStatusCode.InternalServerError, "Server error");

    }

    public async Task DeleteScheduleEventAsync(string id)
    {
        var entity = await _context.ScheduleEvents.AsNoTracking().SingleOrDefaultAsync(t => t.Id == id);
        _context.Remove(entity);
        var result = await _context.SaveChangesAsync();
        if (result == 0) throw new HttpException(HttpStatusCode.InternalServerError, "Server error");
    }
}