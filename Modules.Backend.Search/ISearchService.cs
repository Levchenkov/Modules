using System.ServiceModel;
using System.ServiceModel.Web;

namespace Modules.Backend.Search
{
    [ServiceContract]
    public interface ISearchService
    {
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        string Search(string query);
    }
}
