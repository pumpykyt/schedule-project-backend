using MediatR;
using ScheduleManager.Data.Commands;

namespace ScheduleManager.Data.Handlers;

public class UpdateGroupHandler : IRequestHandler<UpdateGroupCommand>
{
    private readonly DataContext _context;

    public UpdateGroupHandler(DataContext context) => _context = context;
    
    public Task<Unit> Handle(UpdateGroupCommand request, CancellationToken cancellationToken)
    {
        _context.Entry(request.oldEntity).CurrentValues.SetValues(request.newEntity);
        return Task.FromResult(Unit.Value);
    }
}