<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EagleLife.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 128px;
        }
        .auto-style2 {
            height: 42px;
        }
        .auto-style3 {
            width: 128px;
            height: 42px;
        }
        .auto-style4 {
            height: 256px;
            width: 396px;
        }
    </style>
</head>
 <body>
<form runat ="server" id="Login" >
         <asp:Label ID="Label3" runat="server" Text="Young Life Admin Login" Font-Bold="true" Font-Size="XX-Large"></asp:Label>
       <table class="auto-style4" >
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
                    <td>
                        <asp:LinkButton ID="Changelink" runat="server" OnClick="ChangeLink_Click">Need to Change Password ?</asp:LinkButton>
                    </td>
                    <td class="auto-style1">
                        <asp:LinkButton ID="ForgotLink" runat="server" OnClick="ForgotLink_Click">Forgot Password?</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:CheckBox ID="chkRmb" runat="server" Text=" Remember Me!" OnCheckedChanged="chkRmb_CheckedChanged" />
                    </td>
                    <td class="auto-style3">
                        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" /></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblDataFill" runat="server" ForeColor="Red" Text="Missing Input! Please fill out all  boxes."></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblLoginError" runat="server" Text="Incorrect User Credentials" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </table>
         <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:EagleLifeDBConnectionString %>" SelectCommand="SELECT [AdminUserName], [AdminPassWord] FROM [AdminLogin]"></asp:SqlDataSource>
         <br />
    </form>
</body>
</html>
