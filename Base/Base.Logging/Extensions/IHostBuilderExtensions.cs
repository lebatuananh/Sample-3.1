﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Hosting;
using NLog.Web;

namespace Base.Logging.Extensions
{
    public static class IHostBuilderExtensions
    {
        public static IHostBuilder AddNLog(this IHostBuilder hostBuilder)
        {
            return hostBuilder.UseNLog();
        }
    }
}
