namespace Modules
{
    public class BackendModule : Module
    {
        public BackendModule(Host host, ModuleSettings settings) : base(host, settings)
        {
        }

        public override ModuleResponse Process(ModuleRequest request)
        {
            var databaseRequest = new ModuleRequest
            {
                RequestType = ModuleType.Database,
                Data = request.Data
            };

            var fileStorageRequest = new ModuleRequest
            {
                RequestType = ModuleType.FileStorage,
                Data = request.Data
            };

            var databaseResponse = Host.Application.Process(databaseRequest);
            var fileStorageResponse = Host.Application.Process(fileStorageRequest);

            return new ModuleResponse
            {
                Data = string.Format("{2}\n{3}\n{0}: response for {1}, type = {4}", Host.Name, request.Data, databaseResponse.Data, fileStorageResponse.Data, request.RequestType)
            };
        }
    }
}
