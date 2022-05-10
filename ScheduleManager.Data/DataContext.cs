using Microsoft.EntityFrameworkCore;
using ScheduleManager.Data.Entities;

namespace ScheduleManager.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    
    public virtual DbSet<Activity> Activities { get; set; }
    public virtual DbSet<Group> Groups { get; set; }
    public virtual DbSet<Schedule> Schedules { get; set; }
    public virtual DbSet<ScheduleEvent> ScheduleEvents { get; set; }
    public virtual DbSet<User> Users { get; set; }
}