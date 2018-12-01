<%@ Page Title="Employee Info" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeeInfo.aspx.cs" Inherits="MGO.Data.Manager.EmployeeInfo" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row mgo-row">
        <div class="col-lg-12">
            <asp:FormView ID="FrmViewEmployee" CssClass="form-inline pull-left" runat="server" DataKeyNames="Emp_ID" DataSourceID="EntityEmployees" OnItemInserted="FrmViewEmployee_EmployeeInserted">
                <InsertItemTemplate>
                    <div class="col-sm-1" style="padding: 0px; margin-right: 0px;">
                        <div class="input-group">
                            <asp:TextBox ID="txtEmpID" CssClass="form-control" runat="server" Text='<%# Bind("Emp_ID") %>' PlaceHolder="ID" />
                            <div class="input-group-addon">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmpFName" CssClass="text-danger" Display="Dynamic" ErrorMessage="ID is required" ValidationGroup="form_view_validate">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtEmpID" CssClass="text-danger" Display="Dynamic" ErrorMessage="ID must be numberic" ValidationGroup="form_view_validate" Operator="DataTypeCheck" Type="Integer">*</asp:CompareValidator>
                                <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="txtEmpID" CssClass="text-danger" Display="Dynamic" ErrorMessage="ID must not already exist" ValidationGroup="form_view_validate" OnServerValidate="CustomValidator1_ServerValidate">*</asp:CustomValidator>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-2" style="padding: 0px; margin-right: 0px;">
                        <div class="input-group">
                            <asp:TextBox ID="txtEmpFName" CssClass="form-control" runat="server" Text='<%# Bind("Emp_FName") %>' PlaceHolder="First Name" />
                            <div class="input-group-addon">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmpFName" CssClass="text-danger" Display="Dynamic" ErrorMessage="First Name is required" ValidationGroup="form_view_validate">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-2" style="padding: 0px; margin-right: 0px;">
                        <div class="input-group">
                            <asp:TextBox ID="txtEmpLName" CssClass="form-control" runat="server" Text='<%# Bind("Emp_LName") %>' PlaceHolder="Last Name" />
                            <div class="input-group-addon">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtEmpLName" CssClass="text-danger" Display="Dynamic" ErrorMessage="Last Name is required" ValidationGroup="form_view_validate">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    </div>
                    <div class="col-sm-2" style="padding: 0px; margin-right: 0px;">
                        <div class="input-group">
                            <asp:TextBox ID="txtEmpPosition" CssClass="form-control" runat="server" Text='<%# Bind("Emp_Position") %>' PlaceHolder="Position" />
                            <div class="input-group-addon">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtEmpPosition" CssClass="text-danger" Display="Dynamic" ErrorMessage="Position is required" ValidationGroup="form_view_validate">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-2" style="padding: 0px; margin-right: 0px;">
                        <div class="input-group">
                            <asp:TextBox ID="txtEmpCommission" CssClass="form-control" runat="server" Text='<%# Bind("Emp_Commission") %>' PlaceHolder="Commission" />
                            <div class="input-group-addon">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtEmpCommission" CssClass="text-danger" Display="Dynamic" ErrorMessage="Commission is required" ValidationGroup="form_view_validate">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtEmpCommission" CssClass="text-danger" Display="Dynamic" ErrorMessage="Commission must be decimal or percent" Operator="DataTypeCheck" Type="Double" ValidationGroup="edit">*</asp:CompareValidator>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-2">
                        <asp:Button CssClass="btn btn-primary" ID="btnFrmViewEmployeeInsert" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" ValidationGroup="form_view_validate" />
                        <asp:Button CssClass="btn btn-default" ID="btnFrmViewEmployeeCancelInsert" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                    </div>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Button ID="btnFrmViewEmployeeNew" CssClass="btn btn-primary" runat="server" CausesValidation="False" CommandName="New" Text="New Employee" />
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
            <asp:GridView ID="grdviewEmpInfo" runat="server" CssClass="table table-bordered table-striped table-condensed" AutoGenerateColumns="False" DataSourceID="EntityEmployees" AllowSorting="True" OnPreRender="grdviewEmpInfo_PreRender" OnRowDataBound="grd_RowDataBound" OnRowUpdated="grdviewEmpInfo_RowUpdated" OnRowDeleted="grdviewEmpInfo_RowDeleted">
                <Columns>
                    <asp:BoundField DataField="Emp_ID" ReadOnly="true" HeaderText="Employee ID" SortExpression="Emp_ID" HeaderStyle-CssClass="col-sm-1"></asp:BoundField>
                    <asp:TemplateField HeaderText="Employee Name" SortExpression="Emp_FName" HeaderStyle-CssClass="col-sm-3">
                        <EditItemTemplate>
                            <div class="form-row">
                                <div class="input-group">
                                    <asp:TextBox ID="grdEmpFirstName" CssClass="form-control" runat="server" Text='<%# Bind("Emp_FName") %>' PlaceHolder="First Name"></asp:TextBox>
                                    <div class="input-group-addon">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="grdEmpFirstName" CssClass="text-danger" Display="Dynamic" ErrorMessage="First Name is required" ValidationGroup="edit">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="input-group">
                                    <asp:TextBox ID="grdEmpLastName" CssClass="form-control" runat="server" Text='<%# Bind("Emp_LName") %>' PlaceHolder="Last Name"></asp:TextBox>
                                    <div class="input-group-addon">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="grdEmpLastName" CssClass="text-danger" Display="Dynamic" ErrorMessage="Last Name is required" ValidationGroup="edit">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Emp_FName") %>'></asp:Label>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("Emp_LName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Employee Position" SortExpression="Emp_Position" HeaderStyle-CssClass="col-sm-3">
                        <EditItemTemplate>
                            <div class="input-group">
                                <asp:TextBox ID="grdEmpPosition" CssClass="form-control" runat="server" Text='<%# Bind("Emp_Position") %>' PlaceHolder="Position"></asp:TextBox>
                                <div class="input-group-addon">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="grdEmpPosition" CssClass="text-danger" Display="Dynamic" ErrorMessage="Position is required" ValidationGroup="edit">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("Emp_Position") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Employee Commission" SortExpression="Emp_Commission" HeaderStyle-CssClass="col-sm-2">
                        <EditItemTemplate>
                            <div class="input-group">
                                <asp:TextBox ID="grdEmpCommission" CssClass="form-control" runat="server" Text='<%# Bind("Emp_Commission") %>' PlaceHolder="Commission"></asp:TextBox>
                                <div class="input-group-addon">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="grdEmpCommission" CssClass="text-danger" Display="Dynamic" ErrorMessage="Commission is required" ValidationGroup="edit">*</asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" CssClass="text-danger" Display="Dynamic" ErrorMessage="Commission must be decimal or percent" Operator="DataTypeCheck" Type="Double" ValidationGroup="edit" ControlToValidate="grdEmpCommission">*</asp:CompareValidator>
                                </div>
                            </div>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("Emp_Commission", "{0:P}") %>'></asp:Label>
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
            <asp:EntityDataSource ID="EntityEmployees" runat="server" ConnectionString="name=MGO_Entities" DefaultContainerName="MGO_Entities" EntitySetName="Employees" EnableInsert="true" EnableUpdate="true" EnableDelete="true">
            </asp:EntityDataSource>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-12">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="text-danger" HeaderText="Please Correct the following errors:" ValidationGroup="edit" />
            <asp:Label ID="lblErrorMessage" runat="server" CssClass="text-danger" EnableViewState="false"></asp:Label>
        </div>
    </div>
</asp:Content>
