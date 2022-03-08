using Common.AspNetCore.Logging;
using Common.Logging;
using EntityFrameworkCore.DbContextScope;
using LightInject;


namespace Service.Config
{
    public class ServiceRegister : ICompositionRoot
    {
        public void Compose(IServiceRegistry container)
        {
            var ambientDbContextLocator = new AmbientDbContextLocator();

            container.Register<IDbContextScopeFactory>((x) => new DbContextScopeFactory(null));
            container.Register<IAmbientDbContextLocator, AmbientDbContextLocator>(new PerScopeLifetime());
            container.Register<ICustomLog, CustomLog4Net>();
        }
    }
}
