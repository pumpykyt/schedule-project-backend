using Microsoft.EntityFrameworkCore;

namespace ScheduleManager.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
}