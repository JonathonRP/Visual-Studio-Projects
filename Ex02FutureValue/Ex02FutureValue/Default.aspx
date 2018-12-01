<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Ex02FutureValue.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Chapter 2: Future Value</title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 170px;
        }
    </style>
</head>
<body>
    <img src="Images/MurachLogo.jpg" alt="Murach Logo" />
    <h1>401K Future Value Calculator</h1>
    <form id="form1" runat="server">
        <div>

            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">Monthly Investment</td>
                    <td>
                        <asp:DropDownList ID="ddlMonthlyInvestment" runat="server" style="margin-left: 0px" Width="90px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Annual Interest Rate</td>
                    <td>
                        <asp:TextBox ID="txtInterestRate" runat="server" Width="90px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Number of Years</td>
                    <td>
                        <asp:TextBox ID="txtYears" runat="server" Width="90px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Future Value</td>
                    <td>
                        <asp:Label ID="lblFutureValue" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Button ID="btnCalculate" runat="server" Text="Calculate" Width="10em" OnClick="btnCalculate_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnClear" runat="server" Text="Clear" Width="10em" CausesValidation="False" OnClick="btnClear_Click" />
                    </td>
                </tr>
            </table>

        </div>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtInterestRate" Display="Dynamic" ErrorMessage="Interest Rate is required" ForeColor="Red"></asp:RequiredFieldValidator>
        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtInterestRate" Display="Dynamic" ErrorMessage="Interest Rate must be from 1 to 20" ForeColor="Red" MaximumValue="20" MinimumValue="1" Type="Double"></asp:RangeValidator>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtYears" Display="Dynamic" ErrorMessage="Number of Years is required" ForeColor="Red"></asp:RequiredFieldValidator>
        <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtYears" Display="Dynamic" ErrorMessage="Number of Yers must be from 1 to 45" ForeColor="Red" MaximumValue="45" MinimumValue="1" Type="Integer"></asp:RangeValidator>
    </form>
</body>
</html>
