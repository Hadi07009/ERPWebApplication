<%@ Page Title="Default Node List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NodeListForm.aspx.cs" Inherits="ERPWebApplication.ModuleName.Organization.MasterPage.NodeListForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table style="width: 100%; text-align: left">
                <tr>
                    <td colspan="2" style="width: 600px; float: left">
                        <div style="overflow:auto; height:500px;">
                        <asp:TreeView ID="treeNodeList" runat="server" ImageSet="Msdn" OnSelectedNodeChanged="treeNodeList_SelectedNodeChanged" OnTreeNodePopulate="treeNodeList_TreeNodePopulate">
                        </asp:TreeView>
                            </div>
                    </td>
                    <td colspan="2" style="text-align: left; float: left">
                        <table style="width: 100%;">
                            <tr>
                                <td colspan="3" style="margin-top: -5px">
                                    <div style="position: fixed; width: 425px; background-color: #00817F; height: 100px">
                                        <table style="width: 100%; margin-left: 5px">
                                            <tr>
                                                <td colspan="2">
                                                    <asp:Button ID="btnAddNew" runat="server" Text="AddNew" Width="150px" OnClick="btnAddNew_Click" />
                                                </td>
                                                <td colspan="2">
                                                    <asp:Button ID="btnEdit" runat="server" Text="Edit" Width="150px" OnClick="btnEdit_Click" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnPrint" runat="server" Text="Print" Width="95px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnSave" runat="server" Text="Save" Width="70px" OnClick="btnSave_Click" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnCancelAddNew" runat="server" Text="Cancel" Width="70px" OnClick="btnCancelAddNew_Click" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnUpdate" runat="server" Text="Update" Width="70px" OnClick="btnUpdate_Click" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnCancelEdit" runat="server" Text="Cancel" Width="70px" OnClick="btnCancelEdit_Click" />
                                                </td>
                                                <td>
                                                    &nbsp;</td>
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
                                <td colspan="3">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:Label ID="lblParentText" runat="server"></asp:Label>
                                    <asp:Label ID="lblParentValue" runat="server" Visible="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label5" runat="server" Text="Title"></asp:Label>
                                </td>
                                <td>:</td>
                                <td>
                                    <asp:TextBox ID="txtTitle" runat="server" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text="Description"></asp:Label>
                                </td>
                                <td>:</td>
                                <td>
                                    <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblType" runat="server" Text="Type"></asp:Label>
                                </td>
                                <td>:</td>
                                <td>
                                    <asp:DropDownList ID="ddlType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlType_SelectedIndexChanged" Width="310px">
                                        <asp:ListItem Selected="True" Value="-1">--- Please Select ---</asp:ListItem>
                                        <asp:ListItem Value="1">Module Name</asp:ListItem>
                                        <asp:ListItem Value="2">Setup Page</asp:ListItem>
                                        <asp:ListItem Value="3">TransactionPage</asp:ListItem>
                                        <asp:ListItem Value="4">Form</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:Panel ID="PanelFormDetails" runat="server">
                                        <table style="width:100%;">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label6" runat="server" Text="Form URL"></asp:Label>
                                                </td>
                                                <td>:</td>
                                                <td>
                                                    <asp:DropDownList ID="ddlFormURL" runat="server" Width="320px">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label7" runat="server" Text="Position"></asp:Label>
                                                </td>
                                                <td>:</td>
                                                <td>
                                                    <asp:DropDownList ID="ddlShowPosition" runat="server" Width="320px">
                                                        <asp:ListItem Selected="True" Value="-1">--- Please Select ---</asp:ListItem>
                                                        <asp:ListItem Value="1">Menu</asp:ListItem>
                                                        <asp:ListItem Value="2">Dashboard</asp:ListItem>
                                                    </asp:DropDownList>
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
                                        </table>
                                    </asp:Panel>
                                </td>
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
