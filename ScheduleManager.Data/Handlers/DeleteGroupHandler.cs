using MediatR;
using ScheduleManager.Data.Commands;

namespace ScheduleManager.Data.Handlers;

public class DeleteGroupHandler : IRequestHandler<DeleteGroupCommand>
{
    private readonly DataContext _context;

    public DeleteGroupHandler(DataContext context) => _context = context;

    public Task<Unit> Handle(DeleteGroupCommand request, CancellationToken cancellationToken)
    {
        _context.Groups.Remove(request.entity);
        return Task.FromResult(Unit.Value);
    }
}