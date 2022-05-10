using FastEndpoints;
using ScheduleManager.Contracts.Requests;
using ScheduleManager.Domain.Interfaces;

namespace ScheduleManager.Web.Endpoints.Group;

public class GetGroupEndpoint : Endpoint<GroupIdRequest>
{
    private readonly IGroupService _groupService;

    public GetGroupEndpoint(IGroupService groupService) => _groupService = groupService;

    public override void Configure()
    {
        Verbs(Http.GET);
        Routes("api/group/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GroupIdRequest req, CancellationToken ct) 
        => await SendAsync(await _groupService.GetGroupByIdAsync(req.Id));
}