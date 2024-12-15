using System.Web.Mvc;
using MVC4SpecialCharsInRoute.Models;

namespace MVC4SpecialCharsInRoute.Controllers
{

  public class HomeController : Controller
  {

    public ActionResult Index(string id)
    {
      return View(new HomeModel { Id = id });
    }

  }

}