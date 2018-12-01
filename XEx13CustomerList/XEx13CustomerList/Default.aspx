<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="XEx13CustomerList.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ch13: Customer List</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/site.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.9.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
</head>
<body>
<div class="container">
    <header class="jumbotron"><%-- image set in site.css --%></header>
    <main>
        <form id="form1" runat="server" class="form-horizontal">
            <div class="form-group">
                <label id="lblState" for="ddlState" 
                    class="col-xs-4 col-sm-offset-1 col-sm-3 control-label">
                    Choose a state:</label>
                <div class="col-xs-8 col-sm-5">
                    <%-- state drop-down goes here --%>
                    <asp:SqlDataSource ID="SqlState" runat="server" ConnectionString="<%$ ConnectionStrings:HalloweenConnectionString %>" SelectCommand="SELECT * FROM [States] ORDER BY [StateName]"></asp:SqlDataSource>
                    <asp:DropDownList ID="ddlState" runat="server" AutoPostBack="True" DataSourceID="SqlState" DataTextField="StateName" DataValueField="StateCode" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>

            <div class="form-group">
                <div class="col-xs-12 col-sm-offset-1 col-sm-10">
                    <%-- customer data list goes here --%>
                    <asp:SqlDataSource ID="SqlCustomers" runat="server" ConnectionString="<%$ ConnectionStrings:HalloweenConnectionString %>" SelectCommand="SELECT [LastName], [FirstName], [Email], [State] FROM [Customers] WHERE ([State] = @State) ORDER BY [LastName], [FirstName]">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddlState" Name="State" PropertyName="SelectedValue" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:DataList ID="dlCustomers" runat="server" DataKeyField="Email" DataSourceID="SqlCustomers" CssClass="table table-bordered table-striped table-condensed">
                        <HeaderTemplate>
                            <span class="col-xs-3">Last Name</span>
                            <span class="col-xs-3">First Name</span>
                            <span class="col-xs-5">Email</span>
                            <span class="col-xs-1">State</span>
                        </HeaderTemplate>
                        <HeaderStyle CssClass="bg-halloween" />
                        <ItemTemplate>
                            <asp:Label ID="lblLastName" runat="server" Text='<%# Eval("LastName") %>' CssClass="col-xs-3" />
                            <asp:Label ID="lblFirstName" runat="server" Text='<%# Eval("FirstName") %>' CssClass="col-xs-3" />
                            <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("Email") %>' CssClass="col-xs-5" />
                            <asp:Label ID="lblState" runat="server" Text='<%# Eval("State") %>' CssClass="col-xs-1" />
                        </ItemTemplate>
                    </asp:DataList>
                </div>  
            </div>

        </form>
    </main>
</div>
</body>
</html>