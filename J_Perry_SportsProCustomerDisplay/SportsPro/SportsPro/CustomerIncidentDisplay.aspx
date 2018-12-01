<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerIncidentDisplay.aspx.cs" Inherits="SportsPro.CustomerIncidentDisplay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">

    <div class="row">
        <div class="col-sm-offset-1 col-sm-2">Select a customer:</div>
        <div class="col-sm-4">
            <asp:DropDownList ID="ddlCustomers" runat="server"
                CssClass="form-control" AutoPostBack="true"
                DataSourceID="SqlCustomers"
                DataValueField="CustomerID"
                DataTextField="Name">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlCustomers" runat="server" ConnectionString="<%$ ConnectionStrings:TechSupportConnectionString %>" SelectCommand="SELECT [CustomerID], [Name] FROM [Customers] ORDER BY [Name]"></asp:SqlDataSource>
        </div>
    </div>

    <div class="row">
        <div class="col-sm-offset-1 col-sm-10">

            <asp:DataList ID="DataList1" runat="server"
                DataSourceID="SqlIncidents"
                CssClass="table table-bordered table-condensed">
                <AlternatingItemStyle CssClass="active" />
                <HeaderStyle CssClass="header" />
                <HeaderTemplate>
                    <div class="row">
                        <span class="col-sm-5">Product/Incident</span>
                        <span class="col-sm-3">Tech name</span>
                        <span class="col-sm-2">Opened</span>
                        <span class="col-sm-2">Closed</span>
                    </div>
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="row">
                        <asp:Label ID="NameLabel" CssClass="col-sm-5" runat="server" Text='<%# Eval("Name") %>' />

                        <asp:Label ID="TechNameLabel" CssClass="col-sm-3" runat="server" Text='<%# Eval("TechName") %>' />

                        <asp:Label ID="DateOpenedLabel" CssClass="col-sm-2" runat="server" Text='<%# Eval("DateOpened", "{0:d}") %>' />

                        <asp:Label ID="DateClosedLabel" CssClass="col-sm-2" runat="server" Text='<%# Eval("DateClosed", "{0:d}") %>' />
                    </div>
                    <div class="row">
                        <asp:Label ID="DescriptionLabel" CssClass="col-sm-12" runat="server" Text='<%# Eval("Description") %>' />
                    </div>

                </ItemTemplate>
            </asp:DataList>

            <asp:SqlDataSource ID="SqlIncidents" runat="server" ConnectionString="<%$ ConnectionStrings:TechSupportConnectionString %>" SelectCommand="SELECT Products.Name, Technicians.Name AS TechName, Incidents.DateOpened, Incidents.DateClosed, Incidents.Description FROM Incidents INNER JOIN Products ON Incidents.ProductCode = Products.ProductCode INNER JOIN Technicians ON Incidents.TechID = Technicians.TechID WHERE (Incidents.CustomerID = @CustomerID)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="ddlCustomers" Name="CustomerID" PropertyName="SelectedValue" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
    </div>


</asp:Content>
