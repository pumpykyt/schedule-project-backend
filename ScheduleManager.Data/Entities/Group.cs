namespace ScheduleManager.Data.Entities;

public class Group : BaseEntity
{
    public string Name { get; set; }
    public string ScheduleId { get; set; }
    public virtual Schedule Schedule { get; set; }
    public virtual ICollection<User> Users { get; set; }
}