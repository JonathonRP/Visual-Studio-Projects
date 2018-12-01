using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XEx09Reservation
{
    public partial class Request : System.Web.UI.Page
    {
        private string currentDate = DateTime.Today.ToShortDateString();
        private string currentYear = DateTime.Today.Year.ToString();
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                // display saved reservation data if there is any
                if (Session["Reservation"] != null)
                {
                    DisplayReservation();
                }
                else  {
                    // otherwise, set default values
                    txtArrivalDate.Text = currentDate;
                    rdoKing.Checked = true;
                }   
            }
        }

        private void DisplayReservation()
        {
            Reservation reservation = (Reservation)Session["Reservation"];

            txtArrivalDate.Text = reservation.ArrivalDate.ToShortDateString();
            txtDepartureDate.Text = reservation.DepartureDate.ToShortDateString();
            ddlNoOfPeople.SelectedValue = reservation.NoOfPeople.ToString();

            if (reservation.BedType == "King")
                rdoKing.Checked = true;
            else if (reservation.BedType == "Two Queens")
                rdoDouble.Checked = true;
            else
                rdoSingle.Checked = true;

            txtSpecialRequests.Text = reservation.SpecialRequests;
            txtFirstName.Text = reservation.FirstName;
            txtLastName.Text = reservation.LastName;
            txtEmail.Text = reservation.Email;
            txtPhone.Text = reservation.Phone;
            ddlPreferredMethod.SelectedValue = reservation.PreferredMethod;
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtArrivalDate.Text = currentDate;
            txtDepartureDate.Text = "";
            ddlNoOfPeople.SelectedIndex = -1;
            rdoKing.Checked = true;
            rdoDouble.Checked = false;
            rdoSingle.Checked = false;
            txtSpecialRequests.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            ddlPreferredMethod.SelectedIndex = 0;
            lblMessage.Text = "";
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                Reservation reservation = new Reservation();

                reservation.ArrivalDate = Convert.ToDateTime(txtArrivalDate.Text);
                reservation.DepartureDate = Convert.ToDateTime(txtDepartureDate.Text);
                TimeSpan tsDays = reservation.DepartureDate - reservation.ArrivalDate;
                int days = tsDays.Days;
                reservation.NoOfDays = days;
                reservation.NoOfPeople = Convert.ToInt32(ddlNoOfPeople.SelectedValue);

                if (rdoKing.Checked)
                    reservation.BedType = "King";
                else if (rdoDouble.Checked)
                    reservation.BedType = "Two Queens";
                else
                    reservation.BedType = "One Queen";

                if (txtSpecialRequests.Text == "")
                    reservation.SpecialRequests = "None.";
                else
                    reservation.SpecialRequests = txtSpecialRequests.Text;

                reservation.FirstName = txtFirstName.Text;
                reservation.LastName = txtLastName.Text;
                reservation.Email = txtEmail.Text;
                reservation.Phone = txtPhone.Text;
                reservation.PreferredMethod = ddlPreferredMethod.SelectedValue;

                Session["Reservation"] = reservation;
                Response.Redirect("Confirm.aspx");
            }
        }
    }
}