<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PasswordForgot.aspx.cs" Inherits="EagleLife.PasswordForgot" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 172px">
    <form id="form1" runat="server">
        <div>
        </div>
        <br />
        <asp:PasswordRecovery ID="PasswordRecovery1" runat="server" OnSendingMail="PasswordRecovery1_SendingMail" Height="192px" SuccessPageUrl="~/Login.aspx" Width="459px">
        </asp:PasswordRecovery>
        <p>
            &nbsp;</p>
        <p>
            <asp:Button ID="btmBack" runat="server" OnClick="btmBack_Click" Text="Go Back!" />
        </p>
    </form>
</body>
</html>
