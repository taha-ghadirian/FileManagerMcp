using FtpManagerMcp;

var builder = WebApplication.CreateBuilder();
builder.Logging.AddConsole(consoleLogOptions =>
{
    // Configure all logs to go to stderr
    consoleLogOptions.LogToStandardErrorThreshold = LogLevel.Trace;
});
builder.Services
    .AddMcpServer()
    .WithStdioServerTransport()
    .WithTools<FtpTool>();

var app = builder.Build();

app.MapMcp();

app.Run();