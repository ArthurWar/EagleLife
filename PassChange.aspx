<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PassChange.aspx.cs" Inherits="EagleLife.PassWordChange" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style4 {
            height: 289px;
            width: 449px;
        }
        .auto-style5 {
            width: 194px;
        }
        </style>
</head>
<body>
    <form id="form1"  runat="server">
        <div style="vertical-align:middle; text-align: center;">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/title_small.png" />
            <br />
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="XX-Large" Font-Underline="True" Text="Change Password"></asp:Label>
            
            
            <br />
       <table align="center" width="30%" class="auto-style4" >
                <tr>
                    <td class="auto-style5">
                        <asp:Label ID="Label3" runat="server" Text="Username:"></asp:Label></td>
                    <td class="auto-style5">
        <asp:TextBox ID="txtUser" runat="server" AutoComplete="off"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">
                        <asp:Label ID="Label2" runat="server" Text="Current Password:"></asp:Label></td>
                    <td class="auto-style5">
        <asp:TextBox ID="txtCurrent" TextMode="Password" runat="server" AutoComplete="off"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">
                        <asp:Label ID="Label4" runat="server" Text="New Password:"></asp:Label>
                    </td>
                    <td class="auto-style5">
        <asp:TextBox ID="txtNew" TextMode="Password" runat="server" AutoComplete="off"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">
                        <asp:Label ID="Label5" runat="server" Text="Confirm Password:"></asp:Label>
                    </td>
                    <td class="auto-style5">
       <asp:TextBox ID="txtConfirm" TextMode="Password" runat="server"  AutoComplete="off"></asp:TextBox>
                        </td>
                </tr>
                <tr>
                    <td>
        <asp:Label ID="lblError" runat="server" Font-Size="Medium" ForeColor="Red"></asp:Label>
                    </td>
                    <td>
        <asp:Label ID="lblChange" runat="server" Font-Size="Large" ForeColor="#00CC00" Text="Password Changed!"></asp:Label>
                        </td>
                </tr>
            </table>
            <br />
        <asp:Button ID="btnChange" runat="server" Text="Confirm" OnClick="btnChange_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="BtnCncl" runat="server" Text="Back to Login" OnClick="BtnCncl_Click" />
        </div>
    </form>
</body>
</html>
