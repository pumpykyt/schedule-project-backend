using FastEndpoints;
using ScheduleManager.Contracts.Requests;
using ScheduleManager.Domain.Interfaces;

namespace ScheduleManager.Web.Endpoints.Activity;

public class UpdateActivityEndpoint : Endpoint<ActivityUpdateRequest>
{
    private readonly IActivityService _activityService;

    public UpdateActivityEndpoint(IActivityService activityService) => _activityService = activityService;

    public override void Configure()
    {
        Verbs(Http.PUT);
        Routes("api/group");
        AllowAnonymous();
    }

    public override async Task HandleAsync(ActivityUpdateRequest req, CancellationToken ct)
        => await _activityService.UpdateActivityAsync(req);
}