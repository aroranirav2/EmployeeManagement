using Contracts;
using Database.EmployeeManagement.Persistence.EFCore;
using Database.EmployeeManagement.Persistence.EFCore.Repositories;
using EmployeeManagement.API.Extensions;
using EmployeeManagement.Repository.Repositories;
using LoggerService;
using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);
const string AppSettingsOrigins = "AppSettingsOrigins";

// Add services to the container.
builder.Services.AddCors(options =>
{
    var defaultCorsConfig = builder.Configuration.GetSection("CorsSettings:AllowedClients").GetChildren().ToArray();
    var defaultCorsAllowedOrigin = defaultCorsConfig.Select(x => x.Value).ToArray();

    options.AddPolicy(name: AppSettingsOrigins,
        policiyBuilder =>
        {
            policiyBuilder.WithOrigins(defaultCorsAllowedOrigin)
            .AllowCredentials()
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});
//Will use this when I move nlog config to appsettings.json
//LogManager.Configuration = new NLogLoggingConfiguration(builder.Configuration.GetSection("NLog"));
LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
builder.Services.AddSingleton<ILoggerManager, LoggerManager>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEntityFrameworkSqlServer().AddDbContext<EmployeeSystemDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeSystem"))
);
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureCustomExceptionMiddleware();

app.UseHttpsRedirection();

app.UseCors(AppSettingsOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
