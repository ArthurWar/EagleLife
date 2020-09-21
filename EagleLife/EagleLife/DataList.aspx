<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataList.aspx.cs" Inherits="EagleLife.DataList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-right: 0px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="XX-Large" Font-Underline="True" Text="User Database"></asp:Label>
            <br />
            <asp:DataList ID="DataList1" runat="server" CssClass="auto-style1" DataKeyField="userID" DataSourceID="EagleLifeDB" Width="289px">
                <ItemTemplate>
                    userID:
                    <asp:Label ID="userIDLabel" runat="server" Text='<%# Eval("userID") %>' />
                    <br />
                    userName:
                    <asp:Label ID="userNameLabel" runat="server" Text='<%# Eval("userName") %>' />
                    <br />
                    userArea:
                    <asp:Label ID="userAreaLabel" runat="server" Text='<%# Eval("userArea") %>' />
                    <br />
                    userPhone:
                    <asp:Label ID="userPhoneLabel" runat="server" Text='<%# Eval("userPhone") %>' />
                    <br />
                    userEmail:
                    <asp:Label ID="userEmailLabel" runat="server" Text='<%# Eval("userEmail") %>' />
                    <br />
                    userGroupCode:
                    <asp:Label ID="userGroupCodeLabel" runat="server" Text='<%# Eval("userGroupCode") %>' />
                    <br />
<br />
                </ItemTemplate>
            </asp:DataList>
            <asp:SqlDataSource ID="EagleLifeDB" runat="server" ConnectionString="<%$ ConnectionStrings:EagleLifeDBConnectionString %>" SelectCommand="SELECT * FROM [ELUser]"></asp:SqlDataSource>
            <br />
            <asp:Button ID="btnSaveFile" runat="server" Text="Save list to file..." />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Switch to Search View..." />
        </div>
    </form>
</body>
</html>
