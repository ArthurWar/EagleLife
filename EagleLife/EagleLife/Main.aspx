<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="EagleLife.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin-left: 40px">
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="XX-Large" Font-Underline="True" Text="Find User in Database"></asp:Label>
            <br />
            <br />
            ID:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtUserID" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
            <asp:Label ID="lblSearch" runat="server"></asp:Label>
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Image ID="Image1" runat="server" Height="128px" Width="128px" />
            <asp:CheckBox ID="userHasGroup" runat="server" Visible="False" />
            <br />
            Name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtUserName" runat="server" Enabled="False"></asp:TextBox>
            <br />
            School:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtUserSchool" runat="server" Enabled="False"></asp:TextBox>
            <br />
            Phone #:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtUserPhone" runat="server" Enabled="False"></asp:TextBox>
            <br />
            <hr />
            <br />
            Email:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtUserEmail" runat="server" Enabled="False"></asp:TextBox>
            &nbsp;<asp:Button ID="btnOpenEmail" runat="server" OnClick="btnOpenEmail_Click" Text="Email this user..." />
            <br />
            Main Group:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtUserGroup" runat="server" Enabled="False"></asp:TextBox>
&nbsp;<br />
            <br />
            <asp:Button ID="btnSwitchList" runat="server" OnClick="btnSwitchList_Click" Text="Switch to List View..." />
        </div>
    </form>
</body>
</html>
