<%@ Page Title="Item Requisition" Debug="true" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master"  CodeBehind="frmItemRequisition.aspx.cs" Inherits="ERPWebApplication.ModuleName.Inventory.TransactionPage.frmItemRequisition" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%--<%@ Register assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2" namespace="eWorld.UI" tagprefix="ew" %>--%>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
   
        <asp:UpdatePanel ID="uppnl1" runat="server">

            <ContentTemplate>
                <table id="tblmas" style="margin: 0 auto; width:100%" runat="server">
                    
                    <tr >
                        <td  >
                            <table  id="tblsearch" runat="server" style="width:100%; margin-top:0px" >
                                <tr>
                                    <td >
                                        <asp:Panel ID="pnlsearch" runat="server" Width="1011px">
                                           <table style="margin-top:0px">
                                                <tr>
                                                    <td style="padding: 2px">
                                                        <asp:ImageButton ID="header_ToggleImage1" runat="server" ImageUrl="~/images/collapse.jpg" Width="15px" />
                                                    </td>
                                                    <td>&nbsp;<asp:Label ID="Label11" runat="server" Font-Size="20px" ForeColor="#034EA2" Text="Search Requisition" Width="456px"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr >
                                    <td>

                                        <asp:Panel ID="pnlsearchrequisition" runat="server" Width="100%">

                                            <table style="margin-top: 0px">
                                                <tr>
                                                    <td style="width: 33px">&nbsp;</td>
                                                    <td style="width: 101px">&nbsp;</td>
                                                    <td style="text-align: right; margin-left: 160px;">
                                                        <asp:TextBox ID="txtSearch" runat="server" Width="350px"></asp:TextBox>
                                                        <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteForReq" runat="server"
                                                            BehaviorID="AutoCompleteReq" CompletionInterval="1000"
                                                            CompletionListCssClass="autocomplete_completionListElement"
                                                            CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                                                            CompletionListItemCssClass="autocomplete_listItem"
                                                            CompletionSetCount="100" DelimiterCharacters=","
                                                            EnableCaching="false" MinimumPrefixLength="1"
                                                            ServiceMethod="GetRequisitionList"
                                                            ServicePath="~/WebService/ServiceSystem.asmx"
                                                            ShowOnlyCurrentWordInCompletionListItem="true"
                                                            TargetControlID="txtSearch">
                                                        </ajaxToolkit:AutoCompleteExtender>
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" />
                                                        <asp:Button ID="btnAdvSearch" runat="server" OnClick="btnAdvSearch_Click" Text="Advanced Search" Width="147px" />
                                                    </td>
                                                    <td></td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                            </table>
                                        </asp:Panel>

                                        <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender5" runat="Server"
                                            TargetControlID="pnlsearchrequisition"
                                            ExpandControlID="pnlsearch"
                                            CollapseControlID="pnlsearch"
                                            ExpandDirection="Vertical"
                                            Collapsed="true"
                                            SuppressPostBack="true"
                                            ExpandedImage="~/images/collapse.jpg"
                                            CollapsedImage="~/images/expand.jpg"
                                            ImageControlID="header_ToggleImage1" />
                                    </td>
                                </tr>
                                <tr>
                                   <td>

                                       <hr id="searchbottom" runat="server" style="border:0; height: 1px; background: #333;  background-image: linear-gradient(to right, #ccc, #333, #ccc)" />
                                    </td>
                                </tr>
                                <tr>

                                    <td>

                                       
                                            <table id="tbladvsearch" runat="server" style="margin-top:0px">
                                                <tr>
                                                    <td style="width: 12px">&nbsp;</td>
                                                    <td style="text-align:left; width: 117px;">
                                                        <asp:Label ID="Label2" runat="server" Text="Priority "></asp:Label>
                                                        :</td>
                                                    <td style="width: 333px">
                                                        <asp:DropDownList ID="ddlPrioritySearch" runat="server">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="width: 128px">
                                                        <asp:Label ID="Label5" runat="server" Text="From Date:"></asp:Label>
                                                    </td>
                                                    <td style=" margin-top:0px">
                                                        <asp:TextBox ID="txtFrmDate" runat="server" ></asp:TextBox>
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server"  BehaviorID="txtFrmDate"  CssClass="Calendar" Format="dd/MM/yyyy" TargetControlID="txtFrmDate" />
                                                       
                                                        <asp:ImageButton ID="imgbtnadsearch" runat="server" Height="17px" ImageAlign="Top" ImageUrl="~/Images/collapse.jpg" OnClick="imgbtnadsearch_Click" Width="15px" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 12px"></td>
                                                    <td style="text-align:left; width: 117px;">
                                                        <asp:Label ID="Label16" runat="server" Text="Department: "></asp:Label>
                                                    </td>
                                                    <td style="width: 333px">
                                                        <asp:DropDownList ID="ddldepartment" runat="server">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="width: 128px">
                                                        <asp:Label ID="Label6" runat="server" Text="To Date:"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtToDate" runat="server" ></asp:TextBox>
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtTodate" runat="server" BehaviorID="txtFrmDate"  CssClass="Calendar" Format="dd/MM/yyyy" TargetControlID="txtToDate" />
                                                        
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 12px">&nbsp;</td>
                                                    <td style="text-align:left; width: 117px;">
                                                        <asp:Label ID="Label17" runat="server" Text="Purpose: "></asp:Label>
                                                    </td>
                                                    <td style="width: 333px">
                                                        <asp:DropDownList ID="ddlPurposeSearch" runat="server">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="width: 128px">
                                                        <asp:Label ID="Label15" runat="server" Text="Employee:"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtEmployeeSearch" runat="server"></asp:TextBox>
                                                        <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteadempserch" runat="server" BehaviorID="AutoCompleteEmployeeadser" CompletionInterval="1000" CompletionListCssClass="autocomplete_completionListElement" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListItemCssClass="autocomplete_listItem" CompletionSetCount="20" DelimiterCharacters="," EnableCaching="false" MinimumPrefixLength="3" ServiceMethod="GetEmployeeList" ServicePath="~/WebService/ServiceSystem.asmx" ShowOnlyCurrentWordInCompletionListItem="true" TargetControlID="txtEmployeeSearch">
                                                        </ajaxToolkit:AutoCompleteExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 12px">&nbsp;</td>
                                                    <td style="text-align:left; width: 117px;">
                                                        <asp:Label ID="Label18" runat="server" Text="Item: "></asp:Label>
                                                    </td>
                                                    <td style="width: 333px">
                                                        <asp:TextBox ID="txtItemSearch" runat="server"></asp:TextBox>
                                                        <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteItemSearch" runat="server" BehaviorID="AutoCompleteSearch" CompletionInterval="1000" CompletionListCssClass="autocomplete_completionListElement" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListItemCssClass="autocomplete_listItem" CompletionSetCount="20" DelimiterCharacters="," EnableCaching="false" MinimumPrefixLength="1" ServiceMethod="GetItemList" ServicePath="~/WebService/ServiceSystem.asmx" ShowOnlyCurrentWordInCompletionListItem="true" TargetControlID="txtItemSearch">
                                                        </ajaxToolkit:AutoCompleteExtender>
                                                    </td>
                                                    <td style="width: 128px">&nbsp;</td>
                                                    <td>
                                                        <asp:Button ID="btnshow" runat="server" OnClick="btnShow_Click" Text="Show" Width="75px" />
                                                        <asp:Button ID="btnClearAdSearch" runat="server" OnClick="btnClearAdSearch_Click" Text="Clear" Width="75px" />
                                                    </td>
                                                </tr>
                                            </table>
                                    </td>
                                </tr>
                                <tr>

                                    <td >

                                       
                                            <hr id="advsearchbottom" runat="server" style="border:0; height: 1px; background: #333;  background-image: linear-gradient(to right, #ccc, #333, #ccc)" />
                                    </td>
                                </tr>
                                <tr id="trSearchResult" runat="server">
                                    <td colspan="4">
                                        <asp:Panel ID="Panel1" runat="server" Height="150px" ScrollBars="Vertical" Style="overflow: auto; width: 100%; text-align: center;">

                                            
                                           <asp:GridView ID="gdvSearchResult" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" CssClass="gradient-light-radial" OnSelectedIndexChanged="gdvSearchResult_SelectedIndexChanged" Style="text-align: left" Width="100%">
                                                            <FooterStyle BackColor="White" ForeColor="#000066" />
                                                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                            <RowStyle ForeColor="#000066" />
                                                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                                            <SortedDescendingHeaderStyle BackColor="#00547E" />
                                                            <Columns>
                                                                <asp:CommandField SelectText="Select" ShowSelectButton="True">
                                                                <ItemStyle ForeColor="Red" />
                                                                </asp:CommandField>
                                                            </Columns>
                                                        </asp:GridView>
                                        </asp:Panel>
                                    </td>
                                    <td style="width: 1%">&nbsp;</td>
                                </tr>
                                <tr>
                                   <td >
                                        <hr id="headertop" runat="server" style="border:0; height: 1px; background: #333;  background-image: linear-gradient(to right, #ccc, #333, #ccc)" />

                                    
                                    </td>
                                </tr>
                                <tr>
                                    <td style=" width: 100%;">
                                        <table id="tblheader" style="margin-top: 0px; width:100%">
                                            <tr>
                                                <td style="width: 1%">&nbsp;</td>
                                                <td style="width: 10%">
                                                    <br />
                                                    <asp:Label ID="lblStatusforlabel" runat="server" Text="Status: "></asp:Label>
                                                </td>
                                                <td style="width: 25%">
                                                    <br />
                                                    <asp:Label ID="lblstatus" runat="server" Style="font-weight: 700;" Text=""></asp:Label>
                                                </td>
                                                <td style="width: 11%">&nbsp;</td>
                                                <td style="width: 32%">
                                                    <asp:Button ID="btnNewReq" runat="server" OnClick="btnNewReq_Click" Text="New Requisition" Width="130px" />
                                                    <asp:Button ID="btnPrintRequisition" runat="server" OnClick="btnPrintRequisition_Click" Text="Print" Width="80px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 1%">&nbsp;</td>
                                                <td style="width: 10%">
                                                    <asp:Label ID="Label36" runat="server" Text="Reference Type: "></asp:Label>
                                                </td>
                                                <td style="width: 25%">
                                                    <asp:DropDownList ID="ddlRefType" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 11%">
                                                    <asp:Label ID="Label38" runat="server" Text="Request Date: "></asp:Label>
                                                </td>
                                                <td style="width: 32%">
                                                    <asp:TextBox ID="txtrequestedDate" runat="server"    ></asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtRequestedDate" runat="server" BehaviorID="txtRequested" CssClass="Calendar" Format="dd/MM/yyyy" TargetControlID="txtrequestedDate" />

                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 1%; height: 41px;"></td>
                                                <td style="width: 10%; height: 41px;">
                                                    <asp:Label ID="Label19" runat="server" Text="Request By: "></asp:Label>
                                                </td>
                                                <td style="width: 25%; height: 41px;">
                                                    <asp:TextBox ID="txtRequestedBy" runat="server"></asp:TextBox>
                                                    <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteforEmployee" runat="server" BehaviorID="AutoCompleteEmployee" CompletionInterval="1000" CompletionListCssClass="autocomplete_completionListElement" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListItemCssClass="autocomplete_listItem" CompletionSetCount="20" DelimiterCharacters="," EnableCaching="false" MinimumPrefixLength="3" ServiceMethod="GetEmployeeList" ServicePath="~/WebService/ServiceSystem.asmx" ShowOnlyCurrentWordInCompletionListItem="true" TargetControlID="txtRequestedBy">
                                                    </ajaxToolkit:AutoCompleteExtender>
                                                </td>
                                                <td style="width: 11%; height: 41px;">
                                                    <asp:Label ID="Label39" runat="server" Text="Required Date: "></asp:Label>
                                                </td>
                                                <td style="width: 32%; height: 41px;">
                                                    <asp:TextBox ID="txtDateNeed" runat="server"></asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="CalendarExDateNeed" runat="server" BehaviorID="txtRequested" CssClass="Calendar" Format="dd/MM/yyyy" TargetControlID="txtDateNeed" />

                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 1%; height: 35px;"></td>
                                                <td style="width: 10%; height: 35px;">
                                                    <asp:Label ID="Label21" runat="server" Text="Requesting Dept: "></asp:Label>
                                                </td>
                                                <td style="width: 25%; height: 35px;">
                                                    <asp:DropDownList ID="ddlRequestedDept" runat="server" OnSelectedIndexChanged="ddlRequestedDept_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 11%; height: 35px;">
                                                    <asp:Label ID="Label40" runat="server" Text="Priority: "></asp:Label>
                                                </td>
                                                <td style="width: 32%; height: 35px;">
                                                    <asp:DropDownList ID="ddlPriority" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 1%; height: 37px;"></td>
                                                <td style="width: 10%; height: 37px;">
                                                    <asp:Label ID="Label23" runat="server" Text="Item User Type: "></asp:Label>
                                                </td>
                                                <td style="width: 25%; height: 37px;">
                                                    <asp:DropDownList ID="ddlItemUserType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlItemUserType_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 11%; height: 37px;">
                                                    <asp:Label ID="Label41" runat="server" Text="Purpose: "></asp:Label>
                                                </td>
                                                <td style="width: 32%; height: 37px;">
                                                    <asp:DropDownList ID="ddlPurpose" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 1%; "></td>
                                                <td style="width: 10%;">
                                                    <asp:Label ID="Label24" runat="server" Text="User Name: "></asp:Label>
                                                </td>
                                                <td style="width: 25%; ">
                                                    <asp:TextBox ID="txtUserName" runat="server" AutoPostBack="True" OnTextChanged="txtUserName_TextChanged"></asp:TextBox>
                                                    <ajaxToolkit:AutoCompleteExtender ID="AutoUserName" runat="server" BehaviorID="AutoCompleteUserName" CompletionInterval="1000" CompletionListCssClass="autocomplete_completionListElement" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListItemCssClass="autocomplete_listItem" CompletionSetCount="20" DelimiterCharacters="," EnableCaching="false" MinimumPrefixLength="3" ServiceMethod="GetUserList" ServicePath="~/WebService/ServiceSystem.asmx" ShowOnlyCurrentWordInCompletionListItem="true" TargetControlID="txtUserName">
                                                    </ajaxToolkit:AutoCompleteExtender>
                                                </td>
                                                <td style="width: 11%;">
                                                    <asp:Label ID="lblisproject" runat="server" Text="Project Related?"></asp:Label>
                                                </td>
                                                <td style="width: 32%; ">
                                                    <asp:CheckBox ID="chkproject" runat="server" AutoPostBack="True" Checked="true" OnCheckedChanged="chkproject_CheckedChanged1" CssClass="checkbox" />
                                                    <asp:DropDownList ID="ddlProject" runat="server" Visible="true" Width="250px">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 1%; height: 29px;"></td>
                                                <td style="width: 10%; " >
                                                    <asp:Label ID="Label34" runat="server" Text="Location Address: "></asp:Label>
                                                </td>
                                                <td style="width: 25%; text-align: left;" rowspan="2" >
                                                    <asp:TextBox ID="txtLocAddress" runat="server" TextMode="MultiLine" Width="250px" Height="76px"></asp:TextBox>
                                                </td>
                                                <td style="width: 11%; ">
                                                    <asp:Label ID="Label32" runat="server" Text="Comments: "></asp:Label>
                                                </td>
                                                <td style="width: 32%;" rowspan="2">
                                                    
                                                    <asp:TextBox ID="txtComments" runat="server" Height="72px" TextMode="MultiLine" Width="250px"></asp:TextBox>
                                                    
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 1%; height: 29px;">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 1%">&nbsp;</td>
                                                <td style="width: 10%">&nbsp;</td>
                                                <td colspan="3">
                                                    <asp:Label ID="lblref" runat="server" Text="" Visible="false"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="5">
                                                    <hr id="fileaatachtop" runat="server" style="border: 0; height: 1px; background: #333; background-image: linear-gradient(to right, #ccc, #333, #ccc)" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 1%">&nbsp;</td>
                                                <td colspan="4">
                                                    <table id="tblattach" runat="server" style="width: 100%; margin-top:0px">
                                                        <tr>
                                                            <td>
                                                                <table style="width: 100%">
                                                                    <tr>
                                                                        <td style="width: 893px">
                                                                            <table style="width: 100%">
                                                                                <tr>
                                                                                    <td style="width: 123px">
                                                                                        <asp:Label ID="Label42" runat="server" Text="File Attachment" Width="100px"></asp:Label>
                                                                                    </td>
                                                                                    <td >
                                                                                        <asp:FileUpload ID="flAttachmentInBill" runat="server" Width="217px" />
                                                                                    </td>
                                                                                    <td style="width: 175px">
                                                                                        <asp:Button ID="btnAttachFile" runat="server"  OnClick="btnAttachFile_Click" Text="Attach" Width="65px" />
                                                                                        <asp:Button ID="btnDownLoad" runat="server" OnClick="btnDownLoad_Click" Text="Download" Visible="false" />
                                                                                    </td>
                                                                                    <td>&nbsp;</td>
                                                                                    <td>&nbsp;</td>
                                                                                    <td>&nbsp;</td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 123px">&nbsp;</td>
                                                                                    <td style="width: 320px">
                                                                                        <asp:ListBox ID="FileList" runat="server" AutoPostBack="True" Height="120px" OnSelectedIndexChanged="FileList_SelectedIndexChanged" Width="320px"></asp:ListBox>
                                                                                    </td>
                                                                                    <td style="width: 175px">&nbsp;</td>
                                                                                    <td>&nbsp;</td>
                                                                                    <td>&nbsp;</td>
                                                                                    <td>&nbsp;</td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 123px">&nbsp;</td>
                                                                                    <td style="width: 320px">
                                                                                        <asp:Button ID="btnRemoveFile" runat="server" Height="27px" OnClick="btnRemoveFile_Click" Text="Remove" />
                                                                                        <asp:Label ID="lblDownloadSelectedFile" runat="server" Visible="False"></asp:Label>
                                                                                    </td>
                                                                                    <td style="width: 175px">&nbsp;</td>
                                                                                    <td>&nbsp;</td>
                                                                                    <td>&nbsp;</td>
                                                                                    <td>&nbsp;</td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <td style="width: 27%">
                                                                            &nbsp;</td>
                                                                        <td style="width: 1%">&nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2">
                                                                            <hr id="fileattachbottom" runat="server" style="border: 0; height: 1px; background: #333; background-image: linear-gradient(to right, #ccc, #333, #ccc)" />
                                                                        </td>
                                                                        <td style="width: 1%">&nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2">
                                                                            <asp:Label ID="lblreqstatus17" runat="server" Text="This requisition will be forward to" Width="206px"></asp:Label>
                                                                            <asp:DropDownList ID="ddlForwardTo1" runat="server" Height="23px" Width="200px">
                                                                            </asp:DropDownList>
                                                                            &nbsp;&nbsp;<asp:Label ID="lblreqstatus13" runat="server" Text="for Authorization"></asp:Label>
                                                                            &nbsp;&nbsp;<asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Save" Width="60px" />
                                                                            <asp:Button ID="btnPost" runat="server" OnClick="btnPost_Click" Text="Submit" Width="65px" Visible ="false" />
                                                                            <asp:Button ID="btnReject" runat="server" OnClick="btnReject_Click" Text="Reject" Width="65px" Visible="false" />
                                                                        </td>
                                                                        <td style="width: 1%">&nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2">
                                                                            <hr id="forwardbottom" runat="server" style="border: 0; height: 1px; background: #333; background-image: linear-gradient(to right, #ccc, #333, #ccc)" />
                                                                        </td>
                                                                        <td style="width: 1%">&nbsp;</td>
                                                                    </tr>
                                                                    <tr id="trItemDetail" runat="server">
                                                                        <td colspan="2">
                                                                            <asp:Panel ID="pnl" runat="server" Height="150px" ScrollBars="Vertical" Style="overflow: auto; width: 100%; text-align: center;">
                                                                                <asp:GridView ID="gdvItemDetail" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" CssClass="myGridClass" OnRowDataBound="gdvItemDetail_RowDataBound" OnSelectedIndexChanged="gdvItemDetail_SelectedIndexChanged" ShowFooter="true" Style="text-align: left; width: 100%;">
                                                                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                                                                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                                                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                                                    <RowStyle ForeColor="#000066" />
                                                                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                                                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                                                                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                                                                                    <Columns>
                                                                                        <asp:CommandField SelectText="Remove" ShowSelectButton="True">
                                                                                        <ItemStyle ForeColor="Red" />
                                                                                        </asp:CommandField>
                                                                                    </Columns>
                                                                                </asp:GridView>
                                                                            </asp:Panel>
                                                                        </td>
                                                                        
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                 <asp:Panel ID="header_HeaderPanel" runat="server" >
                                                                    <table style=" Width:100%; margin-top:0px">
                                                                        <tr>
                                                                            <td style="padding:2px; width: 15px;">
                                                                                <asp:ImageButton ID="header_ToggleImage3" runat="server" Height="15px" ImageUrl="~/images/collapse.jpg" Width="15px" />
                                                                            </td>
                                                                            <td  style="padding:2px">
                                                                                &nbsp;<asp:Label ID="Label1" runat="server" Font-Size="20px" ForeColor="#034EA2" Text="Add Item Information" Width="456px"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </asp:Panel>
                                                                <hr id="hrtest" runat="server" style="border: 0; height: 1px; background: #333; background-image: linear-gradient(to right, #ccc, #333, #ccc)" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td  >
                                                                 <asp:Panel ID="header_ContentPanel" runat="server" style="width:98%">
                                                                    <table style=" Width:100%; margin-top:0px">
                                                                        <tr>
                                                                            <td style="width: 114px;">
                                                                                <asp:Label ID="lblreqstatus6" runat="server" Text="Item Name:" Width="80px"></asp:Label>
                                                                            </td>
                                                                            <td style="width: 284px">
                                                                                <asp:TextBox ID="txtItem" runat="server" AutoPostBack="True" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" OnTextChanged="txtItem_TextChanged" Width="250px"></asp:TextBox>
                                                                                <ajaxToolkit:TextBoxWatermarkExtender ID="TBWE2" runat="server" TargetControlID="txtItem" WatermarkCssClass="watermark" WatermarkText="Please type item name" />
                                                                                <ajaxToolkit:AutoCompleteExtender ID="autoCompleteforItemDeat" runat="server" BehaviorID="AutoCompleteEx2" CompletionInterval="1000" CompletionListCssClass="autocomplete_completionListElement" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListItemCssClass="autocomplete_listItem" CompletionSetCount="20" DelimiterCharacters="," EnableCaching="false" MinimumPrefixLength="1" ServiceMethod="GetItemList" ServicePath="~/WebService/ServiceSystem.asmx" ShowOnlyCurrentWordInCompletionListItem="true" TargetControlID="txtItem">
                                                                                </ajaxToolkit:AutoCompleteExtender>
                                                                            </td>
                                                                            <td>&nbsp;</td>
                                                                            <td style="text-align:left; width: 76px;">
                                                                                <asp:Label ID="lblreqstatus9" runat="server" Text="Specification:"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtSpec" runat="server"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 114px">
                                                                                <asp:Label ID="lblreqstatus7" runat="server" Text="Unit:"></asp:Label>
                                                                            </td>
                                                                            <td style=" width: 284px;">
                                                                                <table style="width: 54%; margin-top:0px">
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:DropDownList ID="ddlunit" runat="server" Width="260px">
                                                                                            </asp:DropDownList>
                                                                                        </td>
                                                                                        <td>&nbsp;</td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                            <td>&nbsp;</td>
                                                                            <td style="text-align:left; width: 76px;">
                                                                                <asp:Label ID="lblreqstatus10" runat="server" Text="Brand:"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtBrand" runat="server"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 114px">
                                                                                <asp:Label ID="Unit" runat="server" Text="Quantity:"></asp:Label>
                                                                            </td>
                                                                            <td style="width: 284px">
                                                                                <table style="margin-top:0px">
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtQuantity" runat="server" Width="90px"></asp:TextBox>
                                                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxqTY" runat="server" FilterType="Numbers,  Custom" TargetControlID="txtQuantity" ValidChars="." />
                                                                                        </td>
                                                                                        <td>&nbsp;</td>
                                                                                        <td>Rate:</td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtRate" runat="server" Width="90px"></asp:TextBox>
                                                                                            <ajaxToolkit:FilteredTextBoxExtender ID="txtQuantity0_FilteredTextBoxExtender" runat="server" FilterType="Numbers,  Custom" TargetControlID="txtRate" ValidChars="." />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                            <td>&nbsp;</td>
                                                                            <td style="text-align:left; width: 76px;">
                                                                                <asp:Label ID="lblreqstatus11" runat="server" Text="Origin:"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtOrigin" runat="server"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 114px">&nbsp;</td>
                                                                            <td style="width: 284px">&nbsp;</td>
                                                                            <td>&nbsp;</td>
                                                                            <td style="width: 76px;">&nbsp;</td>
                                                                            <td>
                                                                                <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add" />
                                                                                &nbsp;<asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click" Text="Clear" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 114px">&nbsp;</td>
                                                                            <td colspan="4">
                                                                                <asp:Panel ID="Panel4" runat="server" BorderStyle="Solid" BorderWidth="2px" CssClass="tbl" DefaultButton="btncancel" Height="200px" HorizontalAlign="Center" ScrollBars="Auto" Style="border-right: black 2px solid; padding-right: 20px; border-top: black 2px solid; text-align: center; padding-left: 20px; display:none; padding-bottom: 20px; border-left: black 2px solid; padding-top: 20px; border-bottom: black 2px solid; background-color: white" Width="354px">
                                                                                    <div style="border-color: #e6e6fa; border-width: 1px; text-align: center; filter: progid:dximagetransform.microsoft.gradient(endcolorstr='#FFCC0A', startcolorstr='#32A545', gradienttype='0'); width: 98%; height: 177px; text-align: center;">
                                                                                        &nbsp;&nbsp;&nbsp;<table id="tblmsg" runat="server" align="center" style="width: 95%">
                                                                                            <tr>
                                                                                                <td colspan="1" style="width: 364px; height: 18px; text-align: center"><span style="color: #ff0000"><strong>&nbsp;REQUISITION CREATED SUCCESSFULLY</strong></span></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 364px; height: 13px"></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 364px; text-align: center;">REQ REF NO:</td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 364px; text-align: center">
                                                                                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                                                        <ContentTemplate>
                                                                                                            &nbsp;<asp:Label ID="lblporef" runat="server" Font-Bold="True" Width="162px"></asp:Label>
                                                                                                        </ContentTemplate>
                                                                                                        <Triggers>
                                                                                                            <asp:AsyncPostBackTrigger ControlID="btnSubmit" EventName="Click" />
                                                                                                        </Triggers>
                                                                                                    </asp:UpdatePanel>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td colspan="1" style="height: 19px; width: 364px;"></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td colspan="1" style="width: 364px; height: 29px; text-align: center">
                                                                                                    <asp:Button ID="btncancel" runat="server" CssClass="hdn" Height="0px" Width="0px" />
                                                                                                    <asp:Button ID="btnok" runat="server" CssClass="btn2" OnClick="btnok_Click" Text="OK" Width="75px" />
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </div>
                                                                                </asp:Panel>
                                                                                <ajaxToolkit:ConfirmButtonExtender ID="ConfirmButtonExtender5" runat="server" DisplayModalPopupID="ModalPopupExtender5" TargetControlID="Button1" />
                                                                                <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender5" runat="server" BackgroundCssClass="modalBackground" CancelControlID="btncancel" PopupControlID="Panel4" TargetControlID="Button1">
                                                                                </ajaxToolkit:ModalPopupExtender>
                                                                                <asp:Button ID="Button1" runat="server" Text="Button" Visible="False" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </asp:Panel>
                                                                </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                  
                </table>

                </td>
                </tr>
                
                </table>
                </td>
                <td>&nbsp;</td>
                </tr>

                <tr >
                    <td></td>
                    <td>
                        
                        <ajaxToolkit:CollapsiblePanelExtender ID="cpeheader" runat="Server" CollapseControlID="header_HeaderPanel" Collapsed="true" CollapsedImage="~/images/expand.jpg" ExpandControlID="header_HeaderPanel" ExpandDirection="Vertical" ExpandedImage="~/images/collapse.jpg" ImageControlID="header_ToggleImage3" SuppressPostBack="true" TargetControlID="header_ContentPanel" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
               
                </table>


            </ContentTemplate>
            <Triggers>

             
                <asp:PostBackTrigger ControlID="btnAttachFile" />
                <asp:PostBackTrigger ControlID="btnDownLoad" />
                <asp:PostBackTrigger ControlID="btnPrintRequisition" />               
                <asp:AsyncPostBackTrigger ControlID="btnNewReq"  EventName="Click"/>
                <asp:AsyncPostBackTrigger ControlID="btnAdd"  EventName="Click"/>
                   <asp:AsyncPostBackTrigger ControlID="btnSubmit"  EventName="Click"/>


            </Triggers>
        </asp:UpdatePanel>


</asp:Content>




<asp:Content ID="Content1" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .lblmesgq {
            text-align: center;
        }
        .lblmesg {
            font-weight: 700;
        }

        .watermark
            {
          
             opacity:0.4;
           
            }

        .successMerit {
            background-color: #1fa756;
            border: medium none;
            color: White;
        }

        .defaultColor {
            background-color: white;
            color: black;
        }

        .dangerFailed {
            background-color: #f2283a;
            color: White;
        }


        .Calendar {
            background-color:#808080;
            color: white;
            font-family: Courier New;
            font-size: 20px;
            font-weight:normal;
        }
     
        .autocomplete_completionListElement {
            visibility: hidden;
            margin: 0px!important;
            color: white ;
            border: buttonshadow;
            border-width: 2px;
            border-style: solid;
            cursor: default;
            overflow: auto;
            height: 270px;
            width:300px;
            text-align: left;
            list-style-type:disc;
            
            background-color: white;
        }

        .autocomplete_highlightedListItem {
            background-color:#808080;
            color:white;
            padding: 1px;
            cursor: pointer;
        }

        .autocomplete_listItem {
            background-color: window;
            color: windowtext;
            padding: 1px;
        }

        .hdn {
            visibility: hidden;
        }

        .btn2 {
            border: 1px Solid #32A545;
            background-color: White;
            color: #32A545;
            cursor: pointer;
           text-align:center;
            font: 9pt verdana;
        }


    </style>
</asp:Content>








