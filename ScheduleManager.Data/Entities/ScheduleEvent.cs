namespace ScheduleManager.Data.Entities;

public class ScheduleEvent : BaseEntity
{
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public string Type { get; set; }
    public string ActivityId { get; set; }
    public string ScheduleId { get; set; }
    public string JobId { get; set; }
    public virtual Schedule Schedule { get; set; }
    public virtual Activity Activity { get; set; }
}