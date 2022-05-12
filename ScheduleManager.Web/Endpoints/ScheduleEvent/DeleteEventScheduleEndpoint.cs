using FastEndpoints;
using ScheduleManager.Contracts.Requests;
using ScheduleManager.Domain.Interfaces;

namespace ScheduleManager.Web.Endpoints.ScheduleEvent;

public class DeleteEventScheduleEndpoint : Endpoint<ScheduleEventIdRequest>
{
    private readonly IScheduleEventService _eventService;

    public DeleteEventScheduleEndpoint(IScheduleEventService eventService) => _eventService = eventService;

    public override void Configure()
    {
        Verbs(Http.DELETE);
        Routes("api/scheduleEvent");
        AllowAnonymous();
    }

    public override async Task HandleAsync(ScheduleEventIdRequest req, CancellationToken ct)
        => await _eventService.DeleteScheduleEventAsync(req.Id);
}