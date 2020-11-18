<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataList.aspx.cs" Inherits="EagleLife.DataList" %>

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
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Return to search..." />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="XX-Large" Font-Underline="True" Text="Student Database"></asp:Label>
            &nbsp;<br />
            <br />
            <asp:Button ID="btnSaveStudentFile" runat="server" Text="Save list to file..." OnClick="btnSaveFile_Click" />
            <br />
            <br />
            <div style="text-align: left;">
                <table align="center" width="75%">
                    <tr>
                        <td class="auto-style3">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="StID" DataSourceID="EagleLifeDB" Width="100%" AllowPaging="True" AllowSorting="True">
                <Columns>
                    <asp:BoundField DataField="StID" HeaderText="ID" ReadOnly="True" SortExpression="StID" />
                    <asp:BoundField DataField="StName" HeaderText="Name" SortExpression="StName" />
                    <asp:BoundField DataField="StEmail" HeaderText="Email" SortExpression="StEmail" />
                    <asp:BoundField DataField="StPhone" HeaderText="Phone" SortExpression="StPhone" />
                    <asp:BoundField DataField="StLeader" HeaderText="Leader" SortExpression="StLeader" />
                    <asp:BoundField DataField="StSchool" HeaderText="School" SortExpression="StSchool" />
                    <asp:BoundField DataField="StGroupCode" HeaderText="Group Code" SortExpression="StGroupCode" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="EagleLifeDB" runat="server" ConnectionString="<%$ ConnectionStrings:EagleLifeDBConnectionString %>" SelectCommand="SELECT [StID], [StName], [StEmail], [StPhone], [StLeader], [StSchool], [StGroupCode] FROM [Student]"></asp:SqlDataSource>
                            </td>
                    </tr>
                </table>
                <br />
            <br />
            <div style="vertical-align:middle; text-align: center;">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="XX-Large" Font-Underline="True" Text="Leader Database"></asp:Label>
                <br />
                <br />
                <asp:Button ID="btnSaveLeaderFile" runat="server" Text="Save list to file..." OnClick="btnSaveLeaderFile_Click" />
                <br />
                <br />
                <table align="center" width="75%">
                    <tr>
                        <td class="auto-style3">
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="LID" DataSourceID="EagleLifeDBLeaders" Width="100%" AllowPaging="True" AllowSorting="True">
                <Columns>
                    <asp:BoundField DataField="LID" HeaderText="ID" ReadOnly="True" SortExpression="LID" />
                    <asp:BoundField DataField="LName" HeaderText="Name" SortExpression="LName" />
                    <asp:BoundField DataField="LEmail" HeaderText="Email" SortExpression="LEmail" />
                    <asp:BoundField DataField="LPhone" HeaderText="Phone" SortExpression="LPhone" />
                    <asp:BoundField DataField="ScID" HeaderText="School ID" SortExpression="ScID" />
                </Columns>
            </asp:GridView>
                            <asp:SqlDataSource ID="EagleLifeDBLeaders" runat="server" ConnectionString="<%$ ConnectionStrings:EagleLifeDBConnectionString %>" SelectCommand="SELECT * FROM [Leader]"></asp:SqlDataSource>
                            </td>
                    </tr>
                </table>
            </div>
            </div>
            <br />
            <br />
            <asp:Label ID="lblSaveStatus" runat="server"></asp:Label>
            <asp:Label ID="lblFolderStatus" runat="server"></asp:Label>
                <br />
                <br />
        </div>
    </form>
                

</body>
</html>
