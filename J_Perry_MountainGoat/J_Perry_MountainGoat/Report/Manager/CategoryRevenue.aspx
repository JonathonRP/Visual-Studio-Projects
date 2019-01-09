<%@ Page Title="Revenue by Category" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CategoryRevenue.aspx.cs" Inherits="MGO.Reports.Manager.RevenueCategoriesReport" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row mgo-row">
        <div class="col-sm-12">
            <h1 class="text-center"><%: Title %></h1>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-12">
            <asp:ObjectDataSource ID="ObjectRevenuesCategoriesReport" runat="server" SelectMethod="GetRevenueCategoriesReport" TypeName="MGO.Models.RevenueCategoriesReport"></asp:ObjectDataSource>
            <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-striped table-condensed" AutoGenerateColumns="False" DataSourceID="ObjectRevenuesCategoriesReport" GridLines="None">
                <Columns>
                    <asp:BoundField DataField="Product_Category" HeaderText="Product Category" SortExpression="Product_Category" />
                    <asp:BoundField DataField="Product_Name" HeaderText="Product Name" SortExpression="Product_Name" />
                    <asp:BoundField DataField="Category_Qty_Sold" HeaderText="Quantity Sold" SortExpression="Category_Qty_Sold" />
                    <asp:BoundField DataField="Category_Sales_Revenue" DataFormatString="{0:c}" HeaderText="Category Sales Revenue" SortExpression="Category_Sales_Revenue" />
                    <asp:BoundField DataField="Category_Sales_TotalRevenue" DataFormatString="{0:c}" HeaderText="Total Revenue" SortExpression="Category_Sales_TotalRevenue" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
