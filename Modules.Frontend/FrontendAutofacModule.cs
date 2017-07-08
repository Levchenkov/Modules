using Autofac;
using Modules.Backend.Search;
using System;
using System.Linq;
using System.ServiceModel;
using Autofac.Integration.Wcf;
using Modules.Backend.Cache;
using Modules.Backend.Services;

namespace Modules.Frontend
{
    public class FrontendAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            RegisterServiceClient<ISearchService>(builder);
            RegisterServiceClient<ICacheService>(builder);
            RegisterServiceClient<IServiceNumberOne>(builder);
        }

        private void RegisterServiceClient<TService>(ContainerBuilder builder)
        {
            Type contractType = typeof(TService);
            if (!contractType.IsInterface)
            {
                throw new InvalidOperationException("TService must be an interface.");
            }

            var configurationName = contractType.Name.Substring(1);

            builder
                .Register(c => new ChannelFactory<TService>(configurationName))
                .SingleInstance();

            builder
                .Register(RegisterServiceEntry<TService>)
                .InstancePerLifetimeScope()
                .UseWcfSafeRelease()
                .As<TService>();
        }

        private TService RegisterServiceEntry<TService>(IComponentContext context)
        {
            var baseAddress = "http://localhost:54030";
            var factory = context.Resolve<ChannelFactory<TService>>();
            var serviceAddress = factory.Endpoint.Address.Uri;
            var address = new EndpointAddress(String.Concat(baseAddress, serviceAddress.PathAndQuery));
            return factory.CreateChannel(address);
        }
    }
}