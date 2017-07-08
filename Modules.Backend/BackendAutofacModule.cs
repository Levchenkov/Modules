using Autofac;
using Modules.Backend.Cache;
using Modules.Backend.Search;
using Modules.Backend.Services;

namespace Modules.Backend
{
    public class BackendAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<SearchService>().As<ISearchService>();
            builder.RegisterType<CacheService>().As<ICacheService>();
            builder.RegisterType<ServiceNumberOne>().As<IServiceNumberOne>();
            builder.RegisterType<HomeService>().As<IHomeService>();
        }
    }
}