<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PassForgot.aspx.cs" Inherits="EagleLife.PassWordForgot" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             &nbsp;<asp:Label ID="Label1" runat="server" Font-Size="XX-Large" Text="Password Recovery"></asp:Label>
            <br />
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Font-Size="X-Large" Text="Please enter your Admin Email Address;"></asp:Label>
&nbsp;<br />
            <br />
            <asp:TextBox ID="txtEmail" autocomplete="off" runat="server" Height="28px" Width="383px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtCode" autocomplete="off" runat="server" Height="23px" Width="261px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnSend" runat="server" Height="44px" Text="Send Email!" Width="118px" OnClick="btnSend_Click1" autocomplete ="off"/>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnVerify" runat="server" CssClass="auto-style1" Height="39px" OnClick="btnVerify_Click" Text="Verify" Width="93px" />
            <br />
            <asp:Label ID="lblSent" runat="server" ForeColor="Green" Text="Verification code has been sent to your email address."></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblcode" runat="server" ForeColor="Green" Text="Code Verified!"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblincode" runat="server" ForeColor="Red" Text="Code is Incorrect!"></asp:Label>
            <br />
            <asp:Label ID="lblWrong" runat="server" ForeColor="Red" Text="This email address does not match our records or cannot be found. "></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;<br />
             <asp:Label ID="lblFail" runat="server" ForeColor="Red" Text="Email failed to send!"></asp:Label>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <asp:Label ID="lblMissing" runat="server" ForeColor="Red" Text="Please Fill in the email Address box."></asp:Label>
            <br />
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Back to Login!</asp:LinkButton>
            </div>
    </form>
</body>
</html>
