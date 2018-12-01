<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerIncidentDisplay.aspx.cs" Inherits="SportsPro.CustomerIncidentDisplay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <div class="row">
        <div class="col-sm-offset-1 col-sm-2">Select a Customer:</div>
        <div class="col-sm-4">
            <asp:DropDownList ID="ddlCustomers" runat="server" AutoPostBack="True" DataSourceID="SqlCustomers" DataTextField="Name" DataValueField="CustomerID"></asp:DropDownList>
            <asp:SqlDataSource ID="SqlCustomers" runat="server" ConnectionString="<%$ ConnectionStrings:TechSupportConnectionString %>" SelectCommand="SELECT [CustomerID], [Name] FROM [Customers] ORDER BY [Name]"></asp:SqlDataSource>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-offset-1 col-sm-10">
            <asp:SqlDataSource ID="SqlIncidents" runat="server" ConnectionString="<%$ ConnectionStrings:TechSupportConnectionString %>" SelectCommand="SELECT Products.Name, Technicians.Name AS TechName, Incidents.DateOpened, Incidents.DateClosed, Incidents.Description FROM Incidents INNER JOIN Products ON Incidents.ProductCode = Products.ProductCode INNER JOIN Technicians ON Incidents.TechID = Technicians.TechID WHERE (Incidents.CustomerID = @CustomerID)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="ddlCustomers" Name="CustomerID" PropertyName="SelectedValue" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:DataList ID="dlIncidents" runat="server" DataSourceID="SqlIncidents" CssClass="table table-bordered table-condensed">
                <HeaderStyle CssClass="header" />
                <HeaderTemplate>
                    <div class="row">
                        <span class="col-sm-5">Product/Incident</span>
                        <span class="col-sm-3">Tech name</span>
                        <span class="col-sm-2">opened</span>
                        <span class="col-sm-2">closed</span>
                    </div>
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="row">
                        <asp:Label ID="lblProduct" runat="server" Text='<%# Eval("Name") %>' CssClass="col-sm-5" />
                        <asp:Label ID="lblTechnician" runat="server" Text='<%# Eval("TechName") %>' CssClass="col-sm-3" />
                        <asp:Label ID="lblDateOpened" runat="server" Text='<%# Eval("DateOpened", "{0:d}") %>' CssClass="col-sm-2" />
                        <asp:Label ID="lblDateClosed" runat="server" Text='<%# Eval("DateClosed", "{0:d}") %>' CssClass="col-sm-2" />
                    </div>
                    <div class="row">
                        <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("Description") %>' CssClass="col-sm-12" />
                    </div>
                </ItemTemplate>
                <AlternatingItemStyle CssClass="active" />
            </asp:DataList>
        </div>
    </div>
</asp:Content>
