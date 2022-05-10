using FastEndpoints;
using ScheduleManager.Contracts.Requests;
using ScheduleManager.Domain.Interfaces;

namespace ScheduleManager.Web.Endpoints.Schedule;

public class CreateScheduleEndpoint : Endpoint<ScheduleCreateRequest>
{
    private readonly IScheduleService _scheduleService;
    
    public CreateScheduleEndpoint(IScheduleService scheduleService) => _scheduleService = scheduleService;

    public override void Configure()
    {
        Verbs(Http.POST);
        Routes("api/schedule");
        AllowAnonymous();
    }

    public override async Task HandleAsync(ScheduleCreateRequest req, CancellationToken ct) 
        => await _scheduleService.CreateScheduleAsync(req);
}