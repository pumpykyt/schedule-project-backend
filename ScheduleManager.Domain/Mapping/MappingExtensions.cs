using Microsoft.EntityFrameworkCore;
using ScheduleManager.Contracts.Requests;
using ScheduleManager.Contracts.Responses;
using ScheduleManager.Data.Entities;

namespace ScheduleManager.Domain.Mapping;

public static class MappingExtensions
{
    public static Schedule MapToEntity(this ScheduleCreateRequest model)
    {
        return new Schedule
        {
            Name = model.Name
        };
    }

    public static ScheduleResponse MapToResponse(this Schedule entity)
    {
        return new ScheduleResponse
        {
            Id = entity.Id,
            Name = entity.Name
        };
    }

    public static List<ScheduleResponse> MapToResponseList(this List<Schedule> entities)
    {
        return entities.Select(t => new ScheduleResponse
        {
            Id = t.Id,
            Name = t.Name
        }).ToList();
    }
    
    public static Schedule MapToEntity(this ScheduleUpdateRequest model)
    {
        return new Schedule
        {
            Id = model.Id,
            Name = model.Name
        };
    }

    public static Group MapToEntity(this GroupCreateRequest model)
    {
        return new Group
        {
            Name = model.Name,
            ScheduleId = model.ScheduleId
        };
    }
    
    public static Group MapToEntity(this GroupUpdateRequest model)
    {
        return new Group
        {
            Id = model.Id,
            Name = model.Name,
            ScheduleId = model.ScheduleId
        };
    }

    public static GroupResponse MapToResponse(this Group entity)
    {
        return new GroupResponse
        {
            Id = entity.Id,
            Name = entity.Name,
            ScheduleId = entity.ScheduleId
        };
    }

    public static List<GroupResponse> MapToResponseList(this List<Group> entities)
    {
        return entities.Select(t => new GroupResponse
        {
            Id = t.Id,
            Name = t.Name,
            ScheduleId = t.ScheduleId
        }).ToList();
    }
}