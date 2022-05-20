using MediatR;
using ScheduleManager.Data.Commands;

namespace ScheduleManager.Data.Handlers;

public class DeleteScheduleEventHandler : IRequestHandler<DeleteScheduleEventCommand>
{
    private readonly DataContext _context;

    public DeleteScheduleEventHandler(DataContext context) => _context = context;
    
    public Task<Unit> Handle(DeleteScheduleEventCommand request, CancellationToken cancellationToken)
    {
        _context.Remove(request.entity);
        return Task.FromResult(Unit.Value);
    }
}