<%@ Page Title="ITEM REQUISITION" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="frm_item_requisition.aspx.cs" Inherits="ERPWebApplication.ModuleName.Inventory.TransactionPage.frm_item_requisition" %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <%--<div id="wrapper" style="margin: 0 auto">--%>
        <asp:UpdatePanel ID="uppnl1" runat="server">

            <ContentTemplate>

                <table class="auto-style1" style="width: 100%">

                    <tr>
                        <td class="auto-style24">
                            <table class="auto-style1">
                                <tr>
                                    <td class="auto-style228">&nbsp;</td>
                                    <td class="auto-style128" style="text-align: left">
                                        <asp:Label ID="lblwhere" runat="server" ForeColor="#000066" Style="text-decoration: underline"></asp:Label>
                                    </td>
                                    <td class="auto-style225">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style228">&nbsp;</td>
                                    <td class="auto-style128">
                                        <asp:Panel ID="pnlsearch" runat="server" Height="16px" Style="background-color: #006EC7; color: white;" Width="798px">
                                            <div class="heading" style="background-color: #3366CC">
                                                <asp:ImageButton ID="header_ToggleImage1" runat="server" AlternateText="collapse" ImageUrl="~/images/collapse.jpg" />

                                                Search Requisition
                                            </div>
                                        </asp:Panel>
                                    </td>
                                    <td class="auto-style225">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style228">&nbsp;</td>
                                    <td class="auto-style128" colspan="2">

                                        <asp:Panel ID="pnlsearchrequisition" runat="server">
                                            <table class="auto-style90">
                                                <tr>
                                                    <td class="auto-style8"></td>
                                                    <td class="auto-style231"></td>
                                                    <td class="auto-style232"></td>
                                                    <td class="auto-style233"></td>
                                                    <td class="auto-style233"></td>
                                                    <td class="auto-style233"></td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style8">&nbsp;</td>
                                                    <td class="auto-style217">
                                                        <asp:TextBox ID="txtsearchreq0" runat="server" Height="23px" Width="324px"></asp:TextBox>
                                                    </td>
                                                    <td class="auto-style218">
                                                        <asp:Button ID="btnsearch" runat="server" BackColor="#9CC2E5" Height="28px" OnClick="btnsearch_Click" Text="Search" Width="100px" />
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btnadvsearch" runat="server" BackColor="#BF8F00" Height="28px" OnClick="btnadvsearch_Click" Text="Advanced Search" Width="128px" />
                                                    </td>
                                                    <td>&nbsp;</td>
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
                                    <td>&nbsp;</td>
                                </tr>
                            </table>





                            <hr style="border-top: 1px solid #8c8b8b; border-bottom: 1px solid #fff; width: 800px; margin-left: 80px; margin-right: 200px" />

                        </td>
                    </tr>



                    <tr>
                        <td>

                            <table class="auto-style1" id="tbladvsearch" runat="server">
                                <tr>
                                    <td class="auto-style7">&nbsp;</td>
                                    <td class="auto-style134">Item Requisition No:</td>
                                    <td class="auto-style190">
                                        <asp:TextBox ID="txtrequisitionid" runat="server" Width="220px"></asp:TextBox>
                                    </td>
                                    <td class="auto-style210">From date:</td>
                                    <td class="auto-style188">
                                        <asp:TextBox ID="txtfrmdate" runat="server" Width="195px"></asp:TextBox>
                                    </td>
                                    <td class="auto-style209">
                                        <asp:ImageButton ID="ImageButton4" runat="server" Height="15px" ImageUrl="~/Images/collapse.jpg" OnClick="ImageButton1_Click" />
                                    </td>
                                    <td class="auto-style207">&nbsp;</td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td class="auto-style7">&nbsp;</td>
                                    <td class="auto-style208">Item Name:</td>
                                    <td class="auto-style190">
                                        <asp:TextBox ID="txtitmcode" runat="server" Width="220px"></asp:TextBox>
                                    </td>
                                    <td class="auto-style210">To date:</td>
                                    <td class="auto-style188">
                                        <asp:TextBox ID="txttodate" runat="server" Width="195px"></asp:TextBox>
                                    </td>
                                    <td class="auto-style209">&nbsp;</td>
                                    <td class="auto-style207">&nbsp;</td>
                                    <td class="auto-style155">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style7">&nbsp;</td>
                                    <td class="auto-style208">&nbsp;</td>
                                    <td class="auto-style190">&nbsp;</td>
                                    <td class="auto-style205">&nbsp;</td>
                                    <td class="auto-style188">
                                        <asp:Button ID="btnshow" runat="server" BackColor="#5B9BD5" Height="28px" OnClick="btnshow_Click" Text="Show" Width="79px" />
                                        <asp:Button ID="btnclear" runat="server" BackColor="#5B9BD5" Height="28px" Text="Clear" Width="79px" OnClick="btnclear_Click1" />

                                    </td>
                                    <td class="auto-style209">&nbsp;</td>
                                    <td class="auto-style207">&nbsp;</td>
                                    <td class="auto-style155">&nbsp;</td>
                                </tr>
                            </table>
                            <hr id="hradvsearch" runat="server" style="border-top: 1px solid #8c8b8b; border-bottom: 1px solid #fff; width: 800px; margin-left: 80px; margin-right: 200px" />


                        </td>

                    </tr>

                    <tr>
                        <td class="auto-style24">


                            <table class="auto-style1" id="tbladvsearchresult" runat="server">



                                <tr>
                                    <td class="auto-style16">&nbsp;</td>
                                    <td class="auto-style148">
                                        <asp:Label ID="Label2" runat="server"></asp:Label>
                                    </td>
                                    <td class="auto-style89">&nbsp;</td>
                                    <td class="auto-style89">&nbsp;</td>
                                    <td class="auto-style89">&nbsp;</td>
                                    <td class="auto-style89">&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>



                                <tr>
                                    <td class="auto-style16">&nbsp;</td>
                                    <td class="auto-style62">
                                        <asp:Panel ID="Panel1" runat="server" Height="100px" ScrollBars="Vertical" Style="overflow: auto; width: 750px; text-align: center;">
                                            <asp:GridView ID="GridView2" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" Width="100%" CellPadding="3" Style="text-align: left">
                                                <FooterStyle BackColor="White" ForeColor="#000066" />
                                                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                <RowStyle ForeColor="#000066" />
                                                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                                <SortedDescendingHeaderStyle BackColor="#00547E" />
                                            </asp:GridView>
                                        </asp:Panel>
                                    </td>
                                    <td class="auto-style89">&nbsp;</td>
                                    <td class="auto-style89">&nbsp;</td>
                                    <td class="auto-style89">&nbsp;</td>
                                    <td class="auto-style89">&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>



                            </table>
                            <hr id="hradvsearchresult" runat="server" style="border-top: 1px solid #8c8b8b; border-bottom: 1px solid #fff; width: 800px; margin-left: 80px; margin-right: 200px" />

                        </td>
                    </tr>


                    <tr>
                        <td class="auto-style24">


                            <table class="auto-style1">
                                <tr>
                                    <td class="auto-style17">&nbsp;</td>
                                    <td class="auto-style19">
                                        <asp:Label ID="lblreqstatus" runat="server" Text="Requisition Status:"></asp:Label>
                                    </td>
                                    <td class="auto-style253">&nbsp;</td>
                                    <td class="auto-style18">
                                        <asp:Label ID="lblstatus1" runat="server"></asp:Label>
                                    </td>
                                    <td class="auto-style30">&nbsp;</td>
                                    <td class="auto-style31">&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:Button ID="btnnewReq" runat="server" BackColor="#AED49F" ForeColor="White" Height="28px" OnClick="btnnewReq_Click" Text="New Requisition" Width="130px" />&nbsp;
                                <asp:Button ID="btnnewprint" runat="server" BackColor="#AED49F" ForeColor="White" Height="28px" Text="Print" Width="81px" OnClick="btnnewprint_Click" />
                                    </td>
                                    <td class="auto-style14">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style22"></td>
                                    <td class="auto-style23">Request by: </td>
                                    <td class="auto-style24">:</td>
                                    <td class="auto-style25">
                                        <asp:TextBox ID="TextBox1" runat="server" Width="220px"></asp:TextBox>
                                    </td>
                                    <td class="auto-style29"></td>
                                    <td class="auto-style26">Request Date</td>
                                    <td class="auto-style24">:</td>
                                    <td class="auto-style24">
                                        <asp:TextBox ID="TextBox4" runat="server" Width="196px"></asp:TextBox>
                                    </td>
                                    <td class="auto-style27"></td>
                                </tr>
                                <tr>
                                    <td class="auto-style17">&nbsp;</td>
                                    <td class="auto-style19">Requesting department</td>
                                    <td class="auto-style253">:</td>
                                    <td class="auto-style18">
                                        <asp:DropDownList ID="DropDownList1" runat="server" Width="225px">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="auto-style30">&nbsp;</td>
                                    <td class="auto-style31">Date needed</td>
                                    <td>:</td>
                                    <td class="auto-style211">
                                        <asp:TextBox ID="TextBox5" runat="server" Width="196px"></asp:TextBox>
                                    </td>
                                    <td class="auto-style14">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style17">&nbsp;</td>
                                    <td class="auto-style19">Item User Type</td>
                                    <td class="auto-style253">:</td>
                                    <td class="auto-style18">
                                        <asp:DropDownList ID="DropDownList2" runat="server" Width="225px">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="auto-style30">&nbsp;</td>
                                    <td class="auto-style31">Priority</td>
                                    <td>:</td>
                                    <td class="auto-style211">
                                        <asp:DropDownList ID="DropDownList4" runat="server" Width="200px">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="auto-style14">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style17">&nbsp;</td>
                                    <td class="auto-style19">User name</td>
                                    <td class="auto-style253">:</td>
                                    <td class="auto-style18">
                                        <asp:TextBox ID="TextBox2" runat="server" Width="220px"></asp:TextBox>
                                    </td>
                                    <td class="auto-style30">&nbsp;</td>
                                    <td class="auto-style31">Purpose</td>
                                    <td>:</td>
                                    <td class="auto-style211">
                                        <asp:DropDownList ID="DropDownList5" runat="server" Width="200px">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="auto-style14">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style17">&nbsp;</td>
                                    <td class="auto-style19">Location of use</td>
                                    <td class="auto-style253">:</td>
                                    <td class="auto-style18">
                                        <asp:DropDownList ID="DropDownList3" runat="server" Width="225px">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="auto-style30">&nbsp;</td>
                                    <td class="auto-style31">Reference Type</td>
                                    <td>:</td>
                                    <td class="auto-style211">
                                        <asp:DropDownList ID="DropDownList6" runat="server" Width="200px">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="auto-style14">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style17">&nbsp;</td>
                                    <td class="auto-style19">Location address</td>
                                    <td class="auto-style253">:</td>
                                    <td class="auto-style18" rowspan="2">
                                        <asp:TextBox ID="TextBox15" runat="server" Width="220px" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                    <td class="auto-style30">&nbsp;</td>
                                    <td class="auto-style31">Reference No.</td>
                                    <td>:</td>
                                    <td class="auto-style211">
                                        <asp:TextBox ID="TextBox6" runat="server" Width="196px"></asp:TextBox>
                                    </td>
                                    <td class="auto-style14">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style17"></td>
                                    <td class="auto-style19"></td>
                                    <td class="auto-style253"></td>
                                    <td class="auto-style30"></td>
                                    <td class="auto-style31">Is project related?</td>
                                    <td>:</td>
                                    <td class="auto-style211">
                                        <asp:CheckBox ID="chk1" runat="server" OnCheckedChanged="chk1_CheckedChanged" AutoPostBack="True" Text="Yes" />
                                    </td>
                                    <td class="auto-style14"></td>
                                </tr>
                                <tr>
                                    <td class="auto-style17">&nbsp;</td>
                                    <td class="auto-style19">Comments</td>
                                    <td class="auto-style253">:</td>
                                    <td class="auto-style18" rowspan="2">
                                        <asp:TextBox ID="TextBox21" runat="server" TextMode="MultiLine" Width="220px"></asp:TextBox>
                                    </td>
                                    <td class="auto-style30">&nbsp;</td>
                                    <td class="auto-style31">
                                        <asp:Label ID="lbl1" runat="server" Text="Select a project "></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Text=":"></asp:Label>
                                    </td>
                                    <td class="auto-style211">
                                        <asp:DropDownList ID="DropDownList7" runat="server" Width="200px">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="auto-style14">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style17">&nbsp;</td>
                                    <td class="auto-style19">&nbsp;</td>
                                    <td class="auto-style253">&nbsp;</td>
                                    <td class="auto-style30">&nbsp;</td>
                                    <td class="auto-style31">File upload</td>
                                    <td>:</td>
                                    <td class="auto-style211" style="text-align: left">
                                        <asp:FileUpload ID="FileUpload1" runat="server" Width="196px" />
                                    </td>
                                    <td class="auto-style14">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style17">&nbsp;</td>
                                    <td class="auto-style19">&nbsp;</td>
                                    <td class="auto-style253">&nbsp;</td>
                                    <td class="auto-style18">&nbsp;</td>
                                    <td class="auto-style30">&nbsp;</td>
                                    <td class="auto-style31">&nbsp;</td>
                                    <td style="text-align: right">&nbsp;</td>
                                    <td class="auto-style211">&nbsp;</td>
                                    <td class="auto-style14"></td>
                                </tr>
                            </table>


                            <hr id="hr2" runat="server" style="border-top: 1px solid #8c8b8b; border-bottom: 1px solid #fff; width: 800px; margin-left: 80px; margin-right: 200px" />

                        </td>
                    </tr>



                </table>

                <table class="auto-style1" id="tbldet" runat="server">



                    <tr>
                        <td class="auto-style61">&nbsp;</td>
                        <td style="text-align: left">
                            <table class="auto-style241" id="tblauthorization" runat="server">
                                <tr>
                                    <td class="auto-style278">This requisition will be forward to</td>
                                    <td class="auto-style279">
                                        <asp:DropDownList ID="ddlforwardto" runat="server" Width="194px" Height="16px">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="auto-style244">
                                        <asp:Button ID="btnedit" runat="server" BackColor="#5B9BD5" Height="24px" OnClick="btnedit_Click" Text="Enable" Width="60px" />
                                    </td>
                                    <td class="auto-style281"><span class="auto-style280"><em>&nbsp;</em>for Authorization</span>.</td>
                                    <td style="text-align: right">
                                        <asp:Button ID="btnsubmit" runat="server" BackColor="#5B9BD5" Height="28px" OnClick="btnsubmit_Click" Text="Submit" Visible="False" Width="100px" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="auto-style89">&nbsp;</td>
                        <td class="auto-style89">&nbsp;</td>
                        <td class="auto-style89">&nbsp;</td>
                        <td class="auto-style89">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>



                    <tr>
                        <td class="auto-style61">&nbsp;</td>
                        <td class="auto-style62">
                            <asp:Panel ID="pnl" runat="server" Height="151px" ScrollBars="Vertical" Style="overflow: auto; width: 750px; text-align: center;">
                                <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Style="text-align: left" Width="100%">
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                    <RowStyle ForeColor="#000066" />
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                                </asp:GridView>
                            </asp:Panel>
                        </td>
                        <td class="auto-style89">&nbsp;</td>
                        <td class="auto-style89">&nbsp;</td>
                        <td class="auto-style89">&nbsp;</td>
                        <td class="auto-style89">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>



                    <tr>
                        <td class="auto-style61">&nbsp;</td>
                        <td style="text-align: right">&nbsp;</td>
                        <td class="auto-style89">&nbsp;</td>
                        <td class="auto-style89">&nbsp;</td>
                        <td class="auto-style89">&nbsp;</td>
                        <td class="auto-style89">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>


                </table>


                <table class="auto-style90">
                    <tr>
                        <td class="auto-style13"></td>
                        <td class="auto-style138">

                            <asp:Panel ID="header_HeaderPanel" runat="server" Style="background-color: #006EC7; color: white;" Height="16px" Width="801px">
                                <div class="heading" style="background-color: #3366CC">
                                    <asp:ImageButton ID="header_ToggleImage" runat="server" ImageUrl="~/images/collapse.jpg" AlternateText="collapse" />
                                    Add detail Item Information
                                </div>
                            </asp:Panel>
                        </td>
                        <td class="auto-style138">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style13">&nbsp;</td>
                        <td class="auto-style138">

                            <asp:Panel ID="header_ContentPanel" runat="server">

                                <table>
                                    <tr>
                                        <td>Item Name</td>
                                        <td class="auto-style3">:</td>
                                        <td style="text-align: left">
                                            <asp:TextBox ID="txtItem" runat="server" Width="220px"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td>Specification:</td>
                                        <td style="text-align: left">
                                            <asp:TextBox ID="txtSpec" runat="server" Width="196px"></asp:TextBox>
                                        </td>
                                        <td style="text-align: left">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style282">Quantity</td>
                                        <td class="auto-style3">:</td>
                                        <td class="auto-style122" style="text-align: left">
                                            <asp:TextBox ID="txtQunt" runat="server" Width="220px"></asp:TextBox>
                                        </td>
                                        <td class="auto-style89">&nbsp;</td>
                                        <td class="auto-style285">Brand:</td>
                                        <td style="text-align: left" class="auto-style211">
                                            <asp:TextBox ID="txtBrand" runat="server" Width="196px"></asp:TextBox>
                                        </td>
                                        <td style="text-align: left">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style282">Location of use</td>
                                        <td class="auto-style3">:</td>
                                        <td class="auto-style122" style="text-align: left">
                                            <asp:TextBox ID="txtLoc" runat="server" Width="220px"></asp:TextBox>
                                        </td>
                                        <td class="auto-style89">&nbsp;</td>
                                        <td class="auto-style285">Origin:</td>
                                        <td style="text-align: left" class="auto-style211">
                                            <asp:TextBox ID="txtOrigin" runat="server" Width="196px"></asp:TextBox>
                                        </td>
                                        <td style="text-align: left">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style282">&nbsp;</td>
                                        <td class="auto-style3">&nbsp;</td>
                                        <td class="auto-style122">&nbsp;</td>
                                        <td class="auto-style89">&nbsp;</td>
                                        <td class="auto-style285">&nbsp;</td>
                                        <td class="auto-style211">&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style282">&nbsp;</td>
                                        <td class="auto-style3">&nbsp;</td>
                                        <td class="auto-style122">&nbsp;</td>
                                        <td class="auto-style89">&nbsp;</td>
                                        <td class="auto-style285">&nbsp;</td>
                                        <td style="text-align: right" class="auto-style211">
                                            <asp:Button ID="btnadd" runat="server" BackColor="#5B9BD5" Height="28px" Text="Add" Width="82px" OnClick="btnadd_Click" />
                                            <asp:Button ID="btnclearw" runat="server" BackColor="#5B9BD5" Height="28px" OnClick="btnclear_Click" Text="Clear" Width="84px" />
                                        </td>
                                        <td style="text-align: left">&nbsp;</td>
                                    </tr>
                                </table>

                                <hr id="hr1" runat="server" style="border-top: 1px solid #8c8b8b; border-bottom: 1px solid #fff; width: 800px; margin-left: 0px; margin-right: 200px" />

                                <ajaxToolkit:CollapsiblePanelExtender ID="cpeheader" runat="Server"
                                    TargetControlID="header_ContentPanel"
                                    ExpandControlID="header_HeaderPanel"
                                    CollapseControlID="header_HeaderPanel"
                                    ExpandDirection="Vertical"
                                    Collapsed="true"
                                    SuppressPostBack="true"
                                    ExpandedImage="~/images/collapse.jpg"
                                    CollapsedImage="~/images/expand.jpg"
                                    ImageControlID="header_ToggleImage" />

                            </asp:Panel>

                        </td>
                    </tr>

                </table>
            </ContentTemplate>
        </asp:UpdatePanel>

    <%--</div>--%>
</asp:Content>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .auto-style1 {
            width: 1211px;
        }

        .auto-style3 {
            width: 4px;
        }

        .auto-style7 {
            width: 186px;
        }

        .auto-style8 {
            width: 298px;
        }

        .auto-style13 {
            width: 106px;
        }

        .auto-style14 {
            width: 152px;
        }

        .auto-style16 {
            width: 66px;
        }

        .auto-style17 {
            width: 9px;
        }

        .auto-style18 {
            width: 17px;
        }

        .auto-style19 {
            width: 145px;
        }

        .auto-style21 {
            width: 104px;
        }

        .auto-style22 {
            width: 9px;
            height: 45px;
        }

        .auto-style23 {
            width: 145px;
            height: 45px;
        }

        .auto-style24 {
            height: 45px;
        }

        .auto-style25 {
            width: 17px;
            height: 45px;
        }

        .auto-style26 {
            width: 113px;
            height: 45px;
        }

        .auto-style27 {
            width: 152px;
            height: 45px;
        }

        .auto-style28 {
            width: 59px;
        }

        .auto-style29 {
            height: 45px;
            width: 34px;
        }

        .auto-style30 {
            width: 34px;
        }

        .auto-style31 {
            width: 113px;
        }
    </style>
</asp:Content>


