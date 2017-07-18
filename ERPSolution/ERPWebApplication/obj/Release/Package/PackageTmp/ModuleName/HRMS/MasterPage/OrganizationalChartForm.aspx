<%@ Page Title="Organizational Chart" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrganizationalChartForm.aspx.cs" Inherits="ERPWebApplication.ModuleName.HRMS.MasterPage.OrganizationalChartForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table style="width: 100%; text-align: left">
                <tr>
                    <td colspan="3">
                        <ajaxToolkit:TabContainer ID="TabContainerOrgChart" Height="100%" Width="100%" runat="server" ActiveTabIndex="1" CssClass="tab" CssTheme="None" EnableTheming="True" ToolTip="Organizational Chart">

                            <ajaxToolkit:TabPanel runat="server" HeaderText="Organization Elements" ID="TabPanel1">
                                <ContentTemplate>
                                    <table style="width: 100%;">
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label1" runat="server" Text="Company"></asp:Label>
                                            </td>
                                            <td>:</td>
                                            <td>
                                                <asp:DropDownList ID="ddlCompany" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCompany_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                            <td rowspan="2" style="text-align: right; float: right; width: 435px">
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
                                                <asp:Label ID="Label2" runat="server" Text="Elements" Font-Underline="False"></asp:Label>
                                            </td>
                                            <td>:</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <table style="width: 100%;">
                                                    <tr>
                                                        <td>
                                                            <asp:ListBox ID="ListBoxStandardOrgElements" runat="server" Height="300px" Width="500px"></asp:ListBox>
                                                        </td>
                                                        <td>
                                                            <table style="width: 100%;">
                                                                <tr>
                                                                    <td>
                                                                        <asp:Button ID="btnForword" runat="server" Text="&gt;" Width="25px" OnClick="btnForword_Click" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Button ID="btnForwordAll" runat="server" Text="&gt;&gt;" Width="25px" OnClick="btnForwordAll_Click" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Button ID="btnBack" runat="server" Text="&lt;" Width="25px" OnClick="btnBack_Click" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Button ID="btnBackAll" runat="server" Text="&lt;&lt;" Width="25px" OnClick="btnBackAll_Click" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td>
                                                            <asp:ListBox ID="ListBoxOrganizationElements" runat="server" Height="300px" Width="500px" AutoPostBack="True"></asp:ListBox>
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
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </ajaxToolkit:TabPanel>


                            <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="Organizational Chart Setup">
                                <ContentTemplate>
                                    <table style="width: 100%;">
                                        <tr>
                                            <td colspan="2" style="text-align: left; float: left; width: 500px">
                                                <asp:TreeView ID="TreeViewCompanyChart" runat="server" OnTreeNodePopulate="TreeViewCompanyChart_TreeNodePopulate" OnSelectedNodeChanged="TreeViewCompanyChart_SelectedNodeChanged">
                                                </asp:TreeView>
                                            </td>
                                            <td colspan="2" style="text-align: left; float: left; width: 430px">
                                                <table style="width: 100%;">
                                                    <tr>
                                                        <td colspan="3">
                                                            <div style="position: fixed; width: 425px; background-color: white; height: 100px">
                                                                <table style="width: 70%; margin-left: 5px">
                                                                    <tr>
                                                                        <td colspan="2">
                                                                            <asp:Button ID="btnAddNew" runat="server" Text="Add New" Width="150px" OnClick="btnAddNew_Click" />
                                                                        </td>
                                                                        <td colspan="2">
                                                                            <asp:Button ID="btnEdit" runat="server" Text="Edit" Width="150px" OnClick="btnEdit_Click" />
                                                                        </td>
                                                                        <td>
                                                                            <asp:Button ID="Button3" runat="server" Text="Print" Width="95px" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Button ID="btnSaveChart" runat="server" OnClick="btnSaveChart_Click" Text="Save" Width="70px" CssClass="buttonCommand" />
                                                                        </td>
                                                                        <td>
                                                                            <asp:Button ID="btnClearChart" runat="server" OnClick="btnClearChart_Click" Text="Clear" Width="70px" CssClass="buttonCancel" />
                                                                        </td>
                                                                        <td>
                                                                            <asp:Button ID="btnUpdate" runat="server" Text="Update" Width="70px" OnClick="btnUpdate_Click" CssClass="buttonCommand" />
                                                                        </td>
                                                                        <td>
                                                                            <asp:Button ID="btnClearUpdate" runat="server" Text="Clear" Width="70px" OnClick="btnClearUpdate_Click" CssClass="buttonCancel" />
                                                                        </td>
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
                                                            &nbsp;</td>
                                                        <td>&nbsp;</td>
                                                        <td>
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label3" runat="server" Text="Company"></asp:Label>
                                                        </td>
                                                        <td>:</td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlCompanyChart" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCompanyChart_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label4" runat="server" Text="Element"></asp:Label>
                                                        </td>
                                                        <td>:</td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlElement" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlElement_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblParentElementValue" runat="server" Visible="False"></asp:Label>
                                                        </td>
                                                        <td>&nbsp;</td>
                                                        <td>
                                                            <asp:Label ID="lblParentElementText" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label5" runat="server" Text="Title"></asp:Label>
                                                        </td>
                                                        <td>:</td>
                                                        <td>
                                                            <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label7" runat="server" Text="Short Name"></asp:Label>
                                                        </td>
                                                        <td>:</td>
                                                        <td>
                                                            <asp:TextBox ID="txtShortName" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label8" runat="server" Text="Display Name"></asp:Label>
                                                        </td>
                                                        <td>:</td>
                                                        <td>
                                                            <asp:TextBox ID="txtDisplayName" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label9" runat="server" Text="Email"></asp:Label>
                                                        </td>
                                                        <td>:</td>
                                                        <td>
                                                            <asp:TextBox ID="txtEmail" runat="server" TextMode="Email"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label10" runat="server" Text="Name of Head"></asp:Label>
                                                        </td>
                                                        <td>:</td>
                                                        <td>
                                                            <asp:TextBox ID="txtHeadID" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label12" runat="server" Text="Category"></asp:Label>
                                                        </td>
                                                        <td>:</td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlCategory" runat="server">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label13" runat="server" Text="Opening Date"></asp:Label>
                                                        </td>
                                                        <td>:</td>
                                                        <td>
                                                            <asp:TextBox ID="txtOpeningDate" runat="server" TextMode="Date"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                        <td>
                                                            <asp:CheckBox ID="CheckBoxAddress" runat="server" CssClass="checkbox"
                                                                AutoPostBack="True" OnCheckedChanged="CheckBoxAddress_CheckedChanged" />
                                                            <asp:Label ID="Label6" runat="server" AssociatedControlID="CheckBoxAddress" CssClass="checkbox">Address</asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">
                                                            <asp:Panel ID="PanelAddress" runat="server">
                                                                <table style="width: 95%;">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="Label14" runat="server" Text="Contact Number"></asp:Label>
                                                                        </td>
                                                                        <td>:</td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtContactNumber" runat="server" TextMode="Number"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="Label15" runat="server" Text="Display Address"></asp:Label>
                                                                        </td>
                                                                        <td>:</td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtDisplayAddress" runat="server" TextMode="MultiLine" Width="250px"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="Label17" runat="server" Text="Division"></asp:Label>
                                                                        </td>
                                                                        <td>:</td>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddlDivision" runat="server">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="Label16" runat="server" Text="District"></asp:Label>
                                                                        </td>
                                                                        <td>:</td>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddlDistrict" runat="server">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="Label18" runat="server" Text="Postal Code"></asp:Label>
                                                                        </td>
                                                                        <td>:</td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtPostalCode" runat="server"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="Label19" runat="server" Text="Phone No"></asp:Label>
                                                                        </td>
                                                                        <td>:</td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtPhoneNo" runat="server"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="Label20" runat="server" Text="Fax"></asp:Label>
                                                                        </td>
                                                                        <td>:</td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtFax" runat="server"></asp:TextBox>
                                                                        </td>
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
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td colspan="2">&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td colspan="2">&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </ajaxToolkit:TabPanel>

                        </ajaxToolkit:TabContainer></td>
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
        </ContentTemplate>
        <Triggers></Triggers>
    </asp:UpdatePanel>
</asp:Content>
