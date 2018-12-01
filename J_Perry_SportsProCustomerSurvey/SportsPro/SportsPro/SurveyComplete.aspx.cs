using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SportsPro
{
    public partial class SurveyComplete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool contact = (bool)Session["Contact"];
            lblMessage.Text = "<h4>Thank you for your feedback!</h4>";
            if (contact)
            {
                lblMessage.Text += "<p>A customer service representative " +
                    "will contact you within 24 hours.</p>";
            }
        }
    }
}