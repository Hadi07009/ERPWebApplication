using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using CrystalDecisions;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using ERPWebApplication.CommonClass;
using System.Configuration;

namespace ERPWebApplication.ModuleName.Inventory.Report.ReportForm
{
    public partial class ReportViewer : System.Web.UI.Page
    {
        readonly string _connectionString = ConfigurationManager.ConnectionStrings["dbERPSolutionConnection"].ToString();
        ReportDocument rpt1 = new ReportDocument();

        protected void Page_Init(object sender, EventArgs e)
        {
            try
            {
                if (current.SessionReport == null) { return; }
                this.Focus();
               ClsReport rep = new ClsReport();
                DataTable dt = new DataTable();

                rep = current.SessionReport;


                rpt1.Load(Server.MapPath(rep.FileName));

                CrystalReportViewer1.ParameterFieldInfo = rep.ParametersFields;
                dt = (DataTable)rep.Dt;
                if (dt != null)
                {
                    rpt1.SetDataSource(dt);
                }

                ConnectionInfo ConnInfo = new ConnectionInfo();
                string SCBLconnStr = _connectionString;

                string[] ff;
                string[] ss;

                ff = SCBLconnStr.Split('=');

                ss = ff[1].Split(';');
                ConnInfo.ServerName = ss[0];

                ss = ff[2].Split(';');
                ConnInfo.DatabaseName = ss[0];
                if (rep.Databasename != null) { ConnInfo.DatabaseName = rep.Databasename; }

                ss = ff[3].Split(';');
                ConnInfo.UserID = ss[0];

                ss = ff[4].Split(';');
                ConnInfo.Password = ss[0];


                // Tables RepTbls = rpt1.Database.Tables;

                foreach (CrystalDecisions.CrystalReports.Engine.Table RepTbl in rpt1.Database.Tables)
                {
                    TableLogOnInfo RepTblLogonInfo = RepTbl.LogOnInfo;
                    RepTblLogonInfo.ConnectionInfo = ConnInfo;
                    RepTbl.ApplyLogOnInfo(RepTblLogonInfo);
                }

                CrystalReportViewer1.ReportSource = rpt1;

                if (rep.SelectionFormulla != null)
                    if (rep.SelectionFormulla != "")
                        CrystalReportViewer1.SelectionFormula = rep.SelectionFormulla;
                if (rep.Pagezoomfactor != null) CrystalReportViewer1.PageZoomFactor = rep.Pagezoomfactor;
                CrystalReportViewer1.DataBind();




            }
            catch
            { }

        }


        protected void CrystalReportViewer1_Unload(object sender, EventArgs e)
        {
            rpt1.Close();
            rpt1.Dispose();
            GC.Collect();
        }
    }
}