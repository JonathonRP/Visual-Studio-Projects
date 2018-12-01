<%@ Page Title="Employee Purchases" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeePurchases.aspx.cs" Inherits="MGO.Data.Manager.EmployeePurchases" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <asp:GridView ID="grdviewEmpPurch" runat="server" CssClass="table table-bordered table-striped table-condensed" AutoGenerateColumns="False" DataSourceID="ObjectEmployeePurchases" OnPreRender="grdviewEmpPurch_PreRender" OnRowDataBound="grd_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="Emp_Name" HeaderText="Employee Name" SortExpression="Emp_Name" />
                    <asp:BoundField DataField="Product_Name" HeaderText="Product Name" SortExpression="Product_Name" />
                    <asp:BoundField DataField="Purchase_Date" DataFormatString="{0:d}" HeaderText="Purchase Date" SortExpression="Purchase_Date" />
                    <asp:BoundField DataField="Purchase_Total" DataFormatString="{0:c}" HeaderText="Purchase Total" SortExpression="Purchase_Total" />
                </Columns>
                <HeaderStyle CssClass="mgo-grdview-header" />
            </asp:GridView>
            <asp:ObjectDataSource ID="ObjectEmployeePurchases" runat="server" SelectMethod="GetEmployeePurchases" TypeName="MGO.Models.EmployeePurchases"></asp:ObjectDataSource>
        </div>
    </div>
</asp:Content>
