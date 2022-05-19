using MediatR;
using ScheduleManager.Data.Entities;

namespace ScheduleManager.Data.Queries;

public class GetActivitiesQuery : IRequest<List<Activity>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }

    public GetActivitiesQuery(int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
}