using MediatR;
using ScheduleManager.Data.Commands;

namespace ScheduleManager.Data.Handlers;

public class CreateScheduleHandler : IRequestHandler<CreateScheduleCommand>
{
    private readonly DataContext _context;

    public CreateScheduleHandler(DataContext context) => _context = context;
    
    public async Task<Unit> Handle(CreateScheduleCommand request, CancellationToken cancellationToken)
    {
        await _context.Schedules.AddAsync(request.entity);
        return Unit.Value;
    }
}