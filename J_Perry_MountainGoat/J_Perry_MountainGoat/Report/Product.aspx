<%@ Page Title="Products" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="MGO.Reports.ProductReport" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row mgo-row">
        <div class="col-sm-12">
            <h1 class="text-center"><%: Title %></h1>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-12">
            <asp:ObjectDataSource ID="ObjectProductsReport" runat="server" SelectMethod="GetProductReport" TypeName="MGO.Models.ProductReport"></asp:ObjectDataSource>
            <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-striped table-condensed" AutoGenerateColumns="False" DataSourceID="ObjectProductsReport" GridLines="None">
                <Columns>
                    <asp:BoundField DataField="Product_Category" HeaderText="Product Category" SortExpression="Product_Category" />
                    <asp:BoundField DataField="Product_Name" HeaderText="Product Name" SortExpression="Product_Name" />
                    <asp:BoundField DataField="Product_Price" DataFormatString="{0:c}" HeaderText="Product Price" SortExpression="Product_Price" />
                </Columns>
            </asp:GridView>

        </div>
    </div>
</asp:Content>
