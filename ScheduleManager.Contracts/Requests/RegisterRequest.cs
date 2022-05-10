namespace ScheduleManager.Contracts.Requests;

public class RegisterRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string GroupId { get; set; }
    public string Base64 { get; set; }
    public string Fullname { get; set; }
    public int Age { get; set; }
}