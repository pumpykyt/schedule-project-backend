namespace ScheduleManager.Contracts.Requests;

public class ActivityCreateRequest
{
    public string Name { get; set; }
    public string TeacherName { get; set; }
    public string TeacherEmail { get; set; }
}