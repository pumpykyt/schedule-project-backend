using FastEndpoints;
using ScheduleManager.Contracts.Requests;
using ScheduleManager.Domain.Interfaces;

namespace ScheduleManager.Web.Endpoints.ScheduleEvent;

public class UpdateScheduleEventEndpoint : Endpoint<ScheduleEventUpdateRequest>
{
    private readonly IScheduleEventService _eventService;

    public UpdateScheduleEventEndpoint(IScheduleEventService eventService) => _eventService = eventService;

    public override void Configure()
    {
        Verbs(Http.PUT);
        Routes("api/scheduleEvent");
        AllowAnonymous();
    }

    public override async Task HandleAsync(ScheduleEventUpdateRequest req, CancellationToken ct)
        => await _eventService.UpdateScheduleEventAsync(req);
}