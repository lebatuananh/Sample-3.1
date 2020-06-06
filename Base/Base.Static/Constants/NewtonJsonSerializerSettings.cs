using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Base.Static.Constants
{
    public static class NewtonJsonSerializerSettings
    {
        public static readonly JsonSerializerSettings SNAKE = new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            }
        };

        public static readonly JsonSerializerSettings CAMEL = new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            }
        };
    }
}