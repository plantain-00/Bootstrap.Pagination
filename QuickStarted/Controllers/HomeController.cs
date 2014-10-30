using System.Linq;
using System.Web.Mvc;

using Bootstrap.Pagination;

using Newtonsoft.Json.Linq;

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
            var jObject = JObject.Parse("{\"name\":\"test\",\"age\":12,\"bbb\":null}");
            var name = jObject.Get("name");
            var age = jObject.Get<int>("age");
            var a1 = jObject.HasKey("aaa");
            var b1 = jObject.HasKey("bbb");
            var b2 = jObject.IsNotNull("bbb");
            var c1 = jObject.HasKey("name");
            var c2 = jObject.IsNotNull("name");
        }

        public ActionResult Index()
        {
            var page = Request.QueryInt32("page");
            var skipped = Pagination.GetSkipped(page);
            ViewData["pagination"] = new Pagination(_list.Length, page);
            ViewData["data"] = _list.Skip(skipped).Take(10).ToArray();
            return View();
        }

        public ActionResult List()
        {
            var page = Request.QueryInt32("page");
            var skipped = Pagination.GetSkipped(page);
            ViewData["pagination"] = new Pagination(_list.Length, page);
            ViewData["data"] = _list.Skip(skipped).Take(10).ToArray();
            return View();
        }
    }
}