namespace ScheduleManager.Contracts.Requests;

public class ScheduleEventCreateRequest
{
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public string Type { get; set; }
    public string ActivityId { get; set; }
    public string ScheduleId { get; set; }
}