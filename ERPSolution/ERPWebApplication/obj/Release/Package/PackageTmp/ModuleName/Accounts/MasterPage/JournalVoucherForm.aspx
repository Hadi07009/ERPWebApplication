<%@ Page Title="Journal Voucher" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="JournalVoucherForm.aspx.cs" Inherits="ERPWebApplication.ModuleName.Accounts.MasterPage.JournalVoucherForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <ajaxToolkit:TabContainer ID="TabContainer2" runat="server" CssClass="tab" ActiveTabIndex="0"
        Width="1150px" CssTheme="None">
        <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="Voucher Entry">
            <ContentTemplate>
                <table style="width: 1140px">
                    <tr>
                        <td class="auto-style27">
                            <asp:Panel ID="Panel2" runat="server" BorderColor="#336699" BorderStyle="Solid"
                                BorderWidth="0px" Height="358px" Width="1140px">
                                <table style="width: 1140px; font-family: Tahoma; font-size: small; height: 313px;">
                                    <tr>
                                        <td valign="top">
                                            <table style="width: 500px">
                                                <tr>
                                                    <td class="auto-style35">
                                                        <asp:Label ID="Label3" runat="server" Text="Journal Type"></asp:Label>
                                                    </td>
                                                    <td class="auto-style32">:</td>
                                                    <td class="auto-style32">
                                                        <asp:DropDownList ID="dplJournalType" runat="server" AutoPostBack="True"
                                                            Width="307px">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style35">
                                                        <asp:Label ID="Label17" runat="server" Text="Transaction Type"></asp:Label>
                                                    </td>
                                                    <td class="auto-style32">:</td>
                                                    <td class="auto-style32">
                                                        <asp:DropDownList ID="dpTransactionype" runat="server" AutoPostBack="True" Width="307px">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style32">
                                                        <asp:Label ID="Label5" runat="server" Text="Journal Date"></asp:Label>
                                                    </td>
                                                    <td>:</td>
                                                    <td class="auto-style32">
                                                        <asp:TextBox ID="dtptrnDate" runat="server" Width="300px"></asp:TextBox>
                                                        <ajaxToolkit:CalendarExtender ID="dtptrnDate_CalendarExtender" runat="server" Format="dd-MMM-yyyy" TargetControlID="dtptrnDate" BehaviorID="_content_dtptrnDate_CalendarExtender"></ajaxToolkit:CalendarExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style32">
                                                        <asp:Label ID="Label6" runat="server" Text="Account Code"></asp:Label>
                                                    </td>
                                                    <td>:</td>
                                                    <td>
                                                        <asp:TextBox ID="txtAccCode" runat="server" AutoPostBack="True"
                                                            Width="300px"></asp:TextBox>
                                                        <ajaxToolkit:AutoCompleteExtender ID="autoComplete1" runat="server"
                                                            BehaviorID="AutoCompleteEx1"
                                                            CompletionListCssClass="autocomplete_completionListElement"
                                                            CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                                                            CompletionListItemCssClass="autocomplete_listItem" CompletionSetCount="20"
                                                            DelimiterCharacters="," EnableCaching="False"
                                                            MinimumPrefixLength="1" ServiceMethod="GetAccountCode"
                                                            ServicePath="~/services/srvSystem.asmx"
                                                            ShowOnlyCurrentWordInCompletionListItem="True" TargetControlID="txtAccCode">
                                                        </ajaxToolkit:AutoCompleteExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style32">
                                                        <asp:Label ID="Label22" runat="server" Text="Transaction Amount"></asp:Label>
                                                    </td>
                                                    <td>:</td>
                                                    <td valign="top" class="auto-style24">
                                                        <asp:TextBox ID="txtAmount" runat="server" onkeyup="UpdateCurrencyAmount();" Width="100px"></asp:TextBox>
                                                        &nbsp;
                                                                    <asp:Label ID="Label9" runat="server" Text="Voucher Type"></asp:Label>
                                                        &nbsp;
                                                                    <asp:DropDownList ID="dplType" runat="server" Width="95px">
                                                                    </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style28">Particulars</td>
                                                    <td class="auto-style42">:</td>
                                                    <td class="auto-style42">
                                                        <asp:TextBox ID="txtNarration" runat="server"
                                                            TextMode="MultiLine" Width="300px" Height="50px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <asp:Panel ID="pnlcurrency" runat="server">
                                                    <tr>
                                                        <td class="auto-style28">
                                                            <asp:Label ID="Label26" runat="server" Text="Transaction Currency"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label27" runat="server" Text=":"></asp:Label>
                                                        </td>
                                                        <td class="auto-style32">
                                                            <asp:Label ID="lblCurrency" runat="server"></asp:Label>
                                                            &nbsp;&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style32">
                                                            <asp:Label ID="Label24" runat="server" Text="Currency Rate"></asp:Label>
                                                        </td>
                                                        <td class="auto-style32">
                                                            <asp:Label ID="Label28" runat="server" Text=":"></asp:Label>
                                                        </td>
                                                        <td class="auto-style32">
                                                            <asp:TextBox ID="txtRate" runat="server" Font-Bold="True" onkeyup="UpdateCurrencyAmount();" Width="70px"></asp:TextBox>
                                                            &nbsp;&nbsp;&nbsp;&nbsp;
                                                                    <asp:Label ID="Label25" runat="server" Text="Base Amount"></asp:Label>
                                                            &nbsp;&nbsp;
                                                                    <asp:TextBox ID="txtCurRate" runat="server" AutoPostBack="True" BackColor="White" Enabled="False" Font-Bold="True" Width="100px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </asp:Panel>
                                                <tr>
                                                    <td class="auto-style32">&nbsp;</td>
                                                    <td class="auto-style32">&nbsp;</td>
                                                    <td class="auto-style32">
                                                        <asp:Button ID="btnSubledger" runat="server" CssClass="CssBtnShowAll" Text="Add Records" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style32">
                                                        <asp:Button ID="btnInsert" runat="server" CssClass="CssBtnShowAll" Text="Insert" Width="90px" Visible="False" />
                                                    </td>
                                                    <td class="auto-style32"></td>
                                                    <td class="auto-style32">
                                                        <asp:TextBox ID="txtReferance" runat="server" AutoPostBack="True" BackColor="White" Enabled="False" Font-Bold="True" Visible="False" Width="90px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style32">&nbsp;</td>
                                                    <td class="auto-style32">&nbsp;</td>
                                                    <td class="auto-style32">&nbsp;</td>
                                                </tr>
                                            </table>

                                        </td>
                                        <td valign="top">

                                            <table>
                                                <tr>
                                                    <td style="text-align: right" class="auto-style32">

                                                        <asp:Button ID="ButtonSave" runat="server" CssClass="CssBtnShowAll" Text="Save Voucher" Width="100px" />
                                                        <asp:Button ID="btnPrint" runat="server" Text="Print" Width="100px" CssClass="CssBtnRegular" />
                                                        <asp:Button ID="btnClearAll" runat="server" Text="Clear ALL" Width="100px" CssClass="CssBtnPrint" />
                                                        <asp:TextBox ID="txtSearch" runat="server" Width="200px"></asp:TextBox>
                                                        <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionListCssClass="autocomplete_completionListElement" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListItemCssClass="autocomplete_listItem" CompletionSetCount="20" DelimiterCharacters="," EnableCaching="False" MinimumPrefixLength="1" ServiceMethod="GetPostedVoucherReferance" ServicePath="~/services/srvSystem.asmx" ShowOnlyCurrentWordInCompletionListItem="True" TargetControlID="txtSearch" BehaviorID="_content_AutoCompleteExtender1">
                                                        </ajaxToolkit:AutoCompleteExtender>
                                                        <asp:Button ID="btnSearch" runat="server" CssClass="CssBtnSearch" Text="Search" Width="100px" />

                                                    </td>

                                                </tr>

                                                <tr>

                                                    <td>
                                                        <asp:GridView ID="gdvJV" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" CssClass="grid" ForeColor="Black" GridLines="Horizontal" ShowFooter="True">
                                                            <Columns>
                                                                <asp:BoundField DataField="Line" HeaderText="Line">
                                                                    <ItemStyle Width="50px" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Account Code" HeaderText="Accounting Code">
                                                                    <ItemStyle Width="100px" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Description" HeaderText="Particulars">
                                                                    <ItemStyle Width="600px" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Dr" HeaderText="Debit">
                                                                    <ItemStyle Width="80px" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Cr" HeaderText="Credit">
                                                                    <ItemStyle Width="80px" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Type" HeaderText="Type">
                                                                    <ItemStyle Width="100px" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Typeid" HeaderText="Typeid">
                                                                    <ItemStyle Width="100px" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Trtype" HeaderText="Trtype">
                                                                    <ItemStyle Width="100px" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Currency Rate" HeaderText="Currency Rate">
                                                                    <ItemStyle Width="100px" />
                                                                </asp:BoundField>
                                                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/App_Themes/Images/remove.png"
                                                                    ShowSelectButton="True" HeaderText="Remove">
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:CommandField>
                                                            </Columns>
                                                            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                                            <HeaderStyle CssClass="gridHeader" />
                                                            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                                                            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>

                                </table>
                            </asp:Panel>
                        </td>


                    </tr>
                    <tr>
                        <td class="auto-style27">

                            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btnShowAnalysisPopup" PopupControlID="PanelAnalysis"
                                BackgroundCssClass="ModalBackgroud" CancelControlID="btnskip" DynamicServicePath="" BehaviorID="_content_ModalPopupExtender1">
                            </ajaxToolkit:ModalPopupExtender>

                            <asp:Panel ID="PanelAnalysis" runat="server" BorderColor="#336699" BorderStyle="Solid" BackColor="White" Height="500px" Style="display: block" Width="1000px">
                                <table style="width: 100%;">
                                    <tr>
                                        <td class="auto-style11" style="text-align: center">SUBLEDGER ENTRY</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table style="width: 100%;">

                                                <tr>
                                                    <td class="auto-style21" style="border-bottom-style: solid; border-bottom-width: 1px; border-color: #808000" valign="top" colspan="6">&nbsp;</td>

                                                </tr>
                                                <tr>
                                                    <td class="auto-style41">
                                                        <asp:Label ID="Label29" runat="server" ForeColor="#0072B0" Text="Account Code"></asp:Label>
                                                    </td>
                                                    <td class="auto-style37">:</td>
                                                    <td class="auto-style40">
                                                        <asp:Label ID="lblAccountCode" runat="server" ForeColor="#0072B0"></asp:Label>
                                                    </td>
                                                    <td class="style33">
                                                        <asp:Label ID="Label2" runat="server" ForeColor="#0072B0" Text="Account Name"></asp:Label>
                                                    </td>
                                                    <td class="auto-style37">:</td>
                                                    <td class="auto-style21">
                                                        <asp:Label ID="lblAccountName" runat="server" ForeColor="#0072B0"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style41">
                                                        <asp:Label ID="Label31" runat="server" ForeColor="#0072B0" Text="Total Amount"></asp:Label>
                                                    </td>
                                                    <td class="auto-style37">:</td>
                                                    <td class="auto-style40">
                                                        <asp:TextBox ID="txttotalamt" runat="server" Enabled="False" Width="100px"></asp:TextBox>
                                                    </td>
                                                    <td class="auto-style36" colspan="3">
                                                        <asp:Label ID="lblSkip" runat="server" ForeColor="#0072B0">Click </asp:Label>
                                                        <asp:LinkButton ID="btnskip" runat="server">Skip</asp:LinkButton>
                                                        &nbsp;<asp:Label ID="lblSkip0" runat="server" ForeColor="#0072B0">if you dont want to add subledger now</asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style38" colspan="3">
                                                        <table style="vertical-align: top">
                                                            <tr>
                                                                <td class="auto-style29" colspan="2">
                                                                    <asp:Label ID="Label1st0" runat="server" ForeColor="#0072B0" Text="Add Subledger Amount"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style29">
                                                                    <asp:Label ID="Label1st" runat="server" ForeColor="#0072B0" Text="1st Analysis"></asp:Label>
                                                                </td>
                                                                <td class="auto-style30">
                                                                    <asp:DropDownList ID="ddl1st" runat="server" Width="200px">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style1">
                                                                    <asp:Label ID="Label2nd" runat="server" ForeColor="#0072B0" Text="2nd Analysis"></asp:Label>
                                                                </td>
                                                                <td class="auto-style18">
                                                                    <asp:DropDownList ID="ddl2nd" runat="server" Width="200px">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style29">
                                                                    <asp:Label ID="Label3rd" runat="server" ForeColor="#0072B0" Text="3rd Analysis"></asp:Label>
                                                                </td>
                                                                <td class="auto-style30">
                                                                    <asp:DropDownList ID="ddl3rd" runat="server" Width="200px">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style29">
                                                                    <asp:Label ID="Label4th" runat="server" ForeColor="#0072B0" Text="4th Analysis"></asp:Label>
                                                                </td>
                                                                <td class="auto-style30">
                                                                    <asp:DropDownList ID="ddl4th" runat="server" Width="200px">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style29">
                                                                    <asp:Label ID="Label5th" runat="server" ForeColor="#0072B0" Text="5th Analysis"></asp:Label>
                                                                </td>
                                                                <td class="auto-style30">
                                                                    <asp:DropDownList ID="ddl5th" runat="server" Width="200px">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style29">
                                                                    <asp:Label ID="Label15" runat="server" ForeColor="#0072B0" Text="Sub Leger Amt"></asp:Label>
                                                                </td>
                                                                <td class="auto-style30">
                                                                    <asp:TextBox ID="txtsplitamt" runat="server" Width="196px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style29">
                                                                    <asp:Label ID="Label14" runat="server" ForeColor="#0072B0" Text="Balance Amount"></asp:Label>
                                                                </td>
                                                                <td class="auto-style30">
                                                                    <asp:TextBox ID="txtbalamt" runat="server" Enabled="False" Width="196px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style29">
                                                                    <asp:Button ID="btnRemoveAnalysis" runat="server" CssClass="CssBtnRegular" Text="Remove" Visible="False" Width="100px" />
                                                                </td>
                                                                <td class="auto-style30">
                                                                    <asp:Button ID="btnInsertAnalysis" runat="server" CssClass="CssBtnShowAll" Text="Insert" Width="100px" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style29">&nbsp;</td>
                                                                <td class="auto-style30">&nbsp;</td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td class="auto-style36" colspan="3" valign="top">
                                                        <table style="width: 100%;">
                                                            <tr>
                                                                <td>&nbsp;</td>
                                                                <td>&nbsp;</td>
                                                                <td style="text-align: right">
                                                                    <asp:Button ID="btnApplyAnalysis" runat="server" CssClass="CssBtnShowAll" Text="Apply" Width="100px" />
                                                                    <asp:TextBox ID="txtSearchAnalysis" runat="server" Width="150px"></asp:TextBox>
                                                                    <asp:Button ID="btnSearchAnalysis" runat="server" CssClass="CssBtnRegular" Text="Search" Width="100px" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="3">
                                                                    <asp:GridView ID="GridViewAnalysis" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" CssClass="grid" ForeColor="Black" GridLines="Horizontal" Width="100%" AutoGenerateColumns="False">
                                                                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                                                        <HeaderStyle CssClass="gridHeader" />
                                                                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                                                                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                                                                        <Columns>
                                                                            <asp:BoundField DataField="Sub Line" HeaderText="Sub Line">
                                                                                <ItemStyle Width="50px" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="Account Code" HeaderText="Account Code">
                                                                                <ItemStyle Width="50px" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="Group-1" HeaderText="Group-1">
                                                                                <ItemStyle Width="50px" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="Group-2" HeaderText="Group-2">
                                                                                <ItemStyle Width="50px" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="Group-3" HeaderText="Group-3">
                                                                                <ItemStyle Width="50px" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="Group-4" HeaderText="Group-4">
                                                                                <ItemStyle Width="50px" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="Group-5" HeaderText="Group-5">
                                                                                <ItemStyle Width="50px" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="Sub-1" HeaderText="Sub-1">
                                                                                <ItemStyle Width="150px" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="Sub-2" HeaderText="Sub-2">
                                                                                <ItemStyle Width="150px" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="Sub-3" HeaderText="Sub-3">
                                                                                <ItemStyle Width="150px" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="Sub-4" HeaderText="Sub-4">
                                                                                <ItemStyle Width="150px" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="Sub-5" HeaderText="Sub-5">
                                                                                <ItemStyle Width="150px" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="Sub1" HeaderText="Sub1">
                                                                                <ItemStyle Width="50px" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="Sub2" HeaderText="Sub2">
                                                                                <ItemStyle Width="50px" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="Sub3" HeaderText="Sub3">
                                                                                <ItemStyle Width="50px" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="Sub4" HeaderText="Sub4">
                                                                                <ItemStyle Width="50px" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="Sub5" HeaderText="Sub5">
                                                                                <ItemStyle Width="50px" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="Amount" HeaderText="Amount">
                                                                                <ItemStyle Width="100px" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="Line" HeaderText="Line">
                                                                                <ItemStyle Width="50px" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="Sub-6" HeaderText="Sub-6">
                                                                                <ItemStyle Width="50px" />
                                                                            </asp:BoundField>
                                                                            <asp:CommandField ButtonType="Image" SelectImageUrl="~/App_Themes/Images/remove.png"
                                                                                ShowSelectButton="True" HeaderText="Remove">
                                                                                <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </asp:CommandField>

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
                                        </td>
                                    </tr>

                                    <tr>
                                        <td></td>
                                    </tr>


                                </table>
                            </asp:Panel>
                            <asp:Button ID="btnShowAnalysisPopup" runat="server" Style="display: none" />
                        </td>
                    </tr>


                </table>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="Unposted Voucher">
            <ContentTemplate>
                <table style="width: 750px">
                    <tr>
                        <td>
                            <asp:Panel ID="Panel3" runat="server" BorderColor="#336699" BorderStyle="Solid"
                                BorderWidth="0px" Height="25px" Style="text-align: right">
                                <asp:Button ID="ButtonPost" runat="server"
                                    Text="Post" Width="100px" CssClass="CssBtnRegular" />
                                <asp:Button ID="ButtonView" runat="server"
                                    Text="View" Width="100px" CssClass="CssBtnShowAll" />
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>

                        <td>
                            <asp:Panel ID="Panel9" runat="server" BorderColor="#336699" BorderStyle="Solid"
                                BorderWidth="0px" Height="450px" Width="100%">
                                <table style="width: 100%;">
                                    <tr>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:GridView ID="gdvView" runat="server" BackColor="White"
                                                BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4"
                                                ForeColor="Black" GridLines="Horizontal"
                                                Width="100%">
                                                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                                <HeaderStyle CssClass="gridHeader" />
                                                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                                                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chk" runat="server"
                                                                Checked="false"
                                                                Text='' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>

                    </tr>
                </table>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>

    </ajaxToolkit:TabContainer>
    <script>
        function UpdateCurrencyAmount() {
            var CRate = document.getElementById('txtRate').value;
            if (CRate == "" || CRate == 0) {
                document.getElementById('txtCurRate').innerHTML = 0;
                document.getElementById("<%=txtCurRate.ClientID%>").value = 0;

            }
            else {
                document.getElementById('txtCurRate').innerHTML = (document.getElementById('txtAmount').value / document.getElementById('txtRate').value).toFixed(4);
                document.getElementById("<%=txtCurRate.ClientID%>").value = (document.getElementById('txtAmount').value / document.getElementById('txtRate').value).toFixed(4);


            }

        }
    </script>
</asp:Content>
