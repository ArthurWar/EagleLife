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
        <asp:PasswordRecovery ID="PasswordRecovery1" runat="server" OnSendingMail="PasswordRecovery1_SendingMail">
        </asp:PasswordRecovery>
    </form>
</body>
</html>
