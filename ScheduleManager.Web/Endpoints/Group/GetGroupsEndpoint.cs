using FastEndpoints;
using ScheduleManager.Contracts.Requests;
using ScheduleManager.Domain.Interfaces;

namespace ScheduleManager.Web.Endpoints.Group;

public class GetGroupsEndpoint : Endpoint<PagedRequest>
{
    private readonly IGroupService _groupService;

    public GetGroupsEndpoint(IGroupService groupService) => _groupService = groupService;
    
    public override void Configure()
    {
        Verbs(Http.GET);
        Routes("api/group/{pageNumber}/{pageSize}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(PagedRequest req, CancellationToken ct) 
        => await SendAsync(await _groupService.GetGroupsAsync(req.PageNumber, req.PageSize));
}