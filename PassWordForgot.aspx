<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PassWordForgot.aspx.cs" Inherits="EagleLife.PassWordForgot" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:PasswordRecovery ID="PasswordRecovery1" runat="server" Height="176px" OnSendingMail="PasswordRecovery1_SendingMail" Width="434px">
            </asp:PasswordRecovery>
        </div>
        <asp:Button ID="Button1" runat="server" Height="33px" OnClick="Button1_Click" Text="Go Back!" Width="116px" />
    </form>
</body>
</html>
