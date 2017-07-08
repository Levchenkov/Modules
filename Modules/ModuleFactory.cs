using System;

namespace Modules
{
    public static class ModuleFactory
    {
        public static Module CreateModule(Host host, ModuleSettings settings)
        {
            Module module;
            switch (settings.Type)
            {
                case ModuleType.Frontend:
                    module = new FrontendModule(host, settings);
                    break;
                case ModuleType.Backend:
                    module = new BackendModule(host, settings);
                    break;
                case ModuleType.Database:
                    module = new DatabaseModule(host, settings);
                    break;
                case ModuleType.FileStorage:
                    module = new FileStorageModule(host, settings);
                    break;
                default:
                    throw new NotSupportedException(string.Format("It does not support {0} = {1}.", typeof(ModuleType).Name, settings.Type));
            }

            return module;
        }
    }
}
