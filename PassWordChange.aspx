<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PassWordChange.aspx.cs" Inherits="EagleLife.PassWordChange" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 241px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <asp:ChangePassword ID="ChangePassword1" runat="server" autocomplete="off" OnChangedPassword="ChangePassword1_ChangedPassword" CancelButtonImageUrl="~/Login.aspx" ChangePasswordButtonImageUrl="~/Login.aspx" DisplayUserName="True" CancelDestinationPageUrl="~/Login.aspx" ContinueDestinationPageUrl="~/Login.aspx" ChangePasswordFailureText="Password incorrect or New Password invalid. New Password length minimum: {0}. Non-alphanumeric characters required: {1)." ContinueButtonImageUrl="~/Login.aspx" Height="284px" Width="503px">
            </asp:ChangePassword>
            <asp:Label ID="lblSuccess" runat="server" ForeColor="Green" Text="Password changed successfully!"></asp:Label>
            <br />
            <asp:Label ID="lblChange" runat="server" ForeColor="Red" Text="Old Password and new password must be different. "></asp:Label>
        </div>
    </form>
</body>
</html>
