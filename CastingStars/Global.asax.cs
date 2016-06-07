using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Security.Claims;
using System.Web.Security;
using CastingStars.Repository;
using CastingStars.Models;

namespace CastingStars
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                try
                {
                    var ticket = FormsAuthentication.Decrypt(authCookie.Value);
                    FormsIdentity formsIdentity = new FormsIdentity(ticket);
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(formsIdentity);
                    UserRepository repo = new UserRepository();
                    User user = repo.GetUserByEmail(ticket.Name);
                    claimsIdentity.AddClaim(
                            new Claim(ClaimTypes.Role, user.Role));
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    HttpContext.Current.User = claimsPrincipal;
                }
                catch
                {
                }
            }
        }
    }
}
