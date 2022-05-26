using ScheduleManager.Contracts.Requests;
using ScheduleManager.Contracts.Responses;

namespace ScheduleManager.Domain.Interfaces;

public interface IGroupService
{
    Task CreateGroupAsync(GroupCreateRequest model);
    Task<GroupResponse> GetGroupByIdAsync(string id);
    Task<PagedResponse<GroupResponse>> GetGroupsAsync(int pageNumber, int pageSize, string search, string sort);
    Task UpdateGroupAsync(GroupUpdateRequest model);
    Task DeleteGroupAsync(string id);
}