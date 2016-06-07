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


        public ActionResult AjaxLoginUser(LoginVM model)
        {
            if (!ModelState.IsValid)
            {
                int x = 1;
                return Json(new { x = x }, JsonRequestBehavior.AllowGet);
            }
            bool isAuthenticated = _ur.isValidPassword(model.Email, model.Password);
            if (!isAuthenticated)
            {
                int x = 2;
                return Json(new { x = x }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                User user = _ur.GetUserByEmail(model.Email);
                _ur.UpdateLastLogin(user);
                if (model.Isremembered == true)
                {
                    FormsAuthentication.SetAuthCookie(model.Email, true);
                    int x = 3;
                    return Json(new { x = x }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    Session["Email"] = model.Email;
                    Session["Password"] = model.Password;
                    Session["Role"] = user.Role;
                    int x = 4;
                    return Json(new { x = x }, JsonRequestBehavior.AllowGet);
                }
            }
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