using FastEndpoints;
using ScheduleManager.Contracts.Requests;
using ScheduleManager.Contracts.Responses;
using ScheduleManager.Data;
using ScheduleManager.Domain.Interfaces;

namespace ScheduleManager.Web.Endpoints.Schedule;

public class GetSchedulesEndpoint : Endpoint<PagedRequest, List<ScheduleResponse>>
{
    private readonly IScheduleService _scheduleService;

    public GetSchedulesEndpoint(IScheduleService scheduleService) => _scheduleService = scheduleService;

    public override void Configure()
    {
        Verbs(Http.GET);
        Routes("api/schedule/{pageNumber}/{pageSize}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(PagedRequest req, CancellationToken ct)
        => await SendAsync(await _scheduleService.GetSchedulesAsync(req.PageNumber, req.PageSize));
}