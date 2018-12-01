using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

namespace SportsPro
{
    public partial class CustomerDisplay : System.Web.UI.Page
    {
        private Customer selectedCustomer;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlCustomers.DataBind();
            }
            selectedCustomer = GetselectedCustomer();
            DisplayCustomer();
        }

        private Customer GetselectedCustomer()
        {
            DataView customerTable = (DataView)
                SqlDataSource1.Select(DataSourceSelectArguments.Empty);
            customerTable.RowFilter = "CustomerID = " + ddlCustomers.SelectedValue;
            DataRowView row = customerTable[0];

            Customer customer = new Customer();
            customer.CustomerID = Convert.ToInt32(row["CustomerID"]);
            customer.Name = row["Name"].ToString();
            customer.Address = row["Address"].ToString();
            customer.City = row["City"].ToString();
            customer.State = row["State"].ToString();
            customer.ZipCode = row["ZipCode"].ToString();
            customer.Phone = row["Phone"].ToString();
            customer.Email = row["Email"].ToString();
            return customer;
        }

        private void DisplayCustomer()
        {
            lblAddress.Text = selectedCustomer.Address;
            lblCityStateZip.Text = selectedCustomer.City + ", "
                                 + selectedCustomer.State + " "
                                 + selectedCustomer.ZipCode;
            lblPhone.Text = selectedCustomer.Phone;
            lblEmail.Text = selectedCustomer.Email;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            CustomerList contacts = CustomerList.GetCustomers();
            Customer customer = contacts[selectedCustomer.Name];
            if (customer == null)
            {
                contacts.AddItem(selectedCustomer);
                Response.Redirect("ContactDisplay");
            }
            else
            {
                lblErrorMessage.Text = "This customer is already in the contact list.";
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlDataSource1.UpdateParameters["Email"].DefaultValue = txtEmail.Text;

            foreach(Parameter param in SqlDataSource1.UpdateParameters)
            {
                if (param.Name == "CustomerID")
                {
                    param.DefaultValue = selectedCustomer.CustomerID.ToString();
                }
                if (param.Name == "Name")
                {
                    param.DefaultValue = selectedCustomer.Name;
                }
                if (param.Name == "Address")
                {
                    param.DefaultValue = selectedCustomer.Address;
                }
                if (param.Name == "City")
                {
                    param.DefaultValue = selectedCustomer.City;
                }
                if (param.Name == "State")
                {
                    param.DefaultValue = selectedCustomer.State;
                }
                if (param.Name == "ZipCode")
                {
                    param.DefaultValue = selectedCustomer.ZipCode;
                }
                if (param.Name == "Phone")
                {
                    param.DefaultValue = selectedCustomer.Phone;
                }
            }

            try
            {
                SqlDataSource1.Update();
                ddlCustomers.DataBind();
                selectedCustomer = GetselectedCustomer();
                DisplayCustomer();
                lblErrorMessage.Text = "Customer email updated successfully";
                txtEmail.Text = "";
            }
            catch (Exception except)
            {
                lblErrorMessage.Text = $"Error occurred {except.Message}";
            }
        }
    }
}