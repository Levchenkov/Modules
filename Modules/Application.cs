using System.Collections.Generic;

namespace Modules
{
    public class Application
    {
        private readonly Router router;

        private readonly List<Host> hosts;

        private Application()
        {
            hosts = new List<Host>();
            router = new Router();
        }

        public Application(ApplicationSettings settings) : this()
        {
            foreach (var hostSettings in settings.Hosts)
            {
                var host = new Host(this, hostSettings);
                hosts.Add(host);
            }
        }

        public void Start()
        {
            StartHosts();
            router.Start(hosts);
        }

        public HttpResponse Process(HttpRequest request)
        {
            var moduleRequest = new ModuleRequest
            {
                RequestType = ModuleType.Frontend,
                Data = string.Format("Request number {0}", request.Number)
            };

            var moduleResponse = Process(moduleRequest);

            return new HttpResponse
            {
                Result = moduleResponse.Data
            };
        }

        public ModuleResponse Process(ModuleRequest request)
        {
            return router.Process(request);
        }

        private void StartHosts()
        {
            foreach (var host in hosts)
            {
                host.Start();
            }
        }
    }
}