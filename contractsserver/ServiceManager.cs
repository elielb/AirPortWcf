using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.ServiceModel.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace ContractsServer
{
    class ServiceManager
    {
        public static T CreateServiceClient<T>(string configName)
        {
            string _assemblyLocation = Assembly.GetExecutingAssembly().Location;
            var PluginConfig = ConfigurationManager.OpenExeConfiguration(_assemblyLocation);
            ConfigurationChannelFactory<T> channelFactory = new ConfigurationChannelFactory<T>(configName, PluginConfig, null);
            var client = channelFactory.CreateChannel();
            return client;
        }
    }
}