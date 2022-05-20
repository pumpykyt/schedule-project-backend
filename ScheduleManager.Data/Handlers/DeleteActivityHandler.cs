using MediatR;
using ScheduleManager.Data.Commands;

namespace ScheduleManager.Data.Handlers;

public class DeleteActivityHandler : IRequestHandler<DeleteActivityCommand>
{
    private readonly DataContext _context;

    public DeleteActivityHandler(DataContext context) => _context = context;
    
    public Task<Unit> Handle(DeleteActivityCommand request, CancellationToken cancellationToken)
    {
        _context.Activities.Remove(request.entity);
        return Task.FromResult(Unit.Value);
    }
}