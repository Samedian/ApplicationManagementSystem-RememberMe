using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApplicantManagementSystem.Controllers
{
    [SessionState(System.Web.SessionState.SessionStateBehavior.Disabled)]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [ActionSessionState(System.Web.SessionState.SessionStateBehavior.Required)]
        public ActionResult About()
        {
            Session["test"] = "session less controller test";
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}