<%@ Page Title="Subledger Setup" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SubledgerSetupForm.aspx.cs" Inherits="ERPWebApplication.ModuleName.Accounts.MasterPage.SubledgerSetupForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            
    <ajaxToolkit:TabContainer ID="TabContainer2" runat="server" ActiveTabIndex="2"
        Width="763" AutoPostBack="True" CssClass="tab" CssTheme="None">
        <ajaxToolkit:TabPanel runat="server" HeaderText="Subledger Type" ID="TabPanel1">
            <ContentTemplate>

                <table style="width: 100%; font-family: Tahoma; font-size: small;">

                    <tr>
                        <td style="width: 122px">
                            <asp:Label ID="Label2" runat="server"  Text="Subledger Type"></asp:Label>
                        </td>
                        <td style="width: 20px">
                            <asp:Label ID="Label70" runat="server"  Text=":"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtSubledgerType" runat="server" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 122px">
                            <asp:Label ID="Label3" runat="server" 
                                Text="Subledger Prefix"></asp:Label>
                        </td>
                        <td style="width: 20px">
                            <asp:Label ID="Label12" runat="server"  Text=":"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtSubledgerPrefix" runat="server" MaxLength="3" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 122px">
                            <asp:Label ID="Label19" runat="server" 
                                Text="Known By"></asp:Label>
                        </td>
                        <td style="width: 20px">
                            <asp:Label ID="Label21" runat="server"  Text=":"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlKnownValue" runat="server" >
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 122px">
                            <asp:Label ID="Label20" runat="server" 
                                Text="Is Convertible "></asp:Label>
                        </td>
                        <td style="width: 20px">
                            <asp:Label ID="Label22" runat="server"  Text=":"></asp:Label>
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rdoConvert" runat="server"
                                RepeatDirection="Horizontal">
                                <asp:ListItem Selected="True" Value="N">NO</asp:ListItem>
                                <asp:ListItem Value="Y">YES</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 122px">&nbsp;</td>
                        <td style="width: 20px">&nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 122px">&nbsp;</td>
                        <td style="width: 20px">&nbsp;</td>
                        <td>
                            <asp:Button ID="btnSubledgerTypeSave" runat="server" OnClick="btnSubledgerTypeSave_Click" Text="Save" Width="100px" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 122px">&nbsp;</td>
                        <td style="width: 20px">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <table style="width: 100%;">
                                <tr>
                                    <td>
                                        <asp:GridView ID="gdvAccountsGroup" runat="server">

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
                    <tr>
                        <td style="width: 122px">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 122px">&nbsp;</td>
                        <td style="width: 20px">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 122px">&nbsp;</td>
                        <td style="width: 20px">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>

        <ajaxToolkit:TabPanel runat="server" HeaderText="Subledger Setup" ID="TabPanel2">
            <ContentTemplate>
                <table style="width: 100%; font-family: Tahoma; font-size: small;">

                    <tr>
                        <td style="width: 122px">
                            <asp:Label ID="Label4" runat="server"  Text="Subledger Type"></asp:Label>
                        </td>
                        <td style="width: 20px">
                            <asp:Label ID="Label8" runat="server"  Text=":"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlSubLedgerTypeNonConvertable" runat="server" >
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 122px">
                            <asp:Label ID="Label7" runat="server"  Text="Subledger Name"></asp:Label>
                        </td>
                        <td style="width: 20px">
                            <asp:Label ID="Label11" runat="server"  Text=":"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtSubledgerName" runat="server"  ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 122px">
                            <asp:Label ID="Label71" runat="server"  Text="Description"></asp:Label>
                        </td>
                        <td style="width: 20px">
                            <asp:Label ID="Label72" runat="server"  Text=":"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDescription" runat="server"  ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 122px">&nbsp;</td>
                        <td style="width: 20px">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 122px">&nbsp;</td>
                        <td style="width: 20px">&nbsp;</td>
                        <td>
                            <asp:Button ID="btnSaveSubLedger" runat="server" Text="Save" Width="83px" OnClick="btnSaveSubLedger_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 122px">&nbsp;</td>
                        <td style="width: 20px">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <table style="width: 100%;">
                                <tr>
                                    <td>
                                        <asp:GridView ID="gdvSubHead" runat="server"
                                            Width="100%">
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
                    <tr>
                        <td style="width: 122px">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 122px">&nbsp;</td>
                        <td style="width: 20px">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 122px">&nbsp;</td>
                        <td style="width: 20px">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>

        <ajaxToolkit:TabPanel runat="server" HeaderText="Convert to Subledger" ID="TabPanel3">

            <ContentTemplate>
                <table style="width: 100%; font-family: Tahoma; font-size: small;">

                    <tr>
                        <td style="width: 122px">
                            <asp:Label ID="Label13" runat="server"  Text="Subledger Type"></asp:Label>
                        </td>
                        <td style="width: 20px">
                            <asp:Label ID="Label14" runat="server"  Text=":"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlSubLedgerTypeConvertible" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 122px">&nbsp;</td>
                        <td style="width: 20px">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 122px">&nbsp;</td>
                        <td style="width: 20px">&nbsp;</td>
                        <td>
                            <asp:Button ID="btnConvertSubledger" runat="server" Text="Convert" Width="100px" OnClick="btnConvertSubledger_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 122px">&nbsp;</td>
                        <td style="width: 20px">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <table style="width: 100%;">
                                <tr>
                                    <td>
                                        <asp:GridView ID="gdvConvertedLedger" runat="server"
                                            Width="100%">
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 122px">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 122px">&nbsp;</td>
                        <td style="width: 20px">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 122px">&nbsp;</td>
                        <td style="width: 20px">&nbsp;</td>
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
