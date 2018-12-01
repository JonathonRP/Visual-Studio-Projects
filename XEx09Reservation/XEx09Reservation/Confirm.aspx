<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Confirm.aspx.cs" MasterPageFile="~/Site.Master" Inherits="XEx09Reservation.Confirm" %>
 <asp:Content runat="server" ContentPlaceHolderID="head">
     <link href="Content/confirm.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainPlaceHolder" runat="server">
                <h1>Request Confirmation</h1>
                <h3>Please confirm your reservation request</h3>
                <div class="row">
                    <div class="col-sm-3"><label>First name</label></div>
                    <div class="col-sm-9">
                        <asp:Label ID="lblFirstName" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-3"><label>Last name</label></div>
                    <div class="col-sm-9">
                        <asp:Label ID="lblLastName" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-3"><label>Email</label></div>
                    <div class="col-sm-9">
                        <asp:Label ID="lblEmail" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-3"><label>Phone</label></div>
                    <div class="col-sm-9">
                        <asp:Label ID="lblPhone" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-3"><label>Preferred method</label></div>
                    <div class="col-sm-9">
                        <asp:Label ID="lblPreferredMethod" runat="server"></asp:Label>
                    </div>
                </div>

                <h3>Request data</h3>
                <div class="row">
                    <div class="col-sm-3"><label>Arrival date:</label></div>
                    <div class="col-sm-9">
                        <asp:Label ID="lblArrivalDate" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-3"><label>Departure date</label></div>
                    <div class="col-sm-9">
                        <asp:Label ID="lblDepartureDate" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-3"><label>No. of days</label></div>
                    <div class="col-sm-9">
                        <asp:Label ID="lblNoOfDays" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-3"><label>No. of people</label></div>
                    <div class="col-sm-9">
                        <asp:Label ID="lblNoOfPeople" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-3"><label>Bed type</label></div>
                    <div class="col-sm-9">
                        <asp:Label ID="lblBedType" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-3"><label>Special requests</label></div>
                    <div class="col-sm-9">
                        <asp:Label ID="lblSpecialRequests" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-12">&nbsp;</div>
                </div>

                <!-- buttons -->
                <div class="form-group">
                    <div class="col-sm-12">
                        <asp:Button ID="btnConfirm" runat="server" Text="Confirm Request" 
                            CssClass="btn btn-primary" OnClick="btnConfirm_Click" />
                        <asp:Button ID="btnModify" runat="server" Text="Modify Request" 
                            CssClass="btn btn-primary" PostBackUrl="~/Request.aspx" />
                    </div>
                </div>

                <!-- message label -->
                <div class="form-group">
                    <div class="col-sm-12">
                        <asp:Label ID="lblMessage" runat="server" CssClass="text-info"></asp:Label>
                    </div>
                </div>


    </asp:Content>                