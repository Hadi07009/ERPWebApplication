<%@ Page Title="Default Node List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NodeListForm.aspx.cs" Inherits="ERPWebApplication.ModuleName.Organization.MasterPage.NodeListForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table style="width: 100%; text-align: left">
                <tr>
                    <td colspan="2" style="width: 600px; float: left">
                        <asp:TreeView ID="treeNodeList" runat="server"></asp:TreeView>
                    </td>
                    <td colspan="2" style="text-align: left; float: left">
                        <table style="width: 100%;">
                            <tr>
                                <td colspan="3" style="margin-top: -5px">
                                    <div style="position: fixed; width: 425px; background-color: #00817F; height: 50px">
                                        <table style="width: 55%; margin-left: 5px">
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnSave" runat="server" Text="Save" Width="100px" /></td>
                                                <td>
                                                    <asp:Button ID="btnClear" runat="server" Text="Clear" Width="100px" /></td>
                                                <td>&nbsp;</td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text="Description"></asp:Label></td>
                                <td>:</td>
                                <td>
                                    <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox></td>
                            </tr>
                        </table>

                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td colspan="2">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
