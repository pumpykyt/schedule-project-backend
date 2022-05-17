using FastEndpoints;
using ScheduleManager.Contracts.Requests;
using ScheduleManager.Domain.Interfaces;

namespace ScheduleManager.Web.Endpoints.Activity;

public class DeleteActivityEndpoint : EndpointWithoutRequest
{
    private readonly IActivityService _activityService;

    public DeleteActivityEndpoint(IActivityService activityService) => _activityService = activityService;
    public override void Configure()
    {
        Verbs(Http.DELETE);
        Routes("api/activity/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var activityId = Route<string>("id");
        await _activityService.DeleteActivityAsync(activityId);
    }
}