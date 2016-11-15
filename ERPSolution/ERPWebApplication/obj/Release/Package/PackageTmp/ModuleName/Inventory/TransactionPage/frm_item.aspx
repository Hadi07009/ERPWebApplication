<%@ Page Title="Item Requisition" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="frm_item.aspx.cs" Inherits="ERPWebApplication.ModuleName.Inventory.TransactionPage.frm_item" %>



<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <div id="wrapper" style="margin: 0 auto">
        <asp:UpdatePanel ID="uppnl1" runat="server">

            <ContentTemplate>
                <table id="tblmas" style="margin-top:-0.25em" runat="server">
                    
                    <tr>
                        <td >&nbsp;</td>
                        <td>
                            <table  id="tblsearch" runat="server" style="margin-top:0px">
                                <tr>
                                    <td >
                                        <table >
                                            <tr>
                                                <td>
                                                    <asp:Panel ID="pnlsearch" runat="server" Width="945px" style="margin-top:0px">
                                                        <table style="margin-top:0px"  >


                                                            <tr >
                                                                <td style="padding:2px" >

                                                                    <asp:ImageButton ID="header_ToggleImage1" runat="server" Height="15px" Width="15px"  ImageUrl="~/images/collapse.jpg" />

                                                                </td>
                                                                <td  >
                                                                    &nbsp;<asp:Label ID="Label11" runat="server" Text="Search Requisition"  Font-Size="20px" ForeColor="#034EA2" Width="456px"></asp:Label>
                                                                </td>
                                                            </tr>


                                                           
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>

                                    <td style ="margin-top:0px">

                                        <asp:Panel ID="pnlsearchrequisition" runat="server">

                                            <table style="margin-top:0px">
                                                <tr>
                                                    <td >&nbsp;</td>
                                                    <td >&nbsp;</td>
                                                    <td >
                                                        <asp:TextBox ID="TextBox1" runat="server" Width="282px"></asp:TextBox>
                                                    </td>
                                                    <td >
                                                        <asp:Button ID="btnsearch" runat="server" Text="Search" />
                                                    </td>
                                                    <td >
                                                        <asp:Button ID="btnadvsearch" runat="server" Text="Advanced Search" OnClick="btnadvsearch_Click" />
                                                    </td>
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



                                        <table  style="width: 950px; margin-top:0px">
                                            <tr>
                                                <td style="width: 960px">
                                                    <hr id="searchbottom" runat="server" style="border-style: none; border-color: inherit; border-width: 0; background-position: 0% 0%; height: 1px; background-image: linear-gradient(to right, #ccc, #333, #ccc); width: 918px; margin-right: 50px; background-color: #333; background-repeat: repeat; background-attachment: scroll;" />
                                                </td>
                                            </tr>
                                        </table>

                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <%-- <tr>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>--%>
                    <tr>
                        <td >&nbsp;</td>
                        <td style="margin-top :0px">
                            <table  id="tbladvsearch" runat="server">
                                <tr>
                                    <td style="width: 47px" >&nbsp;</td>
                                    <td style="text-align:right">
                                        <asp:Label ID="Label2" runat="server" Text="Ref.NO " CssClass="label"></asp:Label>
                                        :</td>
                                    <td >
                                        <asp:TextBox ID="txtrequisitionid" runat="server" Width="220px"></asp:TextBox>
                                    </td>
                                    <td >
                                        <asp:Label ID="Label5" runat="server" Text="From Date:" CssClass="label"></asp:Label>
                                    </td>
                                    <td >
                                        <asp:TextBox ID="txtrequisitionid1" runat="server" Width="220px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="imgbtnadsearch" runat="server" Height="15px" Width="15px" ImageUrl="~/Images/collapse.jpg" OnClick="imgbtnadsearch_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td  style="width: 47px"></td>
                                    <td  style="text-align:right">
                                        <asp:Label ID="Label3" runat="server" Text="Item Name: " CssClass="label"></asp:Label>
                                    </td>
                                    <td >
                                        <asp:TextBox ID="txtrequisitionid0" runat="server" Height="12px" Width="220px"></asp:TextBox>
                                    </td>
                                    <td >
                                        <asp:Label ID="Label6" runat="server" Text="To Date:" CssClass="label"></asp:Label>
                                    </td>
                                    <td >
                                        <asp:TextBox ID="txtrequisitionid2" runat="server" Width="220px"></asp:TextBox>
                                    </td>
                                    <td >&nbsp;</td>
                                </tr>
                                <tr>
                                    <td  style="width: 47px">&nbsp;</td>
                                    <td  style="text-align:right">
                                        <asp:Label ID="Label4" runat="server" Text="Item Name: " CssClass="label"></asp:Label>
                                    </td>
                                    <td >
                                        <asp:DropDownList ID="DropDownList1" runat="server" Width="225px">
                                        </asp:DropDownList>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td >
                                        <asp:Button ID="btnshow" runat="server" Text="Show" OnClick="btnshow_Click" />
                                        &nbsp;<asp:Button ID="btnclearadsearch" runat="server" Text="Clear" />
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>

                            <table  style="width: 950px">
                                <tr>
 
                                    <td style="width: 950px">
                                        
                                       <hr id="advsearchbottom" runat="server" style="border:0; height: 1px; background: #333;  background-image: linear-gradient(to right, #ccc, #333, #ccc); width: 918px; margin-right: 50px" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <%--<tr>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>--%>
                    <tr>
                        <td >&nbsp;</td>
                        <td>
                            <table id="tbladvsearchresult" runat="server">
                                <tr>
                                    <td>&nbsp;</td>
                                    <td >&nbsp;</td>
                                    <td >
                                        <asp:Panel ID="Panel1" runat="server" Height="105px" ScrollBars="Vertical" Style="overflow: auto; width: 750px; text-align: center;">
                                            <asp:GridView ID="GridView2"  CssClass="myGridClass" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" Width="100%" CellPadding="3" Style="text-align: left">
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
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>

                            <table style="width: 950px">
                                <tr>
                                    <td style="width: 950px">
                                        

                                        <hr id="headertop" runat="server" style="border:0; height: 1px; background: #333;  background-image: linear-gradient(to right, #ccc, #333, #ccc); width: 918px; margin-right: 50px" />

                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>&nbsp;</td>
                    </tr>

                    <%--  <tr>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>--%>
                    <tr>
                        <td >&nbsp;</td>
                        <td>
                            <table>
                                <tr>
                                    <td >&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td style="width: 418px" >&nbsp;</td>
                                    <td style="text-align:right;">
                                       <asp:Button ID="btnnewReq" runat="server" Text="New Requisition"   OnClick="btnnewReq_Click" />
                                    </td>
                                    <td style="text-align:right" >
                                         &nbsp;<asp:Button ID="btnprintrequisition" runat="server" Text="Print" />

                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td >&nbsp;</td>
                        <td>
                            <table >
                                <tr>
                                    <td >&nbsp;</td>
                                    <td >
                                        <asp:Label ID="lblreqstatus" runat="server" CssClass="label" Text="Requisition Status:"></asp:Label>
                                    </td>
                                    <td >
                                        <asp:Label ID="lblstatus1" runat="server"></asp:Label>
                                    </td>
                                    <td >Request Date:</strong></td>
                                    <td>
                                        <asp:TextBox ID="TextBox4" runat="server" Width="196px"></asp:TextBox>
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td >&nbsp;</td>
                                    <td >
                                        <asp:Label ID="lblreqstatus0" runat="server" Text="Request by:"></asp:Label>
                                    </td>
                                    <td >
                                        <asp:TextBox ID="TextBox2" runat="server" Width="220px"></asp:TextBox>
                                    </td>
                                    <td >Date needed:</strong></td>
                                    <td >
                                        <asp:TextBox ID="TextBox5" runat="server" Width="196px"></asp:TextBox>
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td >&nbsp;</td>
                                    <td >
                                        <asp:Label ID="lblreqstatus1" runat="server" Text="Requesting dept."></asp:Label>
                                    </td>
                                    <td >
                                        <asp:DropDownList ID="DropDownList2" runat="server" Width="225px">
                                        </asp:DropDownList>
                                    </td>
                                    <td >Priority:</strong></td>
                                    <td>
                                        <asp:DropDownList ID="DropDownList5" runat="server" Width="200px">
                                        </asp:DropDownList>
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td >&nbsp;</td>
                                    <td>
                                        <asp:Label ID="lblreqstatus2" runat="server" Text="Item User Type:" ></asp:Label>
                                    </td>
                                    <td >
                                        <asp:DropDownList ID="DropDownList3" runat="server" Width="225px">
                                        </asp:DropDownList>
                                    </td>
                                    <td >Purpose:</strong></td>
                                    <td >
                                        <asp:DropDownList ID="DropDownList6" runat="server" Width="200px">
                                        </asp:DropDownList>
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td >
                                        <asp:Label ID="lblreqstatus3" runat="server" Text="User Name:" ></asp:Label>
                                    </td>
                                    <td >
                                        <asp:TextBox ID="TextBox3" runat="server" Width="220px"></asp:TextBox>
                                    </td>
                                    <td >
                                        <asp:Label ID="Label7" runat="server" Text="Reference Type::" ></asp:Label></td>
                                    <td >
                                        <asp:DropDownList ID="DropDownList7" runat="server" Width="200px">
                                        </asp:DropDownList>
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td >&nbsp;</td>
                                    <td>
                                        <asp:Label ID="lblreqstatus4" runat="server" Text="Location of use:" ></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DropDownList4" runat="server" Width="225px">
                                        </asp:DropDownList>
                                    </td>
                                    <td >
                                        <asp:Label ID="Label8" runat="server" Text="Reference No.:"></asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="TextBox6" runat="server" Width="196px"></asp:TextBox>
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td >&nbsp;</td>
                                    <td >
                                        <asp:Label ID="lblreqstatus5" runat="server" Text="Location address:" ></asp:Label>
                                    </td>
                                    <td rowspan="3" style="vertical-align: top">
                                        <asp:TextBox ID="TextBox15" runat="server" Width="219px" TextMode="MultiLine" Height="66px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label9" runat="server" Text="Is project related?:" ></asp:Label></td>
                                    <td>
                                        <asp:CheckBox ID="chk1" runat="server" AutoPostBack="True" />
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td >&nbsp;</td>
                                    <td>
                                        <asp:Label ID="lbl1" runat="server" Text="Select a project "></asp:Label>
                                        :</td>
                                    <td >
                                        <asp:DropDownList ID="DropDownList8" runat="server" Width="200px">
                                        </asp:DropDownList>
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td >&nbsp;</td>
                                    <td >&nbsp;</td>
                                    <td>
                                        <asp:Label ID="Label10" runat="server" Text="File upload:" ></asp:Label></td>
                                    <td >
                                        <asp:FileUpload ID="FileUpload1" runat="server" Width="196px" />
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td >&nbsp;</td>
                                    <td  style="vertical-align: top">Comments:</strong></td>
                                    <td  colspan="3">

                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="TextBox16" runat="server" Width="602px" TextMode="MultiLine"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>

                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>


                            <table  style="width: 950px">
                                <tr>
                                    <td style="width: 950px">
             
                                        <hr id="headerbottom" runat="server" style="border:0; height: 1px; background: #333;  background-image: linear-gradient(to right, #ccc, #333, #ccc); width: 918px; margin-right: 50px" />

                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <%-- <tr>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>--%>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <table  id="tblauthorization" runat="server">
                                <tr>
                                    <td >&nbsp;</td>
                                    <td >
                                        <asp:Label ID="lblreqstatus12" runat="server"  Text="This requisition will be forward to"></asp:Label>
                                    </td>
                                    <td >
                                        <asp:DropDownList ID="ddlforwardto"  runat="server" Width="194px">
                                        </asp:DropDownList>
                                    </td>
                                    <td >
                                        <asp:Button ID="btnedit" runat="server" Text="Enable" />
                                    </td>
                                    <td >
                                        <asp:Label ID="lblreqstatus13" runat="server" Text="for Authorization"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnsubmit" runat="server" Text="Submit" Width="65px" />
                                    </td>
                                </tr>
                            </table>


                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td >&nbsp;</td>
                        <td>
                            <table  id="tblitemdet" runat="server">
                                <tr>
                                    <td >&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:Panel ID="pnl" runat="server" Height="151px" ScrollBars="Vertical" Style="overflow: auto; width: 750px; text-align: center;">
                                            <asp:GridView ID="GridView3" runat="server" CssClass="myGridClass">
                                            </asp:GridView>
                                        </asp:Panel>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <%--<tr>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>--%>
                    <tr>
                        <td >&nbsp;</td>
                        <td>
                            <table >
                                <tr>
                                    <td>
                                        <table>
                                            <tr>
                                                <td>
                                                    <table >
                                                        <tr>
                                                            <td>
                                                                <asp:Panel ID="header_HeaderPanel" runat="server" Width="945px">
                                                                   <table  style="background-color:#7AC0DA; Width:920px"">
                                                            <tr>
                                                                <td >


                                                                 <asp:ImageButton ID="header_ToggleImage3" runat="server" Height="17px" Width="17px" ImageUrl="~/images/collapse.jpg" /></td>
                                                                <td style ="color:white"><asp:Label ID="Label1" runat="server" Text="Add Item Information"  Font-Size="20px" Width="456px" style="margin-left: 0px"></asp:Label></td>
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
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <asp:Panel ID="header_ContentPanel" runat="server">

                                <table >
                                    <tr>
                                        <td >&nbsp;</td>
                                        <td  style="text-align:right">
                                            <asp:Label ID="lblreqstatus6" runat="server"  Text="Item Name:"></asp:Label>
                                        </td>
                                        <td >
                                            <asp:TextBox ID="txtItem" runat="server" Width="220px"></asp:TextBox>
                                        </td>
                                        <td >&nbsp;</td>
                                        <td  style="text-align:right">
                                            <asp:Label ID="lblreqstatus9" runat="server"  Text="Specification:"></asp:Label>
                                        </td>
                                        <td >
                                            <asp:TextBox ID="txtSpec" runat="server" Width="196px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td >&nbsp;</td>
                                        <td  style="text-align:right">
                                            <asp:Label ID="lblreqstatus7" runat="server"  Text="Quantity:"></asp:Label>
                                        </td>
                                        <td >
                                            <asp:TextBox ID="txtQunt" runat="server" Width="220px"></asp:TextBox>
                                        </td>
                                        <td >&nbsp;</td>
                                        <td  style="text-align:right">
                                            <asp:Label ID="lblreqstatus10" runat="server"  Text="Brand:"></asp:Label>
                                        </td>
                                        <td >
                                            <asp:TextBox ID="txtBrand" runat="server" Width="196px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td >&nbsp;</td>
                                        <td style="text-align:right">
                                            <asp:Label ID="lblreqstatus8" runat="server"  Text="Unit:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtLoc" runat="server" Width="220px"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td style="text-align:right">
                                            <asp:Label ID="lblreqstatus11" runat="server"  Text="Origin:"></asp:Label>
                                        </td>
                                        <td >
                                            <asp:TextBox ID="txtOrigin" runat="server" Width="196px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td >&nbsp;</td>
                                        <td >&nbsp;</td>
                                        <td >&nbsp;</td>
                                        <td >&nbsp;</td>
                                        <td >&nbsp;</td>
                                        <td>
                                            <asp:Button ID="btnadd" runat="server" Text="Add" OnClick="btnadd_Click" />
                                            &nbsp;<asp:Button ID="btnclear" runat="server" Text="Clear" />
                                        </td>
                                    </tr>
                                </table>

                            </asp:Panel>


                            <ajaxToolkit:CollapsiblePanelExtender ID="cpeheader" runat="Server"
                                TargetControlID="header_ContentPanel"
                                ExpandControlID="header_HeaderPanel"
                                CollapseControlID="header_HeaderPanel"
                                ExpandDirection="Vertical"
                                Collapsed="true"
                                SuppressPostBack="true"
                                ExpandedImage="~/images/collapse.jpg"
                                CollapsedImage="~/images/expand.jpg"
                                ImageControlID="header_ToggleImage3" />



                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td >&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>


            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

</asp:Content>




