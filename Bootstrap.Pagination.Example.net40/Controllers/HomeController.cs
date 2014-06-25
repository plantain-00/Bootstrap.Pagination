using System.Web.Mvc;

namespace Bootstrap.Pagination.Example.net40.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            var page = Request.QueryInt32("page");
            var group = Request.QueryInt32("group");
            var pagination = new Pagination(100, page, group, 5, 10);
            ViewData["pagination"] = pagination;
            return View();
        }
    }
}