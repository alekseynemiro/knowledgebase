using System.Web.Routing;

namespace MVC4SpecialCharsInRoute
{
  // Примечание: Инструкции по включению классического режима IIS6 или IIS7 
  // см. по ссылке http://go.microsoft.com/?LinkId=9394801

  public class MvcApplication : System.Web.HttpApplication
  {
    protected void Application_Start()
    {
      RouteConfig.RegisterRoutes(RouteTable.Routes);
    }
  }
}