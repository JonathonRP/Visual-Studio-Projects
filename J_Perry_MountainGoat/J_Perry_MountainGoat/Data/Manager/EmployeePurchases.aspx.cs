using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MGO.Data.Manager
{
    public partial class EmployeePurchases : System.Web.UI.Page
    {
        private static string error;

        private static string DatabaseErrorMessage
        {
            get
            {
                return $"A database error has occurred. Message: {error}";
            }
            set
            {
                error = value;
            }
        }

        private static string ConcurrencyErrorMessage
        {
            get
            {
                return "Another user may have updated this product.  Please try again or contact Tech Support at ext. 2544.";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void grdviewEmpPurch_PreRender(object sender, EventArgs e)
        {
            grdviewEmpPurch.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                foreach (DataControlFieldCell cell in e.Row.Cells)
                {
                    foreach (LinkButton control in cell.Controls.OfType<LinkButton>())
                    {
                        if (control != null && control.CommandName == "Delete")
                        {
                            control.OnClientClick = "return confirm('Are you sure you want to delete?');";
                        }
                    }
                }
            }
        }
    }
}