using MediatR;
using ScheduleManager.Data.Entities;

namespace ScheduleManager.Data.Queries;

public record GetActivitiesQuery(int pageNumber, int pageSize) : IRequest<List<Activity>>;
public record GetActivityQuery(string id) : IRequest<Activity>;
public record GetUserByEmailQuery(string email) : IRequest<User>;
public record GetGroupQuery(string id) : IRequest<Group>;
public record GetGroupsQuery(int pageNumber, int pageSize) : IRequest<List<Group>>;
public record GetScheduleEventQuery(string id) : IRequest<ScheduleEvent>;
public record GetScheduleEventsQuery(int pageNumber, int pageSize) : IRequest<List<ScheduleEvent>>;
public record GetScheduleQuery(string id) : IRequest<Schedule>;
public record GetSchedulesQuery(int pageNumber, int pageSize) : IRequest<List<Schedule>>;