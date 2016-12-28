<%@ Page Title="Account Head Setup" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CoaHeadSetup.aspx.cs" Inherits="ERPWebApplication.ModuleName.Accounts.CoaHeadSetup" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 93px;
        }

        .auto-style2 {
            width: 97px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table style="width: 99%">
                <tr>
                    <td>
                        <table style="width: 50%; text-align: left">
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:TextBox ID="txtSearch" runat="server" AutoPostBack="True" placeholder="Search..." Width="337px"></asp:TextBox>
                                    </td>
                                    <ajaxToolkit:AutoCompleteExtender ID="txtSearch_AutoCompleteExtender" runat="server"
                                        CompletionListCssClass="autocomplete_completionListElement"
                                        CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                                        CompletionListItemCssClass="autocomplete_listItem2"
                                        DelimiterCharacters=""
                                        Enabled="True"
                                        MinimumPrefixLength="1" ServiceMethod="GetItemName" ServicePath="~/WebService/ServiceSystem.asmx" TargetControlID="txtSearch">
                                    </ajaxToolkit:AutoCompleteExtender>
                                    <td>
                                        <asp:Button ID="btnSearch" runat="server" Text="Search" Height="30px" Width="100px" OnClick="btnSearch_Click" /></td>
                                </tr>

                            </table>
                    </td>
                    <td>
                        <div style="position: fixed; width: 350px; background-color: #00817F; height: 100px">
                            <table style="width: 100%; text-align: left;margin-left:5px">
                                <tr>
                                    <td colspan="2">
                                        <asp:Button ID="btnAddNew" runat="server" Text="Add New" Width="125px" OnClick="btnAddNew_Click" /></td>
                                    <td colspan="2">
                                        <asp:Button ID="btnEdit" runat="server" Text="Edit" Width="120px" OnClick="btnEdit_Click" /></td>
                                    <td>
                                        <asp:Button ID="btnPrintSummery" runat="server" Text="Print" Width="55px" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" Width="60px" />
                                    </td>
                                    <td>
                                        <asp:Button ID="btnCancelAdd" runat="server" Text="Cancel" Width="60px" OnClick="btnCancelAdd_Click" />
                                    </td>
                                    <td>
                                        <asp:Button ID="btnUpdate" runat="server" Text="Update" Width="60px" OnClick="btnUpdate_Click" /></td>
                                    <td>
                                        <asp:Button ID="btnCancelEdit" runat="server" Text="Cancel" Width="60px" OnClick="btnCancelEdit_Click" /></td>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <hr id="searchbottom" runat="server" style="border:0; height: 1px; background: #333;  background-image: linear-gradient(to right, #ccc, #333, #ccc); width: 665px;" />
                        </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <div style="text-align: left; padding-top: 1px; height: 900px; width: 665px">
                            <div style="height: 415px; width: 600px">
                                <asp:Panel ID="Panel5" runat="server" Height="100%" ScrollBars="Auto"
                                    Width="100%">
                                    <asp:TreeView ID="treeCOAHead" runat="server" ImageSet="Msdn"
                                        NodeStyle-CssClass="treeNode"
                                        RootNodeStyle-CssClass="rootNode"
                                        LeafNodeStyle-CssClass="leafNode"
                                        SelectedNodeStyle-CssClass="selectedNode"
                                        ParentNodeStyle-CssClass="parentNode"
                                        HoverNodeStyle-CssClass="hoverNode"
                                        OnTreeNodePopulate="treeCOAHead_TreeNodePopulate"
                                        OnSelectedNodeChanged="treeCOAHead_SelectedNodeChanged">
                                        <HoverNodeStyle Font-Underline="True" ForeColor="#428BCA" />
                                        <HoverNodeStyle CssClass="hoverNode" />
                                        <LeafNodeStyle CssClass="leafNode" />
                                        <NodeStyle CssClass="treeNode" />
                                        <ParentNodeStyle CssClass="parentNode" />
                                        <RootNodeStyle CssClass="rootNode" />
                                        <SelectedNodeStyle CssClass="selectedNode" />
                                    </asp:TreeView>
                                </asp:Panel>
                            </div>
                        </div>
                    </td>
                    <td>
                        <div style="text-align: left; padding-top: -1px; height: 900px; width: 350px">
                            <asp:Panel ID="Panel1" runat="server" Height="100%" BackColor="Silver" Width="100%">
                                <table style="width: 99%; text-align: left; margin-left: 5px">
                                    <tr>
                                        <td colspan="4"></td>
                                    </tr>
                                    <tr>
                                        <td colspan="4"></td>
                                    </tr>
                                    <tr>
                                        <td colspan="4"></td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <table style="width: 99%;">
                                                <tr>
                                                    <td>
                                                        <asp:RadioButtonList ID="rblAccountType" runat="server" RepeatDirection="Horizontal" AutoPostBack="True"
                                                            OnSelectedIndexChanged="rblAccountType_SelectedIndexChanged" Width="100%">
                                                            <asp:ListItem Value="0" Selected="True">Asset</asp:ListItem>
                                                            <asp:ListItem Value="1">Liability</asp:ListItem>
                                                            <asp:ListItem Value="2">Revenue</asp:ListItem>
                                                            <asp:ListItem Value="3">Expense</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label4" runat="server" Text="Parent Account"></asp:Label>
                                        </td>
                                        <td>:</td>
                                        <td colspan="2">
                                            <asp:DropDownList ID="ddlParentAccountNo" runat="server" AutoPostBack="True" Enabled="False" OnSelectedIndexChanged="ddlParentAccountNo_SelectedIndexChanged" Width="212px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label5" runat="server" Text="Account Head"></asp:Label>
                                        </td>
                                        <td>:</td>
                                        <td colspan="2">
                                            <asp:TextBox ID="txtAccountHead" runat="server" Width="200px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label6" runat="server" Text="Account Type"></asp:Label>
                                        </td>
                                        <td>:</td>
                                        <td colspan="2">
                                            <asp:DropDownList ID="ddlAccountType" runat="server" Width="212px"
                                                Enabled="False">
                                                <asp:ListItem Value="0">Asset</asp:ListItem>
                                                <asp:ListItem Value="1">Liability</asp:ListItem>
                                                <asp:ListItem Value="2">Revenue</asp:ListItem>
                                                <asp:ListItem Value="3">Expense</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label7" runat="server" Text="A/C Description"></asp:Label>
                                        </td>
                                        <td>:</td>
                                        <td colspan="2">
                                            <asp:TextBox ID="txtAccountDescription" runat="server" Height="100px" TextMode="MultiLine" Width="200px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <table style="width: 99%; text-align: left">
                                                <tr>
                                                    <td class="auto-style1">
                                                        <asp:Label ID="Label8" runat="server"></asp:Label>
                                                    </td>
                                                    <td>&nbsp;</td>
                                                    <td>
                                                        <asp:CheckBox ID="CheckBoxIsBudgetRelated" runat="server" CssClass="checkbox" />
                                                        <asp:Label ID="Label2" runat="server" AssociatedControlID="CheckBoxIsBudgetRelated" CssClass="checkbox">Is Budget Related</asp:Label>

                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td class="auto-style1">&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>
                                                        <asp:CheckBox ID="CheckBoxAnalysisRequired" runat="server" CssClass="checkbox"
                                                            AutoPostBack="True" OnCheckedChanged="CheckBoxAnalysisRequired_CheckedChanged" />
                                                        <asp:Label ID="Label3" runat="server" AssociatedControlID="CheckBoxAnalysisRequired" CssClass="checkbox">Analysis Required</asp:Label></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:Panel ID="PanelAnalysisRequired" runat="server" Width="100%">
                                                <table style="width: 99%; text-align: left">
                                                    <tr>
                                                        <td class="auto-style2">
                                                            <asp:Label ID="Label1" runat="server" Text="Subledger Type"></asp:Label>
                                                        </td>
                                                        <td>:</td>
                                                        <td>
                                                            <asp:TextBox ID="txtSubledgerTypeID" runat="server" Width="200px"></asp:TextBox>
                                                            <cc1:AutoCompleteExtender ID="txtSubledgerTypeID_AutoCompleteExtender" runat="server"
                                                                CompletionListCssClass="autocomplete_completionListElement"
                                                                CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                                                                CompletionListItemCssClass="autocomplete_listItem2"
                                                                DelimiterCharacters="" Enabled="True"
                                                                ServicePath="~/WebService/ServiceSystem.asmx"
                                                                MinimumPrefixLength="1"
                                                                ServiceMethod="GetSubledgerHeadName"
                                                                TargetControlID="txtSubledgerTypeID">
                                                            </cc1:AutoCompleteExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style2">
                                                            <asp:Label ID="Label9" runat="server" Text="Subledger Type"></asp:Label>
                                                        </td>
                                                        <td>:</td>
                                                        <td>
                                                            <asp:TextBox ID="txtSubledgerTypeID0" runat="server" Width="200px"></asp:TextBox>
                                                            <cc1:AutoCompleteExtender ID="txtSubledgerTypeID0_AutoCompleteExtender" runat="server"
                                                                CompletionListCssClass="autocomplete_completionListElement"
                                                                CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                                                                CompletionListItemCssClass="autocomplete_listItem2"
                                                                DelimiterCharacters="" Enabled="True"
                                                                ServicePath="~/WebService/ServiceSystem.asmx"
                                                                MinimumPrefixLength="1"
                                                                ServiceMethod="GetSubledgerHeadName"
                                                                TargetControlID="txtSubledgerTypeID0">
                                                            </cc1:AutoCompleteExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style2">
                                                            <asp:Label ID="Label10" runat="server" Text="Subledger Type"></asp:Label>
                                                        </td>
                                                        <td>:</td>
                                                        <td>
                                                            <asp:TextBox ID="txtSubledgerTypeID1" runat="server" Width="200px"></asp:TextBox>
                                                            <cc1:AutoCompleteExtender ID="txtSubledgerTypeID1_AutoCompleteExtender" runat="server"
                                                                CompletionListCssClass="autocomplete_completionListElement"
                                                                CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                                                                CompletionListItemCssClass="autocomplete_listItem2"
                                                                DelimiterCharacters="" Enabled="True"
                                                                ServicePath="~/WebService/ServiceSystem.asmx"
                                                                MinimumPrefixLength="1"
                                                                ServiceMethod="GetSubledgerHeadName"
                                                                TargetControlID="txtSubledgerTypeID1">
                                                            </cc1:AutoCompleteExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style2">
                                                            <asp:Label ID="Label11" runat="server" Text="Subledger Type"></asp:Label>
                                                        </td>
                                                        <td>:</td>
                                                        <td>
                                                            <asp:TextBox ID="txtSubledgerTypeID2" runat="server" Width="200px"></asp:TextBox>
                                                            <cc1:AutoCompleteExtender ID="txtSubledgerTypeID2_AutoCompleteExtender" runat="server"
                                                                CompletionListCssClass="autocomplete_completionListElement"
                                                                CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                                                                CompletionListItemCssClass="autocomplete_listItem2"
                                                                DelimiterCharacters="" Enabled="True"
                                                                ServicePath="~/WebService/ServiceSystem.asmx"
                                                                MinimumPrefixLength="1"
                                                                ServiceMethod="GetSubledgerHeadName"
                                                                TargetControlID="txtSubledgerTypeID2">
                                                            </cc1:AutoCompleteExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style2">
                                                            <asp:Label ID="Label12" runat="server" Text="Subledger Type"></asp:Label>
                                                        </td>
                                                        <td>:</td>
                                                        <td>
                                                            <asp:TextBox ID="txtSubledgerTypeID3" runat="server" Width="200px"></asp:TextBox>
                                                            <cc1:AutoCompleteExtender ID="txtSubledgerTypeID3_AutoCompleteExtender" runat="server"
                                                                CompletionListCssClass="autocomplete_completionListElement"
                                                                CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                                                                CompletionListItemCssClass="autocomplete_listItem2"
                                                                DelimiterCharacters="" Enabled="True"
                                                                ServicePath="~/WebService/ServiceSystem.asmx"
                                                                MinimumPrefixLength="1"
                                                                ServiceMethod="GetSubledgerHeadName"
                                                                TargetControlID="txtSubledgerTypeID3">
                                                            </cc1:AutoCompleteExtender>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Button ID="btnRemove" runat="server" Text="Remove" Width="85px"
                                                OnClick="btnRemove_Click" Visible="False" />
                                        </td>
                                        <td>&nbsp;</td>
                                        <td align="left"></td>
                                        <td>
                                            
                                        </td>
                                    </tr>
                                    
                                </table>
                            </asp:Panel>
                        </div>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSave" />
            <asp:PostBackTrigger ControlID="btnUpdate" />
        </Triggers>
    </asp:UpdatePanel>

</asp:Content>
