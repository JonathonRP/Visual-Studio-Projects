<%@ Page Title="Project 1-A: Display Customers" Language="C#" AutoEventWireup="true" CodeBehind="CustomerDisplay.aspx.cs" Inherits="SportsPro.CustomerDisplay" MasterPageFile="~/Site.Master" %>

<asp:Content ID="main" runat="server" ContentPlaceHolderID="mainContent">
    <div class="row">
        <div class="col-sm-offset-1 col-sm-3">Select a customer:</div>
        <div class="col-sm-6">
            <asp:DropDownList ID="ddlCustomers" runat="server" DataSourceID="SqlDataSource1"
                DataTextField="Name" DataValueField="CustomerID" AutoPostBack="True" CssClass="form-control">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:TechSupportConnectionString %>" 
                SelectCommand="SELECT * FROM [Customers] ORDER BY [Name]">
            </asp:SqlDataSource>
        </div>
    </div>

    <div class="row">
        <div class="col-sm-offset-1 col-sm-3">Address:</div>
        <div class="col-sm-6"><asp:Label ID="lblAddress" runat="server"></asp:Label></div>
    </div>
    <div class="row">
        <div class="col-sm-offset-1 col-sm-3">&nbsp;</div>
        <div class="col-sm-6"><asp:Label ID="lblCityStateZip" runat="server"></asp:Label></div>
    </div>
    <div class="row">
        <div class="col-sm-offset-1 col-sm-3">Phone:</div>
        <div class="col-sm-6"><asp:Label ID="lblPhone" runat="server"></asp:Label></div>
    </div>
    <div class="row">
        <div class="col-sm-offset-1 col-sm-3">Email:</div>
        <div class="col-sm-6"><asp:Label ID="lblEmail" runat="server"></asp:Label></div>
    </div>

    <br />

    <div class="row">
        <div class="col-sm-offset-1 col-sm-10">
            <asp:Button ID="btnAdd" runat="server" Text="Add to Contact List" 
                CssClass="btn btn-primary" OnClick="btnAdd_Click" />
            <asp:Button ID="btnDisplay" runat="server" Text="Display Contact List" 
                PostBackUrl="~/Administration/ContactDisplay.aspx" CssClass="btn btn-primary" />
        </div>
    </div>

    <div class="row">
        <div class="col-sm-offset-1 col-sm-10"><asp:Label ID="lblErrorMessage" runat="server" 
            CssClass="text-danger" EnableViewState="false"></asp:Label>
        </div>
    </div>
</asp:Content>