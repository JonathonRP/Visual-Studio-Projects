using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ex02FutureValue
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //turn off unobtrusive validation
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;


            //populate the dropdown list with numbers from 50 to 500 in increments of 50
            if(!IsPostBack)
            {
                for(int i = 50; i <=500; i += 50)
                {
                    ddlMonthlyInvestment.Items.Add($"{i}");
                }
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ddlMonthlyInvestment.SelectedIndex = 0;
            txtInterestRate.Text = "";
            txtYears.Text = "";
            lblFutureValue.Text = "";
        }

        //method for calculating the future value
        protected decimal CalculateFutureValue(int monthlyInvestment,
                          decimal yearlyInterestRate, int years)
        {
            int months = years * 12;
            decimal monthlyInterestRate = yearlyInterestRate / 12 / 100;
            decimal futureValue = 0;
            for (int i = 0; i < months; i++)
            {
                futureValue = (futureValue + monthlyInvestment) *
                              (1 + monthlyInterestRate);
            }
            return futureValue;
        }

        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            if(IsValid)
            {
                lblFutureValue.Text = $@"{CalculateFutureValue(Convert.ToInt32(ddlMonthlyInvestment.SelectedValue), 
                    Convert.ToDecimal(txtInterestRate.Text), Convert.ToInt32(txtYears.Text)):C}";
            }
        }
    }
}