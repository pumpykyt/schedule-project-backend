using MediatR;
using ScheduleManager.Data.Commands;

namespace ScheduleManager.Data.Handlers;

public class CreateActivityHandler : IRequestHandler<CreateActivityCommand>
{
    private readonly DataContext _context;

    public CreateActivityHandler(DataContext context)
    {
        _context = context;
    }
    
    public async Task<Unit> Handle(CreateActivityCommand request, CancellationToken cancellationToken)
    {
        await _context.Activities.AddAsync(request.Entity);
        return Unit.Value;
    }
}