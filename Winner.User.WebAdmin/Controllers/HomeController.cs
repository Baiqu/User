using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Winner.Framework.MVC;

namespace Winner.User.WebAdmin.Controllers
{
    [AuthRight]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Right()
        {
            return View();
        }
    }
}