<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PassReset.aspx.cs" Inherits="EagleLife.PassWordReset" %>

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
    <form id="form1" runat="server">
        <div style="vertical-align:middle; text-align: center;">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/title_small.png" />
            <br />
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="XX-Large" Font-Underline="True" Text="Password Reset"></asp:Label>
            
            
            <br />
            
            
            <br />
       <table align="center" width="30%" class="auto-style4" >
                <tr>
                    <td class="auto-style5">
                        <asp:Label ID="Label3" runat="server" Text="Username:"></asp:Label>
                        </td>
                    <td class="auto-style5">
        <asp:TextBox ID="txtUser" runat="server" AutoComplete="off"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">
                        <asp:Label ID="Label4" runat="server" Text="New Password:"></asp:Label>
                    </td>
                    <td class="auto-style5">
        <asp:TextBox ID="txtNew" runat="server" AutoComplete="off"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">
                        <asp:Label ID="Label5" runat="server" Text="Confirm Password:"></asp:Label>
                    </td>
                    <td class="auto-style5">
       <asp:TextBox ID="txtConfirm" runat="server"  AutoComplete="off"></asp:TextBox>
                        </td>
                </tr>
                </table>
            <br />
            <asp:Button ID="btnReset" runat="server" OnClick="btnReset_Click" Text="Reset" />
            <br />
            <asp:Label ID="lblSuccess" runat="server" Font-Size="Large" ForeColor="Green" Text="Password has successfully been reset!"></asp:Label>
            <br />
            <asp:Label ID="lblIncorrect" runat="server" ForeColor="Red" Text="Incorrect Username."></asp:Label>
            <br />
            <asp:Label ID="lblEmpty" runat="server" ForeColor="Red" Text="Please fill out the Username field."></asp:Label>
            <br />
            <asp:Label ID="lblMatch" runat="server" ForeColor="Red" Text="New Password and Confirm Password must match!"></asp:Label>
            <br />
            <asp:Label ID="lblLength" runat="server" ForeColor="Red" Text="New Password must be at least six characters long!"></asp:Label>
            <br />
            <br />
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Back to Login</asp:LinkButton>
            <br />
            <hr />
            Created in association with<br />
            <asp:Image ID="Image3" runat="server" Height="25%" ImageUrl="~/Images/YL-Altrnt-Hrzntl-White.png" Width="25%" />
        </div>
    </form>
</body>
</html>
