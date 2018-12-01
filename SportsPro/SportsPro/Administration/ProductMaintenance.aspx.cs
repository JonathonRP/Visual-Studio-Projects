using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SportsPro.Administration
{
    public partial class ProductMaintenance : System.Web.UI.Page
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

        protected void grdProducts_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            if (e.Exception != null)
            {
                DatabaseErrorMessage = e.Exception.Message;

                lblErrorMessage.Text = DatabaseErrorMessage;
                e.ExceptionHandled = true;
            }
            else if (e.AffectedRows == 0)
            {
                lblErrorMessage.Text = ConcurrencyErrorMessage;
            }

        }

        protected void grdProducts_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            if (e.Exception != null)
            {
                DatabaseErrorMessage = e.Exception.Message;

                lblErrorMessage.Text = DatabaseErrorMessage;
                e.KeepInEditMode = true;
                e.ExceptionHandled = true;
            }
            else if (e.AffectedRows == 0)
            {
                lblErrorMessage.Text = ConcurrencyErrorMessage;
            }
        }

        protected void grdProducts_PreRender(object sender, EventArgs e)
        {
            grdProducts.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Control mainContent = Form.FindControl("mainContent");
            IEnumerable<TextBox> NewProductInsertForm = mainContent.Controls.OfType<TextBox>();

            if(IsValid)
            {
                foreach (Parameter param in SqlProducts.InsertParameters)
                {
                    foreach (TextBox input in NewProductInsertForm)
                    {
                        if (input.ID == $"txt{param.Name}")
                        {
                            param.DefaultValue = input.Text;
                        }
                    }
                }

                try
                {
                    SqlProducts.Insert();

                    foreach (TextBox input in NewProductInsertForm)
                    {
                        if (input.ID != txtReleaseDate.ID)
                        {
                            input.Text = "";
                        }
                    }

                    txtReleaseDate.Text = "mm/dd/yyyy";
                    lblErrorMessage.Text = "Product was added successfully";
                }
                catch (Exception ex)
                {
                    DatabaseErrorMessage = ex.Message;
                    lblErrorMessage.Text = DatabaseErrorMessage;
                }
            }
        }
    }
}