using System.Data.Entity;
using MediatR;
using ScheduleManager.Data.Queries;

namespace ScheduleManager.Data.Handlers;

public class GetSchedulesCountHandler : IRequestHandler<GetSchedulesCountQuery, int>
{
    private readonly DataContext _context;

    public GetSchedulesCountHandler(DataContext context)
    {
        _context = context;
    }

    public Task<int> Handle(GetSchedulesCountQuery request, CancellationToken cancellationToken)
        =>  Task.FromResult(_context.Schedules.AsNoTracking().Count());
}