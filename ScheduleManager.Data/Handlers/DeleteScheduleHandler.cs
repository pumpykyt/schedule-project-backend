using MediatR;
using ScheduleManager.Data.Commands;

namespace ScheduleManager.Data.Handlers;

public class DeleteScheduleHandler : IRequestHandler<DeleteScheduleCommand>
{
    private readonly DataContext _context;

    public DeleteScheduleHandler(DataContext context) => _context = context;
    
    public Task<Unit> Handle(DeleteScheduleCommand request, CancellationToken cancellationToken)
    {
        _context.Schedules.Remove(request.entity);
        return Task.FromResult(Unit.Value);
    }
}