using FastEndpoints;
using ScheduleManager.Contracts.Requests;
using ScheduleManager.Contracts.Responses;
using ScheduleManager.Domain.Interfaces;

namespace ScheduleManager.Web.Endpoints.Group;

public class GetGroupsEndpoint : EndpointWithoutRequest
{
    private readonly IGroupService _groupService;

    public GetGroupsEndpoint(IGroupService groupService) => _groupService = groupService;
    
    public override void Configure()
    {
        Verbs(Http.GET);
        Routes("api/group/{pageNumber}/{pageSize}/{search}/{sort}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var pageNumber = Route<int>("pageNumber");
        var pageSize = Route<int>("pageSize");
        var search = Route<string>("search");
        var sort = Route<string>("sort");

        var result = await _groupService.GetGroupsAsync(pageNumber, pageSize, search, sort);
        await SendAsync(result);
    }
        
}