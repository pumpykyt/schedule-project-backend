namespace ScheduleManager.Data.Entities;

public class User : BaseEntity
{
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string GroupId { get; set; }
    public string? ImagePath { get; set; }
    public string Fullname { get; set; }
    public int Age { get; set; }
    public string Role { get; set; }
    public virtual Group Group { get; set; }
}