<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="XEx13CustomerList.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ch14 and Ch15: MaintainProducts</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/site.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.1.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
</head>
<body>
    <div class="container">
        <header class="jumbotron"><%-- image set in site.css --%><a href="Models/">Models/</a></header>
        <main>
            <form id="form1" runat="server" class="form-horizontal">
                <div class="form-group">
                    <h1 class="col-sm-9 col-sm-offset-3">Halloween Store Product Maintenance</h1>
                </div>

                <div class="form-group">
                    <%-- When configuring the SQLDataSource, don't forget to go to the advanced option and select generate insert, update, and delete  --%>
                    <%-- product information goes here; use either a datalist or formview control --%>
                    <div class="col-sm-12 table-responsive">
                        <asp:GridView ID="grdviewProduct" CssClass="table table-bordered table-striped table-condensed" runat="server" AutoGenerateColumns="False" DataKeyNames="ProductID" DataSourceID="sqlProducts" OnRowDeleted="grdProducts_RowDeleted" OnRowUpdated="grdProducts_RowUpdated" OnRowDataBound="grd_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="ProductID" ItemStyle-HorizontalAlign="Center" SortExpression="ProductID">
                                    <EditItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("ProductID") %>'></asp:Label>
                                    </EditItemTemplate>
                                    <HeaderStyle CssClass="col-sm-2" />
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("ProductID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Name" ItemStyle-HorizontalAlign="Center" SortExpression="Name">
                                    <EditItemTemplate>
                                        <div class="row">
                                            <div class="col-sm-11">
                                                <asp:TextBox ID="grdtxtName" runat="server" Text='<%# Bind("Name") %>' CssClass="form-control"></asp:TextBox>
                                            </div>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="grdtxtName" CssClass="text-danger" Display="Dynamic" ErrorMessage="Name is required" ValidationGroup="edit">*</asp:RequiredFieldValidator>
                                        </div>
                                    </EditItemTemplate>
                                    <HeaderStyle CssClass="col-sm-3" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="CategoryID" ItemStyle-HorizontalAlign="Center" SortExpression="CategoryID">
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="sqlProducts" DataTextField="CategoryID" DataValueField="CategoryID" CssClass="form-control">
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                    <HeaderStyle CssClass="col-sm-2" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("CategoryID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="UnitPrice" ItemStyle-HorizontalAlign="Center" SortExpression="UnitPrice">
                                    <EditItemTemplate>
                                        <div class="row">
                                            <div class="col-sm-11">
                                                <asp:TextBox ID="grdtxtPrice" runat="server" Text='<%# Bind("UnitPrice", "{0:C}") %>' CssClass="form-control"></asp:TextBox>
                                            </div>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="grdtxtPrice" CssClass="text-danger" Display="Dynamic" ErrorMessage="Price is required" ValidationGroup="edit">*</asp:RequiredFieldValidator>
                                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="grdtxtPrice" CssClass="text-danger" Display="Dynamic" ErrorMessage="Price must be a currency" Type="Currency" ValidationGroup="edit" Operator="DataTypeCheck">*</asp:CompareValidator>
                                        </div>
                                    </EditItemTemplate>
                                    <HeaderStyle CssClass="col-sm-2" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("UnitPrice", "{0:C}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ShowEditButton="True" ShowDeleteButton="true" ValidationGroup="edit" ItemStyle-HorizontalAlign="Center" />
                            </Columns>
                            <EditRowStyle />
                            <HeaderStyle BackColor="Black" ForeColor="Orange" />
                            <AlternatingRowStyle BackColor="Orange" ForeColor="Black" />
                            <RowStyle ForeColor="Orange" />
                        </asp:GridView>
                        <asp:SqlDataSource ID="sqlProducts" runat="server" ConnectionString="<%$ ConnectionStrings:HalloweenConnectionString %>" DeleteCommand="DELETE FROM [Products] WHERE [ProductID] = @ProductID" InsertCommand="INSERT INTO [Products] ([ProductID], [Name], [CategoryID], [UnitPrice]) VALUES (@ProductID, @Name, @CategoryID, @UnitPrice)" SelectCommand="SELECT [ProductID], [Name], [CategoryID], [UnitPrice] FROM [Products]" UpdateCommand="UPDATE [Products] SET [Name] = @Name, [CategoryID] = @CategoryID, [UnitPrice] = @UnitPrice WHERE [ProductID] = @ProductID">
                            <DeleteParameters>
                                <asp:Parameter Name="ProductID" Type="String" />
                            </DeleteParameters>
                            <InsertParameters>
                                <asp:Parameter Name="ProductID" Type="String" />
                                <asp:Parameter Name="Name" Type="String" />
                                <asp:Parameter Name="CategoryID" Type="String" />
                                <asp:Parameter Name="UnitPrice" Type="Decimal" />
                            </InsertParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="Name" Type="String" />
                                <asp:Parameter Name="CategoryID" Type="String" />
                                <asp:Parameter Name="UnitPrice" Type="Decimal" />
                                <asp:Parameter Name="ProductID" Type="String" />
                            </UpdateParameters>
                        </asp:SqlDataSource>
                        <div class="row">
                            <div class="col-sm-12">
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="text-danger" HeaderText="Please correct the following errors:" ValidationGroup="edit" />
                                <asp:Label ID="lblErrorMessage" runat="server" CssClass="text-danger" EnableViewState="False"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </form>
        </main>
    </div>

</body>
</html>
