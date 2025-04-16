using FileManagerMcp;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;


var builder = Host.CreateApplicationBuilder(args);

builder.ConfigureServices();

var loginDetail = builder.Configuration.GetSection("FTP").Get<FtpCredential>();
builder.Services.AddSingleton(loginDetail ?? throw new ArgumentNullException(nameof(loginDetail)));

await builder.Build().RunAsync();