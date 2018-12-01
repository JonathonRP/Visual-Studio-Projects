<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Payroll.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Payroll Calculator</title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }

        .auto-style2 {
            font-size: large;
        }

        .auto-style3 {
            width: 119px;
        }
        .auto-style4 {
            width: 119px;
            height: 30px;
        }
        .auto-style5 {
            height: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <span class="auto-style2"><strong>Payroll Calculator </strong></span>
            <br />
            <br />
            <table class="auto-style1">
                <tr>
                    <td class="auto-style4">Hours worked</td>
                    <td class="auto-style5">
                        <asp:TextBox ID="txtHours" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtHours" Display="Dynamic" ErrorMessage="Hours Worked is required" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtHours" Display="Dynamic" ErrorMessage="Hours Worked must be between 1 and 40" ForeColor="Red" MaximumValue="40" MinimumValue="1" Type="Double"></asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">Pay Rate</td>
                    <td>
                        <asp:TextBox ID="txtPayRate" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPayRate" Display="Dynamic" ErrorMessage="Pay Rate is required" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtPayRate" Display="Dynamic" ErrorMessage="Pay Rate must be numeric" ForeColor="Red" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">Gross Pay</td>
                    <td>
                        <asp:Label ID="lblGrossPay" runat="server" EnableViewState="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Button ID="btnCalculate" runat="server" Text="Calculate" OnClick="btnCalculate_Click" />
                    </td>
                    <td>
                        <asp:Button ID="Clear" runat="server" CausesValidation="False" OnClick="Clear_Click" Text="Clear" />
                    </td>
                </tr>
            </table>
            <br />
        </div>
    </form>
</body>
</html>
