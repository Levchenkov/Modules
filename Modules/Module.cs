using System;

namespace Modules
{
    public abstract class Module
    {
        public Module(Host host, ModuleSettings settings)
        {
            Host = host;
            Type = settings.Type;
        }

        public ModuleType Type
        {
            get;
            private set;
        }

        public Host Host
        {
            get;
            private set;
        }

        public void Start()
        {
            
        }

        public abstract ModuleResponse Process(ModuleRequest request);
    }    
}