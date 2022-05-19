using MediatR;
using Microsoft.EntityFrameworkCore;
using ScheduleManager.Data.Entities;
using ScheduleManager.Data.Queries;

namespace ScheduleManager.Data.Handlers;

public class GetActivityHandler : IRequestHandler<GetActivityQuery, Activity>
{
    private readonly DataContext _context;

    public GetActivityHandler(DataContext context)
    {
        _context = context;
    }

    public async Task<Activity> Handle(GetActivityQuery request, CancellationToken cancellationToken) 
        => await _context.Activities.AsNoTracking().SingleOrDefaultAsync(t => t.Id == request.Id);
}