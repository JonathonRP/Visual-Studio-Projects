<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Sol02FutureValue.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Chapter 2: Future Value</title>
    <meta name="viewport" content="width=device-width, intial-scale=1" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/site.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.3.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
</head>
<body>
    <div class="container">
        <header class="jumbotron">
            <img src="Images/MurachLogo.jpg" class="img-rounded img-responsive" alt="Murach Logo" /><h1>401K Future Value Calculator</h1>

        </header>
        <main>
            <form id="form1" class="form-horizontal" runat="server">

                <%--Monthly Investment Row--%>
                <div class="form-group">
                    <label class="col-md-3 control-label" for="ddlMonthlyInvestment">Monthly investment</label>
                    <div class="col-md-3">
                        <asp:DropDownList ID="ddlMonthlyInvestment" CssClass="form-control" runat="server">
                        </asp:DropDownList>
                    </div>
                </div>

                <%--Interest Rate Row--%>
                <div class="form-group">
                    <label class="col-md-3 control-label" for="txtInterestRate">Annual interest rate</label>
                    <div class="col-md-3">
                        <asp:TextBox ID="txtInterestRate" CssClass="form-control" runat="server" Text="3"></asp:TextBox>
                    </div>
                    <%--Validators--%>
                    <div class="col-md-6">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="text-danger" runat="server" ErrorMessage="Interest rate is required" ControlToValidate="txtInterestRate" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="RangeValidator1" CssClass="text-danger" runat="server" ErrorMessage="Interest rate must range from 1 to 20" ControlToValidate="txtInterestRate" Display="Dynamic" MaximumValue="20" MinimumValue="1" Type="Integer"></asp:RangeValidator>
                    </div>
                </div>

                <%--Years Row--%>
                <div class="form-group">
                    <label class="col-md-3 control-label" for="txtYears">Number of years</label>
                    <div class="col-md-3">
                        <asp:TextBox ID="txtYears" CssClass="form-control" runat="server">10</asp:TextBox>
                    </div>
                    <%--Validators--%>
                    <div class="col-md-6">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="text-danger" runat="server" ErrorMessage="Number of years is required" ControlToValidate="txtYears" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="RangeValidator2" CssClass="text-danger" runat="server" ErrorMessage="Years must range from 1 to 45" ControlToValidate="txtYears" Display="Dynamic" MaximumValue="45" MinimumValue="1" Type="Integer"></asp:RangeValidator>
                    </div>
                </div>

                <%--Future Value Row--%>
                <div class="form-group">
                    <label class="col-md-3 control-label" for="lblFutureValue">Future value</label>
                    <div class="col-md-3">
                        <asp:Label ID="lblFutureValue" CssClass="text-info bold" runat="server"></asp:Label>
                    </div>
                </div>

                <%--Buttons Row--%>
                <div class="col-md-offset-3 col-md-9">
                    <asp:Button ID="btnCalculate" CssClass="btn btn-primary" runat="server" Text="Calculate" Width="103px" OnClick="btnCalculate_Click" />
                    <asp:Button ID="btnClear" CssClass="btn btn-primary" runat="server" CausesValidation="False" Text="Clear" Width="103px" OnClick="btnClear_Click" />
                </div>

            </form>
        </main>
    </div>
</body>
</html>
