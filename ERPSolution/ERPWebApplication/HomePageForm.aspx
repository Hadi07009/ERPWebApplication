<%@ Page Language="C#" Title="Home Page" AutoEventWireup="true" CodeBehind="HomePageForm.aspx.cs" Inherits="ERPWebApplication.HomePageForm" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<%--<head runat="server">
    <title></title>
</head>--%>
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <title><%: Page.Title %>- ERP Web Application</title>
    <asp:PlaceHolder ID="PlaceHolder1" runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/css" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <meta name="viewport" content="width=device-width" />


    <link href="CSS/CSSstyleTheme/Control/CommandButton.css" rel="stylesheet" />
    <link href="CSS/CSSstyleTheme/CommonCSS/Tree.css" rel="stylesheet" />
    <link href="CSS/GridViewCSS.css" rel="stylesheet" />
    <link href="CSS/StyleSheetGridView.css" rel="stylesheet" />
    <link href="CSS/menuStyle.css" rel="stylesheet" />
    <script type="text/javascript">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                alert("Please Enter Only Numeric Value:");
                return false;
            }
            return true;
        }

    </script>

    <style type="text/css">
        .auto-style1 {
            height: 222px;
        }
        .labelView{
    font-family: Tahoma;
    font-size: 0.9em;
    font-weight: normal;    
    color:#606163;
    text-align: left;
    padding-top:5px;
    padding-bottom:5px;
}
    </style>

</head>
<%--<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>--%>
<body>
    <form id="Form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
            <Scripts>
                <%--Framework Scripts--%>
                <asp:ScriptReference Name="MsAjaxBundle" />
                <asp:ScriptReference Name="jquery" />
                <asp:ScriptReference Name="jquery.ui.combined" />
                <asp:ScriptReference Name="WebForms.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebForms.js" />
                <asp:ScriptReference Name="WebUIValidation.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebUIValidation.js" />
                <asp:ScriptReference Name="MenuStandards.js" Assembly="System.Web" Path="~/Scripts/WebForms/MenuStandards.js" />
                <asp:ScriptReference Name="GridView.js" Assembly="System.Web" Path="~/Scripts/WebForms/GridView.js" />
                <asp:ScriptReference Name="DetailsView.js" Assembly="System.Web" Path="~/Scripts/WebForms/DetailsView.js" />
                <asp:ScriptReference Name="TreeView.js" Assembly="System.Web" Path="~/Scripts/WebForms/TreeView.js" />
                <asp:ScriptReference Name="WebParts.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebParts.js" />
                <asp:ScriptReference Name="Focus.js" Assembly="System.Web" Path="~/Scripts/WebForms/Focus.js" />
                <asp:ScriptReference Name="WebFormsBundle" />
                <%--Site Scripts--%>
            </Scripts>

        </asp:ScriptManager>
        <header>
            <div id="container" style="width: 100%; height: 100px; position: fixed; background-color: #fff; border-top: solid 10px #000">
                <div id="div1">
                    <div style="float: left">
                        <%--<asp:Image ID="Image1" runat="server" ImageUrl="~/Images/logo_120_100.png" />--%>
                    </div>
                    <div style="float: left; padding-left: 60px; margin-top: 31px">
                    </div>
                    <div style="float: right; padding-right: 10px">
                        <div class="content-wrapper">
                            <section style="padding-top: 15px" id="login">
                                <asp:LinkButton ID="lnkbtnRegister" runat="server" OnClick="lnkbtnRegister_Click">Register</asp:LinkButton><asp:LinkButton ID="lnkbtnLogin" runat="server" OnClick="lnkbtnLogin_Click">Log in</asp:LinkButton>
                            </section>
                        </div>
                    </div>
                </div>

                <br />
                <br />
                <br />
                <br />

                <div id="div2">
                    <section class="featured">
                        <div class="content-wrapperHeader">
                            <hgroup class="title">
                                <h2 style="font-size: 1.1em;"><%: Page.Title %>.</h2>
                            </hgroup>
                        </div>
                    </section>
                </div>
            </div>

        </header>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
        <div id="body" style="padding-top: 109px; width: 100%">
            <div id="fixedImage" style="position: fixed; background-color: #fff">
                <section style="margin-left: 80px; max-width: 960px">
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/heroAccent.png" />
                </section>

            </div>

            <section class="content-wrapper main-content clear-fix">
                <table style="width: 100%;">
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>
                            <asp:Panel ID="PanelRegister" runat="server">
                                <table style="width: 100%;">
                                    <tr>
                                        <td colspan="3">
                                            <p class="message-info">
                                                Passwords are required to be a minimum of <%: Membership.MinRequiredPasswordLength %> characters in length.
                                            </p>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style1">
                                            <ol style="list-style-type: none">
                                                <li>
                                                    <asp:Label ID="Label1" runat="server" AssociatedControlID="txtUserName">User name</asp:Label>
                                                    <asp:TextBox runat="server" ID="txtUserName" />
                                                </li>
                                                <li>
                                                    <asp:Label ID="Label3" runat="server" AssociatedControlID="txtPassword">Password</asp:Label>
                                                    <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" />
                                                </li>
                                                <li>
                                                    <asp:Label ID="Label4" runat="server" AssociatedControlID="txtConfirmPassword">Confirm password</asp:Label>
                                                    <asp:TextBox runat="server" ID="txtConfirmPassword" TextMode="Password" />
                                                </li>
                                                <li>
                                                    <asp:Label ID="Label2" runat="server" AssociatedControlID="txtSecurityCode">Security Code</asp:Label>
                                                    <asp:TextBox runat="server" ID="txtSecurityCode" />
                                                </li>
                                                <li>
                                                    <asp:Label ID="Label7" runat="server" AssociatedControlID="txtEmail">Email</asp:Label>
                                                    <asp:TextBox runat="server" ID="txtEmail" TextMode="Email" />
                                                </li>
                                            </ol>
                                        </td>
                                        <td class="auto-style1"></td>
                                        <td class="auto-style1"></td>
                                    </tr>
                                    <tr>
                                        <td style="padding-left: 40px">
                                            <asp:Button ID="btnRegister" runat="server" Text="Register" Width="100px" OnClick="btnRegister_Click" /></td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>
                            <asp:Panel ID="PanelLogin" runat="server">
                                <table style="width: 100%;">
                                    <tr>
                                        <td colspan="3">
                                            <h2>Use an account to log in.</h2>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <ol style="list-style-type: none">
                                                <li>
                                                    <asp:Label  ID="Label5" runat="server" AssociatedControlID="txtLoginUserName" CssClass="labelView" >User name</asp:Label>
                                                    <asp:TextBox runat="server" ID="txtLoginUserName" />
                                                </li>
                                                <li>
                                                    <asp:Label ID="Label6" runat="server" AssociatedControlID="txtLoginPassword" CssClass="labelView">Password</asp:Label>
                                                    <asp:TextBox runat="server" ID="txtLoginPassword" TextMode="Password" />
                                                </li>
                                                <li style="padding-left: 170px">
                                                    <asp:LinkButton ID="lnkbtnCompany" runat="server" OnClick="lnkbtnCompany_Click" CssClass="labelView">Show Company</asp:LinkButton>
                                                </li>
                                                <li>
                                                    
                                                </li>
                                                <li >
                                                    <asp:Label ID="lblCompanyText" runat="server" AssociatedControlID="ddlCompany" CssClass="labelView">Company</asp:Label>
                                                    <asp:DropDownList ID="ddlCompany" runat="server"></asp:DropDownList>
                                                </li>
                                            </ol>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style="padding-left: 40px">
                                            <asp:Button ID="btnLogin" runat="server" Text="Log in" Width="100px" OnClick="btnLogin_Click" /></td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </section>
        </div>
        <footer>
            <div class="content-wrapper">
                <div class="float-left">
                    <p>&copy; <%--<li><a id="registerLink" runat="server" href="~/Account/Register.aspx">Register</a></li>--%>- My ASP.NET Application</p>
                </div>
            </div>
        </footer>
                </ContentTemplate>
            </asp:UpdatePanel>
    </form>
</body>
</html>
