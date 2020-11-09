<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Launch.aspx.cs" Inherits="EagleLife.Initial" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="vertical-align:middle; text-align: center;">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/title_large.png" />
            <br />
            <br />
            Developed by Eagle Eye Consultation<br />
            Version 1.0.0<br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Go to Application" />
        </div>
    </form>
</body>
</html>
