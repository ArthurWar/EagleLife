<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="EagleLife.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style5 {
            width: 29%;
            height: 200px;
        }
        .auto-style6 {
            width: 80px;
            height: 50px;
        }
        .auto-style7 {
            height: 50px;
        }
        .auto-style8 {
            width: 149px;
            height: 50px;
        }
        .auto-style9 {
            width: 80px;
            height: 51px;
        }
        .auto-style10 {
            height: 51px;
        }
        .auto-style11 {
            width: 149px;
            height: 51px;
        }
        .auto-style12 {
            margin-top: 0px;
        }
        .auto-style14 {
            width: 282px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="vertical-align:middle; text-align: center;">
            <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/title_small.png" />
            <br />
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="XX-Large" Font-Underline="True" Text="Find User in Database"></asp:Label>
            
            
            <div style="vertical-align:middle; text-align: center; width:100%;">
                <table align="center" width="30%">
                    <tr>
                        <td class="auto-style14">
            <asp:RadioButtonList ID="rdoSearchToggle" runat="server" AutoPostBack="True" Width="50%" CssClass="auto-style12" OnSelectedIndexChanged="rdoSearchToggle_SelectedIndexChanged">
                <asp:ListItem Selected="True">Leader</asp:ListItem>
                <asp:ListItem>Student</asp:ListItem>
                <asp:ListItem>Young Lives</asp:ListItem>
            </asp:RadioButtonList>
                        </td>
                        <td>
                            <asp:Label ID="lblRanges" runat="server" Text="ID Range: 1001-1999"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
            <br />
            <asp:Button ID="btnSwitchList" runat="server" OnClick="btnSwitchList_Click" Text="View users as a list..." />
        &nbsp;&nbsp;&nbsp; <asp:Button ID="btnSwitchAM" runat="server" OnClick="btnSwitchAM_Click" Text="Add/Modify users..." />
            <br />
            <br />



            <div style="vertical-align:middle; text-align: center; width:100%;">
            <table align="center" class="auto-style7">
                <tr>
                    <td class="auto-style6">ID:</td>
                    <td class="auto-style7"><asp:TextBox ID="txtUserID" runat="server" OnTextChanged="txtUserID_TextChanged"></asp:TextBox>
                    </td>
                    <td class="auto-style8">
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style9">Name:</td>
                    <td class="auto-style10"><asp:TextBox ID="txtUserName" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                    <td class="auto-style11">
                <asp:Label ID="lblSearch" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style6">School:</td>
                    <td class="auto-style7"><asp:TextBox ID="txtUserSchool" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                    <td class="auto-style8">
            <asp:CheckBox ID="userHasGroup" runat="server" Visible="False" />



                    </td>
                </tr>
            </table>
            <table align="center" class="auto-style7">
                <tr>
                    <td class="auto-style6">Phone #: </td>
                    <td class="auto-style7"><asp:TextBox ID="txtUserPhone" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                    <td class="auto-style8"></td>
                </tr>
                <tr>
                    <td class="auto-style6">Email:</td>
                    <td class="auto-style7"><asp:TextBox ID="txtUserEmail" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                    <td class="auto-style8">
                <asp:Button ID="btnOpenEmail" runat="server" OnClick="btnOpenEmail_Click" Text="Email this user..." />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style6">Group:</td>
                    <td class="auto-style7"><asp:TextBox ID="txtUserGroup" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                    <td class="auto-style8">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6">Division:</td>
                    <td class="auto-style7"><asp:TextBox ID="txtDivision" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                    <td class="auto-style8"></td>
                </tr>
            </table>
                        <br />
                <asp:Button ID="btnLogOut" runat="server" OnClick="btnLogOut_Click" Text="Log Out" />
                <br />
                <br />
                        <asp:LinkButton ID="Changelink" runat="server" OnClick="ChangeLink_Click">Need to Change Password ?</asp:LinkButton>
                <br />
            </div>
            <br />
        &nbsp;</div>
    </form>
</body>
</html>
