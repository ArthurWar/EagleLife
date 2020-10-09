<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PassWordChange.aspx.cs" Inherits="EagleLife.PassWordChange" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 214px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <asp:ChangePassword ID="ChangePassword1" runat="server" OnChangedPassword="ChangePassword1_ChangedPassword" CancelButtonImageUrl="~/Login.aspx" ChangePasswordButtonImageUrl="~/Login.aspx" DisplayUserName="True">
            </asp:ChangePassword>
            <asp:Label ID="lblChange" runat="server" ForeColor="Red" Text="Old Password and new password must be different. "></asp:Label>
        </div>
    </form>
</body>
</html>
