<%@ Page Title="Process Details" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="frmProcessDetail.aspx.cs" Inherits="ERPWebApplication.ModuleName.Approval.frmProcessDetail" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%--<%@ Register assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2" namespace="eWorld.UI" tagprefix="ew" %>--%>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <asp:UpdatePanel ID="updpnl2" runat="server">
        <ContentTemplate>
            <asp:Panel ID="PanelLeaveDet" runat="server" CssClass="cpBodyContent" Width="100%" Height="100%">
                <table style="width: 99%; text-align: left">
                    <tr>
                        <td>
                            <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="4"
                                ScrollBars="None" Width="100%">
                                <cc1:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                                    <HeaderTemplate>
                                        Description
                                        <br />
                                    </HeaderTemplate>
                                    <ContentTemplate>
                                        <table style="width: 100%; text-align: left">
                                            <tr>
                                                <td style="width: 138px">
                                                    <asp:Label ID="Label21" runat="server" Text="Process Description"></asp:Label></td>
                                                <td style="width: 7px">&nbsp;: </td>
                                                <td>
                                                    <asp:TextBox ID="txtProcessDescription" runat="server"
                                                        Style="margin-left: 0px"
                                                        Width="300px"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 138px">&nbsp;</td>
                                                <td style="width: 7px">&nbsp;</td>
                                                <td>
                                                    <asp:CheckBox ID="chkActive" runat="server"
                                                        Text="Active" /></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 138px">&nbsp;</td>
                                                <td style="width: 7px">&nbsp;</td>
                                                <td>
                                                    <asp:CheckBox ID="chkInactive" runat="server"
                                                        Text="Inactive" /></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 138px">&nbsp;</td>
                                                <td style="width: 7px">&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 138px">&nbsp;</td>
                                                <td style="width: 7px">&nbsp;</td>
                                                <td>
                                                    <asp:Button ID="btnSave" runat="server" Text="Save" Width="100px" OnClick="btnSave_Click" />
                                                    <asp:TextBox ID="txtProcessId" runat="server" Visible="False"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 138px">&nbsp;</td>
                                                <td style="width: 7px">&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <asp:GridView ID="grdViewProcessDescription" runat="server" AutoGenerateColumns="False" OnRowCommand="grdViewProcessDescription_RowCommand" OnRowDataBound="grdViewProcessDescription_RowDataBound" OnRowEditing="grdViewProcessDescription_RowEditing" Width="100%">
                                                        <Columns>
                                                            <asp:BoundField DataField="ProcessId" HeaderText="Process Id" />
                                                            <asp:BoundField DataField="ProcessDescription" HeaderText="Process Description">
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Status" HeaderText="Status">
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                            <asp:CommandField HeaderText="Edit" ShowSelectButton="True">
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                            </asp:CommandField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 138px">&nbsp;</td>
                                                <td style="width: 7px">&nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 138px">&nbsp;</td>
                                                <td style="width: 7px">&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </cc1:TabPanel>
                                <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                                    <HeaderTemplate>Flow Definition</HeaderTemplate>
                                    <ContentTemplate>
                                        <table style="width: 100%; text-align: left">
                                            <tr>
                                                <td style="width: 122px">
                                                    <asp:Label ID="Label18" runat="server" Text="Process ID"></asp:Label></td>
                                                <td>:</td>
                                                <td>
                                                    <asp:DropDownList ID="ddlProcessId" runat="server" AutoPostBack="True" Style="margin-left: 0px" Width="305px"></asp:DropDownList></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 122px">
                                                    <asp:Label ID="Label19" runat="server" Text="Category ID"></asp:Label></td>
                                                <td>:</td>
                                                <td>
                                                    <asp:DropDownList ID="ddlCategoryId" runat="server" Width="305px">
                                                        <asp:ListItem Selected="True">--please select--</asp:ListItem>
                                                        <asp:ListItem Value="1">Staff</asp:ListItem>
                                                        <asp:ListItem Value="2">Officer</asp:ListItem>
                                                        <asp:ListItem Value="5">All</asp:ListItem>
                                                    </asp:DropDownList></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 122px">
                                                    <asp:Label ID="Label20" runat="server" Text="Flow Description"></asp:Label></td>
                                                <td>:</td>
                                                <td>
                                                    <asp:TextBox ID="txtProcessFlowDescription" runat="server" Style="margin-top: 5px" Width="300px"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 122px">&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 122px">&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>
                                                    <asp:Button ID="btnSaveProcessFlowDescription" runat="server" OnClick="btnSaveProcessFlowDescription_Click" Style="height: 26px" Text="Save" Width="100px" /><asp:TextBox ID="txtProcessFlowId" runat="server" Visible="False"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 122px">&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 122px">&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>
                                                    <asp:GridView ID="grdViewProcessFlowDefinition" runat="server" AutoGenerateColumns="False" OnRowCommand="grdViewProcessFlowDefinition_RowCommand" OnRowDataBound="grdViewProcessFlowDefinition_RowDataBound" OnRowEditing="grdViewProcessFlowDefinition_RowEditing" Width="100%">
                                                        <Columns>
                                                            <asp:BoundField DataField="ProcessId" HeaderText="Process Id Value" />
                                                            <asp:BoundField DataField="ProcessDescription" HeaderText="Process Id" />
                                                            <asp:BoundField DataField="CategoryId" HeaderText="Category Id Value" />
                                                            <asp:BoundField DataField="Category Id Text" HeaderText="Category Id " />
                                                            <asp:BoundField DataField="ProcessFlowId" HeaderText="Process Flow Id" />
                                                            <asp:BoundField DataField="FlowDescription" HeaderText="Flow Description" />
                                                            <asp:CommandField HeaderText="Edit" ShowSelectButton="True">
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:CommandField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 122px">&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </cc1:TabPanel>
                                <cc1:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3">
                                    <HeaderTemplate>Level Description</HeaderTemplate>
                                    <ContentTemplate>
                                        <table style="width: 100%; text-align: left">
                                            <tr>
                                                <td style="width: 122px">
                                                    <asp:Label ID="Label16" runat="server" Text="Process ID"></asp:Label></td>
                                                <td style="width: 11px">&nbsp;:</td>
                                                <td>
                                                    <asp:DropDownList ID="ddlProcessIdForLevel" runat="server"
                                                        OnSelectedIndexChanged="ddlProcessIdForLevel_SelectedIndexChanged"
                                                        Width="305px">
                                                    </asp:DropDownList></td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 122px">
                                                    <asp:Label ID="Label17" runat="server" Text="Level Description"></asp:Label></td>
                                                <td style="width: 11px">&nbsp;:</td>
                                                <td>
                                                    <asp:TextBox ID="txtLevelDescription" runat="server"
                                                        Width="300px"></asp:TextBox></td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 122px">&nbsp;</td>
                                                <td style="width: 11px">&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 122px">&nbsp;</td>
                                                <td style="width: 11px">&nbsp;</td>
                                                <td>
                                                    <asp:Button ID="btnSaveLevelDescription" runat="server"
                                                        OnClick="btnSaveLevelDescription_Click" Text="Save" Width="100px" /><asp:TextBox ID="txtProcessLevelId" runat="server" Visible="False"></asp:TextBox></td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 122px">&nbsp;</td>
                                                <td style="width: 11px">&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 122px">&nbsp;</td>
                                                <td style="width: 11px">&nbsp;</td>
                                                <td colspan="2">
                                                    <asp:GridView ID="grdViewProcessLevelDescription" runat="server" AutoGenerateColumns="False" OnRowCommand="grdViewProcessLevelDescription_RowCommand" OnRowDataBound="grdViewProcessLevelDescription_RowDataBound" OnRowEditing="grdViewProcessLevelDescription_RowEditing" Width="100%">
                                                        <Columns>
                                                            <asp:BoundField DataField="ProcessId" HeaderText="Process Id Value" />
                                                            <asp:BoundField DataField="ProcessDescription" HeaderText="Process Id" />
                                                            <asp:BoundField DataField="ProcessLevelId" HeaderText="Process Level Id" />
                                                            <asp:BoundField DataField="LevelDescription" HeaderText="Level Description" />
                                                            <asp:CommandField HeaderText="Edit" ShowSelectButton="True">
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:CommandField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </cc1:TabPanel>
                                <cc1:TabPanel ID="TabPanel4" runat="server" HeaderText="TabPanel4">
                                    <HeaderTemplate>ActionType</HeaderTemplate>
                                    <ContentTemplate>
                                        <table style="width: 100%; text-align: left">
                                            <tr>
                                                <td style="width: 94px">
                                                    <asp:Label ID="Label14" runat="server" Text="Process ID"></asp:Label></td>
                                                <td style="width: 14px">&nbsp;:</td>
                                                <td>
                                                    <asp:DropDownList ID="ddlProcessIdForAction" runat="server"
                                                        OnSelectedIndexChanged="ddlProcessIdForAction_SelectedIndexChanged"
                                                        Width="305px">
                                                    </asp:DropDownList></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 94px">
                                                    <asp:Label ID="Label15" runat="server" Text="Action Type"></asp:Label></td>
                                                <td style="width: 14px">&nbsp;:</td>
                                                <td>
                                                    <asp:TextBox ID="txtActionType" runat="server"
                                                        OnTextChanged="txtActionType_TextChanged" Style="margin-bottom: 0px"
                                                        Width="300px"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 94px">&nbsp;</td>
                                                <td style="width: 14px">&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 94px">&nbsp;</td>
                                                <td style="width: 14px">&nbsp;</td>
                                                <td>
                                                    <asp:Button ID="btnSaveProcessActionType" runat="server"
                                                        OnClick="btnSaveProcessActionType_Click" Text="Save" Width="100px" /><asp:TextBox ID="txtActionTypeId" runat="server" Visible="False"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 94px">&nbsp;</td>
                                                <td style="width: 14px">&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 94px">&nbsp;</td>
                                                <td style="width: 14px">&nbsp;</td>
                                                <td>
                                                    <asp:GridView ID="grdViewProcessActionType" runat="server"
                                                        AutoGenerateColumns="False" OnRowCommand="grdViewProcessActionType_RowCommand"
                                                        OnRowDataBound="grdViewProcessActionType_RowDataBound"
                                                        OnRowEditing="grdViewProcessActionType_RowEditing" Width="100%">
                                                        <Columns>
                                                            <asp:BoundField DataField="ProcessId" HeaderText="Process Id Value" />
                                                            <asp:BoundField DataField="ProcessDescription" HeaderText="Process Id" />
                                                            <asp:BoundField DataField="ActionTypeId" HeaderText="Action Type Id" />
                                                            <asp:BoundField DataField="Action" HeaderText="Action Type" />
                                                            <asp:CommandField HeaderText="Edit" ShowSelectButton="True">
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:CommandField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 94px">&nbsp;</td>
                                                <td style="width: 14px">&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 94px">&nbsp;</td>
                                                <td style="width: 14px">&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </cc1:TabPanel>
                                <cc1:TabPanel ID="TabPanel5" runat="server" HeaderText="TabPanel5">
                                    <HeaderTemplate>Configuration</HeaderTemplate>
                                    <ContentTemplate>
                                        <table style="width: 100%; text-align: left">
                                            <tr>
                                                <td>&nbsp;<asp:Label ID="Label1" runat="server" Text="Process ID"></asp:Label></td>
                                                <td>:</td>
                                                <td colspan="4">
                                                    <asp:DropDownList ID="ddlProcessIdForConfiguration" runat="server"
                                                        Style="margin-left: 0px" AutoPostBack="True"
                                                        OnSelectedIndexChanged="ddlProcessIdForConfiguration_SelectedIndexChanged"
                                                        Width="305px">
                                                    </asp:DropDownList></td>
                                                <td colspan="7" rowspan="5" valign="top">
                                                    <asp:GridView ID="GridViewRefNO" runat="server"
                                                        OnRowCommand="GridViewRefNO_RowCommand"
                                                        OnRowDataBound="GridViewRefNO_RowDataBound"
                                                        OnRowDeleting="GridViewRefNO_RowDeleting"
                                                        OnSelectedIndexChanged="GridViewRefNO_SelectedIndexChanged" ShowFooter="True" AllowPaging="True" OnPageIndexChanging="GridViewRefNO_PageIndexChanging">
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;<asp:Label ID="Label2" runat="server" Text="Process Flow ID"></asp:Label></td>
                                                <td>:</td>
                                                <td colspan="4">
                                                    <asp:DropDownList ID="ddlProcessFlowId" runat="server"
                                                        OnSelectedIndexChanged="ddlProcessFlowId_SelectedIndexChanged"
                                                        AutoPostBack="True" Width="305px">
                                                    </asp:DropDownList></td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;<asp:Label ID="Label3" runat="server" Text="Department ID"></asp:Label></td>
                                                <td>:</td>
                                                <td colspan="4">
                                                    <asp:DropDownList ID="ddlDepartmentId" runat="server" AutoPostBack="True"
                                                        OnSelectedIndexChanged="ddlDepartmentId_SelectedIndexChanged"
                                                        Width="305px">
                                                    </asp:DropDownList></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label22" runat="server" Text="Employee Code"></asp:Label></td>
                                                <td>:</td>
                                                <td colspan="4">
                                                    <asp:TextBox ID="txtEmployeeSearch" runat="server" AutoPostBack="True" OnTextChanged="txtEmployeeSearch_TextChanged" placeholder="Employee Code" Width="300px"></asp:TextBox>
                                                    <cc1:AutoCompleteExtender ID="txtEmployeeSearch_AutoCompleteExtender" runat="server" CompletionListCssClass="autocomplete_completionListElement" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListItemCssClass="autocomplete_listItem2" DelimiterCharacters="" MinimumPrefixLength="1" ServiceMethod="GetEmpId" ServicePath="~/WebService/ServiceSystem.asmx" TargetControlID="txtEmployeeSearch" BehaviorID="_content_txtEmployeeSearch_AutoCompleteExtender"></cc1:AutoCompleteExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label4" runat="server" Text="Team Name"></asp:Label></td>
                                                <td>:</td>
                                                <td colspan="4">
                                                    <asp:TextBox ID="txtProcessName" runat="server" Width="300px"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td colspan="8">
                                                    <asp:RadioButtonList ID="rblProcessType" runat="server"
                                                        RepeatDirection="Horizontal" AutoPostBack="True"
                                                        OnSelectedIndexChanged="rblProcessType_SelectedIndexChanged">
                                                        <asp:ListItem Text="Add New Process" Value="Y"></asp:ListItem>
                                                        <asp:ListItem Text="Modify Existing Process" Value="N"></asp:ListItem>
                                                    </asp:RadioButtonList></td>
                                                <td colspan="2">&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="13">
                                                    <asp:Panel ID="PanelLeaveHdr2" runat="server" CssClass="cpHeaderContent" HorizontalAlign="Center" Width="100%">APPROVAL FLOW CONFIGURE</asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="120px">&nbsp;<asp:Label ID="Label5" runat="server" Text="Level"></asp:Label></td>
                                                <td>&nbsp;</td>
                                                <td>
                                                    <asp:Label ID="Label6" runat="server" Text="Access ID"></asp:Label></td>
                                                <td>&nbsp;</td>
                                                <td>
                                                    <asp:Label ID="Label7" runat="server" Text="Access Permission"></asp:Label></td>
                                                <td>&nbsp;</td>
                                                <td>
                                                    <asp:Label ID="Label8" runat="server" Text="SubAccess ID"></asp:Label></td>
                                                <td>&nbsp;</td>
                                                <td>
                                                    <asp:Label ID="Label23" runat="server" Text="Access Permission"></asp:Label></td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td valign="top">
                                                    <asp:DropDownList ID="ddlProcessLevelId" runat="server" Width="150px"></asp:DropDownList></td>
                                                <td rowspan="2">&nbsp;</td>
                                                <td valign="top">
                                                    <asp:TextBox ID="txtAccessId" runat="server" AutoPostBack="True"
                                                        OnTextChanged="txtAccessId_TextChanged" Style="height: 22px" Width="120px"></asp:TextBox>
                                                    <cc1:AutoCompleteExtender ID="txtAccessId_AutoCompleteExtender" runat="server"
                                                        DelimiterCharacters="" MinimumPrefixLength="1"
                                                        ServiceMethod="EmployeeID"
                                                        ServicePath="~/WebService/ServiceSystem.asmx"
                                                        TargetControlID="txtAccessId" BehaviorID="_content_txtAccessId_AutoCompleteExtender">
                                                    </cc1:AutoCompleteExtender>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td valign="top" rowspan="2">
                                                    <div style="overflow: scroll; height: 65px; border-width: 1px; border-style: solid; border-color: black;">
                                                        <asp:CheckBoxList ID="ChkLisBoxAccessPermissionType" runat="server" RepeatDirection="Horizontal"></asp:CheckBoxList>
                                                    </div>
                                                </td>
                                                <td rowspan="2">&nbsp;</td>
                                                <td valign="top">
                                                    <asp:TextBox ID="txtSubAccessId0" runat="server" AutoPostBack="True"
                                                        OnTextChanged="txtSubAccessId0_TextChanged" Style="margin-left: 0px" Width="120px"></asp:TextBox><cc1:AutoCompleteExtender ID="txtSubAccessId0_AutoCompleteExtender"
                                                            runat="server" DelimiterCharacters="" MinimumPrefixLength="1"
                                                            ServiceMethod="Emp_Mas_Emp_Id"
                                                            ServicePath="~/modules/Payroll/WebService.asmx"
                                                            TargetControlID="txtSubAccessId0" BehaviorID="_content_txtSubAccessId0_AutoCompleteExtender">
                                                        </cc1:AutoCompleteExtender>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td valign="top" rowspan="2">
                                                    <div class="CheckListBoxStyle" style="overflow: scroll; height: 65px; border-width: 1px; border-style: solid; border-color: black;">
                                                        <asp:CheckBoxList ID="chklistboxAccessSubPermission" runat="server"
                                                            CssClass="checkBoxList" RepeatDirection="Horizontal">
                                                        </asp:CheckBoxList>
                                                    </div>
                                                </td>
                                                <td rowspan="2">&nbsp;</td>
                                                <td valign="top">
                                                    <asp:Button ID="btnAdd" runat="server" CssClass="btn2" OnClick="btnAdd_Click" Text="Add" Width="50px" /></td>
                                                <td>&nbsp;</td>
                                                <td valign="top">
                                                    <asp:TextBox ID="txtMonitoringId1" runat="server" AutoPostBack="True" OnTextChanged="txtMonitoringId1_TextChanged" Style="height: 22px" Visible="False" Width="155px"></asp:TextBox><cc1:AutoCompleteExtender ID="txtMonitoringId1_AutoCompleteExtender" runat="server" DelimiterCharacters="" MinimumPrefixLength="1" ServiceMethod="Emp_Mas_Emp_Id" ServicePath="~/modules/Payroll/WebService.asmx" TargetControlID="txtMonitoringId1" BehaviorID="_content_txtMonitoringId1_AutoCompleteExtender"></cc1:AutoCompleteExtender>
                                                    <asp:TextBox ID="txtSuperUserId1" runat="server" AutoPostBack="True" OnTextChanged="txtSuperUserId1_TextChanged" Visible="False" Width="155px"></asp:TextBox><cc1:AutoCompleteExtender ID="txtSuperUserId1_AutoCompleteExtender" runat="server" DelimiterCharacters="" MinimumPrefixLength="1" ServiceMethod="Emp_Mas_Emp_Id" ServicePath="~/modules/Payroll/WebService.asmx" TargetControlID="txtSuperUserId1" BehaviorID="_content_txtSuperUserId1_AutoCompleteExtender"></cc1:AutoCompleteExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td colspan="2">&nbsp;</td>
                                                <td colspan="2">&nbsp;</td>
                                                <td colspan="2">&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td colspan="8">&nbsp;</td>
                                                <td colspan="2">&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="13">&nbsp;&nbsp;
                                                    <asp:GridView ID="grdViewForBindControl" runat="server"
                                                        AutoGenerateColumns="False" OnRowCommand="grdViewForBindControl_RowCommand"
                                                        OnRowDataBound="grdViewForBindControl_RowDataBound"
                                                        OnRowDeleting="grdViewForBindControl_RowDeleting"
                                                        OnRowEditing="grdViewForBindControl_RowEditing"
                                                        OnSelectedIndexChanged="grdViewForBindControl_SelectedIndexChanged"
                                                        Width="1100px">
                                                        <Columns>
                                                            <asp:BoundField DataField="Line" HeaderText="Line No" />
                                                            <asp:BoundField DataField="Level Id" HeaderText="Level Id" />
                                                            <asp:BoundField DataField="Level IdValue" HeaderText="Level IdValue" />
                                                            <asp:BoundField DataField="Access Id" HeaderText="Access Id" />
                                                            <asp:BoundField DataField="Access Permission" HeaderText="Access Permission" />
                                                            <asp:BoundField DataField="Access PermissionValue "
                                                                HeaderText="Access PermissionValue " />
                                                            <asp:BoundField DataField="SubAccess Id" HeaderText="SubAccess Id" />
                                                            <asp:BoundField DataField="SubAccess Permission"
                                                                HeaderText="SubAccess Permission" />
                                                            <asp:BoundField DataField="SubAccess PermissionValue"
                                                                HeaderText="SubAccess PermissionValue" />
                                                            <asp:BoundField DataField="SuperUser Id" HeaderText="SuperUser Id" />
                                                            <asp:BoundField DataField="Monitoring Id" HeaderText="Monitoring Id" />
                                                            <asp:CommandField ShowSelectButton="True" HeaderText="Edit" />
                                                            <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">&nbsp;</td>
                                                <td colspan="8">&nbsp;</td>
                                                <td colspan="2">&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="13">
                                                    <asp:Panel ID="PanelLeaveHdr0" runat="server" CssClass="cpHeaderContent" Width="100%" HorizontalAlign="Center">EMPLOYEE DETAILS</asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="13">
                                                    <asp:Panel ID="PanelForSearchControl" runat="server">
                                                        <table style="width: 100%;">
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label12" runat="server" Text="Section"></asp:Label></td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlSection" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSection_SelectedIndexChanged" Width="300px"></asp:DropDownList></td>
                                                                <td align="right">
                                                                    <asp:Label ID="Label13" runat="server" Text="Office Location"></asp:Label></td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlOfficeLocation" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlOfficeLocation_SelectedIndexChanged" Width="300px"></asp:DropDownList></td>
                                                                <td style="text-align: right">
                                                                    <asp:Button ID="btnSaveConfigurationbyDepartmentEmployee" runat="server" CssClass="btn2" OnClick="btnSaveConfigurationbyDepartmentEmployee_Click" OnClientClick="ShowConfirmBox(this,'Are you sure save data ?'); return false;" Text="Save" Width="100px" /></td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="13">
                                                    <asp:GridView ID="GridViewEmployeeDetails" runat="server" AutoGenerateColumns="False" EmptyDataText="No Data Found !" OnRowDataBound="GridViewEmployeeDetails_RowDataBound" OnSelectedIndexChanged="GridViewEmployeeDetails_SelectedIndexChanged" Width="100%">
                                                        <Columns>
                                                            <asp:BoundField DataField="EmpID" HeaderText="Employee Id">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="EmpName" HeaderText="Employee Name">
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Designation" HeaderText="Designation">
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Division_Master_Name" HeaderText="Office Location">
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Sect" HeaderText="Section">
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:CheckBox ID="chkheader" runat="server" OnCheckedChanged="chkheader_CheckedChanged" onclick="checkAll(this);" />
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="chkchild" runat="server" onclick="Check_Click(this)" />
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2"></td>
                                                <td colspan="4"></td>
                                                <td colspan="4">&nbsp;</td>
                                                <td colspan="2"></td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">&nbsp;</td>
                                                <td colspan="8">&nbsp;</td>
                                                <td colspan="2">&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="13">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">&nbsp;</td>
                                                <td colspan="8">&nbsp;</td>
                                                <td colspan="2">&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </cc1:TabPanel>
                                <cc1:TabPanel ID="TabPanel6" runat="server" HeaderText="TabPanel4">
                                    <HeaderTemplate>Process View</HeaderTemplate>
                                    <ContentTemplate>
                                        <table style="width: 100%; text-align: left">
                                            <tr>
                                                <td style="width: 94px">
                                                    <asp:Label ID="Label9" runat="server" Text="Process ID"></asp:Label></td>
                                                <td style="width: 14px">&nbsp;:</td>
                                                <td>
                                                    <asp:DropDownList ID="DropDownListProcessId" runat="server" Width="305px"></asp:DropDownList></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 94px">
                                                    <asp:Label ID="Label24" runat="server" Text="Process ID"></asp:Label></td>
                                                <td style="width: 14px">:</td>
                                                <td>
                                                    <asp:DropDownList ID="DropDownListdept" runat="server" Width="305px"></asp:DropDownList></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 94px">
                                                    <asp:Label ID="Label25" runat="server" Text="Process ID"></asp:Label></td>
                                                <td style="width: 14px">:</td>
                                                <td>
                                                    <asp:TextBox ID="txtEmployeeSearchProcessView" runat="server" AutoPostBack="True" placeholder="Employee Code" Width="300px"></asp:TextBox><ajaxToolkit:AutoCompleteExtender ID="txtEmployeeSearchProcessView_AutoCompleteExtender" runat="server"
                                                        CompletionListCssClass="autocomplete_completionListElement"
                                                        CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                                                        CompletionListItemCssClass="autocomplete_listItem2"
                                                        DelimiterCharacters="" Enabled="True" MinimumPrefixLength="1"
                                                        ServiceMethod="GetEmpId"
                                                        ServicePath="~/modules/Payroll/WebService.asmx"
                                                        TargetControlID="txtEmployeeSearchProcessView">
                                                    </ajaxToolkit:AutoCompleteExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 94px">&nbsp;</td>
                                                <td style="width: 14px">&nbsp;</td>
                                                <td>
                                                    <asp:Button ID="btnProcessView" runat="server" Text="View" Width="100px" OnClick="btnProcessView_Click" /></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 94px">&nbsp;</td>
                                                <td style="width: 14px">&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <asp:GridView ID="GridProcessView" runat="server" AutoGenerateColumns="False" EmptyDataText="No Data Found !" Width="100%">
                                                        <Columns>
                                                            <asp:BoundField DataField="ApplicantID" HeaderText="Employee Id">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="EmpName" HeaderText="Employee Name">
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Designation" HeaderText="Designation">
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Office" HeaderText="Office Location">
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="DeptID" HeaderText="Dept">
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Dept" HeaderText="Department">
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Sect" HeaderText="Section">
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="ProcessLevelid" HeaderText="Level">
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Accessid" HeaderText="AccesId">
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="AccessName" HeaderText="AccessName">
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="ProcessName" HeaderText="ProcessName">
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="ReferenceNo" HeaderText="Reference">
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 94px">&nbsp;</td>
                                                <td style="width: 14px">&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </cc1:TabPanel>
                            </cc1:TabContainer>

                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </ContentTemplate>
        <Triggers>
            <%--<asp:AsyncPostBackTrigger ControlID="btnSaveConfigurationbyDepartmentEmployee" EventName="Click" />--%>
            <asp:PostBackTrigger ControlID="TabContainer1$TabPanel5$btnSaveConfigurationbyDepartmentEmployee" />
        </Triggers>
    </asp:UpdatePanel>
    <script type="text/javascript">
        function checkAll(objRef) {
            var GridView = objRef.parentNode.parentNode.parentNode;
            var inputList = GridView.getElementsByTagName("input");
            for (var i = 0; i < inputList.length; i++) {
                var row = inputList[i].parentNode.parentNode;
                if (inputList[i].type == "checkbox" && objRef != inputList[i]) {
                    if (objRef.checked) {
                        row.style.backgroundColor = "silver";
                        if (inputList[i].disabled == false) {
                            inputList[i].checked = true;
                        }
                    }
                    else {
                        if (row.rowIndex % 2 == 0) {
                            row.style.backgroundColor = "#C2D69B";
                        }
                        else {
                            row.style.backgroundColor = "white";
                        }
                        inputList[i].checked = false;
                    }
                }
            }
        }
    </script>
</asp:Content>
