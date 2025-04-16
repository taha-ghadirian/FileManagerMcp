using FileManagerMcp;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

// Set login info from environment variables
Login.host = Environment.GetEnvironmentVariable("FTP_HOST") ?? throw new Exception("FTP_HOST environment variable is required");
Login.username = Environment.GetEnvironmentVariable("FTP_USERNAME") ?? throw new Exception("FTP_USERNAME environment variable is required"); 
Login.password = Environment.GetEnvironmentVariable("FTP_PASSWORD") ?? throw new Exception("FTP_PASSWORD environment variable is required");
if (int.TryParse(Environment.GetEnvironmentVariable("FTP_PORT"), out int port))
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

await builder.Build().RunAsync();

// var app = builder.Build();

// app.MapMcp();

// app.Run();