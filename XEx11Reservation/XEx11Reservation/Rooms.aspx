<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Rooms.aspx.cs" Inherits="XEx11Reservation.Rooms" %>

<asp:Content ContentPlaceHolderID="mainPlaceHolder" runat="server">
    <h1>Our Rooms</h1>
    <div class="row">
        <div class="col-sm-6">
            <div class="thumbnail">
                <img src="/Images/room1.jpg" alt="Room 1" />
                <div class="caption text-center">
                    <p><b>The Attic Room</b></p>
                    <p>This is our most adorable room.</p>
                </div>
            </div>
        </div>
        <div class="col-sm-6">
            <div class="thumbnail">
                <img src="/Images/room2.jpg" alt="Room 2" />
                <div class="caption text-center">
                    <p><b>The Hipster Room</b></p>
                    <p>Quilted walls, yo!</p>
                </div>
            </div>
        </div>
        <div class="col-sm-6">
            <div class="thumbnail">
                <img src="/Images/room3.jpg" alt="Room 3" />
                <div class="caption text-center">
                    <p><b>The Honeymoon Suite</b></p>
                    <p>For that romantic getaway.</p>
                </div>
            </div>
        </div>
        <div class="col-sm-6">
            <div class="thumbnail">
                <img src="/Images/room4.jpg" alt="Room 4" />
                <div class="caption text-center">
                    <p><b>The Royal Suite</b></p>
                    <p>Big enough for a coronation.</p>
                </div>
            </div>
        </div>
    </div>
    
</asp:Content>
