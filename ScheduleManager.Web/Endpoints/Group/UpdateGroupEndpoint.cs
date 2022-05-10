using FastEndpoints;
using ScheduleManager.Contracts.Requests;
using ScheduleManager.Domain.Interfaces;

namespace ScheduleManager.Web.Endpoints.Group;

public class UpdateGroupEndpoint : Endpoint<GroupUpdateRequest>
{
    private readonly IGroupService _groupService;
    
    public UpdateGroupEndpoint(IGroupService groupService) =>  _groupService = groupService;

    public override void Configure()
    {
        Verbs(Http.PUT);
        Routes("api/group");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GroupUpdateRequest req, CancellationToken ct)
        => await _groupService.UpdateGroupAsync(req);
}