using MediatR;
using ScheduleManager.Data.Entities;

namespace ScheduleManager.Data.Commands;

public class CreateActivityCommand : IRequest
{
    public Activity Entity { get; set; }

    public CreateActivityCommand(Activity entity) 
        => Entity = entity;
}