using Common.AspNetCore;
using LightInject;
using Microsoft.Extensions.Configuration;
using Service.Config;
using System;
using System.Reflection;


namespace Service.DependecyInjection
{
    public class DependencyFactory
    {

        public static T GetInstance<T>()
        {
            var container = new ServiceContainer();
            container.RegisterAssembly(typeof(ServiceRegister).GetTypeInfo().Assembly);
            try
            {
                container.Register<IConfiguration>((x) => ConfigManager.GetConfig());
                return container.GetInstance<T>();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
