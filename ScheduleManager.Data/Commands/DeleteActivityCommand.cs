using MediatR;
using ScheduleManager.Data.Entities;

namespace ScheduleManager.Data.Commands;

public class DeleteActivityCommand : IRequest
{
    public Activity Entity { get; set; }

    public DeleteActivityCommand(Activity entity)
    {
        Entity = entity;
    }
}