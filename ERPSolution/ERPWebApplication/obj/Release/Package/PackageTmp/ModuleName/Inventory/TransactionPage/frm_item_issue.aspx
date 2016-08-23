<%@ Page Title="ITEM ISSUE" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="frm_item_issue.aspx.cs" Inherits="ERPWebApplication.ModuleName.Inventory.TransactionPage.frm_item_issue" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <%--<section class="featured">
        <div class="content-wrapperHeader">
            <hgroup class="title">
                <h2><%: Title %>.</h2>
            </hgroup>
            
        </div>
    </section>--%>
</asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div id="wrapper" style="margin: 0 auto">
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
                                    <td class="auto-style225">
                                        <asp:LinkButton ID="lnkhome" runat="server" PostBackUrl="~/Frm_home_page.aspx">Home Page</asp:LinkButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style228">&nbsp;</td>
                                    <td class="auto-style128" colspan="2">

                                        <asp:Panel ID="pnlsearchrequisition" runat="server">
                                            <table class="auto-style90">
                                                <tr>
                                                    <td class="auto-style230"></td>
                                                    <td class="auto-style231"></td>
                                                    <td class="auto-style232"></td>
                                                    <td class="auto-style233"></td>
                                                    <td class="auto-style233"></td>
                                                    <td class="auto-style233"></td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style216">&nbsp;</td>
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
                                    <td class="auto-style155">&nbsp;</td>
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
                                    <td class="auto-style155">&nbsp;</td>
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
                                    <td class="auto-style155">&nbsp;</td>
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
                                    <td class="auto-style61">&nbsp;</td>
                                    <td class="auto-style62">
                                        <asp:Panel ID="Panel1" runat="server" Height="101px" ScrollBars="Vertical" Style="overflow: auto; width: 750px; text-align: center;">
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
                                    <td>
                                        <asp:LinkButton ID="lnkbtn" runat="server" OnClick="lnkbtn_Click">RQ-20160820</asp:LinkButton>
                                    </td>
                                </tr>



                            </table>
                            <hr id="hradvsearchresult" runat="server" style="border-top: 1px solid #8c8b8b; border-bottom: 1px solid #fff; width: 800px; margin-left: 80px; margin-right: 200px" />

                        </td>
                    </tr>


                    <tr>
                        <td class="auto-style24">


                            <table class="auto-style1" id="tblhdr" runat="server">
                                <tr>
                                    <td class="auto-style299">&nbsp;</td>
                                    <td class="auto-style301">
                                        <asp:Label ID="lblreqstatus" runat="server" Text="Requisition Status:"></asp:Label>
                                    </td>
                                    <td class="auto-style253">&nbsp;</td>
                                    <td class="auto-style254">
                                        <asp:Label ID="lblstatus1" runat="server" Text="Approved"></asp:Label>
                                    </td>
                                    <td class="auto-style266">&nbsp;</td>
                                    <td class="auto-style261">&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td style="text-align: right" class="auto-style297">
                                        <table>
                                            <tr>
                                                <td class="auto-style303"></td>
                                                <td>
                                                    <asp:Button ID="btnprint" runat="server" BackColor="#5B9BD5" ForeColor="White" Height="28px" Text="Print" Width="79px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td class="auto-style269">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style299">&nbsp;</td>
                                    <td class="auto-style301">Request by </td>
                                    <td class="auto-style253">:</td>
                                    <td class="auto-style254">
                                        <asp:TextBox ID="TextBox1" runat="server" Width="220px" Enabled="false"></asp:TextBox>
                                    </td>
                                    <td class="auto-style266">&nbsp;</td>
                                    <td class="auto-style261">Request Date</td>
                                    <td>:</td>
                                    <td class="auto-style297">
                                        <asp:TextBox ID="TextBox4" runat="server" Width="196px" Enabled="false"></asp:TextBox>
                                    </td>
                                    <td class="auto-style269">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style299">&nbsp;</td>
                                    <td class="auto-style301">Requesting department</td>
                                    <td class="auto-style253">:</td>
                                    <td class="auto-style254">
                                        <asp:TextBox ID="TextBox25" runat="server" Width="220px" Enabled="false"></asp:TextBox>
                                    </td>
                                    <td class="auto-style266">&nbsp;</td>
                                    <td class="auto-style261">Date needed</td>
                                    <td>:</td>
                                    <td class="auto-style297">
                                        <asp:TextBox ID="TextBox5" runat="server" Width="196px" Enabled="false"></asp:TextBox>
                                    </td>
                                    <td class="auto-style269">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style299">&nbsp;</td>
                                    <td class="auto-style301">Item User Type</td>
                                    <td class="auto-style253">:</td>
                                    <td class="auto-style254">
                                        <asp:TextBox ID="TextBox26" runat="server" Width="220px" Enabled="false"></asp:TextBox>
                                    </td>
                                    <td class="auto-style266">&nbsp;</td>
                                    <td class="auto-style261">Priority</td>
                                    <td>:</td>
                                    <td class="auto-style297">
                                        <asp:TextBox ID="TextBox22" runat="server" Width="196px" Enabled="false"></asp:TextBox>
                                    </td>
                                    <td class="auto-style269">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style299">&nbsp;</td>
                                    <td class="auto-style301">User name</td>
                                    <td class="auto-style253">:</td>
                                    <td class="auto-style254">
                                        <asp:TextBox ID="TextBox2" runat="server" Width="220px" Enabled="false"></asp:TextBox>
                                    </td>
                                    <td class="auto-style266">&nbsp;</td>
                                    <td class="auto-style261">Purpose</td>
                                    <td>:</td>
                                    <td class="auto-style297">
                                        <asp:TextBox ID="TextBox23" runat="server" Width="196px" Enabled="false"></asp:TextBox>
                                    </td>
                                    <td class="auto-style269">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style299">&nbsp;</td>
                                    <td class="auto-style301">Location of use</td>
                                    <td class="auto-style253">:</td>
                                    <td class="auto-style254">
                                        <asp:TextBox ID="TextBox27" runat="server" Width="220px" Enabled="false"></asp:TextBox>
                                    </td>
                                    <td class="auto-style266">&nbsp;</td>
                                    <td class="auto-style261">Reference Type</td>
                                    <td>:</td>
                                    <td class="auto-style297">
                                        <asp:TextBox ID="TextBox24" runat="server" Width="196px" Enabled="false"></asp:TextBox>
                                    </td>
                                    <td class="auto-style269">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style299">&nbsp;</td>
                                    <td class="auto-style301">Location address</td>
                                    <td class="auto-style253">:</td>
                                    <td class="auto-style254" rowspan="2">
                                        <asp:TextBox ID="TextBox15" runat="server" Width="220px" TextMode="MultiLine" Enabled="false"></asp:TextBox>
                                    </td>
                                    <td class="auto-style266">&nbsp;</td>
                                    <td class="auto-style261">Reference No.</td>
                                    <td>:</td>
                                    <td class="auto-style297">
                                        <asp:TextBox ID="TextBox6" runat="server" Width="196px" Enabled="false"></asp:TextBox>
                                    </td>
                                    <td class="auto-style269">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style299"></td>
                                    <td class="auto-style301"></td>
                                    <td class="auto-style253"></td>
                                    <td class="auto-style266"></td>
                                    <td class="auto-style261">Is project related?</td>
                                    <td>:</td>
                                    <td class="auto-style297">
                                        <asp:CheckBox ID="chk1" runat="server" OnCheckedChanged="chk1_CheckedChanged" Checked="true" AutoPostBack="True" Text="Yes" Enabled="false" />
                                    </td>
                                    <td class="auto-style269"></td>
                                </tr>
                                <tr>
                                    <td class="auto-style299">&nbsp;</td>
                                    <td class="auto-style301">Comments</td>
                                    <td class="auto-style253">:</td>
                                    <td class="auto-style254" rowspan="2">
                                        <asp:TextBox ID="TextBox21" runat="server" TextMode="MultiLine" Width="220px" Enabled="false"></asp:TextBox>
                                    </td>
                                    <td class="auto-style266">&nbsp;</td>
                                    <td class="auto-style261">
                                        <asp:Label ID="lbl1" runat="server" Text="Project "></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Text=":"></asp:Label>
                                    </td>
                                    <td class="auto-style297">
                                        <asp:TextBox ID="TextBox28" runat="server" Width="196px" Enabled="false"></asp:TextBox>
                                    </td>
                                    <td class="auto-style269">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style299">&nbsp;</td>
                                    <td class="auto-style301">&nbsp;</td>
                                    <td class="auto-style253">&nbsp;</td>
                                    <td class="auto-style266">&nbsp;</td>
                                    <td class="auto-style261">File upload</td>
                                    <td>:</td>
                                    <td class="auto-style297" style="text-align: left">
                                        <asp:TextBox ID="TextBox29" runat="server" Width="196px" Enabled="false"></asp:TextBox>
                                    </td>
                                    <td class="auto-style269">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style299">&nbsp;</td>
                                    <td class="auto-style301">&nbsp;</td>
                                    <td class="auto-style253">&nbsp;</td>
                                    <td class="auto-style254">&nbsp;</td>
                                    <td class="auto-style259">&nbsp;</td>
                                    <td class="auto-style260">&nbsp;</td>
                                    <td style="text-align: right">&nbsp;</td>
                                    <td class="auto-style297">&nbsp;</td>
                                    <td class="auto-style269"></td>
                                </tr>
                            </table>


                            <hr id="hr2" runat="server" style="border-top: 1px solid #8c8b8b; border-bottom: 1px solid #fff; width: 800px; margin-left: 80px; margin-right: 200px" />

                        </td>
                    </tr>



                </table>
                 <table class="auto-style1" id="tbldet" runat="server">



                    <tr>
                        <td class="auto-style337">&nbsp;</td>
                        <td style="text-align: left">
                            <table class="auto-style241" id="tblauthorization" runat="server">
                                <tr>
                                    <td class="auto-style278">
                                        <table class="auto-style306" style="color: #ff6a00">
                                            <tr>
                                                <td style="width: 350px; font-size: 14px">
                                                    <span class="auto-style339">This requisition is approved.</span></td>

                                            </tr>
                                        </table>
                                    </td>
                                    <td style="text-align: right"></em></span></td>
                                    <td style="text-align: right">&nbsp;</td>
                                    <td style="text-align: right">&nbsp;</td>

                                    <td style="text-align: right; color: #ff6a00">
                                        <asp:Button ID="btissue" runat="server" BackColor="#5B9BD5" ForeColor="White" Height="28px" Text="Issue" Width="65px" />
                                    </td>

                                </tr>
                            </table>
                        </td>
                        <td class="auto-style311">&nbsp;</td>
                        <td class="auto-style310">&nbsp;</td>
                        <td class="auto-style89">&nbsp;</td>
                        <td class="auto-style89">&nbsp;</td>
                        <td>&nbsp;&nbsp;</td>
                    </tr>



                    <tr>
                        <td class="auto-style337">&nbsp;</td>
                        <td class="auto-style62">
                            <table class="auto-style241">
                                <tr>
                                    <td>Comments:</td>
                                    <td>
                                        <asp:TextBox ID="TextBox30" runat="server" Width="677px"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="auto-style311">&nbsp;</td>
                        <td class="auto-style310">&nbsp;</td>
                        <td class="auto-style89">&nbsp;</td>
                        <td class="auto-style89">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>



                    <tr>
                        <td class="auto-style337">&nbsp;</td>
                        <td class="auto-style62">
                            <asp:Panel ID="pnl" runat="server" ScrollBars="Vertical" Style="overflow: auto; text-align: center;" Width="765px">
                                <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Font-Size="14px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Style="text-align: left" Width="100%" OnRowCreated="GridView1_RowCreated">
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                    <RowStyle ForeColor="#000066" />
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                                    <RowStyle BackColor="#EFF3FB" />
                                    <Columns>
                                        <asp:CommandField ShowSelectButton="True" />
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                        </td>
                        <td class="auto-style311">&nbsp;</td>
                        <td class="auto-style310">&nbsp;</td>
                        <td class="auto-style89">&nbsp;</td>
                        <td class="auto-style89">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>



                    <tr>
                        <td class="auto-style337">&nbsp;</td>
                        <td style="text-align: left">&nbsp;</td>
                        <td class="auto-style311">&nbsp;</td>
                        <td class="auto-style310">&nbsp;</td>
                        <td class="auto-style89">&nbsp;</td>
                        <td class="auto-style89">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>


                    <tr>
                        <td class="auto-style337">&nbsp;</td>
                        <td style="text-align: left">
                            <asp:Panel ID="Pnlcon" runat="server" Style="background-color: #006EC7;" Width="600px">
                                <div class="heading" style="background-color: #3366CC; color: white; width: 772px;">
                                    <asp:ImageButton ID="header_ToggleImage2" runat="server" AlternateText="collapse" ImageUrl="~/images/collapse.jpg" />
                                    Item Information
                                </div>
                            </asp:Panel>
                        </td>
                        <td class="auto-style311">&nbsp;</td>
                        <td class="auto-style310">&nbsp;</td>
                        <td class="auto-style89">&nbsp;</td>
                        <td class="auto-style89">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style337">&nbsp;</td>
                        <td style="text-align: left">

                            <asp:Panel ID="pnldett" runat="server">
                                <table class="auto-style307">
                                    <tr>
                                        <td class="auto-style351">Item name</td>
                                        <td class="auto-style89">:</td>
                                        <td class="auto-style329" style="text-align: left">
                                            <asp:TextBox ID="txtItem" runat="server" Width="220px" Enabled="false"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td class="auto-style352">Requested Qty:</td>
                                        <td style="text-align: left">
                                            <asp:TextBox ID="txtSpec" runat="server" Width="196px" Enabled="false"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style351">Quantity</td>
                                        <td class="auto-style89">:</td>
                                        <td class="auto-style329" style="text-align: left">
                                            <asp:TextBox ID="txtQunt" runat="server" Width="220px"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td class="auto-style352">Stock in Hand:</td>
                                        <td style="text-align: left">
                                            <asp:TextBox ID="txtBrand" runat="server" Width="196px" Enabled="false"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style351">Store</td>
                                        <td class="auto-style89">:</td>
                                        <td class="auto-style329" style="text-align: left">
                                            <asp:TextBox ID="txtLoc" runat="server" Width="220px"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td class="auto-style352">Min.Stock:</td>
                                        <td style="text-align: left">
                                            <asp:TextBox ID="txtOrigin" runat="server" Width="196px" Enabled="false"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style351">Specification</td>
                                        <td class="auto-style89">:</td>
                                        <td class="auto-style329" style="text-align: left">
                                            <asp:TextBox ID="txtLoc0" runat="server" Width="220px"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td class="auto-style352">Locked for Oth:</td>
                                        <td style="text-align: left">
                                            <asp:TextBox ID="txtOrigin0" runat="server" Width="196px" Enabled="false"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style351">Brand</td>
                                        <td class="auto-style89">:</td>
                                        <td class="auto-style329" style="text-align: left">
                                            <asp:TextBox ID="txtLoc1" runat="server" Width="220px"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td class="auto-style352">Available for:</td>
                                        <td style="text-align: left">
                                            <asp:TextBox ID="txtOrigin1" runat="server" Width="196px" Enabled="false"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style351">Origin</td>
                                        <td class="auto-style89">:</td>
                                        <td class="auto-style329" style="text-align: left">
                                            <asp:TextBox ID="txtLoc2" runat="server" Width="220px"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td class="auto-style352">Issue Now:</td>
                                        <td style="text-align: left">
                                            <asp:TextBox ID="txtissue" runat="server" Width="196px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style348">MPR</td>
                                        <td class="auto-style89">:</td>
                                        <td class="auto-style329">
                                            <asp:TextBox ID="txtLoc3" runat="server" Width="220px"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td class="auto-style350">&nbsp;</td>
                                        <td style="text-align: left">
                                            <asp:Button ID="btnupdate" runat="server" BackColor="#5B9BD5" ForeColor="White" Height="28px" Text="Update" Width="61px" OnClick="btnupdate_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>

                            <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender6" runat="Server"
                                TargetControlID="pnldett"
                                ExpandControlID="pnlcon"
                                CollapseControlID="pnlcon"
                                ExpandDirection="Vertical"
                                Collapsed="true"
                                SuppressPostBack="true"
                                ExpandedImage="~/images/collapse.jpg"
                                CollapsedImage="~/images/expand.jpg"
                                ImageControlID="header_ToggleImage2" />
                        </td>
                        <td class="auto-style311">&nbsp;</td>
                        <td class="auto-style310">&nbsp;</td>
                        <td class="auto-style89">&nbsp;</td>
                        <td class="auto-style89">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>


                </table>
             </ContentTemplate>
        </asp:UpdatePanel>

    </div>

</asp:Content>

