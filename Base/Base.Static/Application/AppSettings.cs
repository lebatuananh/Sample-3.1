using Microsoft.Extensions.Configuration;

namespace Base.Static.Application
{
    public class AppSettings
    {
        private static IConfiguration config;

        public static void SetConfig(IConfiguration configuration)
        {
            config = configuration;
        }

        public static T Get<T>(string key = null, T defaultValue = default)
        {
            if (string.IsNullOrWhiteSpace(key))
                return config.Get<T>();
            var test = config.GetSection(key).Get<T>();
            return config.GetSection(key).Get<T>();
        }

        public static T Get<T>(string key = null)
        {
            if (string.IsNullOrWhiteSpace(key))
                return config.Get<T>();
            var test = config.GetSection(key).Get<T>();
            return config.GetSection(key).Get<T>();
        }
    }
}