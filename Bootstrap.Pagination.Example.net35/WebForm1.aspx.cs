using System;
using System.Linq;
using System.Web.UI;

namespace Bootstrap.Pagination.Example.net35
{
    public partial class WebForm1 : Page
    {
        public int[] data;
        protected void Page_Load(object sender, EventArgs e)
        {
            var list = new int[123];
            for (var i = 0; i < 123; i++)
            {
                list[i] = i + 1;
            }
            var page = Request.QueryInt32("page");
            var group = Request.QueryInt32("group");
            var pagination = new Pagination(123, page, group, 5, 10);
            UcPagination1.pagination = pagination;
            data = list.Skip(pagination.Skipped).Take(10).ToArray();
            UcPagination1.url = "?";
        }
    }
}