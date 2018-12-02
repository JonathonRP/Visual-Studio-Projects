<%@ Page Title="Product Data" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductData.aspx.cs" Inherits="MGO.Data.Employee.ProductData" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:SqlDataSource ID="SqlProducts" runat="server" ConnectionString="<%$ ConnectionStrings:MGOConnectionString %>"
        SelectCommand="SELECT I.SKU, I.Item_Description, I.Cat_Num, C.Cat_Description, I.Item_Price FROM Item AS I INNER JOIN Category AS C ON I.Cat_Num = C.Cat_Num"
        DeleteCommand="DELETE FROM Item WHERE [SKU] = @SKU"
        InsertCommand="INSERT INTO [Item] ([SKU], [Item_Description], [Item_Price], [Cat_Num]) VALUES (@SKU, @Item_Description, @Item_Price, @Cat_Num)"
        UpdateCommand="UPDATE [Item] SET [Item_Description] = @Item_Description, [Cat_Num] = @Cat_Num, [Item_Price] = @Item_Price WHERE [SKU] = @SKU">
        <DeleteParameters>
            <asp:Parameter Name="SKU" Type="Int16" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="SKU" Type="Int16" />
            <asp:Parameter Name="Item_Description" Type="String" />
            <asp:Parameter Name="Item_Price" Type="Decimal" />
            <asp:Parameter Name="Cat_Num" Type="Int16" />
            <asp:Parameter Name="Cat_Description" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="Item_Description" Type="String" />
            <asp:Parameter Name="Cat_Num" Type="Int16" />
            <asp:Parameter Name="Item_Price" Type="Decimal" />
            <asp:Parameter Name="SKU" Type="Int16" />
            <asp:Parameter Name="Cat_Description" Type="String" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlCategories" runat="server" ConnectionString="<%$ ConnectionStrings:MGOConnectionString %>"
        SelectCommand="SELECT * FROM [Category]"
        DeleteCommand="DELETE FROM [Category] WHERE [Cat_Num] = @Cat_Num"
        InsertCommand="INSERT INTO [Category] ([Cat_Num], [Cat_Description]) VALUES (@Cat_Num, @Cat_Description)"
        UpdateCommand="UPDATE [Category] SET [Cat_Description] = @Cat_Description WHERE [Cat_Num] = @Cat_Num">
        <DeleteParameters>
            <asp:Parameter Name="Cat_Num" Type="Int16" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="Cat_Num" Type="Int16" />
            <asp:Parameter Name="Cat_Description" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="Cat_Description" Type="String" />
            <asp:Parameter Name="Cat_Num" Type="Int16" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <div class="row mgo-row">
        <div class="col-lg-12">
            <asp:FormView ID="FrmViewProduct" CssClass="form-inline pull-left" runat="server" DataKeyNames="SKU" DataSourceID="SqlProducts" OnItemInserted="FrmViewProduct_ItemInserted">
                <InsertItemTemplate>
                    <div class="col-sm-2 mgo-formview-form-group">
                        <div class="input-group">
                            <asp:TextBox ID="SKUTextBox" CssClass="form-control" runat="server" Text='<%# Bind("SKU") %>' PlaceHolder="SKU" />
                            <div class="input-group-addon">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Item_DescriptionTextBox" CssClass="text-danger" Display="Dynamic" ErrorMessage="SKU is required" ValidationGroup="form_view_validate">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="SKUTextBox" CssClass="text-danger" Display="Dynamic" ErrorMessage="SKU must be numberic" ValidationGroup="form_view_validate" Operator="DataTypeCheck" Type="Integer">*</asp:CompareValidator>
                                <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="SKUTextBox" CssClass="text-danger" Display="Dynamic" ErrorMessage="SKU must not already exist" ValidationGroup="form_view_validate" OnServerValidate="CustomValidator1_ServerValidate">*</asp:CustomValidator>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-3 mgo-formview-form-group">
                        <div class="input-group">
                            <asp:TextBox ID="Item_DescriptionTextBox" CssClass="form-control" runat="server" Text='<%# Bind("Item_Description") %>' PlaceHolder="Product Name" />
                            <div class="input-group-addon">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Item_DescriptionTextBox" CssClass="text-danger" Display="Dynamic" ErrorMessage="Product Name is required" ValidationGroup="form_view_validate">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-3 mgo-formview-form-group">
                        <div class="input-group">
                            <asp:DropDownList ID="ddlFormItemCatNum" AutoPostBack="true" CssClass="form-control" runat="server" DataSourceID="SqlCategories" DataTextField="Cat_Num" DataValueField="Cat_Num" OnPreRender="ddlFormItemCatNum_PreRender" OnSelectedIndexChanged="ddlFormItemCatNum_SelectedIndexChanged" SelectedValue='<%# Bind("Cat_Num") %>' />
                            <div class="input-group-addon">
                                <asp:Label ID="lblFormItemCatDescript" CssClass="control-label" runat="server" Text='<%# Bind("Cat_Description") %>' PlaceHolder="Category"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-2 mgo-formview-form-group">
                        <div class="input-group">
                            <asp:TextBox ID="Item_PriceTextBox" CssClass="form-control" runat="server" Text='<%# Bind("Item_Price") %>' PlaceHolder="Price" />
                            <div class="input-group-addon">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Item_PriceTextBox" CssClass="text-danger" Display="Dynamic" ErrorMessage="Price is required" ValidationGroup="form_view_validate">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="Item_PriceTextBox" CssClass="text-danger" Display="Dynamic" ErrorMessage="Price must be a currency" ValidationGroup="form_view_validate" Operator="DataTypeCheck" Type="Currency">*</asp:CompareValidator>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-2">
                        <asp:Button CssClass="btn btn-primary" ID="btnFrmViewProductInsert" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" ValidationGroup="form_view_validate" />
                        <asp:Button CssClass="btn btn-default" ID="btnFrmViewProductCancelInsert" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                    </div>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Button ID="btnFrmViewProductNew" CssClass="btn btn-primary" runat="server" CausesValidation="False" CommandName="New" Text="New Item" OnClick="btnFrmViewProducts_Click" />
                </ItemTemplate>
            </asp:FormView>
            <div class="col-md-8">
                <asp:FormView ID="FrmViewCategory" CssClass="form-inline pull-left" runat="server" DataKeyNames="Cat_Num" DataSourceID="SqlCategories" OnItemInserted="FrmViewCategory_CategoryInserted" OnItemUpdated="FrmViewCategory_CategoryUpdated">
                    <EditItemTemplate>
                        <div class="col-sm-4 mgo-formview-form-group">
                            <div class="input-group">
                                <div class="input-group-addon">
                                    <asp:Label runat="server">Category ID:</asp:Label>
                                </div>
                                <asp:DropDownList ID="ddlFormCatNum" AutoPostBack="true" CssClass="form-control" runat="server" DataSourceID="SqlCategories" DataTextField="Cat_Num" DataValueField="Cat_Num" OnPreRender="ddlFormCatNum_PreRender" OnSelectedIndexChanged="ddlFormCatNum_SelectedIndexChanged" SelectedValue='<%# Bind("Cat_Num") %>' />
                            </div>
                        </div>
                        <div class="col-sm-5">
                            <div class="input-group">
                                <div class="input-group-addon">
                                    <asp:Label runat="server">Category:</asp:Label>
                                </div>
                                <asp:TextBox ID="txtFormCat_Descript" runat="server" CssClass="form-control" Text='<%# Bind("Cat_Description") %>' />
                                <div class="input-group-addon">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtFormCat_Descript" CssClass="text-danger" Display="Dynamic" ErrorMessage="Category is required" ValidationGroup="form_view_validate">*</asp:RequiredFieldValidator>
                                    <asp:CustomValidator ID="CustomValidator2" runat="server" ControlToValidate="txtFormCat_Descript" CssClass="text-danger" Display="Dynamic" ErrorMessage="Category must not already exist" ValidationGroup="form_view_validate" OnServerValidate="CustomValidator2_ServerValidate">*</asp:CustomValidator>
                                </div>
                            </div>
                        </div>
                        <asp:Button ID="btnFrmViewCategoryUpdate" CssClass="btn btn-primary" runat="server" CausesValidation="True" CommandName="Update" Text="Update" ValidationGroup="form_view_validate" />
                        <asp:Button ID="btnFrmViewCategoryCancelUpdate" CssClass="btn btn-default" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <div class="col-sm-4 mgo-formview-form-group">
                            <div class="input-group">
                                <asp:TextBox ID="Cat_NumTextBox" PlaceHolder="Category ID" runat="server" CssClass="form-control" Text='<%# Bind("Cat_Num") %>' />
                                <div class="input-group-addon">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="Cat_NumTextBox" CssClass="text-danger" Display="Dynamic" ErrorMessage="Category Number is required" ValidationGroup="form_view_validate">*</asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="Cat_NumTextBox" CssClass="text-danger" Display="Dynamic" ErrorMessage="Category Number must be numberic" ValidationGroup="form_view_validate" Operator="DataTypeCheck" Type="Integer">*</asp:CompareValidator>
                                    <asp:CustomValidator ID="CustomValidator3" runat="server" ControlToValidate="Cat_NumTextBox" CssClass="text-danger" Display="Dynamic" ErrorMessage="Category Number must not already exist" ValidationGroup="form_view_validate" OnServerValidate="CustomValidator3_ServerValidate">*</asp:CustomValidator>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-5">
                            <div class="input-group">
                                <asp:TextBox ID="Cat_DescriptionTextBox" PlaceHolder="Category" runat="server" CssClass="form-control" Text='<%# Bind("Cat_Description") %>' />
                                <div class="input-group-addon">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="Cat_DescriptionTextBox" CssClass="text-danger" Display="Dynamic" ErrorMessage="Category Name is required" ValidationGroup="form_view_validate">*</asp:RequiredFieldValidator>
                                    <asp:CustomValidator ID="CustomValidator4" runat="server" ControlToValidate="Cat_DescriptionTextBox" CssClass="text-danger" Display="Dynamic" ErrorMessage="Category must not already exist" ValidationGroup="form_view_validate" OnServerValidate="CustomValidator2_ServerValidate">*</asp:CustomValidator>
                                </div>
                            </div>
                        </div>
                        <asp:Button ID="btnFrmViewCategoryInsert" CssClass="btn btn-primary" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" ValidationGroup="form_view_validate" />
                        <asp:Button ID="btnFrmViewCategoryCancelInsert" CssClass="btn btn-default" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Button ID="btnFrmViewCategoryNew" CssClass="btn btn-primary" runat="server" CausesValidation="False" CommandName="New" Text="New Category" />
                        <asp:Button ID="btnFrmViewCategoryEdit" CssClass="btn btn-default" runat="server" CausesValidation="False" CommandName="Edit" Text="Change Category Description" />
                    </ItemTemplate>
                </asp:FormView>
            </div>
            <asp:FormView ID="FrmViewCategoryDelete" CssClass="form-inline pull-right" runat="server" DataKeyNames="Cat_Num" DataSourceID="SqlCategories" OnItemDeleted="FrmViewCategoryDelete_CategoryDeleted">
                <EditItemTemplate>
                    <div class="col-lg-12">
                        <div class="form-group">
                            <asp:Button ID="btnFrmViewCategroyCancelDelete" CssClass="btn btn-default" CausesValidation="false" CommandName="Cancel" runat="server" Text="Cancel" />
                            <asp:Button ID="btnFrmViewCategoryDeleteCategory" CssClass="btn btn-default" CausesValidation="true" CommandName="Delete" runat="server" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete this Category?');" />
                            <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server" AutoPostBack="True" DataSourceID="SqlCategories" DataTextField="Cat_Num" DataValueField="Cat_Num" SelectedValue='<%# Bind("Cat_Num") %>' />
                        </div>
                    </div>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Button ID="btnFrmViewCategoryDelete" CssClass="btn btn-default" CausesValidation="false" CommandName="Edit" runat="server" Text="Delete Catagory" />
                </ItemTemplate>
            </asp:FormView>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-12">
            <asp:ValidationSummary ID="ValidationSummary2" runat="server" CssClass="text-danger" HeaderText="Please Correct the following errors:" ValidationGroup="form_view_validate" />
        </div>
    </div>
    <div class="row">
        <div class="col-sm-12">
            <asp:GridView ID="grdviewProducts" CssClass="table table-bordered table-striped table-condensed" runat="server" AutoGenerateColumns="False" DataKeyNames="SKU" DataSourceID="SqlProducts" AllowSorting="True" OnPreRender="grdviewProducts_PreRender" OnRowDataBound="grd_RowDataBound" OnRowDeleted="grdProducts_RowDeleted" OnRowUpdated="grdProducts_RowUpdated">
                <Columns>
                    <asp:BoundField DataField="SKU" HeaderText="SKU" ReadOnly="True" SortExpression="SKU" HeaderStyle-CssClass="col-sm-1"></asp:BoundField>
                    <asp:TemplateField HeaderText="Product Name" SortExpression="Item_Description" HeaderStyle-CssClass="col-sm-2">
                        <EditItemTemplate>
                            <div class="input-group">
                                <asp:TextBox ID="txtGridItemDescript" CssClass="form-control" runat="server" Text='<%# Bind("Item_Description") %>'></asp:TextBox>
                                <div class="input-group-addon">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtGridItemDescript" CssClass="text-danger" Display="Dynamic" ErrorMessage="Item Description is required" ValidationGroup="edit">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Item_Description") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Category" SortExpression="Cat_Description" HeaderStyle-CssClass="col-sm-2">
                        <EditItemTemplate>
                            <div class="input-group">
                                <asp:DropDownList ID="ddlGridItemCatNum" CssClass="form-control" AutoPostBack="true" runat="server" DataSourceID="SqlCategories" DataTextField="Cat_Num" DataValueField="Cat_Num" OnSelectedIndexChanged="ddlGridItemCatNum_SelectedIndexChanged" SelectedValue='<%# Bind("Cat_Num") %>' />
                                <div class="input-group-addon">
                                    <asp:Label ID="lblGridItemCatDescript" CssClass="col-sm-6" runat="server" Text='<%# Bind("Cat_Description") %>'></asp:Label>
                                </div>
                            </div>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("Cat_Description") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Price" SortExpression="Item_Price" HeaderStyle-CssClass="col-sm-1">
                        <EditItemTemplate>
                            <div class="input-group">
                                <asp:TextBox ID="txtGridItemPrice" CssClass="form-control" runat="server" Text='<%# Bind("Item_Price", "{0:F}") %>'></asp:TextBox>
                                <div class="input-group-addon">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtGridItemPrice" CssClass="text-danger" Display="Dynamic" ErrorMessage="Item Price is required" ValidationGroup="edit">*</asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="CompareValidator5" runat="server" ControlToValidate="txtGridItemPrice" CssClass="text-danger" Display="Dynamic" ErrorMessage="Item Price must be a currency" ValidationGroup="edit" Operator="DataTypeCheck" Type="Currency">*</asp:CompareValidator>
                                </div>
                            </div>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("Item_Price", "{0:C}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False" ItemStyle-HorizontalAlign="center" HeaderStyle-CssClass="col-sm-1">
                        <EditItemTemplate>
                            <div class="col-sm-5">
                                <asp:LinkButton ID="LinkButton1" CssClass="btn btn-primary" runat="server" CausesValidation="True" ValidationGroup="edit" CommandName="Update" Text="Update"></asp:LinkButton>
                            </div>
                            <div class="col-sm-5">
                                <asp:LinkButton ID="LinkButton2" CssClass="btn btn-default" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                            </div>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <div class="col-sm-12">
                                <div class="col-sm-4">
                                    <asp:LinkButton ID="LinkButton1" CssClass="btn btn-primary" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
                                </div>
                                <div class="col-sm-4">
                                    <asp:LinkButton ID="LinkButton2" CssClass="btn btn-default" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete"></asp:LinkButton>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle CssClass="mgo-grdview-header" />
            </asp:GridView>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-12">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="text-danger" HeaderText="Please Correct the following errors:" ValidationGroup="edit" />
            <asp:Label ID="lblErrorMessage" runat="server" CssClass="text-danger" EnableViewState="false"></asp:Label>
        </div>
    </div>
</asp:Content>
