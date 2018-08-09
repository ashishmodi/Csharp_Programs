<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BankingQueue.aspx.cs" Inherits="BankQueueSystem_WebForm.BankingQueue" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bank Queue System</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="border:solid; font-family:Arial; text-align:center">
            <tr>
                <td> <b>Counter 1</b></td>
                <td></td>
                <td><b>Counter 2</b></td>
                <td></td>
                <td><b>Counter 3</b></td>
            </tr>
            <tr>
                <td> <asp:TextBox ID="txtCounter1" runat="server" /> </td>
                <td></td>
                <td> <asp:TextBox ID="txtCounter2" runat="server" /> </td>
                <td></td>
                <td> <asp:TextBox ID="txtCounter3" runat="server" /> </td>
            </tr>
            <tr>
                <td> <asp:Button ID="btnCounter1" Text="Next" runat="server" OnClick="btnCounter1_Click" /></td>
                <td></td>
                <td> <asp:Button ID="btnCounter2" Text="Next" runat="server" OnClick="btnCounter2_Click" /></td>
                <td></td>
                <td> <asp:Button ID="btnCounter3" Text="Next" runat="server" OnClick="btnCounter3_Click" /></td>
            </tr>
            <tr>
                <td colspan="5"> <asp:TextBox ID="txtUserMessage" Width="500px" runat="server" BackColor="#339933" ForeColor="White" Font-Size="Large" /> </td>
            </tr>
            <tr> <td colspan="5"> <asp:ListBox ID="lstTokens" runat="server" Width="150px" /> </td> </tr>
            <tr> <td colspan="5"> <asp:Button ID="btnPrintToken" Text="Print token" runat="server" OnClick="btnPrintToken_Click" /></td></tr>
            <tr> <td colspan="5"> <asp:Label ID="lblPendingTokens" runat="server" /></td></tr>
        </table>
    </div>
    </form>
</body>
</html>
