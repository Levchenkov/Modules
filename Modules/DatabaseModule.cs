﻿namespace Modules
{
    public class DatabaseModule : Module
    {
        public DatabaseModule(Host host, ModuleSettings settings) : base(host, settings)
        {
        }

        public override ModuleResponse Process(ModuleRequest request)
        {
            return new ModuleResponse
            {
                Data = string.Format("{0}: response for {1}, type = {2}", Host.Name, request.Data, request.RequestType)
            };
        }
    }
}
