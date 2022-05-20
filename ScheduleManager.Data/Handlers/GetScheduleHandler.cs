using MediatR;
using Microsoft.EntityFrameworkCore;
using ScheduleManager.Data.Entities;
using ScheduleManager.Data.Queries;

namespace ScheduleManager.Data.Handlers;

public class GetScheduleHandler : IRequestHandler<GetScheduleQuery, Schedule>
{
    private readonly DataContext _context;

    public GetScheduleHandler(DataContext context) => _context = context;

    public async Task<Schedule> Handle(GetScheduleQuery request, CancellationToken cancellationToken)
        => await _context.Schedules.AsNoTracking().SingleOrDefaultAsync(t => t.Id == request.id);
}