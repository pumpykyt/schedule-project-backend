using MediatR;
using Microsoft.EntityFrameworkCore;
using ScheduleManager.Data.Entities;
using ScheduleManager.Data.Queries;

namespace ScheduleManager.Data.Handlers;

public class GetSchedulesHandler : IRequestHandler<GetSchedulesQuery, List<Schedule>>
{
    private readonly DataContext _context;

    public GetSchedulesHandler(DataContext context) => _context = context;
    
    public async Task<List<Schedule>> Handle(GetSchedulesQuery request, CancellationToken cancellationToken) 
        => await _context.Schedules.AsNoTracking()
                                   .Skip((request.pageNumber - 1) * request.pageSize)
                                   .Take(request.pageSize)
                                   .ToListAsync();
}