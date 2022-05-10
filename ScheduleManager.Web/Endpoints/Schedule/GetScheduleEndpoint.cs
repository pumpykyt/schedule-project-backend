using FastEndpoints;
using ScheduleManager.Contracts.Requests;
using ScheduleManager.Contracts.Responses;
using ScheduleManager.Domain.Interfaces;

namespace ScheduleManager.Web.Endpoints.Schedule;

public class GetScheduleEndpoint : Endpoint<ScheduleIdRequest, ScheduleResponse>
{
    private readonly IScheduleService _scheduleService;

    public GetScheduleEndpoint(IScheduleService scheduleService) => _scheduleService = scheduleService;

    public override void Configure()
    {
        Verbs(Http.GET);
        Routes("api/schedule/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(ScheduleIdRequest req, CancellationToken ct)
        => await SendAsync(await _scheduleService.GetScheduleByIdAsync(req.Id));
}