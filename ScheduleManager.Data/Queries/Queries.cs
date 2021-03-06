using MediatR;
using ScheduleManager.Data.Entities;

namespace ScheduleManager.Data.Queries;

public record GetActivitiesQuery(int pageNumber, int pageSize, string search, 
                                 string sort, string teacherName) : IRequest<List<Activity>>;
public record GetActivityQuery(string id) : IRequest<Activity>;
public record GetUserByEmailQuery(string email) : IRequest<User>;
public record GetGroupQuery(string id) : IRequest<Group>;
public record GetGroupsQuery(int pageNumber, int pageSize, string search, string sort) : IRequest<List<Group>>;
public record GetScheduleEventQuery(string id) : IRequest<ScheduleEvent>;
public record GetScheduleEventsQuery(int pageNumber, int pageSize, string search, string sort, string type, DateTime startDate, DateTime endDate) : IRequest<List<ScheduleEvent>>;
public record GetScheduleQuery(string id) : IRequest<Schedule>;
public record GetSchedulesQuery(int pageNumber, int pageSize, string search, string sort) : IRequest<List<Schedule>>;
public record GetActivitiesCountQuery() : IRequest<int>;
public record GetGroupsCountQuery() : IRequest<int>;
public record GetScheduleEventsCountQuery() : IRequest<int>;
public record GetSchedulesCountQuery() : IRequest<int>;