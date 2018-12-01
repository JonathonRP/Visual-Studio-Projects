<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductMaintenance.aspx.cs" Inherits="SportsPro.Administration.ProductMaintenance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <div class="row">
        <%--Products Gridview--%>
        <div class="col-sm-12 table-responsive">
            <asp:GridView ID="grdProducts" AutoGenerateColumns="False"
                CssClass="table table-bordered table-striped table-condensed" runat="server" DataKeyNames="ProductCode" DataSourceID="SqlProducts" OnRowDeleted="grdProducts_RowDeleted" OnRowUpdated="grdProducts_RowUpdated" OnPreRender="grdProducts_PreRender">
                <Columns>
                    <%--Product Code Template--%>
                    <asp:TemplateField HeaderText="Product Code" SortExpression="ProductCode">
                        <EditItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("ProductCode") %>'></asp:Label>
                        </EditItemTemplate>
                        <HeaderStyle CssClass="col-sm-2" />
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("ProductCode") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <%--Name Template--%>
                    <asp:TemplateField HeaderText="Name" SortExpression="Name">
                        <EditItemTemplate>
                            <div class="row">
                                <div class="col-sm-11">
                                    <asp:TextBox ID="txtGridName" CssClass="form-control" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtGridName" CssClass="text-danger" Display="Dynamic" ErrorMessage="Product name is required" ValidationGroup="edit">*</asp:RequiredFieldValidator>
                            </div>
                        </EditItemTemplate>
                        <HeaderStyle CssClass="col-sm-4" />
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <%--Version Template--%>
                    <asp:TemplateField HeaderText="Version" SortExpression="Version">
                        <EditItemTemplate>
                            <div class="row">
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtGridVersion" CssClass="form-control" runat="server" Text='<%# Bind("Version") %>'></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtGridVersion" CssClass="text-danger" Display="Dynamic" ErrorMessage="Version is required" ValidationGroup="edit">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtGridVersion" CssClass="text-danger" Display="Dynamic" ErrorMessage="Version must be numeric" Operator="DataTypeCheck" Type="Double" ValidationGroup="edit">*</asp:CompareValidator>
                            </div>
                        </EditItemTemplate>
                        <HeaderStyle CssClass="col-sm-2" />
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("Version") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <%--Release Date Template--%>
                    <asp:TemplateField HeaderText="Release Date" SortExpression="ReleaseDate">
                        <EditItemTemplate>
                            <div class="row">
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtGridDate" CssClass="form-control" runat="server" Text='<%# Bind("ReleaseDate", "{0:d}") %>'></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtGridDate" CssClass="text-danger" Display="Dynamic" ErrorMessage="Release Date is required" ValidationGroup="edit">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtGridDate" CssClass="text-danger" Display="Dynamic" ErrorMessage="Release Date must be in mm/dd/yyyy format" Operator="DataTypeCheck" Type="Date" ValidationGroup="edit">*</asp:CompareValidator>
                            </div>
                        </EditItemTemplate>
                        <HeaderStyle CssClass="col-sm-2" />
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("ReleaseDate", "{0:d}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowEditButton="True" ValidationGroup="edit" />
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete this product?');" Text="Delete"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EditRowStyle CssClass="active" />
                <HeaderStyle CssClass="header" />
            </asp:GridView>

            <%--SQL Data Source--%>
            <asp:SqlDataSource ID="SqlProducts" runat="server" ConnectionString="<%$ ConnectionStrings:TechSupportConnectionString %>" DeleteCommand="DELETE FROM [Products] WHERE [ProductCode] = @ProductCode" InsertCommand="INSERT INTO [Products] ([ProductCode], [Name], [Version], [ReleaseDate]) VALUES (@ProductCode, @Name, @Version, @ReleaseDate)" SelectCommand="SELECT * FROM [Products]" UpdateCommand="UPDATE [Products] SET [Name] = @Name, [Version] = @Version, [ReleaseDate] = @ReleaseDate WHERE [ProductCode] = @ProductCode">
                <DeleteParameters>
                    <asp:Parameter Name="ProductCode" Type="String" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="ProductCode" Type="String" />
                    <asp:Parameter Name="Name" Type="String" />
                    <asp:Parameter Name="Version" Type="Decimal" />
                    <asp:Parameter Name="ReleaseDate" Type="DateTime" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Name" Type="String" />
                    <asp:Parameter Name="Version" Type="Decimal" />
                    <asp:Parameter Name="ReleaseDate" Type="DateTime" />
                    <asp:Parameter Name="ProductCode" Type="String" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </div>
    </div>

    <%--Validation Summary and Message Label--%>
    <div class="row">
        <div class="col-sm-12">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="text-danger" HeaderText="Please correct the following errors:" ValidationGroup="edit" />
            <asp:Label ID="lblErrorMessage" runat="server" CssClass="text-danger" EnableViewState="false"></asp:Label>
        </div>
    </div>

    <div class="row">
        <div class="col-sm-12">
            <p>To add a new product, enter the product information and click Add Product</p>
        </div>
    </div>

    <%-- Product code text box --%>
    <div class="form-group">
        <div class="col-sm-2">Product code:</div>
        <div class="col-sm-3">
            <asp:TextBox ID="txtProductCode" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-sm-7">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                ControlToValidate="txtProductCode" ErrorMessage="Product code is a required field." 
                Display="Dynamic" CssClass="text-danger" ValidationGroup="Add">
            </asp:RequiredFieldValidator>
        </div>
    </div>

    <%-- Name text box --%>
    <div class="form-group">
        <div class="col-sm-2">Name:</div>
        <div class="col-sm-5">
            <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-sm-5">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                ControlToValidate="txtName" ErrorMessage="Name is a required field." 
                CssClass="text-danger" Display="Dynamic" ValidationGroup="Add">
            </asp:RequiredFieldValidator>
        </div>
    </div>

    <%-- Version text box --%>
    <div class="form-group">
        <div class="col-sm-2">Version:</div>
        <div class="col-sm-3">
            <asp:TextBox ID="txtVersion" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-sm-7">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                ControlToValidate="txtVersion" ErrorMessage="Version is a required field." 
                Display="Dynamic" CssClass="text-danger" ValidationGroup="Add">
            </asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator3" runat="server" 
                ControlToValidate="txtVersion" ErrorMessage="Version must be a decimal value." 
                Display="Dynamic" CssClass="text-danger" 
                Operator="DataTypeCheck" Type="Double" ValidationGroup="Add">
            </asp:CompareValidator>
        </div>
    </div>

    <%-- Release date text box --%>
    <div class="form-group">
        <div class="col-sm-2">Release date:</div>
        <div class="col-sm-3">
            <asp:TextBox ID="txtReleaseDate" runat="server" CssClass="form-control">mm/dd/yy</asp:TextBox>
        </div>
        <div class="col-sm-7">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                ControlToValidate="txtReleaseDate" ErrorMessage="Date is a required field." 
                Display="Dynamic" CssClass="text-danger" InitialValue="mm/dd/yy" ValidationGroup="Add">
            </asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtReleaseDate"
                ErrorMessage="Invalid date format." Operator="DataTypeCheck"
                Type="Date" Display="Dynamic" CssClass="text-danger" ValidationGroup="Add">
            </asp:CompareValidator>
        </div>
    </div>

    <%-- Add button --%>
    <div class="form-group">
        <div class="col-sm-offset-2 col-sm-10">
            <asp:Button ID="btnAdd" runat="server" Text="Add Product" ValidationGroup="Add" 
                CssClass="btn btn-primary" OnClick="btnAdd_Click"  />
        </div>
    </div>
</asp:Content>
