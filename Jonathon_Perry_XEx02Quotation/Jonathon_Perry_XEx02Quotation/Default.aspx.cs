using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Jonathon_Perry_XEx02Quotation
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            if (!IsPostBack)
            {
                SetDefaults();
            }
        }

        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            var salesprice = Convert.ToDouble(txtSalesPrice.Text);
            var discountPercent = Convert.ToDouble(txtDiscountPercent.Text);

            if (IsValid)
            {
                lblDiscountAmount.Text =
                    $"{CalculateDiscount(salesprice, discountPercent):C}";
                lblTotalPrice.Text =
                    $"{CalculateTotalPrice(salesprice, discountPercent):C}";
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            SetDefaults();
        }

        protected void SetDefaults()
        {
            txtSalesPrice.Text = "";
            txtDiscountPercent.Text = "20";
        }

        protected double CalculateDiscount(double salesPrice, double discountPercent)
        {
            return salesPrice * (discountPercent / 100);
        }

        protected double CalculateTotalPrice(double salesPrice, double discountPercent)
        {
            
            return salesPrice - CalculateDiscount(salesPrice, discountPercent);
        }
    }
}