using Microsoft.EntityFrameworkCore;
using ScheduleManager.Data;

var builder = WebApplication.CreateBuilder(args);


//Services
builder.Services.AddDbContext<DataContext>(a => a.UseNpgsql(builder.Configuration.GetSection("ConnectionString").Value,
                                           b => b.MigrationsAssembly("ScheduleManager.Web")));


var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();