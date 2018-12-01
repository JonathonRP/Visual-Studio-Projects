<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Ex03FutureValue.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Chapter 2: Future Value</title>
</head>
<body>
    <header>
        <img src="Images/MurachLogo.jpg" alt="Murach Logo" /><h1>401K Future Value Calculator</h1>
    </header>

    <main>
        <form id="form1" class="form-horizontal" runat="server">

            <%--Monthly investment--%>
            <label for="ddlMonthlyInvestment">Monthly Investment:</label>
            <asp:DropDownList ID="ddlMonthlyInvestment" runat="server" CssClass="entry">
            </asp:DropDownList>
            <br />

            <%--Annual interest rate--%>
            <label for="txtInterestRate">Annual Interest Rate:</label>
            <asp:TextBox ID="txtInterestRate" runat="server" Text="3" CssClass="entry"></asp:TextBox>
            <%--Validators--%>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Interest rate is required" ControlToValidate="txtInterestRate" Display="Dynamic" ForeColor="Red" CssClass="validator"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="RangeValidator3" runat="server" ErrorMessage="Interest rate must range from 1 to 20" ControlToValidate="txtInterestRate" Display="Dynamic" ForeColor="Red" MaximumValue="20" MinimumValue="1" Type="Integer" CssClass="validator"></asp:RangeValidator>
            <br />

            <%--Number of years--%>
            <label for="txtYears">Number of Years:</label>
            <asp:TextBox ID="txtYears" runat="server" CssClass="entry">10</asp:TextBox>
            <%--Validators--%>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Number of years is required" ControlToValidate="txtYears" Display="Dynamic" ForeColor="Red" CssClass="validator"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="Years must range from 1 to 45" ControlToValidate="txtYears" Display="Dynamic" ForeColor="Red" MaximumValue="45" MinimumValue="1" Type="Integer" CssClass="validator"></asp:RangeValidator>
            <br />

            <%--Future value--%>
            <label for="lblFutureValue">Future Value:</label>
            <asp:Label ID="lblFutureValue" runat="server"></asp:Label>
            <br />

            <%--Buttons--%>
            <asp:Button ID="btnCalculate" runat="server" Text="Calculate" Width="103px" OnClick="btnCalculate_Click" CssClass="button" />
            <asp:Button ID="btnClear" runat="server" CausesValidation="False" Text="Clear" Width="103px" OnClick="btnClear_Click" CssClass="button" />
        </form>
    </main>
</body>
</html>
