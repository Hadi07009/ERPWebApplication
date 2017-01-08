<%@ Page Title="New Company.." Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewCompany.aspx.cs" Inherits="ERPWebApplication.ModuleName.Organization.MasterPage.NewCompany" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 108px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%;">
        <tr>
            <td colspan="2" style="width: 600px; float: left">
                <table style="width: 100%;">
                    <tr>
                        <td class="auto-style1">
                            <asp:Label ID="Label1" runat="server" Text="Country Name"></asp:Label>
                        </td>
                        <td>:</td>
                        <td>
                            <asp:DropDownList ID="ddlCountry" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label ID="Label2" runat="server" Text="Company Name"></asp:Label>
                        </td>
                        <td>:</td>
                        <td>
                            <asp:TextBox ID="txtCompanyName" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </td>
            <td colspan="2" style="text-align: left; float: left">
                <table style="width: 100%;">
                    <tr>
                        <td colspan="3" style="margin-top: -5px">
                            <div style="position: fixed; width: 425px; background-color: #00817F; height: 50px">
                                <table style="width: 70%;margin-left:5px">
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnSave" runat="server" Text="Save" Width="100px" /></td>
                                        <td>
                                            <asp:Button ID="btnClear" runat="server" Text="Clear" Width="100px" /></td>
                                        <td>
                                            <asp:Button ID="btnPrint" runat="server" Text="Print" Width="100px" /></td>
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
</asp:Content>
