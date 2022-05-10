using System.Net;
using Microsoft.EntityFrameworkCore;
using ScheduleManager.Contracts.Requests;
using ScheduleManager.Contracts.Responses;
using ScheduleManager.Data;
using ScheduleManager.Domain.Exceptions;
using ScheduleManager.Domain.Interfaces;
using ScheduleManager.Domain.Mapping;

namespace ScheduleManager.Domain.Services;

public class ScheduleService : IScheduleService
{
    private DataContext _context;

    public ScheduleService(DataContext context)
    {
        _context = context;
    }

    public async Task CreateScheduleAsync(ScheduleCreateRequest model)
    {
        var newSchedule = model.MapToEntity();
        newSchedule.Id = Guid.NewGuid().ToString();
        await _context.Schedules.AddAsync(newSchedule);
        var result = await _context.SaveChangesAsync();
        if (result == 0) throw new HttpException(HttpStatusCode.InternalServerError, "Server error");
    }

    public async Task<ScheduleResponse> GetScheduleByIdAsync(string id)
    {
        var entity = await _context.Schedules.AsNoTracking().SingleOrDefaultAsync(t => t.Id == id);
        return entity.MapToResponse();
    }

    public async Task<List<ScheduleResponse>> GetSchedulesAsync(int pageNumber, int pageSize)
    {
        var entities = await _context.Schedules.AsNoTracking()
                                               .Skip((pageNumber - 1) * pageSize)
                                               .Take(pageSize)
                                               .ToListAsync();
        return entities.MapToResponseList();
    }

    public async Task UpdateScheduleAsync(ScheduleUpdateRequest model)
    {
        var oldEntity = await _context.Schedules.SingleOrDefaultAsync(t => t.Id == model.Id);
        var newEntity = model.MapToEntity();
        _context.Entry(oldEntity).CurrentValues.SetValues(newEntity);
        var result = await _context.SaveChangesAsync();
        if (result == 0) throw new HttpException(HttpStatusCode.InternalServerError, "Server error");
    }

    public async Task DeleteScheduleAsync(string id)
    {
        var entity = await _context.Schedules.SingleOrDefaultAsync(t => t.Id == id);
        _context.Schedules.Remove(entity);
        var result = await _context.SaveChangesAsync();
        if (result == 0) throw new HttpException(HttpStatusCode.InternalServerError, "Server error");
    }
}