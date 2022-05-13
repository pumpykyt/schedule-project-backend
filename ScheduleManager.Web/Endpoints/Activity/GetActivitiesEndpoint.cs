using FastEndpoints;
using ScheduleManager.Contracts.Requests;
using ScheduleManager.Contracts.Responses;
using ScheduleManager.Domain.Interfaces;

namespace ScheduleManager.Web.Endpoints.Activity;

public class GetActivitiesEndpoint : Endpoint<PagedRequest, List<ActivityResponse>>
{
    private readonly IActivityService _activityService;

    public GetActivitiesEndpoint(IActivityService activityService)
    {
        _activityService = activityService;
    }

    public override void Configure()
    {
        Verbs(Http.GET);
        Routes("api/activity/{pageNumber}/{pageSize}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(PagedRequest req, CancellationToken ct)
        => await SendAsync(await _activityService.GetActivitiesAsync(req.PageNumber, req.PageSize));
}