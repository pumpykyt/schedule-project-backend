namespace ScheduleManager.Contracts.Requests;

public class GroupUpdateRequest
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string ScheduleId { get; set; }
}