<%@ Page Title="Employees" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Employee.aspx.cs" Inherits="MGO.Reports.Manager.EmployeeReport" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row mgo-row">
        <div class="col-sm-12">
            <h1 class="text-center"><%: Title %></h1>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-12">
            <asp:ObjectDataSource ID="ObjectEmployeesReport" runat="server" SelectMethod="GetEmployeeReport" TypeName="MGO.Models.EmployeeReport"></asp:ObjectDataSource>
            <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-striped table-condensed" AutoGenerateColumns="False" DataSourceID="ObjectEmployeesReport" GridLines="None">
                <Columns>
                    <asp:BoundField DataField="Employee_Name" HeaderText="Employee Name" SortExpression="Employee_Name" />
                    <asp:BoundField DataField="Employee_Position" HeaderText="Employee Position" SortExpression="Employee_Position" />
                    <asp:BoundField DataField="Employee_Commission" DataFormatString="{0:p}" HeaderText="Employee Commission" SortExpression="Employee_Commission" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
