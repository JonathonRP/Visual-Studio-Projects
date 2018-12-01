<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Request.aspx.cs" Inherits="XEx11Reservation.Request" 
    MasterPageFile="~/Site.Master" %>

    <asp:Content runat="server" ContentPlaceHolderID="mainPlaceHolder">
        <h1>Reservation Request</h1>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="* means that the field is required" CssClass="text-danger" />

        <h3>Request data</h3>
        <div class="form-group">
            <label class="col-sm-3 control-label">Arrival Date</label>
            <div class="col-sm-4">
                <asp:TextBox ID="txtArrivalDate" runat="server" TextMode="DateTime"
                        CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-sm-5">
                <asp:RequiredFieldValidator ID="rfvArrivalDate" runat="server" 
                    ControlToValidate="txtArrivalDate" text="*" CssClass="text-danger" Display="Dynamic">
                </asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cvArrivalDate" runat="server" Text="Must be a valid date" CssClass="text-danger"
                    Display="Dynamic" ControlToValidate="txtArrivalDate" Type="Date" Operator="DataTypeCheck">
                </asp:CompareValidator>
            </div>

        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label">Departure Date</label>
            <div class="col-sm-4">
                <asp:TextBox ID="txtDepartureDate" runat="server" TextMode="DateTime"
                        CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-sm-5">
                <asp:RequiredFieldValidator ID="rfvDepartureDate" runat="server" 
                    ControlToValidate="txtDepartureDate" text="*" CssClass="text-danger" Display="Dynamic">
                </asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cvDepartureDate" runat="server" 
                    ControlToValidate="txtDepartureDate" ControlToCompare="txtArrivalDate" Type="Date" 
                    text="Must be after arrival date" Operator="GreaterThan" 
                    Display="Dynamic"  CssClass="text-danger">
                </asp:CompareValidator><br />
            </div>
        </div>

        <div class="form-group">
            <label class="col-sm-3 control-label">Number of people</label>
            <div class="col-sm-4">
                <asp:DropDownList ID="ddlNoOfPeople" runat="server" CssClass="form-control">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label">Bed type</label>
            <div class="col-sm-9">
                <label class="radio-inline"><asp:RadioButton ID="rdoKing" runat="server" Text="King" GroupName="Bed" /></label>
                <label class="radio-inline"><asp:RadioButton ID="rdoDouble" runat="server" Text="Two Queens" GroupName="Bed" /></label>
                <label class="radio-inline"><asp:RadioButton ID="rdoSingle" runat="server" Text="One Queen" GroupName="Bed" /></label>
            </div>
        </div>

        <h3>Special requests</h3>
        <div class="form-group">
            <div class="col-sm-7">
                <asp:TextBox ID="txtSpecialRequests" runat="server" TextMode="Multiline"
                        Rows="4" CssClass="form-control"></asp:TextBox>
            </div>
        </div>

        <h3>Contact information</h3>
        <div class="form-group">
            <label class="col-sm-3 control-label">First Name</label>
            <div class="col-sm-4">
                <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-sm-5">
                <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" 
                    ControlToValidate="txtFirstName" text="*" CssClass="text-danger" Display="Dynamic">
                </asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="form-group">
            <label class="col-sm-3 control-label">Last Name</label>
            <div class="col-sm-4">
                <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-sm-5">
                <asp:RequiredFieldValidator ID="rfvLastName" runat="server" 
                    ControlToValidate="txtLastName" text="*" CssClass="text-danger" Display="Dynamic">
                </asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="form-group">
            <label class="col-sm-3 control-label">Email address</label>
            <div class="col-sm-4">
                <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" 
                    CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-sm-5">
                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" 
                    ControlToValidate="txtEmail" text="*" CssClass="text-danger" Display="Dynamic">
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revEmail" runat="server" 
                    ControlToValidate="txtEmail" Text="Must be valid email address" 
                    Display="Dynamic" CssClass="text-danger"
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                </asp:RegularExpressionValidator>
            </div>

        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label">Telephone number</label>
            <div class="col-sm-4">
                <asp:TextBox ID="txtPhone" runat="server" TextMode="Phone" 
                    CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-sm-5">
                <asp:RequiredFieldValidator ID="rfvPhone" runat="server" 
                    ControlToValidate="txtPhone" text="*" CssClass="text-danger" Display="Dynamic">
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revPhone" runat="server" 
                    ControlToValidate="txtPhone" Text="Use this format: 999-999-9999"
                    Display="Dynamic" CssClass="text-danger" 
                    ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}">
                </asp:RegularExpressionValidator>    
            </div>
        </div>

        <div class="form-group">
            <label class="col-sm-3 control-label">Preferred method</label>
            <div class="col-sm-4">
                <asp:DropDownList ID="ddlPreferredMethod" runat="server" CssClass="form-control">
                    <asp:ListItem>Email</asp:ListItem>
                    <asp:ListItem>Telephone</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>

        <%-- Submit and Clear buttons --%>
        <div class="form-group">
            <div class="col-sm-offset-3 col-sm-9">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit"
                        CssClass="btn btn-primary" OnClick="btnSubmit_Click"  />
                <asp:Button ID="btnClear" runat="server" Text="Clear"
                        CssClass="btn btn-primary" OnClick="btnClear_Click" CausesValidation="false"  />
            </div>
        </div> 
            
        <%-- message label --%>
        <div class="form-group">
            <div class="col-sm-offset-1 col-sm-11">
                <asp:Label ID="lblMessage" runat="server" CssClass="text-info"></asp:Label>
            </div>
        </div>
    </asp:Content>