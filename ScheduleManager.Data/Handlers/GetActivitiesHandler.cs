using MediatR;
using Microsoft.EntityFrameworkCore;
using ScheduleManager.Data.Entities;
using ScheduleManager.Data.Queries;

namespace ScheduleManager.Data.Handlers;

public class GetActivitiesHandler : IRequestHandler<GetActivitiesQuery, List<Activity>>
{
    private readonly DataContext _context;

    public GetActivitiesHandler(DataContext context) => _context = context;
    
    public async Task<List<Activity>> Handle(GetActivitiesQuery request, CancellationToken cancellationToken) 
        => await _context.Activities.AsNoTracking()
                                    .Skip((request.pageNumber - 1) * request.pageSize)
                                    .Take(request.pageSize)
                                    .ToListAsync();
}