namespace Modules
{
    public class Module
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

        public ModuleResponse Process(ModuleRequest request)
        {
            // todo: из фронта надо вызвать бэк и тд
            return new ModuleResponse
            {
                Data = string.Format("{0}: response for {1}", Host.Name, request.Data)
            };
        }
    }
}