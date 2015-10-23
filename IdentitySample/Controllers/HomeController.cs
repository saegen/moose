using System.Reflection;
using System.Diagnostics;
using System.Web.Mvc;
using System.Linq;

namespace DataLib.Controllers
{
    using Extensions;
    using Common;
    using DataLib;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Request.IsAuthenticated && HttpContext.User.IsInRole(UserRole.Admin))
            {
               return View();
            }
            return View();
        }

        //[Authorize(Roles = Common.UserRole.Admin.ToString())] funkar ej, måste vara en konstant
        //[Authorize(Roles = UserRole.Admin + "," + UserRole.Parent)]
     //   [AuthorizeRoles(UserRole.Staff,UserRole.Admin)]
        //[Authorize(Roles = UserRole.Admin)]
        public ActionResult About()
        {
            ViewBag.Message = "Verksamhet";

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Kontakt";

            return View();
        }

        [HttpGet]
        public ViewResult Pedagogy()
        {
            ViewBag.Message = "Pedagogik";

            return View();
        }

        [HttpGet]
        public ViewResult CoOp()
        {
            ViewBag.Message = "Kooperativet";

            return View();
        }

        [HttpGet]
        public ViewResult Staff()
        {
            ViewBag.Message = "Personalen";

            return View();
        }

        [HttpGet]
        public ViewResult Meny()
        {
            ViewBag.Message = "Matsedel";

            return View();
        }
    }
}
