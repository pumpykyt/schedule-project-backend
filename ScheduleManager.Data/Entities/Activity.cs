namespace ScheduleManager.Data.Entities;

public class Activity : BaseEntity
{
    public string Name { get; set; }
    public string TeacherName { get; set; }
    public string TeacherEmail { get; set; }
    public virtual ICollection<ScheduleEvent> ScheduleEvents { get; set; }
}