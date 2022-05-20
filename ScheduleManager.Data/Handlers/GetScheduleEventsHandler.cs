using MediatR;
using Microsoft.EntityFrameworkCore;
using ScheduleManager.Data.Entities;
using ScheduleManager.Data.Queries;

namespace ScheduleManager.Data.Handlers;

public class GetScheduleEventsHandler : IRequestHandler<GetScheduleEventsQuery, List<ScheduleEvent>>
{
    private readonly DataContext _context;

    public GetScheduleEventsHandler(DataContext context) => _context = context;
    
    public async Task<List<ScheduleEvent>> Handle(GetScheduleEventsQuery request, CancellationToken cancellationToken) 
        => await _context.ScheduleEvents.AsNoTracking()
                                        .Skip((request.pageNumber - 1) * request.pageSize)
                                        .Take(request.pageSize)
                                        .ToListAsync();
}