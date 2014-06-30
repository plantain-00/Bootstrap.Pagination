using System.Linq;
using System.Web.Mvc;

using Newtonsoft.Json;

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
            ViewData["data"] = _list.Skip(pagination.ItemIndex).Take(10).ToArray();
            var json = JsonConvert.SerializeObject(new
                                                   {
                                                       pagination = this.PartialViewToString("Pagination"),
                                                       data = this.PartialViewToString("DataList")
                                                   });
            return new JsonResult
                   {
                       Data = json,
                       JsonRequestBehavior = JsonRequestBehavior.AllowGet
                   };
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
            ViewData["data"] = _list.Skip(pager.ItemIndex).Take(10).ToArray();
            var json = JsonConvert.SerializeObject(new
                                                   {
                                                       pager = this.PartialViewToString("Pager"),
                                                       data = this.PartialViewToString("DataList")
                                                   });
            return new JsonResult
                   {
                       Data = json,
                       JsonRequestBehavior = JsonRequestBehavior.AllowGet
                   };
        }
    }
}