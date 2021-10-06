using System.Web.Mvc;
using System.Web.Routing;

namespace CascadeDropDownList
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "api/sitecore/{controller}/{action}/{id}",
                defaults: new { controller = "CascadeDropdownList", action = "SelectItems", id = UrlParameter.Optional }
            );
        }
    }
}

