using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Payroll
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Turn off Unobtrusive validation
            UnobtrusiveValidationMode =
                System.Web.UI.UnobtrusiveValidationMode.None;

            //Do this only on first load
            if (!IsPostBack)
            {
                txtHours.Text = "40";
            }
        }

        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // Using the values from the textboxes, calculate the gross pay 
                // Remember to convert textbox values to the appropriate data type
                // Display the gross pay in the label

                double hoursWorked = Convert.ToDouble(txtHours.Text);
                double payRate = Convert.ToDouble(txtPayRate.Text);

                lblGrossPay.Text = $"{CalculateGrossPay(hoursWorked, payRate):C}";
            }
        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            txtHours.Text = "40";
            txtPayRate.Text = "";
        }

        //calculate gross pay
        protected double CalculateGrossPay(double hours, double pay)
        {
            return hours * pay;
        }
    }
}