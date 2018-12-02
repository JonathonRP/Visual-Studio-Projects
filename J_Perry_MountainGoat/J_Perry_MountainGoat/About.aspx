<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="MGO.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-8">
            <h2><%: Title %>.</h2>
            <h3>Mountain Goat Outfitters Application Description Page.</h3>
            <p style="padding-top: 1.8rem; font-size: 1.8rem; text-align:center;">
                This is an Application used mainly by MGO employees and managers to 
                maintain and store data on the store customers, employees and products.
            </p>
            <p style="font-size: 1.7rem; text-align:center;">
                Customers can access this page and home page. 
                <p style="font-size: 1.7rem; text-align:center;">
                Managers and employees must contact system admin to get their privilages enabled.
                </p>
            </p>
            <p style="padding-top: 1.8rem; font-size: 1.5rem; text-align:center;">
                Dr. Melinda Korzaan: please create login with melinda.korzaan@mtsu.edu as your email.
                <% if (Page.User.IsInRole("teacher"))
                    { %>
                <p style="padding-top: 1.8rem; color:green; text-align:center;">Employee login: "jreesep@mtsu.edu", "Reese93!"</p>
                <p style="color:green; text-align:center;">Manager login: "manager1@mountaingoatoutfitters.com", "#1Manager!"</p>
                <% } %>
            </p>
        </div>
        <div class="col-md-4">
            <div class="img-responsive img-rounded mgo-lawn-background-img mgo-about-img mgo-about-img" />
        </div>
    </div>
</asp:Content>
