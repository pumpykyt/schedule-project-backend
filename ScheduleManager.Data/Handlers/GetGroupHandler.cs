using MediatR;
using Microsoft.EntityFrameworkCore;
using ScheduleManager.Data.Entities;
using ScheduleManager.Data.Queries;

namespace ScheduleManager.Data.Handlers;

public class GetGroupHandler : IRequestHandler<GetGroupQuery, Group>
{
    private readonly DataContext _context;

    public GetGroupHandler(DataContext context) => _context = context;

    public async Task<Group> Handle(GetGroupQuery request, CancellationToken cancellationToken) 
        => await _context.Groups.AsNoTracking().SingleOrDefaultAsync(t => t.Id == request.id);
}