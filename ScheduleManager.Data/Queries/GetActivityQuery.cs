using MediatR;
using ScheduleManager.Data.Entities;

namespace ScheduleManager.Data.Queries;

public class GetActivityQuery : IRequest<Activity>
{
    public string Id { get; set; }

    public GetActivityQuery(string id)
    {
        Id = id;
    }
}