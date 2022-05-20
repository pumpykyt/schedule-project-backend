using MediatR;
using Microsoft.EntityFrameworkCore;
using ScheduleManager.Data.Entities;
using ScheduleManager.Data.Queries;

namespace ScheduleManager.Data.Handlers;

public class GetUserByEmailHandler : IRequestHandler<GetUserByEmailQuery, User>
{
    private readonly DataContext _context;

    public GetUserByEmailHandler(DataContext context) => _context = context;
    
    public async Task<User> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken) 
        => await _context.Users.SingleOrDefaultAsync(t => t.Email == request.email);
}