using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace jQueryGridBootstrap
{

  public class Global : System.Web.HttpApplication
  {

    public static void RegisterGlobalFilters(GlobalFilterCollection filters)
    {
      filters.Add(new HandleErrorAttribute());
    }

    public static void RegisterRoutes(RouteCollection routes)
    {
      routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

      routes.MapRoute(
          "Default", // Имя маршрута
          "{controller}/{action}/{id}", // URL-адрес с параметрами
          new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Параметры по умолчанию
      );
    }

    protected void Application_Start(object sender, EventArgs e)
    {
      AreaRegistration.RegisterAllAreas();

      RegisterGlobalFilters(GlobalFilters.Filters);
      RegisterRoutes(RouteTable.Routes);
    }

  }

}