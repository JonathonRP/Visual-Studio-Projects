<%@ Page Title="Project 1-B: Create Contact List" Language="C#" AutoEventWireup="true" CodeBehind="ContactDisplay.aspx.cs" Inherits="SportsPro.ContactDisplay" MasterPageFile="~/Site.Master" %>

<asp:Content ID="main" runat="server" ContentPlaceHolderID="mainContent">
    <div class="row">
        <div class="col-sm-offset-1 col-sm-7">Contact list:</div>
    </div>

    <div class="row">
        <div class="col-sm-offset-1 col-sm-7">
            <asp:ListBox ID="lstContacts" runat="server" CssClass="form-control"></asp:ListBox>
        </div>
        <div class="col-sm-3">
            <asp:Button ID="btnRemove" runat="server" Text="Remove Contact" 
                CssClass="btn btn-primary" OnClick="btnRemove_Click" />
            <asp:Button ID="btnEmpty" runat="server" Text="Empty List" 
                CssClass="btn btn-primary" OnClick="btnEmpty_Click" />
        </div>
    </div>

    <div class="row">
        <div class="col-sm-offset-1 col-sm-7">
            <asp:Button ID="btnSelect" runat="server" Text="Select Additional Customers" 
                PostBackUrl="~/Administration/CustomerDisplay.aspx" CssClass="btn btn-primary" />
        </div>
    </div>
</asp:Content>