<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Customer.aspx.cs" Inherits="MGO.Reports.CustomerReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-sm-12">
            <asp:ObjectDataSource ID="ObjectCustomersReport" runat="server" SelectMethod="GetCustomerReport" TypeName="MGO.Models.CustomerReport"></asp:ObjectDataSource>
            <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-striped table-responsive table-condensed" AutoGenerateColumns="False" DataSourceID="ObjectCustomersReport">
                <Columns>
                    <asp:BoundField DataField="Customer_Name" HeaderText="Customer Name" SortExpression="Customer_Name" />
                    <asp:BoundField DataField="Customer_Address" HeaderText="Customer Address" SortExpression="Customer_Address" />
                    <asp:BoundField DataField="Customer_Email" HeaderText="Customer Email" SortExpression="Customer_Email" />
                </Columns>
            </asp:GridView>
        </div>
    </div>

</asp:Content>
