<%@ Page Title="Customer Info" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerInfo.aspx.cs" Inherits="MGO.Data.CustomerInfo" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row mgo-row">
        <div class="col-lg-12">
            <asp:FormView ID="FrmViewCustomer" CssClass="form-inline pull-left" runat="server" DataKeyNames="Cust_ID" DataSourceID="EntityCustomers" OnItemInserted="FrmViewCustomer_CustomerInserted">
                <InsertItemTemplate>
                    <div class="col-sm-1 mgo-formview-form-group">
                        <div class="input-group">
                            <asp:TextBox ID="txtCustID" CssClass="form-control" runat="server" Text='<%# Bind("Cust_ID") %>' PlaceHolder="ID" />
                            <div class="input-group-addon">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCustFName" CssClass="text-danger" Display="Dynamic" ErrorMessage="ID is required" ValidationGroup="form_view_validate">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtCustID" CssClass="text-danger" Display="Dynamic" ErrorMessage="ID must be numberic" ValidationGroup="form_view_validate" Operator="DataTypeCheck" Type="Integer">*</asp:CompareValidator>
                                <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="txtCustID" CssClass="text-danger" Display="Dynamic" ErrorMessage="ID must not already exist" ValidationGroup="form_view_validate" OnServerValidate="CustomValidator1_ServerValidate">*</asp:CustomValidator>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-3 mgo-formview-form-group">
                        <div class="input-group">
                            <asp:TextBox ID="txtCustFName" CssClass="form-control" runat="server" Text='<%# Bind("Cust_FName") %>' PlaceHolder="First Name" />
                            <div class="input-group-addon">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCustFName" CssClass="text-danger" Display="Dynamic" ErrorMessage="First Name is required" ValidationGroup="form_view_validate">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-3 mgo-formview-form-group">
                        <div class="input-group">
                            <asp:TextBox ID="txtCustLName" CssClass="form-control" runat="server" Text='<%# Bind("Cust_LName") %>' PlaceHolder="Last Name" />
                            <div class="input-group-addon">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtCustLName" CssClass="text-danger" Display="Dynamic" ErrorMessage="Last Name is required" ValidationGroup="form_view_validate">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    </div>
                    <div class="col-sm-3 mgo-formview-form-group">
                        <div class="input-group">
                            <asp:TextBox ID="txtCustEMail" CssClass="form-control" runat="server" Text='<%# Bind("Cust_EMail") %>' PlaceHolder="EMail Address" />
                            <div class="input-group-addon">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtCustEMail" CssClass="text-danger" Display="Dynamic" ErrorMessage="EMail is required" ValidationGroup="form_view_validate">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-3 mgo-formview-form-group">
                        <div class="input-group">
                            <asp:TextBox ID="txtCustStreet1" CssClass="form-control" runat="server" Text='<%# Bind("Cust_Street1") %>' PlaceHolder="Street1" />
                            <div class="input-group-addon">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtCustStreet1" CssClass="text-danger" Display="Dynamic" ErrorMessage="Street1 is required" ValidationGroup="form_view_validate">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-1 mgo-formview-form-group">
                        <asp:TextBox ID="txtCustStreet2" CssClass="form-control" runat="server" Text='<%# Bind("Cust_Street2") %>' PlaceHolder="Street2" />
                    </div>
                    <div class="col-sm-2 mgo-formview-form-group">
                        <div class="input-group">
                            <asp:TextBox ID="txtCustCity" CssClass="form-control" runat="server" Text='<%# Bind("Cust_City") %>' PlaceHolder="City" />
                            <div class="input-group-addon">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtCustCity" CssClass="text-danger" Display="Dynamic" ErrorMessage="City is required" ValidationGroup="form_view_validate">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-2 mgo-formview-form-group">
                        <div class="input-group">
                            <asp:TextBox ID="txtCustState" CssClass="form-control" runat="server" Text='<%# Bind("Cust_State") %>' PlaceHolder="State" />
                            <div class="input-group-addon">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtCustState" CssClass="text-danger" Display="Dynamic" ErrorMessage="State is required" ValidationGroup="form_view_validate">*</asp:RequiredFieldValidator>
                                <asp:CustomValidator ID="CustomValidator3" runat="server" ControlToValidate="txtCustState" CssClass="text-danger" Display="Dynamic" ErrorMessage="State must be State Initials with length of 2 characters" ValidationGroup="form_view_validate" OnServerValidate="CustomValidator2_ServerValidate">*</asp:CustomValidator>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-2 mgo-formview-form-group">
                        <div class="input-group">
                            <asp:TextBox ID="txtCustZIP" CssClass="form-control" runat="server" Text='<%# Bind("Cust_ZIP") %>' PlaceHolder="ZIP" />
                            <div class="input-group-addon">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCustZIP" CssClass="text-danger" Display="Dynamic" ErrorMessage="ZIP is required" ValidationGroup="form_view_validate">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="txtCustZIP" CssClass="text-danger" Display="Dynamic" ErrorMessage="ZIP must be a numeric" ValidationGroup="form_view_validate" Operator="DataTypeCheck" Type="Integer">*</asp:CompareValidator>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-2">
                        <asp:Button CssClass="btn btn-primary" ID="btnFrmViewProductsInsert" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" ValidationGroup="form_view_validate" />
                        <asp:Button CssClass="btn btn-default" ID="btnFrmViewProductsCancelInsert" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                    </div>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Button ID="btnFrmViewCustomersNew" CssClass="btn btn-primary" runat="server" CausesValidation="False" CommandName="New" Text="New Customer" />
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
            <asp:GridView ID="grdviewCustInfo" runat="server" CssClass="table table-bordered table-striped table-condensed" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="EntityCustomers" OnPreRender="grdviewCustInfo_PreRender" OnRowDataBound="grd_RowDataBound" OnRowUpdated="grdviewCustInfo_RowUpdated" OnRowDeleted="grdviewCustInfo_RowDeleted">
                <Columns>
                    <asp:BoundField DataField="Cust_ID" ReadOnly="true" HeaderText="Customer ID" SortExpression="Cust_ID" HeaderStyle-CssClass="col-sm-1"></asp:BoundField>
                    <asp:TemplateField HeaderText="Customer Name" SortExpression="Cust_FName" HeaderStyle-CssClass="col-sm-2">
                        <EditItemTemplate>
                            <div class="input-group">
                                <asp:TextBox ID="grdCustFirstName" CssClass="form-control" runat="server" Text='<%# Bind("Cust_FName") %>' PlaceHolder="First Name"></asp:TextBox>
                                <div class="input-group-addon">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="grdCustFirstName" CssClass="text-danger" Display="Dynamic" ErrorMessage="First Name is required" ValidationGroup="edit">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="grdCustLastName" CssClass="form-control" runat="server" Text='<%# Bind("Cust_LName") %>' PlaceHolder="Last Name"></asp:TextBox>
                                <div class="input-group-addon">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="grdCustLastName" CssClass="text-danger" Display="Dynamic" ErrorMessage="Last Name is required" ValidationGroup="edit">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Cust_FName") %>'></asp:Label>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("Cust_LName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Customer Address" SortExpression="Cust_Street1" HeaderStyle-CssClass="col-sm-4">
                        <EditItemTemplate>
                            <div class="col-sm-7 mgo-gridview-form-group">
                                <div class="input-group">
                                    <asp:TextBox ID="grdCustStreet1" CssClass="form-control" runat="server" Text='<%# Bind("Cust_Street1") %>' PlaceHolder="Street 1"></asp:TextBox>
                                    <div class="input-group-addon">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="grdCustStreet1" CssClass="text-danger" Display="Dynamic" ErrorMessage="Street1 is required" ValidationGroup="edit">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-5 mgo-gridview-form-group">
                                <asp:TextBox ID="grdCustStreet2" CssClass="form-control" runat="server" Text='<%# Bind("Cust_Street2") %>' PlaceHolder="Street 2"></asp:TextBox>
                            </div>
                            <div class="col-sm-5 mgo-gridview-form-group">
                                <div class="input-group">
                                    <asp:TextBox ID="grdCustCity" CssClass="form-control" runat="server" Text='<%# Bind("Cust_City") %>' PlaceHolder="City"></asp:TextBox>
                                    <div class="input-group-addon">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="grdCustCity" CssClass="text-danger" Display="Dynamic" ErrorMessage="City is required" ValidationGroup="edit">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-3 mgo-gridview-form-group">
                                <div class="input-group">
                                    <asp:TextBox ID="grdCustState" CssClass="form-control" runat="server" Text='<%# Bind("Cust_State") %>' PlaceHolder="State"></asp:TextBox>
                                    <div class="input-group-addon">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="grdCustState" CssClass="text-danger" Display="Dynamic" ErrorMessage="State is required" ValidationGroup="edit">*</asp:RequiredFieldValidator>
                                        <asp:CustomValidator ID="CustomValidator2" runat="server" ControlToValidate="grdCustState" CssClass="text-danger" Display="Dynamic" ErrorMessage="State must be State Initials with length of 2 characters" ValidationGroup="edit" OnServerValidate="CustomValidator2_ServerValidate">*</asp:CustomValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-4 mgo-gridview-form-group">
                                <div class="input-group">
                                    <asp:TextBox ID="grdCustZIP" CssClass="form-control" runat="server" Text='<%# Bind("Cust_ZIP") %>' PlaceHolder="ZIP"></asp:TextBox>
                                    <div class="input-group-addon">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="grdCustZIP" CssClass="text-danger" Display="Dynamic" ErrorMessage="ZIP is required" ValidationGroup="edit">*</asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="CompareValidator1" runat="server" CssClass="text-danger" Display="Dynamic" ErrorMessage="ZIP must be a number" Operator="DataTypeCheck" Type="Integer" ValidationGroup="edit" ControlToValidate="grdCustZIP">*</asp:CompareValidator>
                                    </div>
                                </div>
                            </div>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("Cust_Street1") %>'></asp:Label>
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("Cust_Street2") %>'></asp:Label>
                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("Cust_City") %>'></asp:Label>
                            <asp:Label ID="Label6" runat="server" Text='<%# Bind("Cust_State") %>'></asp:Label>
                            <asp:Label ID="Label7" runat="server" Text='<%# Bind("Cust_ZIP") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Customer EMail" SortExpression="Cust_EMail" HeaderStyle-CssClass="col-sm-2">
                        <EditItemTemplate>
                            <div class="input-group">
                                <asp:TextBox ID="grdCustEMail" CssClass="form-control" runat="server" Text='<%# Bind("Cust_EMail") %>' PlaceHolder="EMail"></asp:TextBox>
                                <div class="input-group-addon">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="grdCustEMail" CssClass="text-danger" Display="Dynamic" ErrorMessage="EMail is required" ValidationGroup="edit">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label8" runat="server" Text='<%# Bind("Cust_EMail") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False" ItemStyle-HorizontalAlign="center" HeaderStyle-CssClass="col-sm-2">
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
            <asp:EntityDataSource ID="EntityCustomers" runat="server" ConnectionString="name=MGO_Entities" DefaultContainerName="MGO_Entities" EntitySetName="Customers" EnableInsert="true" EnableUpdate="true" EnableDelete="true">
            </asp:EntityDataSource>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-12">
            <asp:ValidationSummary ID="ValidationSummary1" ShowModelStateErrors="true" runat="server" CssClass="text-danger" HeaderText="Please Correct the following errors:" ValidationGroup="edit" />
            <asp:Label ID="lblErrorMessage" runat="server" CssClass="text-danger" EnableViewState="false"></asp:Label>
        </div>
    </div>
</asp:Content>
