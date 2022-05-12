using FastEndpoints;
using ScheduleManager.Contracts.Requests;
using ScheduleManager.Contracts.Responses;
using ScheduleManager.Domain.Interfaces;

namespace ScheduleManager.Web.Endpoints.ScheduleEvent;

public class GetScheduleEventsEndpoint : Endpoint<PagedRequest, List<ScheduleEventResponse>>
{
    private readonly IScheduleEventService _eventService;

    public GetScheduleEventsEndpoint(IScheduleEventService eventService) => _eventService = eventService;

    public override void Configure()
    {
        Verbs(Http.GET);
        Routes("api/scheduleEvent/{pageNumber}/{pageSize}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(PagedRequest req, CancellationToken ct)
        => await SendAsync(await _eventService.GetScheduleEventsAsync(req.PageNumber, req.PageSize));
}