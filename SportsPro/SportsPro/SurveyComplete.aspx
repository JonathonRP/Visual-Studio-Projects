<%@ Page Title="Project 2-A: Survey Customer" Language="C#" AutoEventWireup="true" CodeBehind="SurveyComplete.aspx.cs" Inherits="SportsPro.SurveyComplete" MasterPageFile="~/Site.Master" %>

<asp:Content ID="main" runat="server" ContentPlaceHolderID="mainContent">
    <div class="row">
        <div class="col-sm-offset-1 col-sm-10">
            <asp:Label ID="lblMessage" runat="server" CssClass="text-info"></asp:Label>
        </div>
    </div>

    <div class="row">
        <div class="col-sm-offset-1 col-sm-10">
            <asp:Button ID="btnReturn" runat="server" Text="Return to Survey" 
                PostBackUrl="~/CustomerSurvey.aspx" CssClass="btn btn-primary" />
        </div>
    </div>
</asp:Content>