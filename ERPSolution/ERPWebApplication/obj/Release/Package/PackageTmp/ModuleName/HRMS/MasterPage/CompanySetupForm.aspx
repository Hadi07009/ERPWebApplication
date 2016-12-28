<%@ Page Title="Company Information" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CompanySetupForm.aspx.cs" Inherits="ERPWebApplication.ModuleName.HRMS.MasterPage.CompanySetupForm" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        function setfocus(utxtbox) {

            utxtbox.value = utxtbox.value.toUpperCase();

            if (utxtbox.value.length >= 5000) {
                alert("Maximum length of Description must not exceed 5000 characters!");
            }
        }
        </script>
    <script src="../../Scripts/DOMAlert.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table style="width: 100%">
                <tr>
                    <td>
                        <asp:Panel ID="pnlUpdateCompanySetup" runat="server" Visible="false">
                            <table style="width: 100%">
                                <tr>
                                    <td>
                                        <asp:Panel ID="Panel3" runat="server">
                                            <table style="width: 100%">
                                                <tr>
                                                    <td style="width: 13px">&nbsp;</td>
                                                    <td style="width: 8px">&nbsp;</td>
                                                    <td style="width: 179px">&nbsp;</td>
                                                    <td style="width: 3px">&nbsp;</td>
                                                    <td style="width: 291px">&nbsp;</td>
                                                    <td style="width: 2px">&nbsp;</td>
                                                    <td style="width: 177px">&nbsp;</td>
                                                    <td style="width: 306px">&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3" rowspan="6" style="background-color: #f4f4f4;">
                                                        <asp:Panel ID="Panel19" runat="server">
                                                            <table style="width: 100%; height: 175px;">
                                                                <tr>
                                                                    <td style="width: 15px">&nbsp;</td>
                                                                    <td style="padding-bottom: 4px">
                                                                        <asp:Label ID="Label109" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#999999" Text="Company 

Logo"></asp:Label>
                                                                    </td>
                                                                    <td>&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="3">
                                                                        <asp:Panel ID="imageContainer" runat="server" HorizontalAlign="Center">
                                                                            <table style="width: 100%">
                                                                                <tr>
                                                                                    <td style="width: 36px">&nbsp;</td>
                                                                                    <td>
                                                                                        <asp:Image ID="ImgCompanyLogo" runat="server" CssClass="img-responsive" ImageAlign="Middle" />
                                                                                    </td>
                                                                                    <td>&nbsp;</td>
                                                                                </tr>
                                                                            </table>
                                                                        </asp:Panel>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 15px">&nbsp;</td>
                                                                    <td>&nbsp;</td>
                                                                    <td>&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 15px">&nbsp;</td>
                                                                    <td>
                                                                        <asp:FileUpload ID="FluPhotoUpload" runat="server" Height="45px" Width="170px" />
                                                                    </td>
                                                                    <td>&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 15px">&nbsp;</td>
                                                                    <td>
                                                                        <asp:Button ID="btnUploadCompanyImage" runat="server" CssClass="CssBtnPrintAll" OnClick="btnUploadCompanyImage_Click" Text="Upload" />
                                                                    </td>
                                                                    <td>&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 15px">&nbsp;</td>
                                                                    <td>&nbsp;</td>
                                                                    <td>&nbsp;</td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                    </td>
                                                    <td style="width: 3px; height: 18px;"></td>
                                                    <td style="width: 291px; height: 18px;">&nbsp;</td>
                                                    <td style="width: 2px; height: 18px;"></td>
                                                    <td style="width: 177px; height: 18px;"></td>
                                                    <td style="width: 306px; height: 18px;"></td>
                                                    <td style="height: 18px"></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 3px; height: 18px;">&nbsp;</td>
                                                    <td style="width: 291px; height: 18px;">
                                                        <asp:Label ID="txtCompanySetup" runat="server" CssClass="label-default" Font-Size="Large"></asp:Label>
                                                    </td>
                                                    <td style="width: 2px; height: 18px;">&nbsp;</td>
                                                    <td style="width: 177px; height: 18px;">&nbsp;</td>
                                                    <td style="width: 306px; height: 18px;">&nbsp;</td>
                                                    <td style="height: 18px">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 3px; text-align: right; height: 29px;">&nbsp; </td>
                                                    <td style="width: 291px; height: 29px;">
                                                        <asp:Label ID="txtCompanySlogun" runat="server" CssClass="label-default"></asp:Label>
                                                    </td>
                                                    <td style="width: 2px; height: 29px;"></td>
                                                    <td style="width: 177px; text-align: right; height: 29px;">
                                                        <asp:Label ID="Label58" runat="server" Text="Business Nature"></asp:Label>
                                                        &nbsp; </td>
                                                    <td style="height: 29px;">
                                                        <asp:DropDownList ID="ddlBusiness" runat="server" CssClass="cssDropdownList" Width="306px">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="height: 29px"></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 3px; text-align: right; height: 24px;">&nbsp; </td>
                                                    <td style="width: 291px; height: 24px;">
                                                        <asp:Label ID="txtCompanyShortName" runat="server" CssClass="label-default"></asp:Label>
                                                    </td>
                                                    <td style="width: 2px; height: 24px;"></td>
                                                    <td style="width: 177px; text-align: right; height: 24px;">
                                                        <asp:Label ID="Label59" runat="server" Text="Ownership"></asp:Label>
                                                        &nbsp; </td>
                                                    <td style="width: 335px; height: 24px;">
                                                        <asp:DropDownList ID="ddlOwnership" runat="server" CssClass="cssDropdownList" Width="306px">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="height: 24px"></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 3px; text-align: right; height: 30px;"></td>
                                                    <td style="width: 291px; height: 30px;">&nbsp;</td>
                                                    <td style="width: 2px; height: 30px;"></td>
                                                    <td style="width: 177px; text-align: right; height: 30px;">&nbsp; </td>
                                                    <td style="width: 335px; height: 30px;">&nbsp;</td>
                                                    <td style="height: 30px"></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 3px; text-align: right;">&nbsp;</td>
                                                    <td style="width: 291px">&nbsp;</td>
                                                    <td style="width: 2px">&nbsp;</td>
                                                    <td style="width: 177px; text-align: right;">&nbsp;</td>
                                                    <td style="width: 335px">&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 13px">&nbsp;</td>
                                                    <td style="width: 8px">&nbsp;</td>
                                                    <td style="width: 179px">&nbsp;</td>
                                                    <td style="width: 3px">&nbsp;</td>
                                                    <td style="width: 291px">&nbsp;</td>
                                                    <td style="width: 2px">&nbsp;</td>
                                                    <td style="width: 177px">&nbsp;</td>
                                                    <td style="width: 335px">&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Panel ID="Panel4" runat="server">
                                            <div style="height: 6px">
                                            </div>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Panel ID="Panel5" runat="server" BackColor="White">
                                            <table style="width: 100%">
                                                <tr>
                                                    <td colspan="7">
                                                        <asp:Label ID="Label104" runat="server" CssClass="label-default" Font-Bold="True" Font-Size="Large" ForeColor="DarkGray" Text="Company Address"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 15px">&nbsp;</td>
                                                    <td style="width: 25px">&nbsp;</td>
                                                    <td style="width: 171px">&nbsp;</td>
                                                    <td style="width: 329px">&nbsp;</td>
                                                    <td style="width: 3px">&nbsp;</td>
                                                    <td style="width: 542px">&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 15px; height: 94px;"></td>
                                                    <td style="width: 25px; height: 94px;"></td>
                                                    <td style="width: 171px; text-align: right; height: 94px;">
                                                        <asp:Label ID="Label92" runat="server" Text="House Information"></asp:Label>
                                                        &nbsp; </td>
                                                    <td style="width: 329px;">
                                                        <asp:TextBox ID="txtHouse" runat="server" CssClass="cssTextBox" Height="90px" placeholder="ex; House Name# Royal Olive; House No# 287; Floor No# A-4" TextMode="MultiLine" Width="300px"></asp:TextBox>
                                                    </td>
                                                    <td style="width: 3px; height: 94px;"></td>
                                                    <td style="width: 542px;">
                                                        <asp:Panel ID="Panel10" runat="server">
                                                            <table style="width: 100%">
                                                                <tr>
                                                                    <td style="text-align: right; width: 138px;">
                                                                        <asp:Label ID="Label101" runat="server" Text="Country"></asp:Label>
                                                                        &nbsp; </td>
                                                                    <td style="width: 347px;">
                                                                        <asp:DropDownList ID="ddlCountry" runat="server" AutoPostBack="True" CssClass="cssDropdownList" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" Width="306px">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td>&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="text-align: right; width: 138px;">
                                                                        <asp:Label ID="Label100" runat="server" Text="District"></asp:Label>
                                                                        &nbsp; </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlDistrict" runat="server" AutoPostBack="True" CssClass="cssDropdownList" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" Width="306px">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td>&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="text-align: right; width: 138px;">
                                                                        <asp:Label ID="Label97" runat="server" Text="Area Group"></asp:Label>
                                                                        &nbsp; </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlAreaGroup" runat="server" AutoPostBack="True" CssClass="cssDropdownList" OnSelectedIndexChanged="ddlAreaGroup_SelectedIndexChanged" Width="306px">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td>&nbsp;</td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                    </td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 15px">&nbsp;</td>
                                                    <td style="width: 25px">&nbsp;</td>
                                                    <td style="width: 171px; text-align: right;">
                                                        <asp:Label ID="Label93" runat="server" Text="Road Information"></asp:Label>
                                                        &nbsp; </td>
                                                    <td>
                                                        <asp:TextBox ID="txtRoad" runat="server" CssClass="cssTextBox" Height="60px" placeholder="ex; Road Name# West Rajabazar; Road No# 58/Ga" TextMode="MultiLine" Width="300px"></asp:TextBox>
                                                    </td>
                                                    <td style="width: 3px">&nbsp;</td>
                                                    <td style="width: 542px">
                                                        <asp:Panel ID="Panel11" runat="server">
                                                            <table style="width: 100%">
                                                                <tr>
                                                                    <td style="width: 138px; text-align: right;">
                                                                        <asp:Label ID="Label98" runat="server" Text="Area"></asp:Label>
                                                                        &nbsp; </td>
                                                                    <td style="width: 346px;">
                                                                        <asp:DropDownList ID="ddlArea" runat="server" AutoPostBack="True" CssClass="cssDropdownList" Width="306px">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td>&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 138px; text-align: right;">
                                                                        <asp:Label ID="Label102" runat="server" Text="Landmark"></asp:Label>
                                                                        &nbsp; </td>
                                                                    <td style="width: 346px;">
                                                                        <asp:TextBox ID="txtLandMark" runat="server" CssClass="cssTextBox" placeholder="ex; LandMark# Square Hospital" Width="300px"></asp:TextBox>
                                                                    </td>
                                                                    <td>&nbsp;</td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                    </td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 15px">&nbsp;</td>
                                                    <td style="width: 25px">&nbsp;</td>
                                                    <td style="width: 171px; text-align: right;">
                                                        <asp:Label ID="Label94" runat="server" Text="Sector"></asp:Label>
                                                        &nbsp; </td>
                                                    <td style="width: 329px">
                                                        <asp:TextBox ID="txtSector" runat="server" CssClass="cssTextBox" placeholder="ex; Sector# 10" Width="300px"></asp:TextBox>
                                                    </td>
                                                    <td style="width: 3px">&nbsp;</td>
                                                    <td style="width: 542px">&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 15px">&nbsp;</td>
                                                    <td style="width: 25px">&nbsp;</td>
                                                    <td style="width: 171px">&nbsp;</td>
                                                    <td style="width: 329px">&nbsp;</td>
                                                    <td style="width: 3px">&nbsp;</td>
                                                    <td style="width: 542px">&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Panel ID="Panel6" runat="server">
                                            <div style="height: 6px">
                                            </div>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Panel ID="Panel7" runat="server" BackColor="White">
                                            <table style="width: 100%">
                                                <tr>
                                                    <td colspan="8">
                                                        <asp:Label ID="Label105" runat="server" CssClass="label-default" Font-Bold="True" Font-Size="Large" ForeColor="DarkGray" Text="Contact Information"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 15px">&nbsp;</td>
                                                    <td style="width: 31px">&nbsp;</td>
                                                    <td style="width: 164px">&nbsp;</td>
                                                    <td style="width: 333px">&nbsp;</td>
                                                    <td style="width: 3px">&nbsp;</td>
                                                    <td style="width: 143px">&nbsp;</td>
                                                    <td style="width: 336px">&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 15px">&nbsp;</td>
                                                    <td style="width: 31px">&nbsp;</td>
                                                    <td style="width: 164px; text-align: right;">
                                                        <asp:Label ID="Label3" runat="server" Text="Company Phones"></asp:Label>
                                                        &nbsp; </td>
                                                    <td style="width: 333px">
                                                        <asp:TextBox ID="lblDistrictCode" runat="server" CssClass="cssTextBox" Enabled="false" Width="30px"></asp:TextBox>
                                                        <asp:TextBox ID="txtCompanyPhone" runat="server" CssClass="cssTextBox" Width="260px"></asp:TextBox>
                                                        <cc1:FilteredTextBoxExtender ID="txtCompanyPhone0_FilteredTextBoxExtender" runat="server" filtertype="Numbers,Custom" targetcontrolid="txtCompanyPhone" validchars=",+" />
                                                    </td>
                                                    <td style="width: 3px">&nbsp;</td>
                                                    <td style="width: 143px; text-align: right;">
                                                        <asp:Label ID="Label74" runat="server" Text="Company URL"></asp:Label>
                                                        &nbsp; </td>
                                                    <td style="width: 336px;">
                                                        <asp:TextBox ID="txtCompanyURL" runat="server" CssClass="cssTextBox" TextMode="SingleLine" Width="300px"></asp:TextBox>
                                                    </td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 15px">&nbsp;</td>
                                                    <td style="width: 31px">&nbsp;</td>
                                                    <td style="width: 164px; text-align: right;">
                                                        <asp:Label ID="Label77" runat="server" Text="Company Mobile"></asp:Label>
                                                        &nbsp; </td>
                                                    <td style="width: 333px">
                                                        <asp:TextBox ID="lblDialingCode" runat="server" CssClass="cssTextBox" Enabled="false" Width="30px"></asp:TextBox>
                                                        <asp:TextBox ID="txtCompanyMobile" runat="server" CssClass="cssTextBox" Width="260px"></asp:TextBox>
                                                        <cc1:FilteredTextBoxExtender ID="txtCompanyMobile0_FilteredTextBoxExtender" runat="server" filtertype="Numbers,Custom" targetcontrolid="txtCompanyMobile" validchars=",+" />
                                                    </td>
                                                    <td style="width: 3px">&nbsp;</td>
                                                    <td style="width: 143px; text-align: right;">
                                                        <asp:Label ID="Label81" runat="server" Text="FaceBook ID"></asp:Label>
                                                        &nbsp; </td>
                                                    <td style="width: 336px;">
                                                        <asp:TextBox ID="txtFaceBookID" runat="server" CssClass="cssTextBox" Width="300px"></asp:TextBox>
                                                    </td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 15px">&nbsp;</td>
                                                    <td style="width: 31px">&nbsp;</td>
                                                    <td style="width: 164px; text-align: right;">
                                                        <asp:Label ID="Label72" runat="server" Text="Company Fax"></asp:Label>
                                                        &nbsp; </td>
                                                    <td style="width: 333px">
                                                        <asp:TextBox ID="txtCompanyFax" runat="server" CssClass="cssTextBox" Width="300px"></asp:TextBox>
                                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" filtertype="Numbers,Custom" targetcontrolid="txtCompanyFax" validchars=",+" />
                                                    </td>
                                                    <td style="width: 3px">&nbsp;</td>
                                                    <td style="width: 143px; text-align: right;">
                                                        <asp:Label ID="Label86" runat="server" Text="LinkedIn ID"></asp:Label>
                                                        &nbsp; </td>
                                                    <td style="width: 336px;">
                                                        <asp:TextBox ID="txtLinkedInID" runat="server" CssClass="cssTextBox" Width="300px"></asp:TextBox>
                                                    </td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 15px">&nbsp;</td>
                                                    <td style="width: 31px">&nbsp;</td>
                                                    <td style="width: 164px; text-align: right;">
                                                        <asp:Label ID="Label73" runat="server" Text="Company Email"></asp:Label>
                                                        &nbsp; </td>
                                                    <td style="width: 333px">
                                                        <asp:TextBox ID="txtCompanyEmail" runat="server" CssClass="cssTextBox" TextMode="SingleLine" Width="300px"></asp:TextBox>
                                                    </td>
                                                    <td style="width: 3px">&nbsp;</td>
                                                    <td style="width: 143px; text-align: right;">
                                                        <asp:Label ID="Label87" runat="server" Text="Twitter ID"></asp:Label>
                                                        &nbsp; </td>
                                                    <td style="width: 336px;">
                                                        <asp:TextBox ID="txtTwitterID" runat="server" CssClass="cssTextBox" Width="300px"></asp:TextBox>
                                                    </td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 15px">&nbsp;</td>
                                                    <td style="width: 31px">&nbsp;</td>
                                                    <td style="width: 164px">&nbsp;</td>
                                                    <td style="width: 333px">&nbsp;</td>
                                                    <td style="width: 3px">&nbsp;</td>
                                                    <td style="width: 143px; text-align: right;">
                                                        <asp:Label ID="Label88" runat="server" Text="YouTube ID"></asp:Label>
                                                        &nbsp; </td>
                                                    <td style="width: 336px">
                                                        <asp:TextBox ID="txtYouTubeID" runat="server" CssClass="cssTextBox" Width="300px"></asp:TextBox>
                                                    </td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 15px">&nbsp;</td>
                                                    <td style="width: 31px">&nbsp;</td>
                                                    <td style="width: 164px">&nbsp;</td>
                                                    <td style="width: 333px">&nbsp;</td>
                                                    <td style="width: 3px">&nbsp;</td>
                                                    <td style="width: 143px">&nbsp;</td>
                                                    <td style="width: 336px">&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 15px">&nbsp;</td>
                                                    <td style="width: 31px">&nbsp;</td>
                                                    <td style="width: 164px">&nbsp;</td>
                                                    <td style="width: 333px">&nbsp;</td>
                                                    <td style="width: 3px">&nbsp;</td>
                                                    <td style="width: 143px">&nbsp;</td>
                                                    <td style="width: 336px">&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Panel ID="Panel8" runat="server">
                                            <div style="height: 6px">
                                            </div>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Panel ID="Panel9" runat="server" BackColor="White">
                                            <table style="width: 100%">
                                                <tr>
                                                    <td colspan="8">
                                                        <asp:Label ID="Label106" runat="server" CssClass="label-default" Font-Bold="True" Font-Size="Large" ForeColor="DarkGray" Text="Contact Person Information"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 12px">&nbsp;</td>
                                                    <td style="width: 83px">&nbsp;</td>
                                                    <td style="width: 114px">&nbsp;</td>
                                                    <td style="width: 329px">&nbsp;</td>
                                                    <td style="width: 41px">&nbsp;</td>
                                                    <td style="width: 112px">&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 12px; text-align: right;">&nbsp;</td>
                                                    <td style="width: 83px; text-align: right;">
                                                        <asp:Label ID="Label108" runat="server" Text="(1)"></asp:Label>
                                                    </td>
                                                    <td style="width: 114px; text-align: right;">
                                                        <asp:Label ID="Label75" runat="server" Text="Name"></asp:Label>
                                                        &nbsp; </td>
                                                    <td style="width: 329px;">
                                                        <asp:TextBox ID="txtContactPersonName" runat="server" CssClass="cssTextBox" Width="300px"></asp:TextBox>
                                                    </td>
                                                    <td style="width: 41px; text-align: right;">
                                                        <asp:Label ID="Label107" runat="server" Text="(2)"></asp:Label>
                                                    </td>
                                                    <td style="width: 112px; text-align: right;">
                                                        <asp:Label ID="Label89" runat="server" Text="Name"></asp:Label>
                                                        &nbsp;</td>
                                                    <td>
                                                        <asp:TextBox ID="txtAltContactPersonName" runat="server" CssClass="cssTextBox" Width="300px"></asp:TextBox>
                                                    </td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 12px">&nbsp;</td>
                                                    <td style="width: 83px">&nbsp;</td>
                                                    <td style="width: 114px; text-align: right;">
                                                        <asp:Label ID="Label68" runat="server" Text="Designation"></asp:Label>
                                                        &nbsp; </td>
                                                    <td style="width: 329px;">
                                                        <asp:TextBox ID="txtContactPersonDesignation" runat="server" CssClass="cssTextBox" Width="300px"></asp:TextBox>
                                                    </td>
                                                    <td style="width: 41px">&nbsp;</td>
                                                    <td style="width: 112px; text-align: right;">
                                                        <asp:Label ID="Label90" runat="server" Text="Designation"></asp:Label>
                                                        &nbsp; </td>
                                                    <td>
                                                        <asp:TextBox ID="txtAltContactPersonDesignation" runat="server" CssClass="cssTextBox" Width="300px"></asp:TextBox>
                                                    </td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 12px">&nbsp;</td>
                                                    <td style="width: 83px">&nbsp;</td>
                                                    <td style="width: 114px; text-align: right;">
                                                        <asp:Label ID="Label69" runat="server" Text="Contact Number"></asp:Label>
                                                        &nbsp; </td>
                                                    <td style="width: 329px;">
                                                        <asp:TextBox ID="txtContactPersonContactNum" runat="server" CssClass="cssTextBox" Width="300px"></asp:TextBox>
                                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" filtertype="Numbers,Custom" targetcontrolid="txtContactPersonContactNum" validchars=",+" />
                                                    </td>
                                                    <td style="width: 41px">&nbsp;</td>
                                                    <td style="width: 112px; text-align: right;">
                                                        <asp:Label ID="Label91" runat="server" Text="Contact Number"></asp:Label>
                                                        &nbsp; </td>
                                                    <td>
                                                        <asp:TextBox ID="txtAltContactPersonContactNum" runat="server" CssClass="cssTextBox" Width="300px"></asp:TextBox>
                                                        <cc1:FilteredTextBoxExtender ID="txtAltContactPersonContactNum_FilteredTextBoxExtender" runat="server" filtertype="Numbers,Custom" targetcontrolid="txtAltContactPersonContactNum" validchars=",+" />
                                                    </td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 12px">&nbsp;</td>
                                                    <td style="width: 83px">&nbsp;</td>
                                                    <td style="width: 114px; text-align: right;">&nbsp;</td>
                                                    <td style="width: 329px;">&nbsp;</td>
                                                    <td style="width: 41px">&nbsp;</td>
                                                    <td style="width: 112px; text-align: right;">&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Panel ID="Panel12" runat="server">
                                            <div style="height: 6px">
                                            </div>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Panel ID="Panel14" runat="server">
                                            <table style="width: 100%">
                                                <tr>
                                                    <td style="width: 539px; background-color: white">
                                                        <asp:Panel ID="Panel18" runat="server">
                                                            <table style="width: 100%">
                                                                <tr>
                                                                    <td colspan="2">
                                                                        <asp:Label ID="Label85" runat="server" CssClass="label-default" Font-Bold="True" Font-Size="Large" ForeColor="DarkGray" Text="Company Licence"></asp:Label>
                                                                    </td>
                                                                    <td>&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 192px; text-align: right;">&nbsp;</td>
                                                                    <td style="width: 694px">&nbsp;</td>
                                                                    <td>&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="3">
                                                                        <asp:Panel ID="pnlShowGridCompanyLicence" runat="server">
                                                                            <table>
                                                                                <tr>
                                                                                    <td colspan="2">
                                                                                        <asp:Label ID="lblMessageCompanyLicence" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 225px">&nbsp;</td>
                                                                                    <td style="text-align: center">
                                                                                        <asp:GridView ID="grdCompanyLicence" runat="server" AllowPaging="True" AutoGenerateColumns="False" OnPageIndexChanging="grdCompanyLicence_PageIndexChanging" OnRowCancelingEdit="grdCompanyLicence_RowCancelingEdit" OnRowDataBound="grdCompanyLicence_RowDataBound" OnRowDeleting="grdCompanyLicence_RowDeleting" OnRowEditing="grdCompanyLicence_RowEditing" OnRowUpdating="grdCompanyLicence_RowUpdating" PageSize="5" Width="430px">
                                                                                            <Columns>
                                                                                                <asp:BoundField DataField="CompanyID" HeaderText="Company ID">
                                                                                                <ItemStyle BorderColor="#DDDDDD" HorizontalAlign="Left" Width="50px" />
                                                                                                </asp:BoundField>
                                                                                                <asp:BoundField DataField="BranchID" HeaderText="Branch ID">
                                                                                                <ItemStyle BorderColor="#DDDDDD" HorizontalAlign="Left" Width="50px" />
                                                                                                </asp:BoundField>
                                                                                                <asp:BoundField DataField="LicenceID" HeaderText="Licence ID">
                                                                                                <ItemStyle BorderColor="#DDDDDD" HorizontalAlign="Left" Width="50px" />
                                                                                                </asp:BoundField>
                                                                                                <asp:TemplateField HeaderText="Licence Name" ItemStyle-Width="120px">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:DropDownList ID="ddlLicenceName" runat="server" BackColor="White" CssClass="cssDropdownList" Height="27px" Width="150px">
                                                                                                        </asp:DropDownList>
                                                                                                    </ItemTemplate>
                                                                                                    <ItemStyle BorderColor="#DDDDDD" HorizontalAlign="Left" />
                                                                                                    <ControlStyle BackColor="White" BorderStyle="None" Width="120px" />
                                                                                                </asp:TemplateField>
                                                                                                <asp:BoundField DataField="LicenceValue" HeaderText="Licence Value">
                                                                                                <ItemStyle BorderColor="#DDDDDD" HorizontalAlign="Left" Width="180px" />
                                                                                                <ControlStyle CssClass="TextBox" Width="180px" />
                                                                                                </asp:BoundField>
                                                                                                <asp:BoundField DataField="ID" HeaderText="ID">
                                                                                                <ItemStyle BorderColor="#DDDDDD" HorizontalAlign="Left" Width="40px" />
                                                                                                </asp:BoundField>
                                                                                                <asp:CommandField ButtonType="Image" CancelImageUrl="~/App_Themes/CSSstyleTheme/Images/Cancel__Green.png" CancelText="" DeleteImageUrl="~/App_Themes/CSSstyleTheme/Images/Remove.png" DeleteText="" EditImageUrl="~/App_Themes/CSSstyleTheme/Images/pencil.png" EditText="" ShowDeleteButton="True" ShowEditButton="True" UpdateImageUrl="~/App_Themes/CSSstyleTheme/Images/Update.png" UpdateText="">
                                                                                                <ControlStyle BorderColor="#DDDDDD" />
                                                                                                <ItemStyle BorderColor="#DDDDDD" Width="50px" />
                                                                                                </asp:CommandField>
                                                                                            </Columns>
                                                                                            <HeaderStyle CssClass="GridviewScrollHeader" />
                                                                                            <PagerStyle BorderColor="#DDDDDD" CssClass="GridviewScrollPager" />
                                                                                            <RowStyle CssClass="GridviewScrollItem" />
                                                                                        </asp:GridView>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 225px">&nbsp;</td>
                                                                                    <td>&nbsp;</td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 225px">&nbsp;</td>
                                                                                    <td>&nbsp;</td>
                                                                                </tr>
                                                                            </table>
                                                                        </asp:Panel>
                                                                        <div style="text-align: center">
                                                                            <asp:LinkButton ID="lnkExpand" runat="server" OnClick="lnkExpand_Click">Add Company Licence</asp:LinkButton>
                                                                            <cc1:CollapsiblePanelExtender ID="cpe" runat="Server" autocollapse="False" autoexpand="False" collapsecontrolid="btnCloseCompanyLicence" collapsed="True" collapsedsize="0" expandcontrolid="lnkExpand" expanddirection="Vertical" targetcontrolid="pnlEditCompanyLicence" />
                                                                        </div>
                                                                        <div>
                                                                            <asp:Panel ID="pnlEditCompanyLicence" runat="server">
                                                                                <table>
                                                                                    <tr>
                                                                                        <td style="width: 238px">&nbsp;</td>
                                                                                        <td style="width: 18px">&nbsp;</td>
                                                                                        <td style="width: 582px"></td>
                                                                                        <td style="width: 104px"></td>
                                                                                        <td></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 238px; text-align: right;">&nbsp;</td>
                                                                                        <td style="width: 18px; text-align: right;">&nbsp;</td>
                                                                                        <td style="width: 582px; text-align: right;">
                                                                                            <asp:Label ID="Label83" runat="server" Text="Licence Name"></asp:Label>
                                                                                            &nbsp;</td>
                                                                                        <td style="width: 104px">
                                                                                            <asp:DropDownList ID="ddlLicenceNameEnter" runat="server" CssClass="cssDropdownList" Width="305px">
                                                                                            </asp:DropDownList>
                                                                                        </td>
                                                                                        <td>&nbsp;</td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <div style="height: 2px">
                                                                                            </div>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 238px; text-align: right">&nbsp;</td>
                                                                                        <td style="width: 18px; text-align: right">&nbsp;</td>
                                                                                        <td style="width: 582px; text-align: right">
                                                                                            <asp:Label ID="Label84" runat="server" Text="Value"></asp:Label>
                                                                                            &nbsp;</td>
                                                                                        <td style="width: 104px">
                                                                                            <asp:TextBox ID="txtLicenceValueEnter" runat="server" CssClass="cssTextBox" Width="300px"></asp:TextBox>
                                                                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" filtertype="Numbers,Custom" targetcontrolid="txtLicenceValueEnter" validchars="." />
                                                                                        </td>
                                                                                        <td></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 238px">&nbsp;</td>
                                                                                        <td style="width: 18px">&nbsp;</td>
                                                                                        <td style="width: 582px">&nbsp;</td>
                                                                                        <td>
                                                                                            <asp:Button ID="btnCloseCompanyLicence" runat="server" CssClass="CssBtnCancel" OnClick="btnCloseCompanyLicence_Click" Text="Close" />
                                                                                            <asp:Button ID="btnSaveCompanyLicence" runat="server" CssClass="CssBtnCancel" Text="Save" />
                                                                                        </td>
                                                                                        <td>&nbsp;</td>
                                                                                    </tr>
                                                                                </table>
                                                                            </asp:Panel>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            &nbsp;
                                                        </asp:Panel>
                                                    </td>
                                                    <td style="width: 8px">&nbsp;</td>
                                                    <td style="vertical-align: top; background-color: white"></td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="btnCompanySetupCancel" runat="server" CssClass="CssBtnCancel" OnClick="btnCompanySetupCancel_Click" Text="Cancel" />
                                        <asp:Button ID="btnCompanySetupSave" runat="server" CssClass="CssBtnSave" OnClick="btnCompanySetupSave_Click" Text="Save" ValidationGroup="NewProvider" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>

                <tr>
                    <td>&nbsp;</td>
                </tr>

                <tr>
                    <td>
                        <asp:Panel ID="pnlCompanySetupGrid" runat="server" BackColor="White">
                            <table style="width: 100%">
                                <tr>
                                    <td style="width: 30px"></td>
                                    <td style="width: 1043px">&nbsp;</td>
                                    <td style="width: 1043px">&nbsp;</td>
                                    <td style="width: 1043px">&nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="width: 40px">&nbsp;</td>
                                    <td style="width: 1043px">&nbsp;</td>
                                    <td style="width: 1043px">
                                        <asp:Label ID="lblCompanyMessage" runat="server" CssClass="label-default" Font-Bold="True" Font-Size="Large" ForeColor="DarkGray"></asp:Label>
                                    </td>
                                    <td style="width: 1043px">&nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="width: 40px">&nbsp;</td>
                                    <td style="width: 1043px">&nbsp;</td>
                                    <td style="width: 1043px">
                                        <asp:Panel ID="pnlGridCompanySetup" runat="server">
                                            <table style="width: 100%">
                                                <tr>
                                                    <td>
                                                        <asp:GridView ID="GridCompanySetup" runat="server" AllowPaging="True" AutoGenerateColumns="False" OnPageIndexChanging="GridCompanySetup_PageIndexChanging" OnRowDataBound="GridCompanySetup_RowDataBound" OnSelectedIndexChanged="GridCompanySetup_SelectedIndexChanged" PageSize="5" Width="1000px">
                                                            <Columns>
                                                                <asp:BoundField DataField="CompanyID" HeaderText="Company Id">
                                                                <ItemStyle BorderColor="#DDDDDD" HorizontalAlign="Left" Width="50px" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="CompanyName" HeaderText="Company Name">
                                                                <ItemStyle BorderColor="#DDDDDD" HorizontalAlign="Left" Width="40px" />
                                                                <ControlStyle CssClass="TextBox" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="CompanyAddress" HeaderText="Company Address">
                                                                <ItemStyle BorderColor="#DDDDDD" HorizontalAlign="Left" Width="40px" />
                                                                <ControlStyle CssClass="TextBox" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="CompanyPhones" HeaderText="Company Phones">
                                                                <ItemStyle BorderColor="#DDDDDD" HorizontalAlign="Left" Width="40px" />
                                                                <ControlStyle CssClass="TextBox" />
                                                                </asp:BoundField>
                                                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/App_Themes/CSSstyleTheme/Images/accept-icon.png" ShowSelectButton="true">
                                                                <ControlStyle BorderColor="#DDDDDD" />
                                                                <ItemStyle BorderColor="#DDDDDD" Width="30px" />
                                                                </asp:CommandField>
                                                            </Columns>
                                                            <HeaderStyle CssClass="GridviewScrollHeader" />
                                                            <PagerStyle BorderColor="#DDDDDD" CssClass="GridviewScrollPager" />
                                                            <RowStyle CssClass="GridviewScrollItem" />
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                    <td style="width: 1043px">&nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="width: 40px">&nbsp;</td>
                                    <td style="width: 1043px">&nbsp;</td>
                                    <td style="width: 1043px">&nbsp;</td>
                                    <td style="width: 1043px">&nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="width: 40px">
                                        &nbsp;</td>
                                    <td style="width: 1043px">&nbsp;</td>
                                    <td style="width: 1043px">&nbsp;</td>
                                    <td style="width: 1043px">&nbsp;</td>
                                    <td style="width: 30px">&nbsp;</td>
                                </tr>

                            </table>
                        </asp:Panel>
                    </td>
                </tr>




            </table>
        </ContentTemplate>
        <Triggers>
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
