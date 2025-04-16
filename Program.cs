using FileManagerMcp;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

// Load configuration from appsettings.json
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddEnvironmentVariables()
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddUserSecrets<Program>()
    .Build();

// Set login info from environment variables
Login.host = configuration["FTP_Host"] ?? throw new Exception("FTP_Host configuration is required");
Login.username = configuration["FTP_Username"] ?? throw new Exception("FTP_Username configuration is required");
Login.password = configuration["FTP_Password"] ?? throw new Exception("FTP_Password configuration is required");
if (int.TryParse(configuration["FTP_Port"], out int port))
{
    Login.port = port;
}

var builder = Host.CreateApplicationBuilder(args);
builder.Logging.AddConsole(consoleLogOptions =>
{
    // Configure all logs to go to stderr
    consoleLogOptions.LogToStandardErrorThreshold = LogLevel.Trace;
});
builder.Services
    .AddMcpServer()
    .WithStdioServerTransport()
    .WithTools<FtpTool>();

// Add configuration to services
builder.Services.AddSingleton<IConfiguration>(configuration);

await builder.Build().RunAsync();

// var app = builder.Build();

// app.MapMcp();

// app.Run();