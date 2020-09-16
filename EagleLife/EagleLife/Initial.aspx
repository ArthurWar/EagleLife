<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Initial.aspx.cs" Inherits="EagleLife.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="vertical-align:middle; text-align: center;">
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="XX-Large" Font-Underline="True" Text="EagleLife" Font-Italic="True"></asp:Label>
            <br />
            <br />
            Developed by Eagle Eye Consultation<br />
            Version 0.0.1<br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Go to Application" />
        </div>
    </form>
</body>
</html>
