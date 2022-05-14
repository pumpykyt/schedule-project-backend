using FastEndpoints;
using FastEndpoints.Swagger;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using ScheduleManager.Data;
using ScheduleManager.Domain.Configs;
using ScheduleManager.Domain.Interfaces;
using ScheduleManager.Domain.Middlewares;
using ScheduleManager.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFastEndpoints();
builder.Services.AddSwaggerDoc();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(options =>
{
    options.AddPolicy("DefaultCorsPolicy", policy =>
    {
        policy.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
    });
});


var connectionString = builder.Configuration.GetSection("ConnectionString").Value;
builder.Services.AddDbContext<DataContext>(a => a.UseNpgsql(connectionString,
                                           b => b.MigrationsAssembly("ScheduleManager.Web")));

var jwtConfig = builder.Configuration.GetSection("JwtConfig");
builder.Services.Configure<JwtConfig>(jwtConfig);

builder.Services.AddScoped<IScheduleService, ScheduleService>();
builder.Services.AddScoped<IGroupService, GroupService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IScheduleEventService, ScheduleEventService>();
builder.Services.AddScoped<IActivityService, ActivityService>();
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
app.UseOpenApi();
app.UseSwaggerUi3();

app.Run();