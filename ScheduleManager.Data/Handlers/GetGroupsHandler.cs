using MediatR;
using Microsoft.EntityFrameworkCore;
using ScheduleManager.Data.Entities;
using ScheduleManager.Data.Queries;

namespace ScheduleManager.Data.Handlers;

public class GetGroupsHandler : IRequestHandler<GetGroupsQuery, List<Group>>
{
    private readonly DataContext _context;

    public GetGroupsHandler(DataContext context) => _context = context;
    
    public async Task<List<Group>> Handle(GetGroupsQuery request, CancellationToken cancellationToken) 
        => await _context.Groups.AsNoTracking()
                                .Skip((request.pageNumber - 1) * request.pageSize)
                                .Take(request.pageSize)
                                .ToListAsync();
}