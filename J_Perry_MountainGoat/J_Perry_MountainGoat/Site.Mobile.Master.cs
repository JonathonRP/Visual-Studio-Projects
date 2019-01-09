using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;

namespace MGO
{
    public partial class Site_Mobile : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Logout( object sender, EventArgs e )
        {
            Context.GetOwinContext().Authentication.SignOut( DefaultAuthenticationTypes.ApplicationCookie );
            Response.Redirect( "/" );
        }
    }
}