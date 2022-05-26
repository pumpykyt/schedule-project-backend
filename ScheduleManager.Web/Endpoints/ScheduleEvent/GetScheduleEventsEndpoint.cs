using FastEndpoints;
using ScheduleManager.Contracts.Requests;
using ScheduleManager.Contracts.Responses;
using ScheduleManager.Domain.Interfaces;

namespace ScheduleManager.Web.Endpoints.ScheduleEvent;

public class GetScheduleEventsEndpoint : EndpointWithoutRequest
{
    private readonly IScheduleEventService _eventService;

    public GetScheduleEventsEndpoint(IScheduleEventService eventService) => _eventService = eventService;

    public override void Configure()
    {
        Verbs(Http.GET);
        Routes("api/scheduleEvent/{pageNumber}/{pageSize}/{search}/{sort}/{type}/{startDate}/{endDate}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var pageNumber = Route<int>("pageNumber");
        var pageSize = Route<int>("pageSize");
        var search = Route<string>("search");
        var sort = Route<string>("sort");
        var type = Route<string>("type");
        var startDate = Route<DateTime>("startDate");
        var endDate = Route<DateTime>("endDate");

        var result = await _eventService.GetScheduleEventsAsync(pageNumber, pageSize, search, 
                                                                sort, type, startDate, endDate);
        await SendAsync(result);
    }
}