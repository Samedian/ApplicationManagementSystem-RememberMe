using ApplicantManagementSystemBAL;
using ApplicantManagementTables;
using ApplicationManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ApplicantManagementSystem.Controllers
{
    [SessionState(System.Web.SessionState.SessionStateBehavior.Disabled)]

    public class AccountController : Controller
    {

        private readonly IAccountBAl _accountBAl;
        public AccountController(IAccountBAl accountBAL)
        {
            _accountBAl = accountBAL;
        }


        [ActionSessionState(System.Web.SessionState.SessionStateBehavior.Required)]
        [HttpGet]
        public ActionResult CreateAccount()
        {
            Session["test"] = "session less controller test";
            return View();
        }

        [ActionSessionState(System.Web.SessionState.SessionStateBehavior.Required)]
        [HttpPost]
        public ActionResult CreateAccount(UserDetailEntity userDetailEntity)
        {
            userDetailEntity.UserType = "Admin";
            Session["test"] = "session less controller test";
            string message = null;
            try
            {
                message = _accountBAl.SaveCredentials(userDetailEntity);

            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            return Json(new { Message = message, JsonRequestBehavior.AllowGet });

        }

        [ActionSessionState(System.Web.SessionState.SessionStateBehavior.Required)]
        [HttpGet]
        public ActionResult Login()
        {
            Session["test"] = "session less controller test";
            HttpCookie cookie = Request.Cookies["User"];
            if (cookie != null)
            {
                ViewBag.UserName = cookie["UserName"].ToString();

                string EncryptPassword = cookie["pass"].ToString();
                byte[] b = Convert.FromBase64String(EncryptPassword);
                string DecryptPassword = ASCIIEncoding.ASCII.GetString(b);

                ViewBag.pass = DecryptPassword.ToString();
            }
            return View();
        }

        [ActionSessionState(System.Web.SessionState.SessionStateBehavior.Required)]
        [HttpPost]
        public ActionResult Login(Table user)
        {
            HttpCookie cookie = new HttpCookie("User");
            LoginDbEntities db = new LoginDbEntities();

            string message = null;
            try
            {
                if (user.RememberMe == true)
                {
                    cookie["UserName"] = user.UserName;

                    byte[] b = ASCIIEncoding.ASCII.GetBytes(user.pass);
                    string EncryptedPassword = Convert.ToBase64String(b);
                    cookie["pass"] = EncryptedPassword;

                    cookie.Expires = DateTime.Now.AddDays(2);
                    HttpContext.Response.Cookies.Add(cookie);
                }
                else
                {
                    cookie.Expires = DateTime.Now.AddDays(-1);
                    HttpContext.Response.Cookies.Add(cookie);
                }

                var row = db.Tables.Where(x => x.UserName == user.UserName && x.pass == user.pass).FirstOrDefault();
                if (row != null)
                {
                    Session["UserName"] = user.UserName;
                    message = "Success";

                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            FormsAuthentication.SetAuthCookie(user.UserName, false);
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });

        }
    }
}