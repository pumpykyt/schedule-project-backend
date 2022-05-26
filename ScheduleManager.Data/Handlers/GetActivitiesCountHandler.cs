using System.Data.Entity;
using MediatR;
using ScheduleManager.Data.Queries;

namespace ScheduleManager.Data.Handlers;

public class GetActivitiesCountHandler : IRequestHandler<GetActivitiesCountQuery, int>
{
    private readonly DataContext _context;

    public GetActivitiesCountHandler(DataContext context)
    {
        _context = context;
    }

    public Task<int> Handle(GetActivitiesCountQuery request, CancellationToken cancellationToken)
        => Task.FromResult(_context.Activities.Count());
}