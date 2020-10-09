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
            <asp:DataList ID="DataList1" runat="server" CssClass="auto-style1" DataKeyField="StID" DataSourceID="EagleLifeDB" Width="289px" CellPadding="4" ForeColor="#333333">
                <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <ItemTemplate>
                    StID:
                    <asp:Label ID="StIDLabel" runat="server" Text='<%# Eval("StID") %>' />
                    <br />
                    StName:
                    <asp:Label ID="StNameLabel" runat="server" Text='<%# Eval("StName") %>' />
                    <br />
                    StEmail:
                    <asp:Label ID="StEmailLabel" runat="server" Text='<%# Eval("StEmail") %>' />
                    <br />
                    StPhone:
                    <asp:Label ID="StPhoneLabel" runat="server" Text='<%# Eval("StPhone") %>' />
                    <br />
                    StLeader:
                    <asp:Label ID="StLeaderLabel" runat="server" Text='<%# Eval("StLeader") %>' />
                    <br />
                    StSchool:
                    <asp:Label ID="StSchoolLabel" runat="server" Text='<%# Eval("StSchool") %>' />
                    <br />
                    StHasGroup:
                    <asp:Label ID="StHasGroupLabel" runat="server" Text='<%# Eval("StHasGroup") %>' />
                    <br />
                    StGroupCode:
                    <asp:Label ID="StGroupCodeLabel" runat="server" Text='<%# Eval("StGroupCode") %>' />
                    <br />
                    <br />
                </ItemTemplate>
                <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            </asp:DataList>
            <asp:SqlDataSource ID="EagleLifeDB" runat="server" ConnectionString="<%$ ConnectionStrings:EagleLifeDBConnectionString %>" SelectCommand="SELECT * FROM [Student]"></asp:SqlDataSource>
            <br />
            <asp:Button ID="btnSaveFile" runat="server" Text="Save list to file..." />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Switch to Search View..." />
        </div>
    </form>
</body>
</html>
