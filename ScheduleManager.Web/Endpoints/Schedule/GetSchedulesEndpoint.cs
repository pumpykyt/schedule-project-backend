using FastEndpoints;
using ScheduleManager.Contracts.Requests;
using ScheduleManager.Contracts.Responses;
using ScheduleManager.Data;
using ScheduleManager.Domain.Interfaces;

namespace ScheduleManager.Web.Endpoints.Schedule;

public class GetSchedulesEndpoint : EndpointWithoutRequest<List<ScheduleResponse>>
{
    private readonly IScheduleService _scheduleService;

    public GetSchedulesEndpoint(IScheduleService scheduleService) => _scheduleService = scheduleService;

    public override void Configure()
    {
        Verbs(Http.GET);
        Routes("api/schedule/{pageNumber}/{pageSize}/{search}/{sort}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var pageNumber = Route<int>("pageNumber");
        var pageSize = Route<int>("pageSize");
        var search = Route<string>("search");
        var sort = Route<string>("sort");

        var result = await _scheduleService.GetSchedulesAsync(pageNumber, pageSize, search, sort);
        await SendAsync(result);
    }
        
}