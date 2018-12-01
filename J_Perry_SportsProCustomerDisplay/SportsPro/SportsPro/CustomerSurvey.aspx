<%@ Page Title="Project 2-A: Survey Customer" Language="C#" AutoEventWireup="true" CodeBehind="CustomerSurvey.aspx.cs" Inherits="SportsPro.CustomerSurvey" MasterPageFile="~/Site.Master" %>

<asp:Content ID="main" runat="server" ContentPlaceHolderID="mainContent">
    <div class="form-group"><%-- Customer ID text box and button --%>
        <div class="col-sm-3">Enter your customer ID:</div>
        <div class="col-sm-3">
            <asp:TextBox ID="txtCustomerID" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-sm-6">
            <asp:Button ID="btnGetIncidents" runat="server" Text="Get Incidents" 
                ValidationGroup="GetIncidents" CssClass="btn btn-primary" OnClick="btnGetIncidents_Click" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCustomerID"
                Display="Dynamic" ErrorMessage="You must enter a customer ID." 
                ValidationGroup="GetIncidents" CssClass="text-danger"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtCustomerID"
                Display="Dynamic" ErrorMessage="Customer ID must be an integer." Operator="DataTypeCheck"
                Type="Integer" ValidationGroup="GetIncidents" CssClass="text-danger"></asp:CompareValidator>
        </div>
    </div>

    <div class="form-group"><%-- Incident list box --%>
        <div class="col-sm-10">
            <asp:Label ID="lblNoIncidents" runat="server" CssClass="text-danger"></asp:Label>
            <asp:ListBox ID="lstIncidents" runat="server" CssClass="form-control" Enabled="False"></asp:ListBox>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TechSupportConnectionString %>" 
                SelectCommand="SELECT [CustomerID], [ProductCode], [DateOpened], [Title], [DateClosed], [TechID], [IncidentID] FROM [Incidents] ORDER BY [DateClosed]">
            </asp:SqlDataSource>
        </div>
    </div>

    <div class="row">
        <div class="col-sm-12"><label>Please rate this incident by the following categories:</label></div>
    </div>

    <div class="form-group options"><%-- Incident rating options (options CSS class to correct Bootstrap radio button display) --%>
        <div class="col-sm-3">Response time:</div>
        <div class="col-sm-9">
            <asp:RadioButtonList ID="rblResponseTime" runat="server" RepeatDirection="Horizontal" Enabled="False">
                <asp:ListItem Value="1">Not satisfied</asp:ListItem>
                <asp:ListItem Value="2">Somewhat satisfied</asp:ListItem>
                <asp:ListItem Value="3">Satisfied</asp:ListItem>
                <asp:ListItem Value="4">Completely satisfied</asp:ListItem>
            </asp:RadioButtonList>
        </div>

        <div class="col-sm-3">Technician efficiency:</div>
        <div class="col-sm-9">
            <asp:RadioButtonList ID="rblEfficiency" runat="server" RepeatDirection="Horizontal" Enabled="False">
                <asp:ListItem Value="1">Not satisfied</asp:ListItem>
                <asp:ListItem Value="2">Somewhat satisfied</asp:ListItem>
                <asp:ListItem Value="3">Satisfied</asp:ListItem>
                <asp:ListItem Value="4">Completely satisfied</asp:ListItem>
            </asp:RadioButtonList>
        </div>

        <div class="col-sm-3">Problem resolution:</div>
        <div class="col-sm-9">
            <asp:RadioButtonList ID="rblResolution" runat="server" RepeatDirection="Horizontal" Enabled="False">
                <asp:ListItem Value="1">Not satisfied</asp:ListItem>
                <asp:ListItem Value="2">Somewhat satisfied</asp:ListItem>
                <asp:ListItem Value="3">Satisfied</asp:ListItem>
                <asp:ListItem Value="4">Completely satisfied</asp:ListItem>
            </asp:RadioButtonList>
        </div>
    </div>

    <div class="form-group"><%-- Additional comments text box --%>
        <div class="col-sm-3">Additional comments:</div>
        <div class="col-sm-7">
            <asp:TextBox ID="txtComments" runat="server" Rows="4" TextMode="MultiLine" CssClass="form-control" Enabled="False"></asp:TextBox>
        </div>
    </div>

    <div class="form-group options"><%-- Contact options (options CSS class to correct Bootstrap radio button and check box display) --%>
        <div class="col-sm-12">
            <asp:CheckBox ID="chkContact" runat="server" Text="Please contact me to discuss this incident" Enabled="False" />
        </div>
        <div class="col-sm-offset-1 col-sm-11">
            <asp:RadioButton ID="rdoContactByEmail" runat="server" GroupName="Contact" Text="Contact by email" Enabled="False" />
            <br />
            <asp:RadioButton ID="rdoContactByPhone" runat="server" GroupName="Contact" Text="Contact by phone" Enabled="False" />
        </div>
    </div>

    <div class="form-group"><%-- Submit button --%>
        <div class="col-sm-3">
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" Enabled="False" 
                ValidationGroup="Submit" CssClass="btn btn-primary" OnClick="btnSubmit_Click" />
        </div>
        <div class="col-sm-7">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ErrorMessage="You must select an incident." ControlToValidate="lstIncidents" Display="Dynamic" ValidationGroup="Submit" CssClass="text-danger"></asp:RequiredFieldValidator>
            <asp:CustomValidator ID="CustomValidator1" runat="server" Display="Dynamic" CssClass="text-danger" ErrorMessage="Please select contact by email or contact by phone." OnServerValidate="CustomValidator1_ServerValidate" ValidationGroup="Submit"></asp:CustomValidator>
        </div>
    </div>
</asp:Content>