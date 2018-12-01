<%@ Page Title="Project 1-A: Display Customers" Language="C#" AutoEventWireup="true" CodeBehind="CustomerDisplay.aspx.cs" Inherits="SportsPro.CustomerDisplay" MasterPageFile="~/Site.Master" %>

<asp:Content ID="main" runat="server" ContentPlaceHolderID="mainContent">
    <div class="row">
        <div class="col-sm-offset-1 col-sm-3">Select a customer:</div>
        <div class="col-sm-6">
            <asp:DropDownList ID="ddlCustomers" runat="server" DataSourceID="SqlDataSource1"
                DataTextField="Name" DataValueField="CustomerID" AutoPostBack="True" CssClass="form-control">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:TechSupportConnectionString %>" 
                SelectCommand="SELECT * FROM [Customers] ORDER BY [Name]" DeleteCommand="DELETE FROM [Customers] WHERE [CustomerID] = @CustomerID" InsertCommand="INSERT INTO [Customers] ([Name], [Address], [City], [State], [ZipCode], [Phone], [Email]) VALUES (@Name, @Address, @City, @State, @ZipCode, @Phone, @Email)" UpdateCommand="UPDATE [Customers] SET [Name] = @Name, [Address] = @Address, [City] = @City, [State] = @State, [ZipCode] = @ZipCode, [Phone] = @Phone, [Email] = @Email WHERE [CustomerID] = @CustomerID">
                <DeleteParameters>
                    <asp:Parameter Name="CustomerID" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="Name" Type="String" />
                    <asp:Parameter Name="Address" Type="String" />
                    <asp:Parameter Name="City" Type="String" />
                    <asp:Parameter Name="State" Type="String" />
                    <asp:Parameter Name="ZipCode" Type="String" />
                    <asp:Parameter Name="Phone" Type="String" />
                    <asp:Parameter Name="Email" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Name" Type="String" />
                    <asp:Parameter Name="Address" Type="String" />
                    <asp:Parameter Name="City" Type="String" />
                    <asp:Parameter Name="State" Type="String" />
                    <asp:Parameter Name="ZipCode" Type="String" />
                    <asp:Parameter Name="Phone" Type="String" />
                    <asp:Parameter Name="Email" Type="String" />
                    <asp:Parameter Name="CustomerID" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </div>
    </div>

    <div class="row">
        <div class="col-sm-offset-1 col-sm-3">Address:</div>
        <div class="col-sm-6"><asp:Label ID="lblAddress" runat="server"></asp:Label></div>
    </div>
    <div class="row">
        <div class="col-sm-offset-1 col-sm-3">&nbsp;</div>
        <div class="col-sm-6"><asp:Label ID="lblCityStateZip" runat="server"></asp:Label></div>
    </div>
    <div class="row">
        <div class="col-sm-offset-1 col-sm-3">Phone:</div>
        <div class="col-sm-6"><asp:Label ID="lblPhone" runat="server"></asp:Label></div>
    </div>
    <div class="row">
        <div class="col-sm-offset-1 col-sm-3">Email:</div>
        <div class="col-sm-6"><asp:Label ID="lblEmail" runat="server"></asp:Label></div>
    </div>

    <div class="row">
        <div class="col-sm-offset-1 col-sm-3">New Email:</div>
        <div class="col-sm-6">
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>

    <br />

    <div class="row">
        <div class="col-sm-offset-1 col-sm-10">
            <asp:Button ID="btnAdd" runat="server" Text="Add to Contact List" 
                CssClass="btn btn-primary" OnClick="btnAdd_Click" />
            <asp:Button ID="btnDisplay" runat="server" Text="Display Contact List" 
                PostBackUrl="~/Administration/ContactDisplay.aspx" CssClass="btn btn-primary" />
            <asp:Button ID="btnUpdate" runat="server" Text="Update Email" CssClass="btn btn-primary" OnClick="btnUpdate_Click" />
        </div>
    </div>

    <div class="row">
        <div class="col-sm-offset-1 col-sm-10"><asp:Label ID="lblErrorMessage" runat="server" 
            CssClass="text-danger" EnableViewState="false"></asp:Label>
        </div>
    </div>
</asp:Content>