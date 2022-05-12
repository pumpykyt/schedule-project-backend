using ScheduleManager.Contracts.Requests;
using ScheduleManager.Contracts.Responses;

namespace ScheduleManager.Domain.Interfaces;

public interface IScheduleEventService
{
    Task CreateScheduleEventAsync(ScheduleEventCreateRequest model);
    Task<ScheduleEventResponse> GetScheduleEventByIdAsync(string id);
    Task<List<ScheduleEventResponse>> GetScheduleEventsAsync(int pageNumber, int pageSize);
    Task UpdateScheduleEventAsync(ScheduleEventUpdateRequest model);
    Task DeleteScheduleEventAsync(string id);
}