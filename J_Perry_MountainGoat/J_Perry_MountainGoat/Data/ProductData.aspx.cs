using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using MGO.Models;

namespace MGO.Data.Employee
{
    public partial class ProductData : System.Web.UI.Page
    {
        protected enum View
        {
            Form,
            Grid
        }
        protected enum DisplayOptions
        {
            Show,
            Hide
        }

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
        protected void grdviewProducts_PreRender(object sender, EventArgs e)
        {
            grdviewProducts.HeaderRow.TableSection = TableRowSection.TableHeader;
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

        protected void ddlGridItemCatNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            getCat_Descript(sender, "lblGridItemCatDescript", View.Grid);
            DisplayForm();
        }
        protected void ddlFormItemCatNum_PreRender(object sender, EventArgs e)
        {
            getCat_Descript(sender, formView: FrmViewProduct, id: "lblFormItemCatDescript");
        }
        protected void ddlFormItemCatNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            getCat_Descript(sender, formView: FrmViewProduct, id: "lblFormItemCatDescript");
            DisplayForm();
        }
        protected void ddlFormCatNum_PreRender(object sender, EventArgs e)
        {
            getCat_Descript(sender, formView: FrmViewProduct, id: "txtFormCat_Descript");
        }
        protected void ddlFormCatNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            getCat_Descript(sender, formView: FrmViewCategory, id: "txtFormCat_Descript");
            DisplayForm();
        }
        protected void getCat_Descript(object sender, string id, View view = View.Form, FormView formView = null)
        {
            //SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MGOConnectionString"].ConnectionString);
            //connection.Open();
            //string query = $@"Select [Cat_Description]
            //            FROM CATEGORY
            //            WHERE Cat_Num = {Convert.ToInt16((sender as DropDownList).SelectedValue)}";
            //SqlCommand selectCommand = new SqlCommand(query, connection);
            //SqlDataReader sqlData = selectCommand.ExecuteReader();
            //string Cat_Descript = "";

            //while (sqlData.Read())
            //{
            //    Cat_Descript = (string)sqlData["Cat_Description"];
            //}
            //sqlData.Close();
            //connection.Close();

            string Cat_Descript;
            short Cat_Num = Convert.ToInt16((sender as DropDownList).SelectedValue);

            using (var db = new MGO_Entities())
            {
                Cat_Descript = (from category in db.Categories
                               where category.Cat_Num == Cat_Num
                               select category.Cat_Description).SingleOrDefault();
            }

            if (view == View.Form)
            {
                if (formView.CurrentMode == FormViewMode.Insert)
                {
                    (formView.FindControl(id) as Label).Text = Cat_Descript;
                }
                else if (formView.CurrentMode == FormViewMode.Edit)
                {
                    (formView.FindControl(id) as TextBox).Text = Cat_Descript;
                }
            }
            else
            {
                (grdviewProducts.Rows[grdviewProducts.EditIndex].FindControl(id) as Label).Text = Cat_Descript;
            }
        }
        protected void btnFrmViewProducts_Click(object sender, EventArgs e)
        {
            DisplayForm(new FormView[] { FrmViewCategory, FrmViewCategoryDelete }, DisplayOptions.Hide);
        }
        //protected void btnFrmViewCategoriesEdit_Click(object sender, EventArgs e)
        //{
        //    DisplayForm(FrmViewCategoriesDelete, DisplayOptions.Hide);
        //}
        protected void DisplayForm()
        {
            if (FrmViewProduct.CurrentMode == FormViewMode.ReadOnly)
            {
                DisplayForm(new FormView[] { FrmViewCategory, FrmViewCategoryDelete }, DisplayOptions.Show);
            }
            else if (FrmViewProduct.CurrentMode == FormViewMode.Insert)
            {
                DisplayForm(new FormView[] { FrmViewCategory, FrmViewCategoryDelete }, DisplayOptions.Hide);
            }

            //if (FrmViewCategories.CurrentMode == FormViewMode.ReadOnly)
            //{
            //    DisplayForm(FrmViewCategoriesDelete, DisplayOptions.Show);
            //}
            //else if (FrmViewCategories.CurrentMode == FormViewMode.Edit)
            //{
            //    DisplayForm(FrmViewCategoriesDelete, DisplayOptions.Hide);
            //}
        }
        protected void DisplayForm(FormView formView, DisplayOptions display)
        {
            bool displayOption = (display == DisplayOptions.Show) ? true : false;

            if (formView.CurrentMode == FormViewMode.Insert)
            {
                formView.ChangeMode(FormViewMode.ReadOnly);
            }

            formView.EnableViewState = displayOption;
            formView.Visible = displayOption;
        }
        protected void DisplayForm(FormView[] formViews, DisplayOptions display)
        {
            bool displayOption = (display == DisplayOptions.Show) ? true : false;

            foreach (var formView in formViews)
            {
                if (formView.CurrentMode == FormViewMode.Insert)
                {
                    formView.ChangeMode(FormViewMode.ReadOnly);
                }

                formView.EnableViewState = displayOption;
                formView.Visible = displayOption;
            }
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
        protected void FrmViewProduct_ItemInserted(object sender, FormViewInsertedEventArgs e)
        {
            if (e.Exception != null)
            {
                DatabaseErrorMessage = e.Exception.Message;

                lblErrorMessage.Text = DatabaseErrorMessage;
                e.KeepInInsertMode = true;
                e.ExceptionHandled = true;
            }
            else if (e.AffectedRows == 0)
            {
                lblErrorMessage.Text = ConcurrencyErrorMessage;
            }
        }
        protected void FrmViewCategory_CategoryInserted(object sender, FormViewInsertedEventArgs e)
        {
            if (e.Exception != null)
            {
                DatabaseErrorMessage = e.Exception.Message;

                lblErrorMessage.Text = DatabaseErrorMessage;
                e.KeepInInsertMode = true;
                e.ExceptionHandled = true;
            }
            else if (e.AffectedRows == 0)
            {
                lblErrorMessage.Text = ConcurrencyErrorMessage;
            }
        }
        protected void FrmViewCategory_CategoryUpdated(object sender, FormViewUpdatedEventArgs e)
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
        protected void FrmViewCategoryDelete_CategoryDeleted(object sender, FormViewDeletedEventArgs e)
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

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            Int16 SKU = Convert.ToInt16(args.Value);
            bool DoesntExistsInDatabase = false;

            using (var db = new MGO_Entities())
            {
                DoesntExistsInDatabase = (from item in db.Items
                                          where item.SKU == SKU
                                          select item).IsNull();
            }

            args.IsValid = DoesntExistsInDatabase;
            DisplayForm();
        }

        protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string Cat_Description = args.Value;
            bool DoesntExistsInDatabase = false;

            using (var db = new MGO_Entities())
            {
                DoesntExistsInDatabase = (from category in db.Categories
                                          where category.Cat_Description == Cat_Description
                                          select category).IsNull();
            }

            args.IsValid = DoesntExistsInDatabase;
        }

        protected void CustomValidator3_ServerValidate(object source, ServerValidateEventArgs args)
        {
            Int16 Cat_Num = Convert.ToInt16(args.Value);
            bool DoesntExistsInDatabase = false;

            using (var db = new MGO_Entities())
            {
                DoesntExistsInDatabase = (from category in db.Categories
                                          where category.Cat_Num == Cat_Num
                                          select category).IsNull();
            }

            args.IsValid = DoesntExistsInDatabase;
        }
    }
}