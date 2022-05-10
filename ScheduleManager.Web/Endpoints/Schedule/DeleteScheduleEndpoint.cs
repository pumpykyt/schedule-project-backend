using FastEndpoints;
using ScheduleManager.Contracts.Requests;
using ScheduleManager.Domain.Interfaces;

namespace ScheduleManager.Web.Endpoints.Schedule;

public class DeleteScheduleEndpoint : Endpoint<ScheduleIdRequest>
{
    private readonly IScheduleService _scheduleService;

    public DeleteScheduleEndpoint(IScheduleService scheduleService) => _scheduleService = scheduleService;

    public override void Configure()
    {
        Verbs(Http.DELETE);
        Routes("api/schedule/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(ScheduleIdRequest req, CancellationToken ct)
    {
        await _scheduleService.DeleteScheduleAsync(req.Id);
    }
}