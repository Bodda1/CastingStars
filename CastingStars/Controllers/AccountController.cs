using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CastingStars.VM.Account;
using CastingStars.Repository;
using CastingStars.Models;

namespace CastingStars.Controllers
{
    public class AccountController : BaseController
    {
        private UserRepository _ur;


        public AccountController ()
        {
            _ur = new UserRepository();
        }


        public ActionResult Login ()
        {
            ViewBag.background = "body-bg-black";
            return View();
        }


        public ActionResult SignUp()
        {
            ViewBag.background = "body-bg-black";
            return View();
        }


        public ActionResult ForgotPassword()
        {
            ViewBag.background = "body-bg-black";
            return View();
        }


        public ActionResult AgentProfile()
        {
            ViewBag.background = "body-bg-white";
            return View();
        }


        public ActionResult TalentProfile()
        {
            ViewBag.background = "body-bg-white";
            return View();
        }


        public ActionResult CrewProfile()
        {
            ViewBag.background = "body-bg-white";
            return View();
        }


        public ActionResult LocationProfile()
        {
            ViewBag.background = "body-bg-white";
            return View();
        }


        public ActionResult AgentDashboard()
        {
            ViewBag.background = "body-bg-black";
            return View();
        }


        [HttpPost]
        public ActionResult Login(LoginVM model)
        {
            if (!ModelState.IsValid)
            {
                int x = 1;
                return Json(new { x = x }, JsonRequestBehavior.AllowGet);
            }
            bool isAuthenticated = _ur.isValidPassword(model.Username, model.Password);
            if (!isAuthenticated)
            {
                int x = 2;
                return Json(new { x = x }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                User user = _ur.GetUserByEmail(model.Username);
                _ur.UpdateLastLogin(user);
                if (model.Isremembered == true)
                {
                    FormsAuthentication.SetAuthCookie(model.Username, true);
                    int x = 3;
                    return Json(new { x = x }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    Session["Email"] = model.Username;
                    Session["Password"] = model.Password;
                    Session["Role"] = user.Role;
                    int x = 4;
                    return Json(new { x = x }, JsonRequestBehavior.AllowGet);
                }
            }
        }


        [HttpPost]
        public ActionResult SignUp(SignUpVM model)
        {
            return View();
        }


        [HttpPost]
        public ActionResult ForgotPassword(ForgotPasswordVM model)
        {
            return View();
        }


        [HttpPost]
        public ActionResult AgentProfile(UserProfile model)
        {
            return View();
        }


        [HttpPost]
        public ActionResult TalentProfile(UserProfile model)
        {
            return View();
        }


        [HttpPost]
        public ActionResult CrewProfile(UserProfile model)
        {
            return View();
        }


        [HttpPost]
        public ActionResult LocationProfile(UserProfile model)
        {
            return View();
        }


        [Authorize(Roles = "Admin, Agency, UWP, UWOP")]
        public ActionResult Logout()
        {
            var authCookie = HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName];
            authCookie.Expires = DateTime.Now.AddDays(-1);
            authCookie.Value = null;
            authCookie = null;
            FormsAuthentication.SignOut();
            Session.RemoveAll();
            return RedirectToAction("Login", "Account");
        }
    }
}