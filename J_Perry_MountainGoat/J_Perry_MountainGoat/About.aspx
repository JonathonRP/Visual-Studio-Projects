<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="MGO.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-8">
            <h2><%: Title %>.</h2>
            <h3>Your application description page.</h3>
            <p>Use this area to provide additional information.</p>
        </div>
        <div class="col-md-4">
            <div class="img-responsive img-rounded mgo-lawn-background-img mgo-about-img mgo-about-img" />
        </div>
    </div>
</asp:Content>
