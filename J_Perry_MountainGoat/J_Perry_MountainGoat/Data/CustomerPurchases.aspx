<%@ Page Title="Customer Purchases" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerPurchases.aspx.cs" Inherits="MGO.Data.Employee.CustomerPurchases" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <asp:GridView ID="grdviewCustPurch" runat="server" CssClass="table table-bordered table-striped table-condensed" AutoGenerateColumns="False" DataSourceID="ObjectCustomerPurchases" OnPreRender="grdviewCustPurch_PreRender" OnRowDataBound="grd_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="Customer_Name" HeaderText="Customer Name" SortExpression="Customer_Name" />
                    <asp:BoundField DataField="Product_Name" HeaderText="Product Name" SortExpression="Product_Name" />
                    <asp:BoundField DataField="Purchase_Date" HeaderText="Purchase Date" SortExpression="Purchase_Date" />
                    <asp:BoundField DataField="Sale_Total" HeaderText="Sale Total" SortExpression="Sale_Total" />
                    <asp:BoundField DataField="Employee_Name" HeaderText="Employee Name" SortExpression="Employee_Name" />
                </Columns>
                <HeaderStyle CssClass="mgo-grdview-header" />
            </asp:GridView>
            <asp:ObjectDataSource ID="ObjectCustomerPurchases" runat="server" SelectMethod="GetCustomerPurchases" TypeName="MGO.Models.CustomerPurchases"></asp:ObjectDataSource>
        </div>
    </div>
</asp:Content>
