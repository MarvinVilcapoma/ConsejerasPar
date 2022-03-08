using Microsoft.Extensions.Configuration;
using System.IO;

namespace Common.AspNetCore
{
    public static class ConfigManager
    {
        public static IConfigurationRoot GetConfig()
        {
            return new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json")
              .Build();
        }
    }
}
