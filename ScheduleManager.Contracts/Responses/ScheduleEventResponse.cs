namespace ScheduleManager.Contracts.Responses;

public class ScheduleEventResponse
{
    public string Id { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public string Type { get; set; }
    public string ActivityId { get; set; }
    public string ScheduleId { get; set; }
}