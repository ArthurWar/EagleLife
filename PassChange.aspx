<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PassChange.aspx.cs" Inherits="EagleLife.PassWordChange" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ChangePassword ID="ChangePassword1" runat="server" autocomplete="off" CancelDestinationPageUrl="~/Login.aspx" ChangePasswordPageUrl="~/Login.aspx" DisplayUserName="True" Height="230px" OnChangedPassword="ChangePassword1_ChangedPassword" Width="495px">
            </asp:ChangePassword>
             <asp:Label ID="lblSuccess" runat="server" ForeColor="Green" Text="Password changed successfully!"></asp:Label>
            <br />
            <asp:Label ID="lblChange" runat="server" ForeColor="Red" Text="Old Password and new password must be different. "></asp:Label>
        </div>
    </form>
</body>
</html>
