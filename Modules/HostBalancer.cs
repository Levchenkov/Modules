using System.Collections.Generic;

namespace Modules
{
    public class HostBalancer
    {
        private readonly Queue<HostRequestCounter> hostCounters;

        public HostBalancer()
        {
            hostCounters = new Queue<HostRequestCounter>();
        }

        public void Start()
        {
        }

        public void Add(Host host)
        {
            var hostRequestCounter = new HostRequestCounter
            {
                Host = host
            };
            hostCounters.Enqueue(hostRequestCounter);
        }

        public ModuleResponse Process(ModuleRequest request)
        {
            var counter = hostCounters.Dequeue();
            counter.ActiveRequestCount++;
            return counter.Host.Process(request);
        }
    }
}