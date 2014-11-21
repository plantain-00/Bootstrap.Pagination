using System.Linq;
using System.Web.Mvc;

using Bootstrap.Pagination;

namespace QuickStarted.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        private readonly int[] _list;

        public HomeController()
        {
            _list = new int[123];
            for (var i = 0; i < 123; i++)
            {
                _list[i] = i + 1;
            }
        }

        public ActionResult Index(int page = 1)
        {
            var skipped = Pagination.GetSkipped(page);
            ViewData["pagination"] = new Pagination(_list.Length, page);
            ViewData["data"] = _list.Skip(skipped).Take(10).ToArray();
            ViewData["page"] = page;
            return View();
        }

        public ActionResult List(int page = 1)
        {
            var skipped = Pagination.GetSkipped(page);
            ViewData["pagination"] = new Pagination(_list.Length, page);
            ViewData["data"] = _list.Skip(skipped).Take(10).ToArray();
            return View();
        }
    }
}