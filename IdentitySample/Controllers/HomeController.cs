using System.Reflection;
using System.Diagnostics;
using System.Web.Mvc;
using System.Linq;

namespace IdentitySample.Controllers
{
    using Extensions;
    using Common;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Request.IsAuthenticated && HttpContext.User.IsInRole(UserRole.Admin))
            {
                return RedirectToAction("About");
                //return View();
            }
            return View();
        }

        //[Authorize(Roles = Common.UserRole.Admin.ToString())] funkar ej, måste vara en konstant
        //[Authorize(Roles = UserRole.Admin + "," + UserRole.Parent)]
        [AuthorizeRoles(UserRole.Staff,UserRole.Admin)]
        //[Authorize(Roles = UserRole.Admin)]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "";

            return View();
        }
    }
}
