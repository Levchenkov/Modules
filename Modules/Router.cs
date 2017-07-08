using System.Collections.Generic;

namespace Modules
{
    public class Router
    {
        private readonly IDictionary<ModuleType, HostBalancer> routes;

        public Router()
        {
            routes = new Dictionary<ModuleType, HostBalancer>
            {
                { ModuleType.Frontend, new HostBalancer() } ,
                { ModuleType.Backend, new HostBalancer() } ,
                { ModuleType.Database, new HostBalancer() } ,
                { ModuleType.FileStorage, new HostBalancer() }
            };
        }

        public void Start(List<Host> hosts)
        {
            foreach (var host in hosts)
            {
                foreach (var module in host.Modules)
                {
                    var balancer = GetHostBalancer(module.Type);
                    balancer.Add(host);
                }
            }
        }

        public ModuleResponse Process(ModuleRequest request)
        {
            var balancer = GetHostBalancer(request.RequestType);
            return balancer.Process(request);
        }

        private HostBalancer GetHostBalancer(ModuleType type)
        {
            if (routes.ContainsKey(type))
            {
                return routes[type];
            }

            throw new KeyNotFoundException(string.Format("{0} does not found with for {1} = {2}.", typeof(HostBalancer).Name, typeof(ModuleType).Name, type));
        }
    }
}