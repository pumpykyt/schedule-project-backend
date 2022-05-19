using FastEndpoints;
using FastEndpoints.Swagger;
using FluentValidation.AspNetCore;
using Hangfire;
using Hangfire.PostgreSql;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ScheduleManager.Data;
using ScheduleManager.Data.Handlers;
using ScheduleManager.Domain.Configs;
using ScheduleManager.Domain.Interfaces;
using ScheduleManager.Domain.Middlewares;
using ScheduleManager.Domain.Services;
using Serilog;

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

var logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).Enrich
    .FromLogContext()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
builder.Services.AddHangfire(cfg => cfg
    .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
    .UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings()
    .UsePostgreSqlStorage(connectionString)
);
builder.Services.AddHangfireServer();

var jwtConfig = builder.Configuration.GetSection("JwtConfig");
builder.Services.Configure<JwtConfig>(jwtConfig);
builder.Services.AddMediatR(typeof(CreateActivityHandler));
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
app.UseHangfireDashboard();
app.UseEndpoints(endpoints =>
{
    endpoints.MapHangfireDashboard();
});

app.Run();