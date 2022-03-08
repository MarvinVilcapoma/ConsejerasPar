using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class ConfigProperty
    {
        private IConfigurationLib ConfigurationLib = null;

        public ConfigProperty(IConfigurationLib _configurationLib)
        {
            ConfigurationLib = _configurationLib;
        }

        public string FilePath()
        {
            return ConfigurationLib.FilePath;
        }
    }
}
