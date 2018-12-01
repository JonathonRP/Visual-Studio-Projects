using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using Microsoft.AspNet.FriendlyUrls;
using Microsoft.AspNet.FriendlyUrls.Resolvers;

namespace XEx11Reservation
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Temporary;
            routes.EnableFriendlyUrls(settings, new UrlResolver());

            routes.MapPageRoute("History", "AboutUs/History", "~/History.aspx");
            routes.MapPageRoute("Directions", "AboutUs/Directions", "~/Directions.aspx");
        }
    }

    class UrlResolver : WebFormsFriendlyUrlResolver
    {
        protected override bool TrySetMobileMasterPage(HttpContextBase httpContext, Page page, string mobileSuffix)
        {
            return false;
        }

        public override string ConvertToFriendlyUrl(string path)
        {
            if (path.Contains("History") || path.Contains("Directions"))
            {
                return "~/AboutUs" + path.Replace(".aspx", "");
            }

            return base.ConvertToFriendlyUrl(path);
        }
    }
}
