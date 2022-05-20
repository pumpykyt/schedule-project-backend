using MediatR;
using ScheduleManager.Data.Entities;

namespace ScheduleManager.Data.Commands;

public record CreateUserCommand(User entity) : IRequest;
public record CreateActivityCommand(Activity entity) : IRequest;
public record DeleteActivityCommand(Activity entity) : IRequest;
public record SaveChangesCommand : IRequest<int>;
public record UpdateActivityCommand(Activity oldEntity, Activity newEntity) : IRequest;
public record CreateGroupCommand(Group entity) : IRequest;
public record UpdateGroupCommand(Group oldEntity, Group newEntity) : IRequest;
public record DeleteGroupCommand(Group entity) : IRequest;