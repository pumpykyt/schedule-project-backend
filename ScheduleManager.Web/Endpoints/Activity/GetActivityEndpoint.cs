using FastEndpoints;
using ScheduleManager.Contracts.Requests;
using ScheduleManager.Contracts.Responses;
using ScheduleManager.Domain.Interfaces;

namespace ScheduleManager.Web.Endpoints.Activity;

public class GetActivityEndpoint : Endpoint<ActivityIdRequest, ActivityResponse>
{
    private readonly IActivityService _activityService;

    public GetActivityEndpoint(IActivityService activityService) => _activityService = activityService;

    public override void Configure()
    {
        Verbs(Http.GET);
        Routes("api/activity/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(ActivityIdRequest req, CancellationToken ct)
        => await SendAsync(await _activityService.GetActivityAsync(req.Id));
}