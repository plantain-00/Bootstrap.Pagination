Bootstrap.Pagination
====================

pagination
--------------------
### Controller
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
                page : page,
                group : group
            }, function(data) {
                var json = eval('(' + data + ')');
                $("#pagination").html(json.pagination);
                $("#data").html(json.data);
            });
        }
    </script>
![](/images/Pagination-Example.JPG)

pager
--------------------
### Controller
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

![](/images/Pager-Example.JPG)

## nuget
You can get [it](https://www.nuget.org/packages/Bootstrap.Pagination) from Nuget.
