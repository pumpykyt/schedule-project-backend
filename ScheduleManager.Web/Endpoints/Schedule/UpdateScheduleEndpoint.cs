using FastEndpoints;
using ScheduleManager.Contracts.Requests;
using ScheduleManager.Domain.Interfaces;

namespace ScheduleManager.Web.Endpoints.Schedule;

public class UpdateScheduleEndpoint : Endpoint<ScheduleUpdateRequest>
{
    private readonly IScheduleService _scheduleService;
    
    public UpdateScheduleEndpoint(IScheduleService scheduleService) =>  _scheduleService = scheduleService;

    public override void Configure()
    {
        Verbs(Http.PUT);
        Routes("api/schedule");
        AllowAnonymous();
    }

    public override async Task HandleAsync(ScheduleUpdateRequest req, CancellationToken ct)
        => await _scheduleService.UpdateScheduleAsync(req);
}