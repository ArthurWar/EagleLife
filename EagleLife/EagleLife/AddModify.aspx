<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddModify.aspx.cs" Inherits="EagleLife.AddModify" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style6 {
            width: 80px;
            height: 50px;
        }
        .auto-style7 {
            height: 50px;
        }
        .auto-style12 {
            margin-top: 0px;
        }
        .auto-style14 {
            width: 282px;
        }
        .auto-style15 {
            width: 148px;
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
            width: 250px;
        }
        .auto-style16 {
            width: 148px;
            height: 51px;
        }
        .auto-style11 {
            width: 149px;
            height: 51px;
        }
        .auto-style17 {
            height: 50px;
            width: 250px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="vertical-align:middle; text-align: center;">
            <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/title_small.png" />
            <br />
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="XX-Large" Font-Underline="True" Text="Add/Modify Users..."></asp:Label>
            
            
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
                <br />
            <asp:Button ID="btnSwitchList" runat="server" OnClick="btnSwitchList_Click" Text="Switch to Search..." />
            </div>
            <br />



            <div style="vertical-align:middle; text-align: center; width:100%;">
            <table align="center">
                <tr>
                    <td class="auto-style6">ID:</td>
                    <td class="auto-style7"><asp:TextBox ID="txtUserID" runat="server" OnTextChanged="txtUserID_TextChanged"></asp:TextBox>
                    </td>
                </tr>
            </table>
                <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" />
                <br />
                <br />
            <table align="center" width="50%">
                <tr>
                    <td class="auto-style6">Name:</td>
                    <td class="auto-style17"><asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style15">
                        Email:</td>
                    <td class="auto-style8">
                        <asp:TextBox ID="txtUserEmail" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style9">School:</td>
                    <td class="auto-style10"><asp:TextBox ID="txtUserSchool" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                    <td class="auto-style16">
                        Group:</td>
                    <td class="auto-style11">
                        <asp:TextBox ID="txtUserGroup" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style6">Phone #: </td>
                    <td class="auto-style17"><asp:TextBox ID="txtUserPhone" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style15">
                        Leader /
                        Division:</td>
                    <td class="auto-style8">
                        <asp:TextBox ID="txtDivision" runat="server"></asp:TextBox>



                    </td>
                </tr>
            </table>
                <br />
                <asp:Label ID="lblSystemMessage" runat="server"></asp:Label>
                <br />
                <br />
            <table align="center">
                <tr>
                    <td class="auto-style6">
                <asp:RadioButtonList ID="rdoAddModify" runat="server" OnSelectedIndexChanged="rdoAddModify_SelectedIndexChanged" Width="90px">
                    <asp:ListItem Selected="True">Add</asp:ListItem>
                    <asp:ListItem>Modify</asp:ListItem>
                </asp:RadioButtonList>
                </tr>
            </table>
                <br />
                <asp:Button ID="btnConfirm" runat="server" OnClick="btnConfirm_Click" Text="Confirm" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete" />
                <br />
                <br />
                <br />
                <br />
            </div>



        </div>
    </form>
</body>
</html>
