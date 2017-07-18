<%@ Page Title="Company Setup" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CompanySetupForm.aspx.cs" Inherits="ERPWebApplication.ModuleName.HRMS.MasterPage.CompanySetupForm"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table style="width: 100%; text-align: left">
                <tr>
                    <td colspan="3">
                        <asp:Panel ID="PanelDetails" runat="server">
                            <table style="width: 100%;">
                                <tr>
                                    <td colspan="2" style="width: 675px; float: left; text-align: left">
                                        <table style="width: 100%;">
                                            <tr>
                                                <td rowspan="7">
                                                    <asp:Panel ID="Panel11" runat="server" Height="310px" Width="235px">
                                                        <table style="width: 100%; text-align: left">
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblImage" runat="server" BorderColor="Black" BorderWidth="0px" Font-Bold="True" Font-Italic="True" Font-Size="Medium" ForeColor="Red" Height="155px" Style="text-align: center; vertical-align: middle" Width="155px"> <br /> Logo
                                             <br />  Not <br />  Available  
                                             
                                                                    </asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label98" runat="server" Text="[150X150,  Files are supported]"></asp:Label>
                                                                    <div id="dvMsg" style="background-color: Red; color: White; width: 190px; padding: 3px; display: none;">
                                                                        Maximum size allowed is 500 kb
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:FileUpload ID="ProfileImageUpload" runat="server" Width="95%" Height="24px" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="text-align: left; margin-top: -30px">
                                                                    <asp:ImageButton ID="btnCompanyLogo" runat="server" Width="27px" ImageUrl="~/Images/imageup.jpg" Height="12px" OnClick="btnCompanyLogo_Click" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="margin-top: -30px">
                                                                    <asp:RegularExpressionValidator ID="RevImg" runat="server" ControlToValidate="ProfileImageUpload" ErrorMessage="Invalid File!(only  .gif, .jpg, .jpeg, .bmp, .png  Files are supported)" ForeColor="Red" ValidationExpression="^.+(.jpg|.JPG|.gif|.GIF|.jpeg|JPEG| .bmp|BMP| .png|PNG)$" Width="100%"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label1" runat="server" Text="Country Name" Width="100px"></asp:Label>
                                                </td>
                                                <td>:</td>
                                                <td>
                                                    <asp:DropDownList ID="ddlCountry" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label2" runat="server" Text="Company Name"></asp:Label>
                                                </td>
                                                <td>:</td>
                                                <td>
                                                    <asp:TextBox ID="txtCompanyName" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label3" runat="server" Text="Email"></asp:Label>
                                                </td>
                                                <td>:</td>
                                                <td>
                                                    <asp:TextBox ID="txtEmail" runat="server" TextMode="Email"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label4" runat="server" Text="Mobile"></asp:Label>
                                                </td>
                                                <td>:</td>
                                                <td>
                                                    <asp:TextBox ID="txtMobile" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label99" runat="server" Text="Short Name"></asp:Label>
                                                </td>
                                                <td>:</td>
                                                <td>
                                                    <asp:TextBox ID="txtShortName" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td>&nbsp;</td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <asp:Label ID="Label124" runat="server" Text="Company Address" CssClass="labelasHeader"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td rowspan="6">
                                                    <table style="width: 100%;">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label120" runat="server" Text="Facebook ID"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="txtFaceBook" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label121" runat="server" Text="LinkedIn ID"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="txtLinkedInID" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label122" runat="server" Text="Twitter ID"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="txtTwitterID" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label123" runat="server" Text="YouTube ID"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="txtYouTubeID" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label103" runat="server" Text="House"></asp:Label>
                                                </td>
                                                <td>:</td>
                                                <td>
                                                    <asp:TextBox ID="txtHouse" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label104" runat="server" Text="Road"></asp:Label>
                                                </td>
                                                <td>:</td>
                                                <td>
                                                    <asp:TextBox ID="txtRoad" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label105" runat="server" Text="Sector"></asp:Label>
                                                </td>
                                                <td>:</td>
                                                <td>
                                                    <asp:TextBox ID="txtSector" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label106" runat="server" Text="Landmark"></asp:Label>
                                                </td>
                                                <td>:</td>
                                                <td>
                                                    <asp:TextBox ID="txtLandmark" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label107" runat="server" Text="District"></asp:Label>
                                                </td>
                                                <td>:</td>
                                                <td>
                                                    <asp:DropDownList ID="ddlDistrict" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label116" runat="server" Text="Phone"></asp:Label>
                                                </td>
                                                <td>:</td>
                                                <td>
                                                    <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width:300px">&nbsp;</td>
                                                <td >
                                                    <asp:Label ID="Label117" runat="server" Text="Fax"></asp:Label>
                                                </td>
                                                <td >:</td>
                                                <td>
                                                    <asp:TextBox ID="txtFax" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td>
                                                    <asp:Label ID="Label118" runat="server" Text="URL"></asp:Label>
                                                </td>
                                                <td>:</td>
                                                <td>
                                                    <asp:TextBox ID="txtURL" runat="server" TextMode="Url"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td>
                                                    <asp:Label ID="Label119" runat="server" Text="Licence"></asp:Label>
                                                </td>
                                                <td>:</td>
                                                <td>
                                                    <asp:TextBox ID="txtLicence" runat="server" TextMode="Number"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td style="text-align: left; float: left;padding-left:40px">
                                        <table style="width: 100%; text-align: left;">
                                            <tr>
                                                <td colspan="3" style="margin-top: -5px">
                                                    <div style="position: fixed; width: 345px; background-color: white; height: 60px; text-align: center">
                                                        <table style="width: 90%; margin-left: 5px">
                                                            <tr>
                                                                <td style="text-align: right">
                                                                    <asp:Button ID="btnSave" runat="server" Text="Save" Width="100px" OnClick="btnSave_Click" /></td>
                                                                <td style="text-align: center">
                                                                    <asp:Button ID="btnClear" runat="server" Text="Clear" Width="100px" OnClick="btnClear_Click" /></td>
                                                                <td style="text-align: left">
                                                                    <asp:Button ID="btnPrint" runat="server" Text="Print" Width="100px" /></td>
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
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label100" runat="server" Text="Business Type"></asp:Label>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <asp:DropDownList ID="ddlBusinessType" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label101" runat="server" Text="Ownership Type"></asp:Label>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <asp:DropDownList ID="ddlOwnershipType" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label102" runat="server" Text="Slogun"></asp:Label>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txtSlogun" runat="server" TextMode="MultiLine" Width="250px" Height="25px"></asp:TextBox>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label108" runat="server" CssClass="labelasHeader" Text="Contact Person"></asp:Label>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label109" runat="server" Text="Name"></asp:Label>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txtContactPersonName" runat="server"></asp:TextBox>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label110" runat="server" Text="Designation"></asp:Label>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:DropDownList ID="ddlContactPersonDesignation" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label111" runat="server" Text="Contact Number"></asp:Label>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txtContactNumber" runat="server"></asp:TextBox>
                                                </td>
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
                                                    <asp:Label ID="Label112" runat="server" CssClass="labelasHeader" Text="Alternate Contact Person"></asp:Label>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label113" runat="server" Text="Name"></asp:Label>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txtAltContName" runat="server"></asp:TextBox>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label114" runat="server" Text="Designation"></asp:Label>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:DropDownList ID="ddlAltContDesignation" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label115" runat="server" Text="Contact Number"></asp:Label>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txtAltContactNumber" runat="server"></asp:TextBox>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:GridView ID="grdCompany" runat="server" AutoGenerateColumns="False" Width="100%" OnRowCommand="grdCompany_RowCommand" OnRowDataBound="grdCompany_RowDataBound" OnRowDeleting="grdCompany_RowDeleting">
                            <Columns>
                                <asp:TemplateField HeaderText="SL">
                                    <ItemTemplate>
                                        <%# Container.DisplayIndex + 1 %>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Country Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCountryName" runat="server" Text='<%# Bind("CountryName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Company Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCompanyName" runat="server" Text='<%# Bind("CompanyName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Email">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCompanyEmail" runat="server" Text='<%# Bind("CompanyEmail") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Mobile">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCompanyMobile" runat="server" Text='<%# Bind("CompanyMobile") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Company ID">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCompanyID" runat="server" Text='<%# Bind("CompanyID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Country ID">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCountryID" runat="server" Text='<%# Bind("CountryID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ShowSelectButton="True">
                                    <controlstyle cssclass="cssSelect" />
                                </asp:CommandField >
                                    

                            </Columns>
                            <HeaderStyle />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnCompanyLogo" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
