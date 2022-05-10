using FastEndpoints;
using ScheduleManager.Contracts.Requests;
using ScheduleManager.Domain.Interfaces;

namespace ScheduleManager.Web.Endpoints.Group;

public class CreateGroupEndpoint : Endpoint<GroupCreateRequest>
{
    private readonly IGroupService _groupService;

    public CreateGroupEndpoint(IGroupService groupService) => _groupService = groupService;

    public override void Configure()
    {
        Verbs(Http.POST);
        Routes("api/group");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GroupCreateRequest req, CancellationToken ct) 
        => await _groupService.CreateGroupAsync(req);
}