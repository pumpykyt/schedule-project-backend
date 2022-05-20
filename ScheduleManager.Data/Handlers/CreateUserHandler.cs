using MediatR;
using ScheduleManager.Data.Commands;

namespace ScheduleManager.Data.Handlers;

public class CreateUserHandler : IRequestHandler<CreateUserCommand>
{
    private readonly DataContext _context;

    public CreateUserHandler(DataContext context) => _context = context;

    public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        await _context.Users.AddAsync(request.entity);
        return Unit.Value;
    }
}