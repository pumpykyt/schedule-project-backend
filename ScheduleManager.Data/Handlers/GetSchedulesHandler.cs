using LinqKit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ScheduleManager.Data.Entities;
using ScheduleManager.Data.Extensions;
using ScheduleManager.Data.Queries;

namespace ScheduleManager.Data.Handlers;

public class GetSchedulesHandler : IRequestHandler<GetSchedulesQuery, List<Schedule>>
{
    private readonly DataContext _context;

    public GetSchedulesHandler(DataContext context) => _context = context;

    public async Task<List<Schedule>> Handle(GetSchedulesQuery request, CancellationToken cancellationToken)
    {
        var predicate = PredicateBuilder.New<Schedule>(true);

        if (!string.IsNullOrEmpty(request.search))
        {
            predicate = predicate.And(t => t.Name.ToUpper().Contains(request.search.ToUpper()));
        }

        var entities = _context.Schedules.Where(predicate);

        switch (request.sort)
        {
            case "name_asc" : entities = entities.OrderBy(t => t.Name);
                break;
            case "name_desc" : entities = entities.OrderByDescending(t => t.Name);
                break;
            default : break;
        }

        return await entities.Page(request.pageNumber, request.pageSize)
                             .AsNoTracking()
                             .ToListAsync();
    }
}