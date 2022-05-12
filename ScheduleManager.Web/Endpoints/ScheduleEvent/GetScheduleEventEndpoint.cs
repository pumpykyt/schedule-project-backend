using FastEndpoints;
using ScheduleManager.Contracts.Requests;
using ScheduleManager.Contracts.Responses;
using ScheduleManager.Domain.Interfaces;

namespace ScheduleManager.Web.Endpoints.ScheduleEvent;

public class GetScheduleEventEndpoint : Endpoint<ScheduleEventIdRequest, ScheduleEventResponse>
{
    private readonly IScheduleEventService _eventService;

    public GetScheduleEventEndpoint(IScheduleEventService eventService) => _eventService = eventService;

    public override void Configure()
    {
        Verbs(Http.GET);
        Routes("api/scheduleEvent/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(ScheduleEventIdRequest req, CancellationToken ct)
        => await SendAsync(await _eventService.GetScheduleEventByIdAsync(req.Id));
}