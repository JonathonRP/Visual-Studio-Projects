<%@ Page Title="Sales by Product" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductSales.aspx.cs" Inherits="MGO.Reports.Manager.ProductSalesReport" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row mgo-row">
        <div class="col-sm-12">
            <h1 class="text-center"><%: Title %></h1>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-12">
            <asp:ObjectDataSource ID="ObjectProductsSalesReport" runat="server" SelectMethod="GetProductSalesReport" TypeName="MGO.Models.ProductSalesReport"></asp:ObjectDataSource>
            <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-striped table-condensed" AutoGenerateColumns="False" DataSourceID="ObjectProductsSalesReport" GridLines="None">
                <Columns>
                    <asp:BoundField DataField="Product_Category" HeaderText="Product Category" SortExpression="Product_Category" />
                    <asp:BoundField DataField="Product_Name" HeaderText="Product Name" SortExpression="Product_Name" />
                    <asp:BoundField DataField="Product_Qty_Sold" HeaderText="Quantity Sold" SortExpression="Product_Qty_Sold" />
                    <asp:BoundField DataField="Product_Price" DataFormatString="{0:c}" HeaderText="Product Price" SortExpression="Product_Price" />
                    <asp:BoundField DataField="Sale_Total" DataFormatString="{0:c}" HeaderText="Sale Total" SortExpression="Sale_Total" />
                    <asp:BoundField DataField="Sale_Date" DataFormatString="{0:d}" HeaderText="Sale Date" SortExpression="Sale_Date" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
