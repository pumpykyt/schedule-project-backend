using System.Net;
using Hangfire;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ScheduleManager.Contracts.Requests;
using ScheduleManager.Contracts.Responses;
using ScheduleManager.Data;
using ScheduleManager.Data.Commands;
using ScheduleManager.Data.Queries;
using ScheduleManager.Domain.Exceptions;
using ScheduleManager.Domain.Interfaces;
using ScheduleManager.Domain.Mapping;

namespace ScheduleManager.Domain.Services;

public class ScheduleEventService : IScheduleEventService
{
    private readonly IMediator _mediator;
    
    public ScheduleEventService(IMediator mediator) => _mediator = mediator;

    public async Task CreateScheduleEventAsync(ScheduleEventCreateRequest model)
    {
        var newScheduleEvent = model.MapToEntity();
        newScheduleEvent.Id = Guid.NewGuid().ToString();
        newScheduleEvent.JobId = BackgroundJob.Schedule(() => DeleteScheduleEventAsync(newScheduleEvent.Id), 
                                                              newScheduleEvent.End.AddDays(7));
        await _mediator.Send(new CreateScheduleEventCommand(newScheduleEvent));
        var result = await _mediator.Send(new SaveChangesCommand());
        if (result == 0) throw new HttpException(HttpStatusCode.InternalServerError, "Server error");
    }

    public async Task<ScheduleEventResponse> GetScheduleEventByIdAsync(string id)
    {
        var entity = await _mediator.Send(new GetScheduleEventQuery(id));
        return entity.MapToResponse();
    }

    public async Task<List<ScheduleEventResponse>> GetScheduleEventsAsync(int pageNumber, int pageSize,
                        string search, string sort, string type, DateTime startDate, DateTime endDate)
    {
        if (search == "%default%") search = string.Empty;
        if (type == "%default%") search = string.Empty;
        var entities = await _mediator.Send(new GetScheduleEventsQuery(pageNumber, pageSize, search, sort, type, startDate, endDate));
        return entities.MapToResponseList();
    }

    public async Task UpdateScheduleEventAsync(ScheduleEventUpdateRequest model)
    {
        var oldEntity = await _mediator.Send(new GetScheduleEventQuery(model.Id));
        var newEntity = model.MapToEntity();
        _mediator.Send(new UpdateScheduleEventCommand(oldEntity, newEntity));
        var result = await _mediator.Send(new SaveChangesCommand());
        if (result == 0) throw new HttpException(HttpStatusCode.InternalServerError, "Server error");

    }

    public async Task DeleteScheduleEventAsync(string id)
    {
        var entity = await _mediator.Send(new GetScheduleEventQuery(id));
        BackgroundJob.Delete(entity.JobId);
        _mediator.Send(new DeleteScheduleEventCommand(entity));
        var result = await _mediator.Send(new SaveChangesCommand());
        if (result == 0) throw new HttpException(HttpStatusCode.InternalServerError, "Server error");
    }
}