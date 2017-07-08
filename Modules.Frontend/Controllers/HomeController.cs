using Modules.Backend.Search;
using System.Web.Mvc;

namespace Modules.Frontend.Controllers
{
    public class HomeController : Controller
    {
        private ISearchService searchService;

        public HomeController(ISearchService searchService)
        {
            this.searchService = searchService;
        }

        public string Index(string query)
        {
            return searchService.Search(query);
        }
    }
}