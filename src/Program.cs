using FileManagerMcp;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

// Load configuration from appsettings.json
// var configuration = new ConfigurationBuilder()
//     .SetBasePath(Directory.GetCurrentDirectory())
//     .AddEnvironmentVariables()
//     .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
//     .AddUserSecrets<Program>()
//     .Build();

// Use the new ServiceConfiguration class to configure services
var builder = Host.CreateApplicationBuilder(args);

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddEnvironmentVariables()
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddUserSecrets<Program>();

var configuration = builder.Configuration;

var loginDetail = builder.Configuration.GetSection("FTP").Get<FtpCredential>();
builder.Services.AddSingleton<FtpCredential>(loginDetail ?? throw new ArgumentNullException(nameof(loginDetail)));

builder.ConfigureServices(configuration);

await builder.Build().RunAsync();