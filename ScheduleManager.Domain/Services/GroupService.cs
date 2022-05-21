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

public class GroupService : IGroupService
{
    private readonly IMediator _mediator;

    public GroupService(IMediator mediator) => _mediator = mediator;

    public async Task CreateGroupAsync(GroupCreateRequest model)
    {
        var newGroup = model.MapToEntity();
        newGroup.Id = Guid.NewGuid().ToString();
        await _mediator.Send(new CreateGroupCommand(newGroup));
        var result = await _mediator.Send(new SaveChangesCommand());
        if (result == 0) throw new HttpException(HttpStatusCode.InternalServerError, "Server error");
    }

    public async Task<GroupResponse> GetGroupByIdAsync(string id)
    {
        var entity = await _mediator.Send(new GetGroupQuery(id));
        return entity.MapToResponse();
    }

    public async Task<List<GroupResponse>> GetGroupsAsync(int pageNumber, int pageSize, string search, string sort)
    {
        if (search == "%default%") search = string.Empty;
        var entities = await _mediator.Send(new GetGroupsQuery(pageNumber, pageSize, search, sort));
        return entities.MapToResponseList();
    }

    public async Task UpdateGroupAsync(GroupUpdateRequest model)
    {
        var oldEntity = await _mediator.Send(new GetGroupQuery(model.Id));
        var newEntity = model.MapToEntity();
        await _mediator.Send(new UpdateGroupCommand(oldEntity, newEntity));
        var result = await _mediator.Send(new SaveChangesCommand());
        if (result == 0) throw new HttpException(HttpStatusCode.InternalServerError, "Server error");
    }

    public async Task DeleteGroupAsync(string id)
    {
        var entity = await _mediator.Send(new GetGroupQuery(id));
        _mediator.Send(new DeleteGroupCommand(entity));
        var result = await _mediator.Send(new SaveChangesCommand());
        if (result == 0) throw new HttpException(HttpStatusCode.InternalServerError, "Server error");
    }
}