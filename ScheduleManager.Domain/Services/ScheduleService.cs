using System.Net;
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

public class ScheduleService : IScheduleService
{
    private readonly IMediator _mediator;

    public ScheduleService(IMediator mediator) => _mediator = mediator;

    public async Task CreateScheduleAsync(ScheduleCreateRequest model)
    {
        var newSchedule = model.MapToEntity();
        newSchedule.Id = Guid.NewGuid().ToString();
        await _mediator.Send(new CreateScheduleCommand(newSchedule));
        var result = await _mediator.Send(new SaveChangesCommand());
        if (result == 0) throw new HttpException(HttpStatusCode.InternalServerError, "Server error");
    }

    public async Task<ScheduleResponse> GetScheduleByIdAsync(string id)
    {
        var entity = await _mediator.Send(new GetScheduleQuery(id));
        return entity.MapToResponse();
    }

    public async Task<List<ScheduleResponse>> GetSchedulesAsync(int pageNumber, int pageSize, string search, string sort)
    {
        if (search == "%default%") search = string.Empty;
        var entities = await _mediator.Send(new GetSchedulesQuery(pageNumber, pageSize, search, sort));
        return entities.MapToResponseList();
    }

    public async Task UpdateScheduleAsync(ScheduleUpdateRequest model)
    {
        var oldEntity = await _mediator.Send(new GetScheduleQuery(model.Id));
        var newEntity = model.MapToEntity();
        _mediator.Send(new UpdateScheduleCommand(oldEntity, newEntity));
        var result = await _mediator.Send(new SaveChangesCommand());
        if (result == 0) throw new HttpException(HttpStatusCode.InternalServerError, "Server error");
    }

    public async Task DeleteScheduleAsync(string id)
    {
        var entity = await _mediator.Send(new GetScheduleQuery(id));
        _mediator.Send(new DeleteScheduleCommand(entity));
        var result = await _mediator.Send(new SaveChangesCommand());
        if (result == 0) throw new HttpException(HttpStatusCode.InternalServerError, "Server error");
    }
}