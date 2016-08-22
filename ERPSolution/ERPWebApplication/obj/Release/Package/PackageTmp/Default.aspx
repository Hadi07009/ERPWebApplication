<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ERPWebApplication._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h2><%: Title %>.</h2>
            </hgroup>

        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <nav>
        <ul id="menu" >
             <li><a id="A1" runat="server" href="~/ModuleName/Inventory/TransactionPage/frm_item_issue.aspx">ITEM ISSUE</a></li> 
            <li><a id="A2" runat="server" href="~/ModuleName/Inventory/TransactionPage/frm_item_requisition.aspx">ITEM REQUISITION</a></li>
        </ul>
    </nav>
</asp:Content>
