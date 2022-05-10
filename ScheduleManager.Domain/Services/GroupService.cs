using System.Net;
using Microsoft.EntityFrameworkCore;
using ScheduleManager.Contracts.Requests;
using ScheduleManager.Data;
using ScheduleManager.Domain.Exceptions;
using ScheduleManager.Domain.Interfaces;
using ScheduleManager.Domain.Mapping;

namespace ScheduleManager.Domain.Services;

public class GroupService : IGroupService
{
    private readonly DataContext _context;

    public GroupService(DataContext context)
    {
        _context = context;
    }

    public async Task CreateGroupAsync(GroupCreateRequest model)
    {
        var newGroup = model.MapToEntity();
        newGroup.Id = Guid.NewGuid().ToString();
        await _context.Groups.AddAsync(newGroup);
        var result = await _context.SaveChangesAsync();
        if (result == 0) throw new HttpException(HttpStatusCode.InternalServerError, "Server error");
    }

    public async Task<GroupResponse> GetGroupByIdAsync(string id)
    {
        var entity = await _context.Groups.AsNoTracking().SingleOrDefaultAsync(t => t.Id == id);
        return entity.MapToResponse();
    }

    public async Task<List<GroupResponse>> GetGroupsAsync(int pageNumber, int pageSize)
    {
        var entities = await _context.Groups.AsNoTracking()
                                            .Skip((pageNumber - 1) * pageSize)
                                            .Take(pageSize)
                                            .ToListAsync();
        return entities.MapToResponseList();
    }

    public async Task UpdateGroupAsync(GroupUpdateRequest model)
    {
        var oldEntity = await _context.Groups.SingleOrDefaultAsync(t => t.Id == model.Id);
        var newEntity = model.MapToEntity();
        _context.Entry(oldEntity).CurrentValues.SetValues(newEntity);
        var result = await _context.SaveChangesAsync();
        if (result == 0) throw new HttpException(HttpStatusCode.InternalServerError, "Server error");
    }

    public async Task DeleteGroupAsync(string id)
    {
        var entity = await _context.Groups.SingleOrDefaultAsync(t => t.Id == id);
        _context.Groups.Remove(entity);
        var result = await _context.SaveChangesAsync();
        if (result == 0) throw new HttpException(HttpStatusCode.InternalServerError, "Server error");
    }
}