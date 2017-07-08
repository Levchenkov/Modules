using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.Wcf;
using Modules.Backend.Cache;
using Modules.Backend.Search;
using Modules.Backend.Services;
using System.ServiceModel.Activation;
using System.Web.Mvc;
using System.Web.Routing;

namespace Modules.Backend
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            RouteTable.Routes.Add(new ServiceRoute("", new WebServiceHostFactory(), typeof(HomeService)));
            RouteTable.Routes.Add(new ServiceRoute("ServiceNumberOne", new WebServiceHostFactory(), typeof(ServiceNumberOne)));
            RouteTable.Routes.Add(new ServiceRoute("SearchService", new WebServiceHostFactory(), typeof(SearchService)));
            RouteTable.Routes.Add(new ServiceRoute("CacheService", new WebServiceHostFactory(), typeof(CacheService)));

            var builder = new ContainerBuilder();
            builder.RegisterModule<BackendAutofacModule>();
            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            AutofacHostFactory.Container = container;
        }
    }
}
