using System;
using System.Linq;
using System.Web.UI;

namespace Bootstrap.Pagination.Example.net35
{
    public partial class WebForm2 : Page
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
            var pager = new Pager(123, page, 10);
            UcPager1.pager = pager;
            data = list.Skip(pager.ItemIndex).Take(10).ToArray();
            UcPager1.url = "?";
        }
    }
}