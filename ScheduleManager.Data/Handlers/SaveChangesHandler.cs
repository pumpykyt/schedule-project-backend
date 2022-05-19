using MediatR;
using ScheduleManager.Data.Commands;

namespace ScheduleManager.Data.Handlers;

public class SaveChangesHandler : IRequestHandler<SaveChangesCommand, int>
{
    private readonly DataContext _context;

    public SaveChangesHandler(DataContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(SaveChangesCommand request, CancellationToken cancellationToken) 
        => await _context.SaveChangesAsync();
}