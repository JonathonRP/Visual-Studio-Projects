using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Mvc;

namespace MGO
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            // Load and Register Routes
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            // Load and Register Bundles
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
            // Load and Register Areas
            AreaRegistration.RegisterAllAreas();
            // Load and Register Global Filters
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            // Load and Register Bundles for Razor Pages
            BundleConfig2.RegisterBundles(BundleTable.Bundles);
        }
    }
}
