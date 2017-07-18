<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OrganizationalChartControl.ascx.cs" Inherits="ERPWebApplication.WebUserControls.OrganizationalChartControl" %>
<table style="width: 100%;">
    <tr>
        <td colspan="3">
            <asp:GridView ID="GridViewOrganizationalChart" runat="server" AutoGenerateColumns="False" ShowHeader="False" Width="395px" OnRowDataBound="GridViewOrganizationalChart_RowDataBound">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label ID="lblElementName" runat="server" Text='<%# Bind("OrgElementName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label ID="Label13" runat="server" Text=":"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlElementData"  runat="server" Width="250px" AutoPostBack="True" OnSelectedIndexChanged="ddlElementData_SelectedIndexChanged">

                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
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

