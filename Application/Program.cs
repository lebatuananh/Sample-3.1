using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Base.Logging;
using Base.Logging.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Application.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            var loggerFactory = (ILoggerFactory)host.Services.GetService(typeof(ILoggerFactory));
            ApplicationLogManager.LoggerFactory = loggerFactory;

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", true)
            .AddJsonFile($"appsettings.{environmentName}.json", true)
            .Build();

            var hostBuilder = Host.CreateDefaultBuilder(args)
                .ConfigureHostConfiguration(config =>
                {
                    config.AddConfiguration(configuration);

                })
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                    //logging.UseSerilog(configuration);

                    var configFilePath = configuration
                        .GetSection("Logging:Providers:NLog:ConfigFilePath").Get<string>();
                    logging.UseNLog(configFilePath);
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

            return hostBuilder;
        }
    }
}
