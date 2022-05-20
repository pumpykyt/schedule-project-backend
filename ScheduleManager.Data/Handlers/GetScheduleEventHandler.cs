using MediatR;
using Microsoft.EntityFrameworkCore;
using ScheduleManager.Data.Entities;
using ScheduleManager.Data.Queries;

namespace ScheduleManager.Data.Handlers;

public class GetScheduleEventHandler : IRequestHandler<GetScheduleEventQuery, ScheduleEvent>
{
    private readonly DataContext _context;

    public GetScheduleEventHandler(DataContext context) => _context = context;

    public async Task<ScheduleEvent> Handle(GetScheduleEventQuery request, CancellationToken cancellationToken) 
        => await _context.ScheduleEvents.AsNoTracking().SingleOrDefaultAsync(t => t.Id == request.id);
}