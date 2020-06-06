using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Modules.Customer.Registrations;
using AutoMapper;

namespace Application.Api.Registrations
{
    public class MapperInitiator
    {
        public static void Init()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMissingTypeMaps = true;
                cfg.AllowNullCollections = true;
                cfg.ForAllMaps((map, exp) =>
                {
                    foreach (var unmappedPropertyName in map.GetUnmappedPropertyNames())
                        exp.ForMember(unmappedPropertyName, opt => opt.Ignore());
                });

                RegisterMapping(cfg);
            });
        }
        private static void RegisterMapping(IMapperConfigurationExpression cfg)
        {
            cfg.RegisterCustomerModule();
        }
    }
}
