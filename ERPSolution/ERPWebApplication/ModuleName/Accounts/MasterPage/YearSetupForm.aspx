<%@ Page Title="Year Setup" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="YearSetupForm.aspx.cs" Inherits="ERPWebApplication.ModuleName.Accounts.MasterPage.YearSetupForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <ajaxToolkit:TabContainer ID="TabContainer2" runat="server" CssClass="tab" ActiveTabIndex="0"
                Width="100%" CssTheme="None">
                <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="YEAR SETUP">
                    <ContentTemplate>
                        <table style="width: 100%;">
                            <tr>
                                <td colspan="3">
                                    <asp:Label ID="Label22" runat="server" Text="Last Open Year :"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:Panel ID="PanelLastOpenYear" runat="server">
                                        <table style="width: 65%;margin-left:100px;">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label23" runat="server" Text="Start Date"></asp:Label>
                                                </td>
                                                <td>:</td>
                                                <td>
                                                    <asp:TextBox ID="txtLastYearStartDate" runat="server" TextMode="Date" Enabled="False"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label24" runat="server" Text="End Date"></asp:Label>
                                                </td>
                                                <td>:</td>
                                                <td>
                                                    <asp:TextBox ID="txtLastYearEndDate" runat="server" TextMode="Date" Enabled="False"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr >
                                <td colspan="3" style="padding-left:100px" >
                                    <asp:Label ID="lblLastOpenYear" runat="server" Text="Year did not open yet."></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:Panel ID="PanelOpenNewYear" runat="server">
                                        <table style="width: 100%;">
                                            <tr>
                                                <td colspan="3">
                                                    <asp:Label ID="Label26" runat="server" Text="Open New Year :"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <table style="width: 65%;margin-left:100px;">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label27" runat="server" Text="Start Date"></asp:Label>
                                                            </td>
                                                            <td>:</td>
                                                            <td>
                                                                <asp:TextBox ID="txtNewYearStartDate" runat="server" TextMode="Date"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label28" runat="server" Text="End Date"></asp:Label>
                                                            </td>
                                                            <td>:</td>
                                                            <td>
                                                                <asp:TextBox ID="txtNewYearEndDate" runat="server" TextMode="Date"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label29" runat="server" Text="Open By"></asp:Label>
                                                            </td>
                                                            <td>:</td>
                                                            <td colspan="4">
                                                                <asp:TextBox ID="txtOpenBy" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label30" runat="server" Text="Remarks"></asp:Label>
                                                            </td>
                                                            <td>:</td>
                                                            <td colspan="4">
                                                                <asp:TextBox ID="txtRemarks" runat="server" MaxLength="255" TextMode="MultiLine" Width="250px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td colspan="4">
                                                                <asp:Button ID="btnYearOpen" runat="server" OnClick="btnYearOpen_Click" Text="Year Open" Width="100px" />
                                                                <asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click" Text="Clear" Width="100px" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td colspan="4">&nbsp;</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="YEAR CLOSING">
                    <ContentTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td class="auto-style1">&nbsp;</td>
                                <td class="auto-style2">&nbsp;</td>
                                <td class="auto-style6">&nbsp;</td>
                                <td class="auto-style4">&nbsp;</td>
                                <td class="auto-style5">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>

                                <td class="auto-style1">
                                    <asp:Label ID="Label16" runat="server" Text="Current Year From"></asp:Label>
                                </td>

                                <td class="auto-style2">:</td>
                                <td class="auto-style6">
                                    <asp:TextBox ID="dtpCurrentFrom" runat="server" Width="200px"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="dtpCurrentFrom_CalendarExtender" runat="server"
                                        Enabled="True" Format="dd/MM/yyyy" TargetControlID="dtpCurrentFrom"></ajaxToolkit:CalendarExtender>
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="Label17" runat="server" Text="Current Year To"></asp:Label>
                                </td>
                                <td class="auto-style5">:</td>
                                <td>
                                    <asp:TextBox ID="dtpCurrentYearto" runat="server" Width="200px"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="dtpCurrentYearto_CalendarExtender" runat="server"
                                        Enabled="True" Format="dd/MM/yyyy" TargetControlID="dtpCurrentYearto"></ajaxToolkit:CalendarExtender>
                                </td>

                            </tr>
                            <tr>
                                <td class="auto-style1">
                                    <asp:Label ID="Label18" runat="server" Text="Closing Year From"></asp:Label>
                                </td>
                                <td class="auto-style2">:</td>
                                <td class="auto-style6">
                                    <asp:TextBox ID="dtpCloseFrom" runat="server" Width="200px"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="dtpCloseFrom_CalendarExtender" runat="server"
                                        Enabled="True" Format="dd/MM/yyyy" TargetControlID="dtpCloseFrom"></ajaxToolkit:CalendarExtender>
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="Label19" runat="server" Text="Closing Year To"></asp:Label>
                                </td>
                                <td class="auto-style5">:</td>
                                <td>
                                    <asp:TextBox ID="dtpCloseTo" runat="server" Width="200px"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="dtpCloseTo_CalendarExtender" runat="server"
                                        Enabled="True" Format="dd/MM/yyyy" TargetControlID="dtpCloseTo"></ajaxToolkit:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style1">
                                    <asp:Label ID="Label20" runat="server" Text="Starting Year From"></asp:Label>
                                </td>
                                <td class="auto-style2">:</td>
                                <td class="auto-style6">
                                    <asp:TextBox ID="dtpStart" runat="server" Width="200px"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="dtpStart_CalendarExtender" runat="server"
                                        Enabled="True" Format="dd/MM/yyyy" TargetControlID="dtpStart"></ajaxToolkit:CalendarExtender>
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="Label21" runat="server" Text="Ending Year"></asp:Label>
                                </td>
                                <td class="auto-style5">:</td>
                                <td>
                                    <asp:TextBox ID="dtpEnd" runat="server" Width="200px"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="dtpEnd_CalendarExtender" runat="server"
                                        Enabled="True" Format="dd/MM/yyyy" TargetControlID="dtpEnd"></ajaxToolkit:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style1">&nbsp;</td>
                                <td class="auto-style2">&nbsp;</td>
                                <td class="auto-style6">&nbsp;</td>
                                <td class="auto-style4">&nbsp;</td>
                                <td class="auto-style5">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style1">&nbsp;</td>
                                <td class="auto-style2">&nbsp;</td>
                                <td class="auto-style6">&nbsp;</td>
                                <td class="auto-style4">&nbsp;</td>
                                <td class="auto-style5">&nbsp;</td>
                                <td>
                                    <asp:Button ID="btnProcesscLosing" runat="server" Text="Process Closing" Width="120px" />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style1">&nbsp;</td>
                                <td class="auto-style2">&nbsp;</td>
                                <td class="auto-style6">&nbsp;</td>
                                <td class="auto-style4">&nbsp;</td>
                                <td class="auto-style5">&nbsp;</td>
                                <td>
                                    <asp:Button ID="btndeleteclosing" runat="server" Text="Delete Closing" Width="120px" />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style1">&nbsp;</td>
                                <td class="auto-style2">&nbsp;</td>
                                <td class="auto-style6">&nbsp;</td>
                                <td class="auto-style4">&nbsp;</td>
                                <td class="auto-style5">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style1">&nbsp;</td>
                                <td class="auto-style2">&nbsp;</td>
                                <td class="auto-style6">&nbsp;</td>
                                <td class="auto-style4">&nbsp;</td>
                                <td class="auto-style5">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
            </ajaxToolkit:TabContainer>
        </ContentTemplate>
        <Triggers></Triggers>
    </asp:UpdatePanel>
</asp:Content>
