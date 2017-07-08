using System.Collections.Generic;
using System.Linq;

namespace Modules
{
    public class Host
    {
        private readonly Dictionary<ModuleType, Module> modules;

        private Host(Application application)
        {
            modules = new Dictionary<ModuleType, Module>();
            Application = application;
        }

        public Host(Application application, HostSettings settings) : this(application)
        {
            Name = settings.Name;

            foreach (var moduleSettings in settings.Modules)
            {
                var module = new Module(this, moduleSettings);
                modules.Add(module.Type, module);
            }
        }

        public Application Application
        {
            get;
            private set;
        }

        public string Name
        {
            get;
            private set;
        }

        public List<Module> Modules
        {
            get
            {
                return modules.Values.ToList();
            }
        }

        public void Start()
        {
            StartModules();
        }

        public ModuleResponse Process(ModuleRequest request)
        {
            var module = GetModule(request.RequestType);
            return module.Process(request);
        }

        private Module GetModule(ModuleType type)
        {
            if (modules.ContainsKey(type))
            {
                return modules[type];
            }

            throw new KeyNotFoundException(string.Format("{0} does not contains {1} = {2}", typeof(Host).Name, typeof(ModuleType).Name, type));
        }

        private void StartModules()
        {
            foreach (var module in modules)
            {
                module.Value.Start();
            }
        }
    }
}