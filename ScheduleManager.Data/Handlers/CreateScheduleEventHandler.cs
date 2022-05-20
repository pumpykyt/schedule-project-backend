using MediatR;
using ScheduleManager.Data.Commands;

namespace ScheduleManager.Data.Handlers;

public class CreateScheduleEventHandler : IRequestHandler<CreateScheduleEventCommand>
{
    private readonly DataContext _context;

    public CreateScheduleEventHandler(DataContext context) => _context = context;
    
    public async Task<Unit> Handle(CreateScheduleEventCommand request, CancellationToken cancellationToken)
    {
        await _context.ScheduleEvents.AddAsync(request.entity);
        return Unit.Value;
    }
}