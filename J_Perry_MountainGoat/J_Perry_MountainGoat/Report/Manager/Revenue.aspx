﻿<%@ Page Title="Revenue" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Revenue.aspx.cs" Inherits="MGO.Reports.Manager.RevenueReport" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row mgo-row">
        <div class="col-sm-12">
            <h1 class="text-center"><%: Title %></h1>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-12">
            <asp:ObjectDataSource ID="ObjectRevenuesReport" runat="server" SelectMethod="GetRevenueReport" TypeName="MGO.Models.RevenueReport"></asp:ObjectDataSource>
            <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-striped table-responsive table-condensed" AutoGenerateColumns="False" DataSourceID="ObjectRevenuesReport" GridLines="None">
                <Columns>
                    <asp:BoundField DataField="Product_Category" HeaderText="Product Category" SortExpression="Product_Category" />
                    <asp:BoundField DataField="Product_Name" HeaderText="Product Name" SortExpression="Product_Name" />
                    <asp:BoundField DataField="Product_Qty_Sold" HeaderText="Quantity Sold" SortExpression="Product_Qty_Sold" />
                    <asp:BoundField DataField="Product_Sales_Revenue" DataFormatString="{0:c}" HeaderText="Product Sales Revenue" SortExpression="Product_Sales_Revenue" />
                    <asp:BoundField DataField="Product_Sales_TotalRevenue" DataFormatString="{0:c}" HeaderText="Total Revenue" SortExpression="Product_Sales_TotalRevenue" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
