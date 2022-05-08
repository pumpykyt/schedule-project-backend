namespace ScheduleManager.Data.Entities;

public class Schedule : BaseEntity
{
    public string Name { get; set; }
    public virtual ICollection<ScheduleEvent> ScheduleEvents { get; set; }
    public virtual Group Group { get; set; }
}