<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Commission.aspx.cs" Inherits="MGO.Reports.Manager.CommissionsReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-sm-12">
            <asp:ObjectDataSource ID="ObjectCommissionsReport" runat="server" SelectMethod="GetCommissionsReport" TypeName="MGO.Models.CommissionsReport"></asp:ObjectDataSource>
            <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-striped table-responsive table-condensed" AutoGenerateColumns="False" DataSourceID="ObjectCommissionsReport">
                <Columns>
                    <asp:BoundField DataField="Employee_Name" HeaderText="Employee Name" SortExpression="Employee_Name" />
                    <asp:BoundField DataField="Employee_Commission" DataFormatString="{0:p}" HeaderText="Employee Commission" SortExpression="Employee_Commission" />
                    <asp:BoundField DataField="Employee_Qty_Sold" HeaderText="Quantity Sold" SortExpression="Employee_Qty_Sold" />
                    <asp:BoundField DataField="Employee_Sales" HeaderText="Employee Sales" SortExpression="Employee_Sales" DataFormatString="{0:c}" />
                    <asp:BoundField DataField="Employee_Commission_Total" HeaderText="Total Commission" SortExpression="Employee_Commission_Total" DataFormatString="{0:c}" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
