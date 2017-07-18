<%@ Page Title="User Permission" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserPermissionForm.aspx.cs" Inherits="ERPWebApplication.ModuleName.Organization.MasterPage.UserPermissionForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table style="width: 100%;">
                <tr>
                    <td>
                        <ajaxToolkit:TabContainer ID="TabContainerUserPermission" runat="server" Width="100%" Height="100%" ActiveTabIndex="1" CssClass="tab" CssTheme="None">
                            <ajaxToolkit:TabPanel ID="TabPanelRoleSetup" runat="server" HeaderText="Role Setup">
                                <ContentTemplate>
                                    <table style="width: 100%;">
                                        <tr>
                                            <td style="text-align: left; float: left; width: 500px">
                                                <div style="overflow: auto; height: 450px;">
                                                    <asp:TreeView ID="TreeViewAllNode" runat="server" OnTreeNodePopulate="TreeViewAllNode_TreeNodePopulate" ShowCheckBoxes="All" NodeIndent="50" ShowExpandCollapse="False">
                                                        <ParentNodeStyle Font-Bold="True" />
                                                        <RootNodeStyle Font-Bold="True" />
                                                    </asp:TreeView>
                                                </div>
                                            </td>
                                            <td style="text-align: left; float: left; width: 435px">
                                                <table style="width: 100%;">
                                                    <tr>
                                                        <td colspan="3">
                                                            <div style="position: fixed; width: 425px; background-color: white; height: 50px">
                                                                <table style="width: 50%;">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Button ID="btnRoleSave" runat="server" Width="100px" Text="Save" OnClick="btnRoleSave_Click" /></td>
                                                                        <td>
                                                                            <asp:Button ID="btnRoleClear" runat="server" Width="100px" Text="Clear" OnClick="btnRoleClear_Click" /></td>
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
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label2" runat="server" Text="Role Type"></asp:Label>
                                                        </td>
                                                        <td>:</td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlRoleType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlRoleType_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label1" runat="server" Text="Role Title"></asp:Label>
                                                        </td>
                                                        <td>:</td>
                                                        <td>
                                                            <asp:TextBox ID="txtRoleTitle" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">
                                                            <asp:GridView ID="GridViewRoles" runat="server" Width="100%" AutoGenerateColumns="False" OnRowDataBound="GridViewRoles_RowDataBound" OnRowCommand="GridViewRoles_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="SL">
                                                                        <ItemTemplate>
                                                                            <%# Container.DisplayIndex + 1 %>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Role ID">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblRoleID" runat="server" Text='<%# Bind("RoleID") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Role Name">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblRoleName" runat="server" Text='<%# Bind("RoleName") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Role Type ID">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblRoleTypeID" runat="server" Text='<%# Bind("RoleTypeID") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:CommandField ShowSelectButton="True" />
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </ajaxToolkit:TabPanel>
                            <ajaxToolkit:TabPanel ID="TabPanelUserPermission" runat="server" HeaderText="User Permission">
                                <ContentTemplate>
                                    <table style="width: 100%;">
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label3" runat="server" Text="User Code"></asp:Label>
                                            </td>
                                            <td>:</td>
                                            <td>
                                                <asp:TextBox ID="txtUserCode" runat="server" AutoPostBack="True" OnTextChanged="txtUserCode_TextChanged"></asp:TextBox>
                                                <ajaxToolkit:AutoCompleteExtender ID="txtUserCode_AutoCompleteExtender" runat="server"
                                        CompletionListCssClass="autocomplete_completionListElement"
                                        CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                                        CompletionListItemCssClass="autocomplete_listItem2"
                                        DelimiterCharacters=""
                                        MinimumPrefixLength="1" ServiceMethod="GetEmpId" ServicePath="~/WebService/ServiceSystem.asmx" TargetControlID="txtUserCode" BehaviorID="_content_txtUserCode_AutoCompleteExtender">
                                    </ajaxToolkit:AutoCompleteExtender>
                                            </td>
                                            <td rowspan="3" style="text-align: right; float: right; width: 435px">
                                                <div style="position: fixed; width: 425px; background-color: white; height: 50px">
                                                    <table style="width: 70%; margin-left: 5px">
                                                        <tr>
                                                            <td>
                                                                <asp:Button ID="btnSave" runat="server" Text="Save" Width="100px" OnClick="btnSave_Click" /></td>
                                                            <td>
                                                                <asp:Button ID="btnClear" runat="server" Text="Clear" Width="100px" OnClick="btnClear_Click" /></td>
                                                            <td>
                                                                <asp:Button ID="btnPrint" runat="server" Text="Print" Width="100px" /></td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label5" runat="server" Text="Role Type"></asp:Label>
                                            </td>
                                            <td>:</td>
                                            <td>
                                                <asp:DropDownList ID="ddlRoleTypeUser" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlRoleTypeUser_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label4" runat="server" Font-Underline="False" Text="Role list"></asp:Label>
                                            </td>
                                            <td>:</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <table style="width: 100%;">
                                                    <tr>
                                                        <td>
                                                            <asp:ListBox ID="ListBoxRoles" runat="server" Height="300px" Width="250px"></asp:ListBox>
                                                        </td>
                                                        <td>
                                                            <table style="width: 100%;">
                                                                <tr>
                                                                    <td>
                                                                        <asp:Button ID="btnForword" runat="server" OnClick="btnForword_Click" Text="&gt;" Width="25px" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Button ID="btnForwordAll" runat="server" OnClick="btnForwordAll_Click" Text="&gt;&gt;" Width="25px" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="&lt;" Width="25px" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Button ID="btnBackAll" runat="server" OnClick="btnBackAll_Click" Text="&lt;&lt;" Width="25px" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td>
                                                            <asp:ListBox ID="ListBoxSelectedRoles" runat="server" AutoPostBack="True" Height="300px" Width="250px"></asp:ListBox>
                                                        </td>
                                                        <td>
                                                            &nbsp;</td>
                                                        <td>
                                                            <asp:ListBox ID="ListBoxRelatedUserRole" Height="300px" Width="250px" runat="server"></asp:ListBox>
                                                        </td>
                                                        <td>
                                                            <table style="width:100%;">
                                                                <tr>
                                                                    <td>
                                                                        <asp:Button ID="btnForwordUserRole" runat="server" Text="&gt;" Width="25px" OnClick="btnForwordUserRole_Click" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Button ID="btnForwordAllUserRole" runat="server" Text="&gt;&gt;" Width="25px" OnClick="btnForwordAllUserRole_Click" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Button ID="btnBackUserRole" runat="server" Text="&lt;" Width="25px" OnClick="btnBackUserRole_Click" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Button ID="btnBackAllUserRole" runat="server" Text="&lt;&lt;" Width="25px" OnClick="btnBackAllUserRole_Click" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td>
                                                            <asp:ListBox ID="ListBoxSelectedRelatedUserRole" Height="300px" Width="250px" runat="server"></asp:ListBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                        <td colspan="3">&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                        <td colspan="3">&nbsp;</td>
                                                    </tr>
                                                </table>
                                            </td>
                                            
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </ajaxToolkit:TabPanel>
                        </ajaxToolkit:TabContainer>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers></Triggers>
    </asp:UpdatePanel>
</asp:Content>
