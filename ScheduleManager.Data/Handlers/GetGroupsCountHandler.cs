using System.Data.Entity;
using MediatR;
using ScheduleManager.Data.Queries;

namespace ScheduleManager.Data.Handlers;

public class GetGroupsCountHandler : IRequestHandler<GetGroupsCountQuery, int>
{
    private readonly DataContext _context;

    public GetGroupsCountHandler(DataContext context)
    {
        _context = context;
    }

    public Task<int> Handle(GetGroupsCountQuery request, CancellationToken cancellationToken)
        => Task.FromResult(_context.Groups.Count());
}