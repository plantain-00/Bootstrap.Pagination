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
            var skipped = Pagination.GetSkipped(page);
            var pagination = new Pagination(123, page);
            ViewData["pagination"] = pagination;
            ViewData["data"] = _list.Skip(skipped).Take(10).ToArray();
            return View();
        }

        public ActionResult GetPagination()
        {
            var page = Request.QueryInt32("page");
            var skipped = Pagination.GetSkipped(page);
            var pagination = new Pagination(123, page);
            ViewData["pagination"] = pagination;
            ViewData["data"] = _list.Skip(skipped).Take(10).ToArray();
            return this.NewtonJson(new
                                   {
                                       pagination = this.PartialViewToString("Pagination"),
                                       data = this.PartialViewToString("DataList")
                                   },
                                   JsonRequestBehavior.AllowGet);
        }

        public ActionResult PagerIndex()
        {
            var page = Request.QueryInt32("page");
            var skipped = Pager.GetSkipped(page);
            var pager = new Pager(123, page);
            ViewData["pager"] = pager;
            ViewData["data"] = _list.Skip(skipped).Take(10).ToArray();
            return View();
        }

        public ActionResult GetPager()
        {
            var page = Request.QueryInt32("page");
            var pager = new Pager(123, page);
            ViewData["pager"] = pager;
            var skipped = Pager.GetSkipped(page);
            ViewData["data"] = _list.Skip(skipped).Take(10).ToArray();
            return this.NewtonJson(new
                                   {
                                       pager = this.PartialViewToString("Pager"),
                                       data = this.PartialViewToString("DataList")
                                   },
                                   JsonRequestBehavior.AllowGet);
        }
    }
}