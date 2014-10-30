using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using Bootstrap.Pagination;

namespace QuickStarted
{
    public class CustomRoute : RouteBase
    {
        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            var virtualPath = httpContext.Request.AppRelativeCurrentExecutionFilePath + httpContext.Request.PathInfo;
            virtualPath = virtualPath.Substring(2).Trim('/');
            int page;
            if (int.TryParse(virtualPath, out page))
            {
                var data = new RouteData(this, new MvcRouteHandler());
                data.Values.AddController("Home");
                data.Values.AddAction("Index");
                data.Values.Add("page", page);
                return data;
            }
            return null;
        }

        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            if (values.HasAction("Home", "Index"))
            {
                if (values.ContainsKey("page"))
                {
                    int page;
                    if (int.TryParse(values["page"] as string, out page))
                    {
                        return new VirtualPathData(this, page.ToString());
                    }
                }
            }
            return null;
        }
    }
}