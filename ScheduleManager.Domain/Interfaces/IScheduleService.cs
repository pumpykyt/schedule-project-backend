using ScheduleManager.Contracts.Requests;
using ScheduleManager.Contracts.Responses;

namespace ScheduleManager.Domain.Interfaces;

public interface IScheduleService
{
    Task CreateScheduleAsync(ScheduleCreateRequest model);
    Task<ScheduleResponse> GetScheduleByIdAsync(string id);
    Task<PagedResponse<ScheduleResponse>> GetSchedulesAsync(int pageNumber, int pageSize, string search, string sort);
    Task UpdateScheduleAsync(ScheduleUpdateRequest model);
    Task DeleteScheduleAsync(string id);
}