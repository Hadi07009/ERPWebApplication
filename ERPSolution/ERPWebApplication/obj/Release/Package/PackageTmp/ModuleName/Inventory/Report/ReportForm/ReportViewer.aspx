<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportViewer.aspx.cs" Inherits="ERPWebApplication.ModuleName.Inventory.Report.ReportForm.ReportViewer" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" lang="javascript" src ="../../../../crystalreportviewers13/js/crviewer/crv.js">
        </script>
</head>
<a href="ReportViewer.aspx">ReportViewer.aspx</a>


<body>
    <form id="form1" runat="server">
    <div>
         <asp:UpdatePanel ID="pnl" runat="server">
    <ContentTemplate>

        <div style="text-align: center">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
           
            
            <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"  HyperlinkTarget="_blank"
                  ReuseParameterValuesOnRefresh="True" ToolPanelView="None" Width="1210px"  PrintMode="ActiveX"  ToolPanelWidth="200px"
                
                />
           
            
        </div>
    </ContentTemplate>
    </asp:UpdatePanel>
    
    </div>
    </form>
</body>
</html>
