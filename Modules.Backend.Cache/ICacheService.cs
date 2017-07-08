using System.ServiceModel;
using System.ServiceModel.Web;

namespace Modules.Backend.Cache
{
    [ServiceContract]
    public interface ICacheService
    {
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        string GetValue(string key);
    }
}
