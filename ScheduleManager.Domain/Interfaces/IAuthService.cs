using ScheduleManager.Contracts.Requests;
using ScheduleManager.Contracts.Responses;

namespace ScheduleManager.Domain.Interfaces;

public interface IAuthService
{
    Task<AuthResponse> LoginAsync(LoginRequest model);
    Task<AuthResponse> RegisterAsync(RegisterRequest model);
}