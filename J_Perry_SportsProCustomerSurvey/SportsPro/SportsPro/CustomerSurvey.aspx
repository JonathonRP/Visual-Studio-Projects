<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerSurvey.aspx.cs" Inherits="SportsPro.CustomerSurvey" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="main" ContentPlaceHolderID="mainContent" runat="server">
    <div class="form-group">
        <%--Customer ID textbox and button--%>
        <div class="col-sm-3">Enter your customer ID:</div>
        <div class="col-sm-3">
            <asp:TextBox ID="txtCustomerID" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-sm-6">
            <asp:Button ID="btnGetIncidents" runat="server" CssClass="btn btn-primary" Text="Get Incidents" OnClick="btnGetIncidents_Click" ValidationGroup="getincidents" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Customer ID is Required" ControlToValidate="txtCustomerID" CssClass="text-danger" Display="Dynamic" ValidationGroup="getincidents"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Customer ID must be numeric without decimal places" ControlToValidate="txtCustomerID" CssClass="text-danger" Display="Dynamic" Operator="DataTypeCheck" Type="Integer" ValidationGroup="getincidents"></asp:CompareValidator>
        </div>
    </div>
    <div class="form-group">
        <%--NoIncidents label, Incidents Listbox, SQLDataSource--%>
        <div class="col-sm-10">
            <asp:Label ID="lblNoIncidents" runat="server" EnableViewState="False" CssClass="text-danger"></asp:Label>
            <asp:ListBox ID="lstIncidents" runat="server" Enabled="false" CssClass="form-control"></asp:ListBox>
            
            <asp:SqlDataSource ID="SqlIncidents" runat="server" ConnectionString="<%$ ConnectionStrings:TechSupportConnectionString %>" SelectCommand="SELECT [IncidentID], [CustomerID], [ProductCode], [TechID], [DateOpened], [DateClosed], [Title] FROM [Incidents] ORDER BY [DateClosed]"></asp:SqlDataSource>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-12">
            <label>
                Please rate this incident by the following categories:
            </label>
        </div>
    </div>

    <div class="form-group options">
        <%--Incident rating options (options css class to correct bootstrap radio button display)--%>
        <div class="col-sm-3">Response time:</div>
        <div class="col-sm-9">
            <asp:RadioButtonList ID="rblResponseTime" runat="server" Enabled="false" RepeatDirection="Horizontal">
                <asp:ListItem Value="1">Not satisfied</asp:ListItem>
                <asp:ListItem Value="2">Somewhat satisfied</asp:ListItem>
                <asp:ListItem Value="3">Satisfied</asp:ListItem>
                <asp:ListItem Value="4">Completely satisfied</asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <div class="col-sm-3">Technician efficiency:</div>
        <div class="col-sm-9">
            <asp:RadioButtonList ID="rblEfficiency" runat="server" Enabled="false" RepeatDirection="Horizontal">
                <asp:ListItem Value="1">Not satisfied</asp:ListItem>
                <asp:ListItem Value="2">Somewhat satisfied</asp:ListItem>
                <asp:ListItem Value="3">Satisfied</asp:ListItem>
                <asp:ListItem Value="4">Completely satisfied</asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <div class="col-sm-3">Problem resolution:</div>
        <div class="col-sm-9">
            <asp:RadioButtonList ID="rblResolution" runat="server" Enabled="false" RepeatDirection="Horizontal">
                <asp:ListItem Value="1">Not satisfied</asp:ListItem>
                <asp:ListItem Value="2">Somewhat satisfied</asp:ListItem>
                <asp:ListItem Value="3">Satisfied</asp:ListItem>
                <asp:ListItem Value="4">Completely satisfied</asp:ListItem>
            </asp:RadioButtonList>
        </div>
    </div>

    <div class="form-group">
        <%--Additional comments multi-line textbox--%>
        <div class="col-sm-3">Additional comments:</div>
        <div class="col-sm-7">
            <asp:TextBox ID="txtComments" runat="server" Enabled="False" CssClass="form-control" Rows="4" TextMode="MultiLine"></asp:TextBox>
        </div>
    </div>

    <div class="form-group options">
        <%--Contact options (options css class to correct bootstrap radio button and check box display)--%>
        <div class="col-sm-12">
            <asp:CheckBox ID="chkContact" runat="server" Enabled="false" Text="Please contact me to discuss this incident" />
        </div>
        <div class="col-sm-offset-1 col-sm-11">
            <asp:RadioButton ID="rdoContactByEmail" runat="server" Enabled="false" GroupName="contact" Text="Contact by email" />
            <br />
            <asp:RadioButton ID="rdoContactByPhone" runat="server" Enabled="false" GroupName="contact" Text="Contact by phone" />
        </div>
    </div>

    <div class="form-group">
        <%--Submit button--%>
        <div class="col-sm-3">
            <asp:Button ID="btnSubmit" runat="server" Enabled="false" CssClass="btn btn-primary" Text="Submit" ValidationGroup="submit" OnClick="btnSubmit_Click" />
            <asp:Button ID="btnClear" runat="server" Enabled="false" CausesValidation="false" CssClass="btn btn-primary" Text="Clear" OnClick="btnClear_Click"/>
        </div>
        <div class="col-sm-7">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please select an incident" ControlToValidate="lstIncidents" CssClass="text-danger" Display="Dynamic" ValidationGroup="submit"></asp:RequiredFieldValidator>
            <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Please select either contact by email or by phone" CssClass="text-danger" Display="Dynamic" OnServerValidate="CustomValidator1_ServerValidate" ValidationGroup="submit"></asp:CustomValidator>
        </div>
    </div>

</asp:Content>
