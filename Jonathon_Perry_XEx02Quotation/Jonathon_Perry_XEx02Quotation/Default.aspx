<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Jonathon_Perry_XEx02Quotation.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Price Quotation</title>
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
    <h1>
        Price Quotation
    </h1>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">Sales Price:</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txtSalesPrice" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSalesPrice" Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtSalesPrice" Display="Dynamic" ErrorMessage="must be between 10 and 1000" ForeColor="Red" MaximumValue="1000" MinimumValue="10" Type="Double"></asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">Discount Percent:</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txtDiscountPercent" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDiscountPercent" Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtDiscountPercent" Display="Dynamic" ErrorMessage="must be between 10 and 50" ForeColor="Red" MaximumValue="50" MinimumValue="10" Type="Double"></asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Discount Amount:</td>
                    <td class="auto-style2">
                        <asp:Label ID="lblDiscountAmount" runat="server" EnableViewState="False" Font-Bold="True"></asp:Label>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">Total Price:</td>
                    <td class="auto-style2">
                        <asp:Label ID="lblTotalPrice" runat="server" EnableViewState="False" Font-Bold="True"></asp:Label>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Button ID="btnCalculate" runat="server" Text="Calculate" OnClick="btnCalculate_Click"/>
                    </td>
                    <td class="auto-style2">
                        <asp:Button ID="btnClear" runat="server" Text="Clear" CausesValidation="False" OnClick="btnClear_Click" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
