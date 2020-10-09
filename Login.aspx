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
            height: 258px;
            width: 508px;
        }
        .auto-style3 {
            width: 131px;
        }
    </style>
</head>
 <body>
<form runat ="server" id="Login" >
         <asp:Label ID="Label3" runat="server" Text="Young Life Admin Login" Font-Bold="true" Font-Size="XX-Large"></asp:Label>
       <table class="auto-style2" >
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="Label1" runat="server" Text="Username:"></asp:Label></td>
                    <td class="auto-style1">
                        <asp:TextBox ID="txtUsername" autocomplete="off" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="Label2" runat="server" Text="Password:"></asp:Label>
                        <br />
                        <br />
                        <asp:LinkButton ID="LinkButton2" runat="server" OnClick="ChangeLnk_Click">Need to Change Password?</asp:LinkButton>
                    </td>
                    <td class="auto-style1">
                        <asp:TextBox ID="txtPassword" AutoComplete="off" runat="server"></asp:TextBox>
                        <br />
                        <br />
                        <asp:LinkButton ID="ForgotLnk" runat="server" OnClick="ForgotLnk_Click">Forgot Password?</asp:LinkButton>
&nbsp;&nbsp;&nbsp;&nbsp; </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:CheckBox ID="chkRmb" runat="server" OnCheckedChanged="chkRmb_CheckedChanged" Text="Remember Me!" />
                    </td>
                    <td class="auto-style1">
                        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" /></td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="lblDatafill" runat="server" ForeColor="Red" Text="Missing Input. Please fill out all boxes!"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblLoginError" runat="server" Text="Incorrect User Credentials" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </table>
         <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:EagleLifeDBConnectionString %>" SelectCommand="SELECT [AdminUser], [AdminPass] FROM [AdminLogin]"></asp:SqlDataSource>
    </form>
</body>
</html>
