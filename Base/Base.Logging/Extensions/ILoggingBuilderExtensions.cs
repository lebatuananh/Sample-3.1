using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Filters;
using NLog.Web;

namespace Base.Logging.Extensions
{
    public static class ILoggingBuilderExtensions
    {
        public static void UseSerilog(this ILoggingBuilder builder, IConfiguration configuration)
        {
            builder.AddSerilog();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration, "Logging:Providers:Serilog")
                .CreateLogger();

            //Log.Logger = new LoggerConfiguration()
            //    .WriteTo.Console()
            //    .WriteTo.Logger(configuration =>
            //    {
            //        configuration.WriteTo.File("Logs/error.log");
            //        configuration.Filter.ByIncludingOnly(ev => ev.)
            //    })
            //    .CreateLogger();
        }
        public static void UseNLog(this ILoggingBuilder builder, string configFile)
        {
            builder.AddNLog(configFile);
        }
    }
}
