<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Jonathon_Perry_XEx02QuotationBootstrap.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Price Quotation</title>
    <meta name="viewport" content="width=device-width, intial-scale=1" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/site.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.3.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
</head>
<body>
    <main class="container">
        <h1 class="jumbotron">Price Quotation</h1>

        <form id="form1" class="form-horizontal" runat="server">

            <%--Sales Price:--%>
            <div class="form-group">
                <label class="col-md-3 control-label" for="txtSalesPrice">Sales Price:</label>
                <div class="col-md-3">
                    <asp:TextBox ID="txtSalesPrice" CssClass="form-control bold" runat="server"></asp:TextBox>
                </div>
                <%--Validators--%>
                <div class="col-md-6">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="text-danger" runat="server" ControlToValidate="txtSalesPrice" Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="RangeValidator1" runat="server" CssClass="text-danger" ControlToValidate="txtSalesPrice" Display="Dynamic" ErrorMessage="must be between 10 and 1000" MaximumValue="1000" MinimumValue="10" Type="Double"></asp:RangeValidator>
                </div>
            </div>

            <%--Discount Percent:--%>
            <div class="form-group">
                <label class="col-md-3 control-label" for="txtDiscountPercent">Discount Percent:</label>
                <div class="col-md-3">
                    <asp:TextBox ID="txtDiscountPercent" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <%--Validators--%>
                <div class="col-md-6">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="text-danger" runat="server" ControlToValidate="txtDiscountPercent" Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="RangeValidator2" runat="server" CssClass="text-danger" ControlToValidate="txtDiscountPercent" Display="Dynamic" ErrorMessage="must be between 10 and 50" MaximumValue="50" MinimumValue="10" Type="Double"></asp:RangeValidator>
                </div>
            </div>

            <%--Discount Amount:--%>
            <div class="form-group">
                <label class="col-md-3 control-label" for="lblDiscountAmount">Discount Amount:</label>
                <div class="col-md-3">
                    <asp:Label ID="lblDiscountAmount" CssClass="form-control bold" runat="server" EnableViewState="False"></asp:Label>
                </div>
            </div>

            <%--Total Price:--%>
            <div class="form-group">
                <label class="col-md-3 control-label" for="lblTotalPrice">Total Price:</label>
                <div class="col-md-3">
                    <asp:Label ID="lblTotalPrice" CssClass="form-control bold" runat="server" EnableViewState="False"></asp:Label>
                </div>
            </div>

            <%--Buttons:--%>
            <div class="col-md-offset-3 col-md-9">
                <asp:Button ID="btnCalculate" CssClass="btn btn-primary" runat="server" Text="Calculate" OnClick="btnCalculate_Click" />
                <asp:Button ID="btnClear" CssClass="btn btn-primary" runat="server" Text="Clear" CausesValidation="False" OnClick="btnClear_Click" />
            </div>

        </form>
    </main>
</body>
</html>
