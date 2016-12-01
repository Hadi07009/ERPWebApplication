<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CoaHeadSetup.aspx.cs" Inherits="ERPWebApplication.ModuleName.Accounts.CoaHeadSetup" %>

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
    <table style="width: 99%">
        <tr>
            <td colspan="2">
                <div style="text-align: left; padding-top: 1px; height: 450px; width: 665px">
                    <asp:Panel ID="Panel5" runat="server" Height="100%" ScrollBars="Auto"
                        Width="100%">
                        <asp:TreeView ID="treeCOAHead" runat="server" ImageSet="Arrows"
                            OnTreeNodePopulate="treeCOAHead_TreeNodePopulate" ShowLines="True"
                            OnSelectedNodeChanged="treeCOAHead_SelectedNodeChanged">
                            <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
                            <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
                            <ParentNodeStyle Font-Bold="False" />
                            <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" HorizontalPadding="0px" VerticalPadding="0px" />

                        </asp:TreeView>
                    </asp:Panel>
                </div>
            </td>
            <td>
                <div style="text-align: left; padding-top: -1px; height: 800px; width: 350px">
                    <asp:Panel ID="Panel2" runat="server" Height="40px" BackColor="Silver"
                        BorderStyle="Solid" BorderColor="#CCCCCC" BorderWidth="2px" Width="99%">
                        <table style="width: 99%;">
                            <tr>
                                <td>
                                    <asp:RadioButtonList ID="rblAccountType" runat="server"
                                        RepeatDirection="Vertical" AutoPostBack="True"
                                        OnSelectedIndexChanged="rblAccountType_SelectedIndexChanged" Width="100%">
                                        <asp:ListItem Value="0" Selected="True">Asset</asp:ListItem>
                                        <asp:ListItem Value="1">Liability</asp:ListItem>
                                        <asp:ListItem Value="2">Revenue</asp:ListItem>
                                        <asp:ListItem Value="3">Expense</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>

                        </table>
                    </asp:Panel>
                    <asp:Panel ID="Panel1" runat="server" Height="100%" BackColor="Silver" Width="100%">

                        <table style="width: 99%; text-align: left">
                            <tr>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text="Parent Account"></asp:Label>
                                </td>
                                <td>:</td>
                                <td colspan="2">
                                    <asp:DropDownList ID="ddlParentAccountNo" runat="server" Width="205px"
                                        AutoPostBack="True" Enabled="False"
                                        OnSelectedIndexChanged="ddlParentAccountNo_SelectedIndexChanged">
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
                                    <asp:DropDownList ID="ddlAccountType" runat="server" Width="205px"
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
                                                <asp:CheckBox ID="CheckBoxIsBudgetRelated" runat="server" Text="Is Budget Related" Width="200px" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style1">&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>
                                                <asp:CheckBox ID="CheckBoxAnalysisRequired" runat="server" Text="Analysis Required" AutoPostBack="True" OnCheckedChanged="CheckBoxAnalysisRequired_CheckedChanged" />
                                            </td>
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
                                                    <asp:TextBox ID="txtSubledgerTypeID" runat="server" Width="200px" OnTextChanged="txtSubledgerTypeID_TextChanged"></asp:TextBox>
                                                    <cc1:AutoCompleteExtender ID="txtSubledgerTypeID_AutoCompleteExtender" runat="server"
                                                        DelimiterCharacters="" Enabled="True"
                                                        ServicePath="~/services/srvSystem.asmx"
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
                                                        DelimiterCharacters="" Enabled="True"
                                                        ServicePath="~/services/srvSystem.asmx"
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
                                                        DelimiterCharacters="" Enabled="True"
                                                        ServicePath="~/services/srvSystem.asmx"
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
                                                        DelimiterCharacters="" Enabled="True"
                                                        ServicePath="~/services/srvSystem.asmx"
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
                                                        DelimiterCharacters="" Enabled="True"
                                                        ServicePath="~/services/srvSystem.asmx"
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
                                <td align="left">
                                    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" Width="85px" />
                                </td>
                                <td>
                                    <asp:Button ID="btnPrint" runat="server" Text="Print" Width="85px"
                                        OnClick="btnPrint_Click" Visible="False" />
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td colspan="2">
                                    <asp:Button ID="btnClose" runat="server" Text="Close" Width="85px"
                                        Visible="False" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </div>
            </td>
        </tr>

    </table>

</asp:Content>
