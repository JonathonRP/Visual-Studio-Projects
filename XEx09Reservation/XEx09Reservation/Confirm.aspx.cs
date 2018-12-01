using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XEx09Reservation
{
    public partial class Confirm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DisplayReservation();
        }

        private void DisplayReservation()
        {
            Reservation reservation = (Reservation)Session["Reservation"];

            lblArrivalDate.Text = reservation.ArrivalDate.ToShortDateString();
            lblDepartureDate.Text = reservation.DepartureDate.ToShortDateString();
            lblNoOfDays.Text = reservation.NoOfDays.ToString();
            lblNoOfPeople.Text = reservation.NoOfPeople.ToString();
            lblBedType.Text = reservation.BedType;
            lblSpecialRequests.Text = reservation.SpecialRequests;
            lblFirstName.Text = reservation.FirstName;
            lblLastName.Text = reservation.LastName;
            lblEmail.Text = reservation.Email;
            lblPhone.Text = reservation.Phone;
            lblPreferredMethod.Text = reservation.PreferredMethod;
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "Thank you for your request.<br />" +
                              "We will get back to you within 24 hours.";
        }
    }
}