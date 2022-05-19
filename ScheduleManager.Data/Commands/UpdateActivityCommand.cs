using MediatR;
using ScheduleManager.Data.Entities;

namespace ScheduleManager.Data.Commands;

public class UpdateActivityCommand : IRequest
{
    public Activity OldEntity { get; set; }
    public Activity NewEntity { get; set; }

    public UpdateActivityCommand(Activity oldEntity, Activity newEntity)
    {
        OldEntity = oldEntity;
        NewEntity = newEntity;
    }
}