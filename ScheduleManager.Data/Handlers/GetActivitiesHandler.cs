using LinqKit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ScheduleManager.Data.Entities;
using ScheduleManager.Data.Extensions;
using ScheduleManager.Data.Queries;

namespace ScheduleManager.Data.Handlers;

public class GetActivitiesHandler : IRequestHandler<GetActivitiesQuery, List<Activity>>
{
    private readonly DataContext _context;

    public GetActivitiesHandler(DataContext context) => _context = context;

    public async Task<List<Activity>> Handle(GetActivitiesQuery request, CancellationToken cancellationToken)
    {
        var predicate = PredicateBuilder.New<Activity>(true);

        if (!string.IsNullOrEmpty(request.search))
        {
            predicate = predicate.And(t => t.Name.ToUpper().Contains(request.search.ToUpper()));
        }
        
        if (!string.IsNullOrEmpty(request.teacherName))
        {
            predicate = predicate.And(t => t.TeacherName.ToUpper().Contains(request.teacherName.ToUpper()));
        }
        
        var entities = _context.Activities.Where(predicate);

        switch (request.sort)
        {
            case "name_asc": 
                entities = entities.OrderBy(t => t.Name);
                break;
            case "name_desc":
                entities = entities.OrderByDescending(t => t.Name);
                break;
            default: break;
        }

        return await entities.Page(request.pageNumber, request.pageSize)
                             .AsNoTracking()
                             .ToListAsync();
    }
}