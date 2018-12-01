<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Confirm.aspx.cs" Inherits="XEx11Reservation.Confirm" 
    MasterPageFile="~/Site.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="mainPlaceHolder">
    <h1>Request Confirmation</h1>
    <div class="row">
        <div class="col-sm-offset-1 col-sm-5">
            <h3>Personal data</h3>
            <table class="table table-bordered table-condensed">
                <tbody>
                    <tr>
                        <td><label>First name</label></td>
                        <td><asp:Label ID="lblFirstName" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><label>Last name</label></td>
                        <td><asp:Label ID="lblLastName" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><label>Email</label></td>
                        <td><asp:Label ID="lblEmail" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><label>Phone</label></td>
                        <td><asp:Label ID="lblPhone" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><label>Preferred method</label></td>
                        <td><asp:Label ID="lblPreferredMethod" runat="server"></asp:Label></td>
                    </tr>
                </tbody>
            </table>
        </div>

        <div class="col-sm-5">
            <h3>Reservation data</h3>
            <table class="table table-bordered table-condensed">
                <tbody>
                    <tr>
                        <td><label>Arrival date:</label></td>
                        <td><asp:Label ID="lblArrivalDate" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><label>Departure date</label></td>
                        <td><asp:Label ID="lblDepartureDate" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><label>No. of days</label></td>
                        <td><asp:Label ID="lblNoOfDays" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><label>No. of people</label></td>
                        <td><asp:Label ID="lblNoOfPeople" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><label>Bed type</label></td>
                        <td><asp:Label ID="lblBedType" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><label>Special requests</label></td>
                        <td><asp:Label ID="lblSpecialRequests" runat="server"></asp:Label></td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>

    <!-- buttons -->
    <div class="form-group">
        <div class="col-sm-12">
            <asp:Button ID="btnConfirm" runat="server" Text="Confirm Request" 
                CssClass="btn btn-primary" OnClick="btnConfirm_Click" />
            <asp:Button ID="btnModify" runat="server" Text="Modify Request" 
                CssClass="btn btn-primary" PostBackUrl="~/Request" />
        </div>
    </div>

    <!-- message label -->
    <div class="form-group">
        <div class="col-sm-12">
            <asp:Label ID="lblMessage" runat="server" CssClass="text-info"></asp:Label>
        </div>
    </div>
</asp:Content>
