using System.Web.Mvc;
using System.Web.Routing;

namespace MVC4SpecialCharsInRoute
{
  public class RouteConfig
  {
    public static void RegisterRoutes(RouteCollection routes)
    {
      routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
      routes.IgnoreRoute("{*pathInfo}", new { pathInfo = @".*\.(css|js|gif|jpg|jpeg|png|ttf|woff|woff2|otf|svg|map|doc|docx|pdf|html|htm|txt)(/.)?" });

      routes.MapRoute(
          name: "Default",
          url: "{id}",
          defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
      );
    }
  }
}