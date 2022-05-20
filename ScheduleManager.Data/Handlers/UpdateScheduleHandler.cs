using MediatR;
using ScheduleManager.Data.Commands;

namespace ScheduleManager.Data.Handlers;

public class UpdateScheduleHandler : IRequestHandler<UpdateScheduleCommand>
{
    private readonly DataContext _context;

    public UpdateScheduleHandler(DataContext context) => _context = context;
    
    public Task<Unit> Handle(UpdateScheduleCommand request, CancellationToken cancellationToken)
    {
        _context.Entry(request.oldEntity).CurrentValues.SetValues(request.newEntity);
        return Task.FromResult(Unit.Value);
    }
}