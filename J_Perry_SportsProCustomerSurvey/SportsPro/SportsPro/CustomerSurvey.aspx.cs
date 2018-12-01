using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SportsPro
{
    public partial class CustomerSurvey : System.Web.UI.Page
    {
        DataView incidentsTable;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Form.DefaultButton = btnGetIncidents.UniqueID;
                txtCustomerID.Focus();
            }
        }

        protected void btnGetIncidents_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                incidentsTable = (DataView)SqlIncidents.Select(DataSourceSelectArguments.Empty);
                incidentsTable.RowFilter = $"CustomerID = {txtCustomerID.Text} AND DateClosed Is Not Null";

                if (incidentsTable.Count > 0)
                {
                    lstIncidents.Items.Clear();
                    //Call method to display the closed incidents for the customer
                    DisplayClosedIncidents();
                    //Call method to enable all controls on the form
                    EnableControls(true);
                    lstIncidents.Focus();
                    Form.DefaultButton = btnSubmit.UniqueID;
                }
                else
                {
                    lblNoIncidents.Text = "There are no incidents for that customer";
                    //Call method to disable all controls on the form except CustomerID (textbox) and GetIncidents (button)
                    EnableControls(false);
                    txtComments.Focus();
                    Form.DefaultButton = btnGetIncidents.UniqueID;
                }
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect(Page.Request.RawUrl);
        }

        protected void EnableControls(bool enable)
        {
            lstIncidents.Enabled = enable;
            rblResponseTime.Enabled = enable;
            rblEfficiency.Enabled = enable;
            rblResolution.Enabled = enable;
            txtComments.Enabled = enable;
            chkContact.Enabled = enable;
            rdoContactByEmail.Enabled = enable;
            rdoContactByPhone.Enabled = enable;
            btnSubmit.Enabled = enable;
            btnClear.Enabled = enable;
        }

        protected void DisplayClosedIncidents()
        {
            lstIncidents.Items.Add(new ListItem("--Select an incident--", ""));
            foreach (DataRowView row in incidentsTable)
            {
                Incident incident = new Incident();
                incident.IncidentID = Convert.ToInt32(row["IncidentID"]);
                incident.ProductCode = row["ProductCode"].ToString();
                incident.DateClosed = Convert.ToDateTime(row["DateClosed"]);
                incident.Title = row["Title"].ToString();

                lstIncidents.Items.Add(new ListItem(
                    incident.CustomerIncidentDisplay(), incident.IncidentID.ToString()));
            }
            lstIncidents.SelectedIndex = 0;
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (chkContact.Checked)
            {
                if(rdoContactByEmail.Checked || rdoContactByPhone.Checked)
                {
                    args.IsValid = true;
                }
                else
                {
                    args.IsValid = false;
                }
            }
            else
            {
                rdoContactByEmail.Checked = false;
                rdoContactByPhone.Checked = false;
                args.IsValid = true;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                Survey survey = new Survey();
                survey.CustomerID = Convert.ToInt32(txtCustomerID.Text);
                survey.IncidentID = Convert.ToInt32(lstIncidents.SelectedValue);
                if (rblResponseTime.SelectedIndex != -1)
                {
                    survey.ResponseTime = Convert.ToInt32(rblResponseTime.SelectedValue);
                }
                if (rblEfficiency.SelectedIndex != -1)
                {
                    survey.TechEfficiency = Convert.ToInt32(rblEfficiency.SelectedValue);
                }
                if (rblResolution.SelectedIndex != -1)
                {
                    survey.Resolution = Convert.ToInt32(rblResolution.SelectedValue);
                }

                survey.Comments = txtComments.Text;
                if (chkContact.Checked)
                {
                    survey.Contact = true;
                    if (rdoContactByEmail.Checked)
                        survey.ContactBy = "Email";
                    else
                        survey.ContactBy = "Phone";
                }
                else
                {
                    survey.Contact = false;
                }

                Session["Contact"] = survey.Contact;
                Response.Redirect("~/SurveyComplete.aspx");
            }
        }
    }
}