<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="XEx09Reservation.ContactUs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 180px;
            vertical-align: top;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainPlaceHolder" runat="server">
    <h1>
        How to contact us
    </h1>
    <p>
        We welcome your questions and comments.<br />
        please contact us whatever way is most convenient for you.
    </p>
    <table class="auto-style1">
            <tr>
                <td class="auto-style2">Phone:</td>
                <td>1-800-829-2311<br />
                    Available 24 Hours</td>
            </tr>
            <tr>
                <td class="auto-style2">Email:</td>
                <td><a href="mailto:royalinns@royalty.com">royalinns@royalty.com</a></td>
            </tr>
            <tr>
                <td class="auto-style2">Fax:</td>
                <td>1-615-898-1844</td>
            </tr>
            <tr>
                <td class="auto-style2">Address:</td>
                <td>Royal Inns and Suites<br />
                    7211 Atrium Way<br />
                    Nashville, TN 37214</td>
            </tr>
        </table>
</asp:Content>
