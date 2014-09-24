Bootstrap.Pagination
====================

Get Started
--------------------

### HomeController

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

### Index View

    <div id="list">
        @Html.Partial("List")
    </div>
    <script src="~/Scripts/jquery-1.9.0.min.js"></script>
    <script src="~/Scripts/bootstrap.min.js"></script>
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" />
    <script type="text/javascript">
        function navigateTo(page) {
            $.ajax({
                url : "@Url.Action("List")",
                data : {
                    page : page
                },
                success : function(data) {
                    $("#list").html(data);
                }
            });
        }
    </script>

### List View

    @{
        var data = ViewData["data"] as int[];
    }
    <ul>
        @foreach (var d in data)
        {
            <li>@d</li>
        }
    </ul>
    @Html.Partial("Pagination")

pagination
--------------------
### Controller
    public ActionResult Index()
    {
        var page = Request.QueryInt32("page");
        var pagination = new Pagination(123, page);
        var skipped = Pagination.GetSkipped(page);
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
### View
    <div id="data">
        @Html.Partial("DataList")
    </div>
    <div id="pagination">
        @Html.Partial("Pagination")
    </div>
    <script src="~/Scripts/jquery-1.9.1.min.js"></script>
    <script src="~/Scripts/bootstrap.min.js"></script>
    <script type="text/javascript">
        function navigateTo(page, group) {
            $.getJSON("@Url.Action("GetPagination")", {
                page : page
            }, function(data) {
                var json = eval('(' + data + ')');
                $("#pagination").html(json.pagination);
                $("#data").html(json.data);
            });
        }
    </script>
![](https://raw.githubusercontent.com/plantain-00/Bootstrap.Pagination/master/images/Pagination-Example.JPG)

pager
--------------------
### Controller
    public ActionResult PagerIndex()
    {
        var page = Request.QueryInt32("page");
        var pager = new Pager(123, page);
        ViewData["pager"] = pager;
        ViewData["data"] = _list.Skip(pager.Skipped).Take(10).ToArray();
        return View();
    }
    public ActionResult GetPager()
    {
        var page = Request.QueryInt32("page");
        var pager = new Pager(123, page);
        ViewData["pager"] = pager;
        ViewData["data"] = _list.Skip(pager.Skipped).Take(10).ToArray();
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
### View
    <div id="data">
        @Html.Partial("DataList")
    </div>
    <div id="pager">
        @Html.Partial("Pager")
    </div>
    <script src="~/Scripts/jquery-1.9.1.min.js"></script>
    <script src="~/Scripts/bootstrap.min.js"></script>
    <script type="text/javascript">
        function navigateTo(page) {
            $.getJSON("@Url.Action("GetPager")", {
                page : page
            }, function(data) {
                var json = eval('(' + data + ')');
                $("#pager").html(json.pager);
                $("#data").html(json.data);
            });
        }
    </script>

![](https://raw.githubusercontent.com/plantain-00/Bootstrap.Pagination/master/images/Pager-Example.JPG)

## nuget
You can get [it](https://www.nuget.org/packages/Bootstrap.Pagination) from Nuget.
