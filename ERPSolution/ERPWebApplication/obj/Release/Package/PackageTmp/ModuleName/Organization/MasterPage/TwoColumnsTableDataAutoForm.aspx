<%@ Page Title="Two Columns Table Data(Auto)" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TwoColumnsTableDataAutoForm.aspx.cs" Inherits="ERPWebApplication.ModuleName.Organization.MasterPage.TwoColumnsTableDataAutoForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table style="width: 100%;text-align:left">
                <tr>
                    <td colspan="3">
                        <asp:GridView ID="grdTableName" runat="server" AutoGenerateColumns="False" Width="40%" OnRowCommand="grdTableName_RowCommand" OnRowDataBound="grdTableName_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="TableID">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTableID" runat="server" Text='<%# Bind("TableID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="TableName">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTableName" runat="server" Text='<%# Bind("TableName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField SelectText="Apply" ShowSelectButton="True" />
                            </Columns>
                        </asp:GridView>
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
        </ContentTemplate>
        <Triggers>

        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
