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
}