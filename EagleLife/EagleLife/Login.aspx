<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EagleLife.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 128px;
        }
    </style>
</head>
 <body>
<form runat ="server" id="Login" >
         <asp:Label ID="Label3" runat="server" Text="Young Life Admin Login" Font-Bold="true" Font-Size="XX-Large"></asp:Label>
       <table style="height: 149px; width: 321px" >
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Username:"></asp:Label></td>
                    <td class="auto-style1">
                        <asp:TextBox ID="txtUsername" autocomplete="off" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Password:"></asp:Label></td>
                    <td class="auto-style1">
                        <asp:TextBox ID="txtPassword" AutoComplete="off" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td class="auto-style1">
                        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" /></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Label ID="lblLoginError" runat="server" Text="Incorrect User Credentials" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </table>
    </form>
</body>
</html>
