using FastEndpoints;
using ScheduleManager.Contracts.Requests;
using ScheduleManager.Domain.Interfaces;

namespace ScheduleManager.Web.Endpoints.ScheduleEvent;

public class CreateScheduleEventEndpoint : Endpoint<ScheduleEventCreateRequest>
{
    private readonly IScheduleEventService _eventService;

    public CreateScheduleEventEndpoint(IScheduleEventService eventService) => _eventService = eventService;

    public override void Configure()
    {
        Verbs(Http.POST);
        Routes("api/scheduleEvent");
        AllowAnonymous();
    }

    public override async Task HandleAsync(ScheduleEventCreateRequest req, CancellationToken ct) 
        => await _eventService.CreateScheduleEventAsync(req);
}