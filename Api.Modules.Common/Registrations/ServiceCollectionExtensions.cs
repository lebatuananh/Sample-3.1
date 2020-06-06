using System;
using System.Collections.Generic;
using System.Text;
using Api.Modules.Common.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Modules.Common.Registrations
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCommonModule(this IServiceCollection services)
        {
            services.AddSingleton<IRegionService, RegionService>();
        }
    }
}
