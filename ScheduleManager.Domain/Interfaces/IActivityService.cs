using ScheduleManager.Contracts.Requests;
using ScheduleManager.Contracts.Responses;

namespace ScheduleManager.Domain.Interfaces;

public interface IActivityService
{
    Task CreateActivityAsync(ActivityCreateRequest model);
    Task<ActivityResponse> GetActivityAsync(string id);
    Task<List<ActivityResponse>> GetActivitiesAsync(int pageNumber, int pageSize);
}