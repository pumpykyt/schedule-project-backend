using FastEndpoints;
using ScheduleManager.Contracts.Requests;
using ScheduleManager.Domain.Interfaces;

namespace ScheduleManager.Web.Endpoints.Activity;

public class CreateActivityEndpoint : Endpoint<ActivityCreateRequest>
{
    private readonly IActivityService _activityService;

    public CreateActivityEndpoint(IActivityService activityService) => _activityService = activityService;

    public override void Configure()
    {
        Verbs(Http.POST);
        Routes("api/activity");
        AllowAnonymous();
    }

    public override async Task HandleAsync(ActivityCreateRequest req, CancellationToken ct) 
        => await _activityService.CreateActivityAsync(req);

}