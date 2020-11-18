<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PassForgot.aspx.cs" Inherits="EagleLife.PassWordForgot" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="vertical-align:middle; text-align: center;">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/title_small.png" />
            <br />
            <asp:Label ID="Label1" runat="server" Font-Size="XX-Large" Text="Password Recovery" Font-Bold="True"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Font-Size="X-Large" Text="Please enter your Admin Email Address:"></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="txtEmail" autocomplete="off" runat="server" Width="350px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnSend" runat="server" Text="Send Email" Width="120px" OnClick="btnSend_Click1" autocomplete ="off"/>
            <br />
            <br />
            <asp:TextBox ID="txtCode" autocomplete="off" runat="server" Width="261px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnVerify" runat="server" CssClass="auto-style1" OnClick="btnVerify_Click" Text="Verify Code" Width="90px" />
            <br />
            <asp:Label ID="lblSent" runat="server" ForeColor="Green" Text="Verification code has been sent to your email address."></asp:Label>
            &nbsp;<asp:Label ID="lblcode" runat="server" ForeColor="Green" Text="Code Verified!"></asp:Label>
            <br />
            <asp:Label ID="lblincode" runat="server" ForeColor="Red" Text="Code is Incorrect!"></asp:Label>
            &nbsp;<asp:Label ID="lblWrong" runat="server" ForeColor="Red" Text="This email address does not match our records or cannot be found. "></asp:Label>
            <asp:Label ID="lblMissing" runat="server" ForeColor="Red" Text="Please Fill in the email Address box."></asp:Label>
            <br />
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Back to Login</asp:LinkButton>
            </div>
    </form>
</body>
</html>
