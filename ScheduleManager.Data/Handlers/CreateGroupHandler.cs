using MediatR;
using ScheduleManager.Data.Commands;

namespace ScheduleManager.Data.Handlers;

public class CreateGroupHandler : IRequestHandler<CreateGroupCommand>
{
    private readonly DataContext _context;

    public CreateGroupHandler(DataContext context) => _context = context;

    public async Task<Unit> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
    {
        await _context.Groups.AddAsync(request.entity);
        return Unit.Value;
    }
}