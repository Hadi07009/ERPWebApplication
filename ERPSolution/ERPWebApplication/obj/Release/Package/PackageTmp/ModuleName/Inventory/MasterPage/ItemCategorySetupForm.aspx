﻿<%@ Page Title="Item Category Setup" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ItemCategorySetupForm.aspx.cs" Inherits="ERPWebApplication.ModuleName.Inventory.MasterPage.ItemCategorySetupForm" %>

<%@ Register Assembly="ControlLibrary" Namespace="ERPSolution.Common.Controls" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 110px;
        }

        .auto-style3 {
            width: 142px;
        }

        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <cc1:MessageBox ID="MessageBox1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table style="width: 100%;text-align:left">
                <tr >
                    <td colspan="2" >
                        <asp:Panel ID="Panel1" Width="430px" runat="server">
                        <table style="width: 100%;text-align:left">
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:TextBox ID="txtSearch" Width="300px" placeholder="Search..." runat="server" AutoPostBack="True"></asp:TextBox></td>
                                <ajaxToolkit:AutoCompleteExtender ID="txtSearch_AutoCompleteExtender" runat="server"
                                            CompletionListCssClass="autocomplete_completionListElement"
                                            CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                                            CompletionListItemCssClass="autocomplete_listItem2"
                                            DelimiterCharacters=""
                                            Enabled="True"
                                            MinimumPrefixLength="1" ServiceMethod="GetItemName" ServicePath="~/WebService/ServiceSystem.asmx" TargetControlID="txtSearch">
                                        </ajaxToolkit:AutoCompleteExtender>
                                <td>
                                    <asp:Button ID="btnSearch" runat="server" Text="Search" Height="30px" Width="100px" OnClick="btnSearch_Click" /></td>
                            </tr>
                            
                        </table>
                            </asp:Panel>
                            
                    </td>
                    <td colspan="2" style="float:right;margin-right:430px" >
                        <div  style="position:fixed; width: 425px;background-color:#00817F;height:50px">
                            <table style="width: 100%;">
                                        <tr>
                                            <td> 
                                &nbsp;<asp:CheckBox runat="server" ID="CheckBoxAddItem" CssClass="checkbox" ForeColor="White" AutoPostBack="True" OnCheckedChanged="CheckBoxAddItem_CheckedChanged" />
                                                <asp:Label ID="Label3" runat="server" AssociatedControlID="CheckBoxAddItem" CssClass="checkbox" ForeColor="White">Add Item?</asp:Label>
                                            </td>
                                            <td style="text-align: right">
                                                <asp:Button ID="btnSave" runat="server" Text="Save" Width="75px" OnClick="btnSave_Click" />
                                            </td>
                                            <td style="text-align: center">
                                                <asp:Button ID="Button2" runat="server" Text="Print Summery" Width="115px" />
                                            </td>
                                            <td style="text-align: left">

                                                <asp:Button ID="Button3" runat="server" Text="Print" Width="75px" />

                                            </td>

                                        </tr>
                                    </table>
                        </div></td>
                </tr>
                
                <tr>
                    <td colspan="4">

                        <asp:Panel ID="PanelBody" runat="server">

                            <table style="width: 100%;">
                                <tr>
                                    <td>
                                        <div style="height: 415px; width: 600px">
                                            <asp:Panel ID="PanelLeft" runat="server" Height="100%" Width="100%" ScrollBars="Auto">
                                                <table style="width: 100%;">
                                                    <tr>
                                                        <td colspan="3">
                                                            <asp:TreeView ID="TreeViewCategory" 
                                                                NodeStyle-CssClass="treeNode"
                                                                RootNodeStyle-CssClass="rootNode"
                                                                LeafNodeStyle-CssClass="leafNode"
                                                                SelectedNodeStyle-CssClass="selectedNode"
                                                                ParentNodeStyle-CssClass="parentNode"
                                                                HoverNodeStyle-CssClass="hoverNode"

                                                                
                                                                
                                                                runat="server" OnTreeNodePopulate="TreeViewCategory_TreeNodePopulate"
                                                                OnSelectedNodeChanged="TreeViewCategory_SelectedNodeChanged"
                                                                ImageSet="Msdn" ForeColor="#428BCA" Width="90%">
                                                                <HoverNodeStyle CssClass="hoverNode" />
                                                                <LeafNodeStyle CssClass="leafNode" />
                                                                <NodeStyle CssClass="treeNode" />
                                                                <ParentNodeStyle CssClass="parentNode" />
                                                                <RootNodeStyle CssClass="rootNode" />
                                                                <SelectedNodeStyle CssClass="selectedNode" />
                                                            </asp:TreeView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </div>
                                    </td>
                                    <td >
                                        <div style="height: 415px; width: 425px">
                                            <asp:Panel ID="PanelRight" runat="server" BackColor="#E0E0E0" Width="100%">
                                                <table style="width: 99%; margin-left: 5px; text-align: left">
                                                    
                                                    <tr>
                                                        <td>
                                                            &nbsp;</td>
                                                        <td>&nbsp;</td>
                                                        <td>
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label1" runat="server" Text="Category Name"></asp:Label>
                                                        </td>
                                                        <td>:</td>
                                                        <td>
                                                            <asp:TextBox ID="txtCategoryName" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label2" runat="server" Text="Parent Category"></asp:Label>
                                                        </td>
                                                        <td>:</td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlParentCategory" runat="server" Enabled="False">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3" style="margin-left:-5px">
                                                            <asp:Panel ID="PanelProductType" Width="100%" BorderStyle="Solid" BorderWidth="1px" BorderColor="Gray" runat="server" >

                                                                <table style="width: 100%">

                                                                    <tr>
                                                                        <td class="auto-style1">
                                                                           &nbsp;<asp:Label ID="Label4" runat="server" Text="Product Type" ></asp:Label>
                                                                        </td>
                                                                        <td>:</td>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddlProductType" runat="server">
                                                                                <asp:ListItem Selected="True" Value="1">Barcode Item</asp:ListItem>
                                                                                <asp:ListItem Value="2">Scale Item</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="auto-style1"></td>
                                                                        <td></td>
                                                                        <td style="text-align: left">
                                                                            <asp:Button ID="btnChangeCategory" runat="server" Text="Change Category" />
                                                                        </td>
                                                                    </tr>
                                                                </table>

                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                    </tr>
                                                    
                                                    <tr>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                    </tr>

                                                </table>
                                            </asp:Panel>
                                        </div>
                                    </td>
                                </tr>
                            </table>

                        </asp:Panel>

                    </td>
                </tr>

                <tr>
                    <td colspan="4">

                        <asp:Panel ID="PanelItemSetup" BackColor="#DDEFF9" Width="100%" runat="server">
                            <table style="width: 100%;">
                                <tr>
                                    <td colspan="4">
                                        <asp:Panel ID="PanelGetCategory" BackColor="#E0E0E0" BorderStyle="Solid" BorderWidth="3px" BorderColor="#E0E0E0" runat="server">
                                            <table style="width: 40%;">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label9" Style="text-align: center" runat="server" Text="Category" BackColor="#FE817F" Width="65px" ForeColor="White" Font-Bold="True"></asp:Label>
                                                    </td>
                                                    <td>:</td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlCategory" runat="server">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>

                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td colspan="2"></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <div style="padding-top: 0px; width: 500px">
                                            <table style="width: 100%; text-align: left">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label10" runat="server" Text="Item Code"></asp:Label>
                                                    </td>
                                                    <td>:</td>
                                                    <td>
                                                        <asp:TextBox ID="txtItemCode" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label11" Style="text-align: center" runat="server" Text="Item Name" BackColor="#FE817F" Width="75px" ForeColor="White" Font-Bold="true"></asp:Label>
                                                    </td>
                                                    <td>:</td>
                                                    <td>
                                                        <asp:TextBox ID="txtItemName" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label33" runat="server" Text="Item Type ID"></asp:Label>
                                                    </td>
                                                    <td>:</td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlItemTypeID" runat="server">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label34" runat="server" Text="Item Usage ID"></asp:Label>
                                                    </td>
                                                    <td>:</td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlItemUsageID" runat="server">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td></td>
                                                    <td></td>
                                                    <td>
                                                        <asp:CheckBox ID="CheckBoxIsVATPayable" runat="server" CssClass="checkbox" />
                                                        <asp:Label ID="Label19" runat="server" AssociatedControlID="CheckBoxIsVATPayable" CssClass="checkbox">Is VAT Payable ?</asp:Label>

                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label14" runat="server" Text="Related Supplier"></asp:Label>
                                                    </td>
                                                    <td>:</td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlRelatedSupplier" runat="server">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td></td>
                                                    <td>
                                                        <asp:CheckBox ID="CheckBoxSameSupplier" runat="server" CssClass="checkbox" />
                                                        <asp:Label ID="Label20" runat="server" AssociatedControlID="CheckBoxSameSupplier" CssClass="checkbox">Same Supplier</asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3"><table style="width: 50%; text-align: left">
                                            <tr>
                                                <td colspan="4">
                                                    <asp:Label ID="Label27" runat="server" Text="Enter Account Information" ForeColor="#793F19" Width="500px"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label28" runat="server" Text="Sales Account No"></asp:Label>
                                                </td>
                                                <td>:</td>
                                                <td>
                                                    <asp:DropDownList ID="ddlSalesAccountNo" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label29" runat="server" Text="Stock Account No"></asp:Label>
                                                </td>
                                                <td>:</td>
                                                <td>
                                                    <asp:DropDownList ID="ddlStockAccountNo" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label30" runat="server" Text="COGS Account No"></asp:Label>
                                                </td>
                                                <td>:</td>
                                                <td>
                                                    <asp:DropDownList ID="ddlCOGSAccountNo" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label31" runat="server" Text="Sales Return Account"></asp:Label>
                                                </td>
                                                <td>:</td>
                                                <td>
                                                    <asp:DropDownList ID="ddlSalesReturnAccount" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td></td>
                                                <td colspan="2">
                                                    <asp:CheckBox ID="CheckBoxSameAccount" runat="server" CssClass="checkbox" />
                                                    <asp:Label ID="Label32" runat="server" AssociatedControlID="CheckBoxSameAccount" CssClass="checkbox"> Same Account for all items</asp:Label>
                                                </td>
                                            </tr>
                                        </table></td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                    <td colspan="2">
                                        <div style="padding-top: 0px; width: 500px">
                                            <table style="width: 98%;">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label15" runat="server" Text="Description"></asp:Label>
                                                    </td>
                                                    <td>:</td>
                                                    <td>
                                                        <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Width="250px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label16" runat="server" Text="H.S. Code "></asp:Label>
                                                    </td>
                                                    <td>:</td>
                                                    <td>
                                                        <asp:TextBox ID="txtHSCode" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        <table style="width:100%;text-align:left">
                                                            <tr>
                                                                <td colspan="3">
                                                                    <asp:Label ID="Label35" runat="server" ForeColor="#793F19" Text="Unit Information"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style3">
                                                                    <asp:Label ID="Label17" runat="server" Text="Opening Balance"></asp:Label>
                                                                </td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtOpeningBalance" runat="server" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style3">
                                                                    <asp:Label ID="Label12" runat="server" Text="Unit"></asp:Label>
                                                                </td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlUnit" runat="server">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style3">
                                                                    <asp:Label ID="Label36" runat="server" Text="Break Up Quantity"></asp:Label>
                                                                </td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtBreakUpQuantity" runat="server" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style3">
                                                                    <asp:Label ID="Label37" runat="server" Text="Break Up Unit"></asp:Label>
                                                                </td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlBreakupUnit" runat="server">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label18" runat="server" Text="Re-Order Level"></asp:Label>
                                                    </td>
                                                    <td>:</td>
                                                    <td>
                                                        <asp:TextBox ID="txtReOrderLevel" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label38" runat="server" Text="Minimum Quantity"></asp:Label>
                                                    </td>
                                                    <td>:</td>
                                                    <td>
                                                        <asp:TextBox ID="txtMinimumQuantity" runat="server" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2"></td>
                                    <td colspan="2"></td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        
                                    </td>
                                </tr>

                            </table>
                        </asp:Panel>

                    </td>
                </tr>

                <tr>
                    <td></td>
                    <td colspan="2"></td>
                    <td></td>
                </tr>
            </table>

        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSave" />
        </Triggers>   
    </asp:UpdatePanel>
</asp:Content>
