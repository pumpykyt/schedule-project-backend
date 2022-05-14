using System.Net;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ScheduleManager.Contracts.Requests;
using ScheduleManager.Contracts.Responses;
using ScheduleManager.Data;
using ScheduleManager.Data.Constraints;
using ScheduleManager.Data.Entities;
using ScheduleManager.Domain.Configs;
using ScheduleManager.Domain.Exceptions;
using ScheduleManager.Domain.Helpers;
using ScheduleManager.Domain.Interfaces;

namespace ScheduleManager.Domain.Services;

public class AuthService : IAuthService
{
    private readonly DataContext _context;
    private readonly JwtConfig _jwtConfig;

    public AuthService(DataContext context, IOptions<JwtConfig> options)
    {
        _context = context;
        _jwtConfig = options.Value;
    }

    public async Task<AuthResponse> LoginAsync(LoginRequest model)
    {
        var user = await _context.Users.SingleOrDefaultAsync(t => t.Email == model.Email);
        if (user is null) throw new HttpException(HttpStatusCode.Unauthorized, "Wrong data");
        var isVerified = BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash);
        if (!isVerified) throw new HttpException(HttpStatusCode.Unauthorized, "Wrong credentials");
        var jwt = JwtHelper.GenerateJwt(user.Id, user.Email, user.Role, _jwtConfig);
        return new AuthResponse { Token = jwt };
    }

    public async Task<AuthResponse> RegisterAsync(RegisterRequest model)
    {
        var user = await _context.Users.SingleOrDefaultAsync(t => t.Email == model.Email);
        if(user is not null) throw new HttpException(HttpStatusCode.Conflict, "That email is already registered");
        var newUser = new User
        {
            Id = Guid.NewGuid().ToString(),
            Email = model.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password),
            Age = model.Age,
            GroupId = model.GroupId,
            Fullname = model.Fullname,
            Role = RoleConstraints.UserRole
        };
        if (!string.IsNullOrEmpty(model.Base64))
        {
            newUser.ImagePath = await ImageHelper.SaveImageAsync(model.Base64);
        }
        await _context.Users.AddAsync(newUser);
        var result = await _context.SaveChangesAsync();
        if (result == 0) throw new HttpException(HttpStatusCode.InternalServerError, "Server error");
        var jwt = JwtHelper.GenerateJwt(newUser.Id, newUser.Email, newUser.Role, _jwtConfig);
        return new AuthResponse { Token = jwt };
    }
}