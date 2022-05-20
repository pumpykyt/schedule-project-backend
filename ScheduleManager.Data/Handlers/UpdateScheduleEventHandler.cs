using MediatR;
using ScheduleManager.Data.Commands;

namespace ScheduleManager.Data.Handlers;

public class UpdateScheduleEventHandler : IRequestHandler<UpdateScheduleEventCommand>
{
    private readonly DataContext _context;

    public UpdateScheduleEventHandler(DataContext context) => _context = context;

    public Task<Unit> Handle(UpdateScheduleEventCommand request, CancellationToken cancellationToken)
    {
        _context.Entry(request.oldEntity).CurrentValues.SetValues(request.newEntity);
        return Task.FromResult(Unit.Value);
    }
}