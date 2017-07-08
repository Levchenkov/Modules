using System.ServiceModel;
using System.ServiceModel.Web;

namespace Modules.Backend.Services
{
    [ServiceContract]
    public interface IServiceNumberOne
    {
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        string MethodOne(string input1, string input2);
    }
}
