<%@ Page Title="A List of Form" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NodeList.aspx.cs" Inherits="ERPWebApplication.NodeList" %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <table style="width: 100%;">
        <tr>
            <td>
                <asp:LinkButton ID="lnkfrm_item_issue" runat="server" PostBackUrl="~/ModuleName/Inventory/TransactionPage/frm_item_issue.aspx"
                    Width="390px">ITEM ISSUE</asp:LinkButton></td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:LinkButton ID="LinkButtonITEMREQUISITION" PostBackUrl="~/ModuleName/Inventory/TransactionPage/frm_item_requisition.aspx" runat="server">ITEM REQUISITION</asp:LinkButton>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:LinkButton ID="LinkButtonITEM" PostBackUrl="~/ModuleName/Inventory/TransactionPage/frm_item.aspx" runat="server">ITEM</asp:LinkButton>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <ul>
                    <li id="shellmenu_43"><a tabindex="20"  href="MicrosoftMenuHtmlPage.html"  >MICROSOFT MENU
                        </a></li>
                    </ul></td>
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
    </table>
</asp:Content>
