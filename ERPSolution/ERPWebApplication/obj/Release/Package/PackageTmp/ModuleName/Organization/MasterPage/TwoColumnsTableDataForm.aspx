<%@ Page Title="Two Columns Table Data" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="TwoColumnsTableDataForm.aspx.cs" Inherits="ERPWebApplication.ModuleName.Organization.MasterPage.TwoColumnsTableDataForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table style="width: 100%; text-align: left">
                <tr>
                    <td colspan="2" style="width: 600px; float: left">
                        <asp:GridView ID="grdTableName" runat="server" AutoGenerateColumns="False" OnRowDataBound="grdTableName_RowDataBound" OnSelectedIndexChanged="grdTableName_SelectedIndexChanged">
                            <Columns>
                                <asp:TemplateField HeaderText="SL">
                                    <ItemTemplate>
                                        <%# Container.DisplayIndex + 1 %>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="30px" />
                                    <ItemStyle HorizontalAlign="Center" Width="30px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Table ID">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTableID" runat="server" Text='<%# Bind("TableID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Table Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTableName" runat="server" Text='<%# Bind("TableName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                    <td colspan="2" style="text-align: left; float: left">
                        <table style="width: 100%;">
                            <tr>
                                <td colspan="3" style="margin-top: -5px">
                                    <div style="position: fixed; width: 425px; background-color: #00817F; height: 50px">
                                        <table style="width: 55%;">
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnSave" runat="server" Text="Save" Width="100px" OnClick="btnSave_Click" /></td>
                                                <td>
                                                    <asp:Button ID="btnClear" runat="server" Text="Clear" Width="100px" OnClick="btnClear_Click" /></td>
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
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text="Table Name"></asp:Label>
                                </td>
                                <td>:</td>
                                <td>
                                    <asp:Label ID="lblSelectedTableName" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text="Field Of Name"></asp:Label></td>
                                <td>:</td>
                                <td>
                                    <asp:TextBox ID="txtFieldOfName" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text="Field Description"></asp:Label></td>
                                <td>:</td>
                                <td>
                                    <asp:TextBox ID="txtFieldDescription" runat="server"></asp:TextBox></td>
                            </tr>
                        </table>

                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="float:right;text-align:right">
                        <asp:GridView ID="grdTableData" runat="server" AutoGenerateColumns="False" OnRowCommand="grdTableData_RowCommand" OnRowDataBound="grdTableData_RowDataBound" OnRowDeleting="grdTableData_RowDeleting" Width="100%">
                            <Columns>
                                <asp:TemplateField HeaderText="SL">
                                    <ItemTemplate>
                                        <%# Container.DisplayIndex + 1 %>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="30px" />
                                    <ItemStyle HorizontalAlign="Center" Width="30px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Field Of ID">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFieldOfID" runat="server" Text='<%# Bind("FieldOfID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Field Of Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFieldOfName" runat="server" Text='<%# Bind("FieldOfName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Field Description">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFieldDescription" runat="server" Text='<%# Bind("FieldDescription") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ShowSelectButton="True" />
                                <asp:CommandField ShowDeleteButton="True" />
                            </Columns>
                        </asp:GridView>
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
        <Triggers>
           
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
