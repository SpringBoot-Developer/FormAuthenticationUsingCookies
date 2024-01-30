using FormAuthentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FormAuthentication.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if(ModelState.IsValid)
            {
                if(model.UserName == "admin" && model.Password == "123")
                {
                    Console.WriteLine("---");
                    FormsAuthentication.SetAuthCookie(model.UserName , true);
                    return RedirectToAction("Dashboard");
                }
            }

            return View(model);
        }

        [Authorize]
        [HttpGet]
        public ActionResult Dashboard()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.RemoveAll();
            return View("Login");
        }
    }
}