using System.Linq;
using System.Web.Mvc;

namespace Bootstrap.Pagination.Example.net40.Controllers
{
    public class HomeController : Controller
    {
        private readonly int[] _list;
        public HomeController()
        {
            _list = new int[123];
            for (var i = 0; i < 123; i++)
            {
                _list[i] = i + 1;
            }
        }
        public ActionResult Index()
        {
            var page = Request.QueryInt32("page");
            var group = Request.QueryInt32("group");
            var pagination = new Pagination(123, page, group, 5, 10);
            ViewData["pagination"] = pagination;
            ViewData["data"] = _list.Skip(pagination.ItemIndex).Take(10).ToArray();
            return View();
        }
        public ActionResult GetPagination()
        {
            var page = Request.QueryInt32("page");
            var group = Request.QueryInt32("group");
            var pagination = new Pagination(123, page, group, 5, 10);
            ViewData["pagination"] = pagination;
            return View("Pagination");
        }
        public ActionResult GetPaginationData()
        {
            var page = Request.QueryInt32("page");
            var group = Request.QueryInt32("group");
            var pagination = new Pagination(123, page, group, 5, 10);
            ViewData["data"] = _list.Skip(pagination.ItemIndex).Take(10).ToArray();
            return View("DataList");
        }
        public ActionResult PagerIndex()
        {
            var page = Request.QueryInt32("page");
            var pager = new Pager(123, page, 10);
            ViewData["pager"] = pager;
            ViewData["data"] = _list.Skip(pager.ItemIndex).Take(10).ToArray();
            return View();
        }
        public ActionResult GetPager()
        {
            var page = Request.QueryInt32("page");
            var pager = new Pager(123, page, 10);
            ViewData["pager"] = pager;
            return View("Pager");
        }
        public ActionResult GetPagerData()
        {
            var page = Request.QueryInt32("page");
            var pager = new Pager(123, page, 10);
            ViewData["data"] = _list.Skip(pager.ItemIndex).Take(10).ToArray();
            return View("DataList");
        }
    }
}