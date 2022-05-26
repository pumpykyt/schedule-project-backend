using System.Data.Entity;
using MediatR;
using ScheduleManager.Data.Queries;

namespace ScheduleManager.Data.Handlers;

public class GetScheduleEventsCountHandler : IRequestHandler<GetScheduleEventsCountQuery, int>
{
    private readonly DataContext _context;

    public GetScheduleEventsCountHandler(DataContext context)
    {
        _context = context;
    }

    public Task<int> Handle(GetScheduleEventsCountQuery request, CancellationToken cancellationToken)
        => Task.FromResult(_context.ScheduleEvents.Count());
}