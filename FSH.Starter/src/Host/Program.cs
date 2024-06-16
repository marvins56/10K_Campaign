using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using FSH.Starter.Application;
using FSH.Starter.Application.Common.Interfaces;
using FSH.Starter.Host.Configurations;
using FSH.Starter.Host.Controllers;
using FSH.Starter.Infrastructure;
using FSH.Starter.Infrastructure.Common;
using FSH.Starter.Infrastructure.Logging.Serilog;
using FSH.Starter.Infrastructure.Persistence.Context;
using Serilog;
using Serilog.Formatting.Compact;

[assembly: ApiConventionType(typeof(FSHApiConventions))]

StaticLogger.EnsureInitialized();
Log.Information("Server Booting Up...");
try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.AddConfigurations().RegisterSerilog();
    builder.Services.AddControllers();
    builder.Services.AddInfrastructure(builder.Configuration);
    builder.Services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

    builder.Services.AddApplication();

    var app = builder.Build();

    await app.Services.InitializeDatabasesAsync();


    app.UseInfrastructure(builder.Configuration);
    app.MapEndpoints();
    app.Run();
}
catch (Exception ex) when (!ex.GetType().Name.Equals("StopTheHostException", StringComparison.Ordinal))
{
    StaticLogger.EnsureInitialized();
    Log.Fatal(ex, "Unhandled exception");
}
finally
{
    StaticLogger.EnsureInitialized();
    Log.Information("Server Shutting down...");
    Log.CloseAndFlush();
}