namespace Modules
{
    public class FrontendModule : Module
    {
        public FrontendModule(Host host, ModuleSettings settings) : base(host, settings)
        {
        }

        public override ModuleResponse Process(ModuleRequest request)
        {
            var backendRequest = new ModuleRequest
            {
                RequestType = ModuleType.Backend,
                Data = request.Data
            };

            var backendResponse = Host.Application.Process(backendRequest);

            return new ModuleResponse
            {
                Data = string.Format("{2}\n{0}: response for {1}, type = {3}", Host.Name, request.Data, backendResponse.Data, request.RequestType)
            };
        }
    }
}
