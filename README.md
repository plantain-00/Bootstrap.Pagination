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

    public ActionResult Index(int page = 1)
    {
        var skipped = Pagination.GetSkipped(page);
        ViewData["pagination"] = new Pagination(_list.Length, page);
        ViewData["data"] = _list.Skip(skipped).Take(10).ToArray();
        return View();
    }

    public ActionResult List(int page = 1)
    {
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


example for pagination
--------------------
### Controller
    public ActionResult Index(int page = 1)
    {
        var skipped = Pagination.GetSkipped(page);
        ViewData["pagination"] = new Pagination(123, page);
        ViewData["data"] = _list.Skip(skipped).Take(10).ToArray();
        return View();
    }
    public ActionResult GetPagination(int page = 1)
    {
        var skipped = Pagination.GetSkipped(page);
        ViewData["pagination"] = new Pagination(123, page);
        ViewData["data"] = _list.Skip(skipped).Take(10).ToArray();
        return this.NewtonJson(new
                               {
                                   pagination = this.PartialViewToString("Pagination"),
                                   data = this.PartialViewToString("DataList")
                               },
                               JsonRequestBehavior.AllowGet);
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
            }, function(json) {
                $("#pagination").html(json.pagination);
                $("#data").html(json.data);
            });
        }
    </script>
![](https://raw.githubusercontent.com/plantain-00/Bootstrap.Pagination/master/images/Pagination-Example.JPG)

example for pager
--------------------
### Controller
    public ActionResult PagerIndex(int page = 1)
    {
        var skipped = Pager.GetSkipped(page);
        ViewData["pager"] = new Pager(123, page);
        ViewData["data"] = _list.Skip(skipped).Take(10).ToArray();
        return View();
    }
    public ActionResult GetPager(int page = 1)
    {
        var skipped = Pager.GetSkipped(page);
        ViewData["pager"] = new Pager(123, page);
        ViewData["data"] = _list.Skip(skipped).Take(10).ToArray();
        return this.NewtonJson(new
                               {
                                   pager = this.PartialViewToString("Pager"),
                                   data = this.PartialViewToString("DataList")
                               },
                               JsonRequestBehavior.AllowGet);
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
            }, function(json) {
                $("#pager").html(json.pager);
                $("#data").html(json.data);
            });
        }
    </script>

![](https://raw.githubusercontent.com/plantain-00/Bootstrap.Pagination/master/images/Pager-Example.JPG)

## nuget
You can get [it](https://www.nuget.org/packages/Bootstrap.Pagination) and [MVC](https://www.nuget.org/packages/Bootstrap.Pagination.MVC/) from Nuget.
