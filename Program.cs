using FluentValidation.AspNetCore;
using FluentValidation;
using Mapster;
using FootballTeam2.BL;
using FootballTeam2.DL;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;
using FootballTeam2.Controllers;
using FootballTeam2.HealthChecks;
using FootballTeam2.ServiceExtensions;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .WriteTo.Console(theme: AnsiConsoleTheme.Code)
            .CreateLogger();

        builder.Logging.AddSerilog(logger);

        // Add services to the container.
        builder.Services
            .AddConfigurations(builder.Configuration)
            .AddDataDependencies()
            .AddBusinessDependencies()
            .AddBackgroundServices();

        builder.Services.AddMapster();

        builder.Services.AddValidatorsFromAssemblyContaining<TestRequest>();
        builder.Services.AddFluentValidationAutoValidation();

        builder.Services.AddControllers();
        builder.Services.AddSwaggerGen();

        builder.Services.AddHealthChecks()
            .AddCheck<SampleHealthCheck>("Sample");

        // 🔌 Add Kafka Producer
        builder.Services.AddSingleton<IKafkaProducer, KafkaProducer>();

        // 🌐 Add HTTP API Service
        builder.Services.AddHttpClient<IApiService, ApiService>();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.MapHealthChecks("/healthz");

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}