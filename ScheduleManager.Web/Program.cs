using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using ScheduleManager.Data;
using ScheduleManager.Domain.Configs;
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

var connectionString = builder.Configuration.GetSection("ConnectionString").Value;
builder.Services.AddDbContext<DataContext>(a => a.UseNpgsql(connectionString,
                                           b => b.MigrationsAssembly("ScheduleManager.Web")));

var jwtConfig = builder.Configuration.GetSection("JwtConfig");
builder.Services.Configure<JwtConfig>(jwtConfig);

builder.Services.AddScoped<IScheduleService, ScheduleService>();
builder.Services.AddScoped<IGroupService, GroupService>();
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