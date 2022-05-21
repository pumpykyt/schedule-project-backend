using LinqKit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ScheduleManager.Data.Entities;
using ScheduleManager.Data.Extensions;
using ScheduleManager.Data.Queries;

namespace ScheduleManager.Data.Handlers;

public class GetScheduleEventsHandler : IRequestHandler<GetScheduleEventsQuery, List<ScheduleEvent>>
{
    private readonly DataContext _context;

    public GetScheduleEventsHandler(DataContext context) => _context = context;

    public async Task<List<ScheduleEvent>> Handle(GetScheduleEventsQuery request, CancellationToken cancellationToken)
    {
        var predicate = PredicateBuilder.New<ScheduleEvent>(true);

        if (!string.IsNullOrEmpty(request.search))
        {
            predicate = predicate.And(t => (t.Activity.Name + t.Type).ToUpper().Contains(request.search.ToUpper()));
        }

        if (request.startDate != DateTime.MinValue && request.endDate != DateTime.MinValue)
        {
            predicate = predicate.And(t => t.End >= request.startDate && t.End <= request.endDate);
            predicate = predicate.And(t => t.Start >= request.startDate && t.Start <= request.endDate);
        }

        if (!string.IsNullOrEmpty(request.type))
        {
            predicate = predicate.And(t => t.Type.ToUpper().Contains(request.type.ToUpper()));
        }

        var entities = _context.ScheduleEvents.Where(predicate);

        switch (request.sort)
        {
            case "name_asc" : entities = entities.OrderBy(t => t.Activity.Name);
                break;
            case "name_desc" : entities = entities.OrderByDescending(t => t.Activity.Name);
                break;
            case "start_date_asc" : entities = entities.OrderBy(t => t.Start);
                break;
            case "start_date_desc" : entities = entities.OrderByDescending(t => t.Start);
                break;
            case "end_date_asc" : entities = entities.OrderBy(t => t.End);
                break;
            case "end_date_desc" : entities = entities.OrderByDescending(t => t.End);
                break;
            default : break;
        }

        return await entities.Page(request.pageNumber, request.pageSize)
                             .AsNoTracking()
                             .ToListAsync();
    }
}