namespace ScheduleManager.Contracts.Requests;

public class ActivityUpdateRequest
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string TeacherName { get; set; }
    public string TeacherEmail { get; set; }
}