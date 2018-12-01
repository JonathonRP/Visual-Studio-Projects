using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

using Microsoft.AspNet.FriendlyUrls.Resolvers;

namespace SportsPro
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Temporary;
            routes.EnableFriendlyUrls(settings, new MyUrlResolver());

            //map custom customer support static routes
            routes.MapPageRoute("RegProducts", "CustomerSupport/ProductRegistration", "~/ProductRegistration.aspx");
            routes.MapPageRoute("CustSurvey", "CustomerSupport/CustomerSurvey", "~/CustomerSurvey.aspx");
            routes.MapPageRoute("SurveyDone", "CustomerSupport/SurveyComplete", "~/SurveyComplete.aspx");

            //map custom tech support static routes
            routes.MapPageRoute("CustIncidents", "TechSupport/CustomerIncidentDisplay", "~/CustomerIncidentDisplay.aspx");
            routes.MapPageRoute("UpdateIncident", "TechSupport/IncidentUpdate", "~/IncidentUpdate.aspx");

        }
    }

    public class MyUrlResolver : WebFormsFriendlyUrlResolver
    {
        protected override bool IsMobileExtension(HttpContextBase httpContext, string extension)
        {
            return false;
        }


        public override string ConvertToFriendlyUrl(string path)
        {
            if(path.Contains("ProductRegistration") ||
                path.Contains("CustomerSurvey") ||
                path.Contains("SurveyComplete"))
            {
                return "~/CustomerSupport" + path.Replace(".aspx", "");
            }
            else if(path.Contains("CustomerIncidentDisplay") ||
                path.Contains("IncidentUpdate"))
            {
                return "~/TechSupport" + path.Replace(".aspx", "");
            }
            return base.ConvertToFriendlyUrl(path);
        }


    }


}
