using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using CastingStars.Helpers;

namespace CastingStars
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "login",
                url: "{culture}/login",
                defaults: new { culture = CultureHelper.GetDefaultCulture(), controller = "Account", action = "Login", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "signup",
                url: "{culture}/signup",
                defaults: new { culture = CultureHelper.GetDefaultCulture(), controller = "Account", action = "SignUp", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "forgotpassword",
                url: "{culture}/forgotpassword",
                defaults: new { culture = CultureHelper.GetDefaultCulture(), controller = "Account", action = "ForgotPassword", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "agentprofile",
                url: "{culture}/agentprofile",
                defaults: new { culture = CultureHelper.GetDefaultCulture(), controller = "Account", action = "AgentProfile", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "talentprofile",
                url: "{culture}/talentprofile",
                defaults: new { culture = CultureHelper.GetDefaultCulture(), controller = "Account", action = "TalentProfile", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "crewprofile",
                url: "{culture}/crewprofile",
                defaults: new { culture = CultureHelper.GetDefaultCulture(), controller = "Account", action = "CrewProfile", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "locationprofile",
                url: "{culture}/locationprofile",
                defaults: new { culture = CultureHelper.GetDefaultCulture(), controller = "Account", action = "LocationProfile", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "agentdashboard",
                url: "{culture}/agentdashboard",
                defaults: new { culture = CultureHelper.GetDefaultCulture(), controller = "Account", action = "AgentDashboard", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{culture}/{controller}/{action}/{id}",
                defaults: new { culture = CultureHelper.GetDefaultCulture(), controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
