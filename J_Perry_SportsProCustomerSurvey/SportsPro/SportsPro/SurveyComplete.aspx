<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SurveyComplete.aspx.cs" Inherits="SportsPro.SurveyComplete" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <div class="row">
        <div class="col-sm-offset-1 col-sm-10">
            <asp:Label ID="lblMessage" runat="server" CssClass="text-info"></asp:Label>
        </div>
    </div>

    <div class="row">
        <div class="col-sm-offset-1 col-sm-10">
            <asp:Button ID="btnReturn" runat="server" CssClass="btn btn-primary" Text="Return to Survey" PostBackUrl="~/CustomerSurvey.aspx" />
        </div>
    </div>
</asp:Content>
