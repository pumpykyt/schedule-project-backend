using FastEndpoints;
using ScheduleManager.Contracts.Requests;
using ScheduleManager.Domain.Interfaces;

namespace ScheduleManager.Web.Endpoints.Group;

public class DeleteGroupEndpoint : Endpoint<GroupIdRequest>
{
    private readonly IGroupService _groupService;

    public DeleteGroupEndpoint(IGroupService groupService) => _groupService = groupService;

    public override void Configure()
    {
        Verbs(Http.DELETE);
        Routes("api/group/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GroupIdRequest req, CancellationToken ct) 
        => await _groupService.DeleteGroupAsync(req.Id);
}