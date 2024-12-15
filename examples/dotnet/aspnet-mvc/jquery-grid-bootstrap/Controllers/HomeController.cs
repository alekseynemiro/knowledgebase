using System;
using System.Linq;
using System.Web.Mvc;
using jQueryGridBootstrap.Models;

namespace jQueryGridBootstrap.Controllers
{

  public class HomeController : Controller
  {

    public ActionResult Index()
    {
      return View();
    }

    [HttpPost]
    public JsonResult GetAccounts(int page, int limit)
    {
      using (var context = new Database1Entities())
      {
        // get all records
        // var result = context.Account.ToArray();

        // records for page
        var result = context.Account.OrderBy(row => row.AccountID).Skip((page - 1) * limit).Take(limit).ToArray();
        int total = context.Account.Count();

        // return json
        return Json(new { records = result, total = total });
      }
    }

  }

}