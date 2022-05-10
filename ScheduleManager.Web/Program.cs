using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using ScheduleManager.Data;
using ScheduleManager.Domain.Interfaces;
using ScheduleManager.Domain.Middlewares;
using ScheduleManager.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFastEndpoints();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(options =>
{
    options.AddPolicy("DefaultCorsPolicy", policy =>
    {
        policy.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
    });
});
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(a => a.UseNpgsql(builder.Configuration.GetSection("ConnectionString").Value,
                                           b => b.MigrationsAssembly("ScheduleManager.Web")));

builder.Services.AddScoped<IScheduleService, ScheduleService>();
var app = builder.Build();

app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseRouting();
app.UseCors("DefaultCorsPolicy");
//app.UseAuthentication();
//app.UseAuthorization();
app.UseFastEndpoints();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseFileServer();
app.UseSwagger();
app.UseSwaggerUI();

app.Run();