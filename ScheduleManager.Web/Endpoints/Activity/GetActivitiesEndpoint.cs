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
        Routes("api/activity/{pageNumber}/{pageSize}/{search}/{sort}/{teacherName}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(PagedRequest req, CancellationToken ct)
    {
        var pageNumber = Route<int>("pageNumber");
        var pageSize = Route<int>("pageSize");
        var search = Route<string>("search");
        var sort = Route<string>("sort");
        var teacherName = Route<string>("teacherName");

        var result = await _activityService.GetActivitiesAsync(pageNumber, pageSize, search, sort, teacherName);

        await SendAsync(result);
    }
}