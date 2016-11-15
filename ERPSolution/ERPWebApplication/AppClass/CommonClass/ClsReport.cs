using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace ERPWebApplication.CommonClass
{
    public class ClsReport
    {

        public ClsReport()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private string databasename;   
        private int pagezoomfactor;

        private string rptfilename;
        private string rptselectionformulla;
        private ConnectionInfo rptconnectioninfo;
        private ParameterFields rptparametersfields;
        private string formulla;
        private object dt;




        public string Databasename
        {
            get { return databasename; }
            set { databasename = value; }
        }

        public int Pagezoomfactor
        {
            get { return pagezoomfactor; }
            set { pagezoomfactor = value; }
        }

        public String FileName
        {
            get { return rptfilename; }
            set { rptfilename = value; }
        }

        public String SelectionFormulla
        {
            get { return rptselectionformulla; }
            set { rptselectionformulla = value; }
        }

        public String Formulla
        {
            get { return formulla; }
            set { formulla = value; }
        }

        public ConnectionInfo ConnectionInfo
        {
            get { return rptconnectioninfo; }
            set { rptconnectioninfo = value; }
        }

        public ParameterFields ParametersFields
        {
            get { return rptparametersfields; }
            set { rptparametersfields = value; }
        }

        public object Dt
        {
            get { return dt; }
            set { dt = value; }
        }


    }
}