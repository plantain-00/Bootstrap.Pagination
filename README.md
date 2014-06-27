Bootstrap.Pagination
====================

pagination
--------------------
### Controller
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
### View
        @{
        var data = ViewData["data"] as int[];
    }
    <ul>
        @for (var i = 0; i < data.Length; i++)
        {
            <li>@data[i]</li>
        }
    </ul>
    @Html.Partial("Pagination")
![](/images/Pagination-Example.JPG)

pager
--------------------
### Controller
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
### View
        @{
        var data = ViewData["data"] as int[];
    }
    <ul>
        @for (var i = 0; i < data.Length; i++)
        {
            <li>@data[i]</li>
        }
    </ul>
    @Html.Partial("Pager")

![](/images/Pager-Example.JPG)

You can get [it](https://www.nuget.org/packages/Bootstrap.Pagination) from Nuget.
