using System.ServiceModel;
using System.ServiceModel.Web;

namespace Modules.Backend
{
    [ServiceContract]
    internal interface IHomeService
    {
        [OperationContract]
        [WebGet(UriTemplate = "")]
        string Hello();
    }
}