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

public class ActivityService : IActivityService
{
    private readonly IMediator _mediator;

    public ActivityService(IMediator mediator) => _mediator = mediator;

    public async Task CreateActivityAsync(ActivityCreateRequest model)
    {
        var entity = model.MapToEntity();
        entity.Id = Guid.NewGuid().ToString();
        await _mediator.Send(new CreateActivityCommand(entity));
        var result = await _mediator.Send(new SaveChangesCommand());
        if (result == 0) throw new HttpException(HttpStatusCode.InternalServerError, "Server error");
    }

    public async Task<ActivityResponse> GetActivityAsync(string id)
    {
        var entity = await _mediator.Send(new GetActivityQuery(id));
        return entity.MapToResponse();
    }

    public async Task<List<ActivityResponse>> GetActivitiesAsync(int pageNumber, int pageSize)
    {
        var entities = await _mediator.Send(new GetActivitiesQuery(pageNumber, pageSize));
        return entities.MapToResponseList();
    }

    public async Task UpdateActivityAsync(ActivityUpdateRequest model)
    {
        var oldEntity = await _mediator.Send(new GetActivityQuery(model.Id));
        var newEntity = model.MapToEntity();
        _mediator.Send(new UpdateActivityCommand(oldEntity, newEntity));
        var result = await _mediator.Send(new SaveChangesCommand());
        if (result == 0) throw new HttpException(HttpStatusCode.InternalServerError, "Server error");
    }

    public async Task DeleteActivityAsync(string id)
    {
        var entity = await _mediator.Send(new GetActivityQuery(id));
        _mediator.Send(new DeleteActivityCommand(entity));
        var result = await _mediator.Send(new SaveChangesCommand());
        if (result == 0) throw new HttpException(HttpStatusCode.InternalServerError, "Server error");
    }
}