<%@ Page Title="Trend" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Trend.aspx.cs" Inherits="MGO.Reports.Manager.TrendReport" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row mgo-row">
        <div class="col-sm-12">
            <h1 class="text-center"><%: Title %></h1>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-12">
            <asp:ObjectDataSource ID="ObjectTrendsReport" runat="server" SelectMethod="GetTrendReport" TypeName="MGO.Models.TrendReport"></asp:ObjectDataSource>
            <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-striped table-condensed" AutoGenerateColumns="False" DataSourceID="ObjectTrendsReport" GridLines="None">
                <Columns>
                    <asp:BoundField DataField="Product_Category" HeaderText="Product Category" SortExpression="Product_Category" />
                    <asp:BoundField DataField="Category_Sales_TotalRevenue" DataFormatString="{0:c}" HeaderText="Total Revenue" SortExpression="Category_Sales_TotalRevenue" />
                    <asp:BoundField DataField="Category_Sales_Date" DataFormatString="{0:d}" HeaderText="Sales Date" SortExpression="Category_Sales_Date" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
