<%@ Page Title="Sales by Employee" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeeSales.aspx.cs" Inherits="MGO.Reports.Manager.EmployeeSalesReport" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row mgo-row">
        <div class="col-sm-12">
            <h1 class="text-center"><%: Title %></h1>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-12">
            <asp:ObjectDataSource ID="ObjectEmployeesSalesReport" runat="server" SelectMethod="GetEmployeeSalesReport" TypeName="MGO.Models.EmployeeSalesReport"></asp:ObjectDataSource>
            <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-striped table-condensed" AutoGenerateColumns="False" DataSourceID="ObjectEmployeesSalesReport" GridLines="None">
                <Columns>
                    <asp:BoundField DataField="Employee_Name" HeaderText="Employee Name" SortExpression="Employee_Name" />
                    <asp:BoundField DataField="Employee_Commission" DataFormatString="{0:c}" HeaderText="Employee Commission" SortExpression="Employee_Commission" />
                    <asp:BoundField DataField="Sale_Total" DataFormatString="{0:c}" HeaderText="Sale Total" SortExpression="Sale_Total" />
                    <asp:BoundField DataField="Sale_Date" DataFormatString="{0:d}" HeaderText="Sale Date" SortExpression="Sale_Date" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
