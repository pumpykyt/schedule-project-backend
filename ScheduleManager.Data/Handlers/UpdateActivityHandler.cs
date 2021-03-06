using MediatR;
using ScheduleManager.Data.Commands;

namespace ScheduleManager.Data.Handlers;

public class UpdateActivityHandler : IRequestHandler<UpdateActivityCommand>
{
    private readonly DataContext _context;

    public UpdateActivityHandler(DataContext context) => _context = context;

    public Task<Unit> Handle(UpdateActivityCommand request, CancellationToken cancellationToken)
    {
        _context.Entry(request.oldEntity).CurrentValues.SetValues(request.newEntity);
        return Task.FromResult(Unit.Value);
    }
}