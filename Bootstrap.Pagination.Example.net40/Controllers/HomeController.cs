using System.Linq;
using System.Web.Mvc;

namespace Bootstrap.Pagination.Example.net40.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            var list = new int[123];
            for (var i = 0; i < 123; i++)
            {
                list[i] = i + 1;
            }
            var page = Request.QueryInt32("page");
            var group = Request.QueryInt32("group");
            var pagination = new Pagination(123, page, group, 5, 10);
            ViewData["pagination"] = pagination;
            ViewData["data"] = list.Skip(pagination.ItemIndex).Take(10).ToArray();
            return View();
        }

        public ActionResult IndexPager()
        {
            var list = new int[123];
            for (var i = 0; i < 123; i++)
            {
                list[i] = i + 1;
            }
            var page = Request.QueryInt32("page");
            var pager = new Pager(123, page, 10);
            ViewData["pager"] = pager;
            ViewData["data"] = list.Skip(pager.ItemIndex).Take(10).ToArray();
            return View();
        }
    }
}