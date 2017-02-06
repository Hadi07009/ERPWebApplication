using ERPWebApplication.AppClass.CommonClass;
using ERPWebApplication.CommonClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebApplication.ModuleName.Approval
{
    public partial class frmProcessDetail : System.Web.UI.Page
    {
        string refno = "";
        DataTable dt = new DataTable();
        
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["dbERPSolutionConnection"].ToString();
        
        #region LoadEvents

        protected void Page_Load(object sender, EventArgs e)
        {
            rblProcessType.AutoPostBack = true;
            rblProcessType.SelectedIndexChanged += new EventHandler(rblProcessType_SelectedIndexChanged);
            if (!IsPostBack)
            {
                LoadProcessIdIntoDDL(ddlProcessIdForConfiguration);
                LoadProcessIdIntoDDL(ddlProcessIdForAction);
                LoadProcessIdIntoDDL(ddlProcessIdForLevel);
                LoadProcessIdIntoDDL(ddlProcessId);
                LoadProcessIdIntoDDL(DropDownListProcessId);
                LoadDepartmentIntoDropdown(DropDownListdept);

                LoadProcessLevelId();
                LoadProcessFlowId();
                LoadDepartmentId();
                LoadListBoxForActionTypeId("");
                LoadListBoxForSubAccessPermissionTypeID("");
                LoadProcessDescription();
                LoadProcessFlowDefinition();
                LoadProcessLevelDescription();
                LoadProcessActionType();
                rblProcessType.Items.FindByValue("Y").Selected = true;
                rblProcessType.Items.FindByValue("N").Selected = false;
                PanelForSearchControl.Visible = false;
                txtEmployeeSearch_AutoCompleteExtender.ContextKey = connectionString;
                txtEmployeeSearchProcessView_AutoCompleteExtender.ContextKey = connectionString;

            }
        }

        #endregion

        #region Methods

        public void LoadProcessDescription()
        {
            String queryString = "SELECT ProcessId, ProcessDescription, [Status] FROM dbo.ProcessDescription";
            ClsGridViewLoad.GetData(queryString, grdViewProcessDescription);
        }

        public void LoadProcessFlowDefinition()
        {
            String queryString = "SELECT [ProcessFlowDefinition].[ProcessId],[ProcessDescription].ProcessDescription,[ProcessFlowDefinition].[CategoryId],CASE WHEN [ProcessFlowDefinition].[CategoryId] = '1' THEN 'Staff' WHEN [ProcessFlowDefinition].[CategoryId] = '2' THEN 'Officer' WHEN [ProcessFlowDefinition].[CategoryId] = '5' THEN 'All' ELSE '-' END AS [Category Id Text],[ProcessFlowDefinition].[ProcessFlowId],[ProcessFlowDefinition].[FlowDescription] FROM [dbo].[ProcessFlowDefinition] INNER JOIN [ProcessDescription] ON [ProcessFlowDefinition].[ProcessId] = [ProcessDescription].[ProcessId]";
            ClsGridViewLoad.GetData(queryString, grdViewProcessFlowDefinition);
        }

        public void LoadProcessLevelDescription()
        {
            String queryString = "SELECT[ProcessLevelDescription].[ProcessId],[ProcessDescription].ProcessDescription,[ProcessLevelDescription].[ProcessLevelId],[ProcessLevelDescription].[LevelDescription]FROM [dbo].[ProcessLevelDescription] INNER JOIN [ProcessDescription] ON [ProcessLevelDescription].[ProcessId] = [ProcessDescription].[ProcessId]";
            ClsGridViewLoad.GetData(queryString, grdViewProcessLevelDescription);
        }

        public void LoadProcessActionType()
        {
            String queryString = "SELECT[ProcessActionType].[ProcessId],[ProcessDescription].ProcessDescription,[ProcessActionType].[ActionTypeId],[ProcessActionType].[Action]FROM [dbo].[ProcessActionType] INNER JOIN [ProcessDescription] ON [ProcessActionType].[ProcessId] = [ProcessDescription].[ProcessId]";
            ClsGridViewLoad.GetData(queryString, grdViewProcessActionType);
        }

        private void ShowNoResultFound(DataTable source, GridView gv)
        {
            source.Rows.Add(source.NewRow());
            gv.DataSource = source;
            gv.DataBind();
            int columnsCount = gv.Columns.Count;
            gv.Rows[0].Cells.Clear();
            gv.Rows[0].Cells.Add(new TableCell());
            gv.Rows[0].Cells[0].ColumnSpan = columnsCount;
            gv.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            gv.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
            gv.Rows[0].Cells[0].Font.Bold = true;
            gv.Rows[0].Cells[0].Text = "NO RESULT FOUND!";
            gv.FooterRow.Visible = true;
        }

        public string GetStatus()
        {
            string status = "";
            if (chkActive.Checked == true && chkInactive.Checked == false)
            {
                status = chkActive.Text;
                return status;
            }
            else if (chkInactive.Checked == true && chkActive.Checked == false)
            {
                status = chkInactive.Text;
                return status;
            }
            else if (chkActive.Checked == true && chkInactive.Checked == true)
            {
                status = "Error";
                return status;
            }
            return status;
        }

        private void SaveDataForProcessDescription()
        {
            try
            {
                if (GetStatus() != "Error")
                {
                    DataTable ValuesForUpdate = CheckDuplicateValue.DuplicateCheckForUpdate("ProcessDescription", "ProcessId", "ProcessDescription", txtProcessDescription.Text.ToString() == "" ? "" : txtProcessDescription.Text.ToString());
                    if (btnSave.Text == "Save")
                    {
                        if (ValuesForUpdate.Rows.Count == 0)
                        {
                            SqlConnection myConnection = new SqlConnection(connectionString);
                            myConnection.Open();
                            SqlCommand myCommand = myConnection.CreateCommand();
                            SqlTransaction myTrans;
                            string retValue = "";
                            myTrans = myConnection.BeginTransaction("SaveAllTransaction");
                            myCommand.Connection = myConnection;
                            myCommand.Transaction = myTrans;
                            try
                            {
                                List<ProcessHeader> lstProcessHeader = new List<ProcessHeader>();
                                ProcessHeader objProcessHeader = new ProcessHeader();
                                objProcessHeader.ProcessId = "";
                                objProcessHeader.ProcessDescription = txtProcessDescription.Text.ToString() == "" ? "" : txtProcessDescription.Text.ToString();
                                objProcessHeader.Status = GetStatus();
                                objProcessHeader.Tag = "INSERT";
                                lstProcessHeader.Add(objProcessHeader);
                                Process objProcess = new Process();
                                retValue = objProcess.SaveProcessDescription(lstProcessHeader, myCommand);
                                if (retValue.ToString() == "")
                                {
                                    myTrans.Rollback("SaveAllTransaction");
                                }
                                else
                                {
                                    myTrans.Commit();
                                }
                            }
                            catch (Exception ex)
                            {
                                myTrans.Rollback("SaveAllTransaction");
                            }
                            finally
                            {
                                myConnection.Close();
                            }
                        }
                        else
                        {
                            Response.Write(@"<script language='javascript'>alert('ProcessDescription already exists pleae choose different ProcessDescription')</script>");
                        }
                    }
                    else if (btnSave.Text != "Save")
                    {
                        if (ValuesForUpdate.Rows.Count == 0 || ValuesForUpdate.Rows[0][1].ToString() == txtProcessId.Text.ToString())
                        {
                            SqlConnection myConnection = new SqlConnection(connectionString);
                            myConnection.Open();
                            SqlCommand myCommand = myConnection.CreateCommand();
                            SqlTransaction myTrans;
                            string retValue = "";
                            myTrans = myConnection.BeginTransaction("SaveAllTransaction");
                            myCommand.Connection = myConnection;
                            myCommand.Transaction = myTrans;
                            List<ProcessHeader> lstProcessHeader = new List<ProcessHeader>();
                            ProcessHeader objProcessHeader = new ProcessHeader();
                            objProcessHeader.ProcessId = txtProcessId.Text.ToString() == "" ? "" : txtProcessId.Text.ToString();
                            objProcessHeader.ProcessDescription = txtProcessDescription.Text.ToString() == "" ? "" : txtProcessDescription.Text.ToString();
                            objProcessHeader.Status = GetStatus();
                            objProcessHeader.Tag = "UPDATE";
                            lstProcessHeader.Add(objProcessHeader);
                            Process objProcess = new Process();
                            retValue = objProcess.SaveProcessDescription(lstProcessHeader, myCommand);
                            if (retValue.ToString() == "")
                            {
                                myTrans.Rollback("SaveAllTransaction");
                            }
                            else
                            {
                                myTrans.Commit();
                            }
                            btnSave.Text = "Save";
                        }
                        else
                        {
                            Response.Write(@"<script language='javascript'>alert('ProcessDescription already exists pleae choose different ProcessDescription')</script>");
                        }
                    }
                    LoadProcessIdIntoDDL(ddlProcessIdForConfiguration);
                    LoadProcessIdIntoDDL(ddlProcessIdForAction);
                    LoadProcessIdIntoDDL(ddlProcessIdForLevel);
                    LoadProcessIdIntoDDL(ddlProcessId);
                    txtProcessDescription.Text = string.Empty;
                    chkActive.Checked = false;
                    chkInactive.Checked = false;
                }
                else
                {
                    Response.Write(@"<script language='javascript'>alert('Please select only one Status')</script>");
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void LoadProcessIdIntoDDL(DropDownList DropDownListName)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            string strSql = "SELECT ProcessId, ProcessDescription FROM ProcessDescription";
            SqlDataAdapter adapter = new SqlDataAdapter(strSql, connection);
            adapter.Fill(ds);
            dt = ds.Tables[0];
            DropDownListName.Items.Clear();
            DropDownListName.Items.Add("--please select--");
            foreach (DataRow dr in dt.Rows)
            {
                ListItem lst = new ListItem();
                lst.Value = dr["ProcessId"].ToString();
                lst.Text = dr["ProcessDescription"].ToString();
                DropDownListName.Items.Add(lst);
            }
        }

        public void LoadDepartmentIntoDropdown(DropDownList DropDownListName)
        {
            DataTable dtForPFId = new DataTable();
           // string strSql = "SELECT distinct DeptID, Dept FROM Emp_Details INNER JOIN Hrms_Emp_Mas on Emp_Details.EmpId = Hrms_Emp_Mas .Emp_Mas_Emp_Id and Emp_Mas_Term_Flg = 'N' ORDER BY Dept  ASC";

            string strSql = "select DepartmentID,DepartmentName from oDepartmentSetup where DataUsed ='a' ORDER BY DepartmentName  ASC";
            
            dtForPFId = Process.Run(strSql);
            DropDownListName.Items.Clear();
            DropDownListName.Items.Add("--please select--");
            foreach (DataRow dr in dtForPFId.Rows)
            {
                ListItem lst = new ListItem();
                lst.Value = dr["DepartmentID"].ToString();
                lst.Text = dr["DepartmentName"].ToString();
                DropDownListName.Items.Add(lst);
            }
        }


        private void LoadProcessLevelId()
        {
            DataTable dtForPLId = new DataTable();
            string strSql = "SELECT ProcessLevelId, LevelDescription FROM ProcessLevelDescription";
            dtForPLId = Process.Run(strSql);
            ddlProcessLevelId.Items.Clear();
            ddlProcessLevelId.Items.Add("--please select--");
            foreach (DataRow dr in dtForPLId.Rows)
            {
                ListItem lst = new ListItem();
                lst.Value = dr["ProcessLevelId"].ToString();
                lst.Text = dr["LevelDescription"].ToString();
                ddlProcessLevelId.Items.Add(lst);
            }
        }

        private void LoadProcessFlowId()
        {
            DataTable dtForPFId = new DataTable();
            string strSql = "SELECT ProcessFlowId, FlowDescription FROM ProcessFlowDefinition";
            dtForPFId = Process.Run(strSql);
            ddlProcessFlowId.Items.Clear();
            ddlProcessFlowId.Items.Add("--please select--");
            foreach (DataRow dr in dtForPFId.Rows)
            {
                ListItem lst = new ListItem();
                lst.Value = dr["ProcessFlowId"].ToString();
                lst.Text = dr["FlowDescription"].ToString();
                ddlProcessFlowId.Items.Add(lst);
            }
        }

        private void LoadOfficeLocation(string departmentCode, string sectionCode)
        {
            string storedProcedureCommandTest = "exec [spProcessLoadOfficeLocation] '" + departmentCode + "','" + sectionCode + "'";
            ClsDropDownListController.LoadDropDownListFromStoredProcedure(connectionString, storedProcedureCommandTest, ddlOfficeLocation, "Office", "OfficeID");
            ddlOfficeLocation.Items.RemoveAt(0);
            ddlOfficeLocation.Items.Insert(0, new ListItem("--- All Office Location ---", "-1"));
        }

        private void LoadSectionCode(string departmentCode)
        {
            var sqlQuery = "SELECT DISTINCT Sect_Code,Sect_Name FROM Hrms_Sect_Mas WHERE Sect_Dept_Code='" + departmentCode + "' ORDER BY Sect_Name";
            ClsDropDownListController.LoadDropDownList(connectionString, sqlQuery, ddlSection, "Sect_Name", "Sect_Code");
            ddlSection.Items.RemoveAt(0);
            ddlSection.Items.Insert(0, new ListItem("--- All Section ---", "-1"));
        }

        public void LoadDepartmentId()
        {
            DataTable dtForPFId = new DataTable();
          //  string strSql = "SELECT distinct DeptID, Dept FROM Emp_Details INNER JOIN Hrms_Emp_Mas on Emp_Details.EmpId = Hrms_Emp_Mas .Emp_Mas_Emp_Id and Emp_Mas_Term_Flg = 'N' ORDER BY Dept  ASC";

            string strSql = " select DepartmentID,DepartmentName from oDepartmentSetup where DataUsed ='a' ORDER BY DepartmentName  ASC";


       

            dtForPFId = Process.Run(strSql);
            ddlDepartmentId.Items.Clear();
            ddlDepartmentId.Items.Add("--please select--");
            foreach (DataRow dr in dtForPFId.Rows)
            {
                ListItem lst = new ListItem();
                lst.Value = dr["DepartmentID"].ToString();
                lst.Text = dr["DepartmentName"].ToString();
                ddlDepartmentId.Items.Add(lst);
            }
        }

        public void LoadGridViewAccordingToDeptId(string DeptId)
        {
            string strSql = @"SELECT EmpID, EmpName, Designation,office as Division_Master_Name,Sect FROM  Emp_Details 
                            INNER JOIN hrms_emp_mas on EmpID=Emp_Mas_Emp_Id and Emp_Mas_Term_Flg='N' 
                            WHERE  (DeptID = '" + DeptId + "') order by EmpID ";

            DataTable dtEmployee = Process.Run(strSql);
            GridViewEmployeeDetails.DataSource = null;
            GridViewEmployeeDetails.DataBind();
            PanelForSearchControl.Visible = false;
            ddlOfficeLocation.Items.Clear();

            if (dtEmployee.Rows.Count > 0)
            {
                GridViewEmployeeDetails.DataSource = dtEmployee;
                GridViewEmployeeDetails.DataBind();
                PanelForSearchControl.Visible = true;
                LoadSectionCode(DeptId);
                LoadOfficeLocation(DeptId, ddlSection.SelectedValue);
            }
        }

        public void LoadGridViewAccordingToEmployeeId(string departmentCode, string employeeCode)
        {
            string strSql = @"SELECT EmpID, EmpName, Designation,Office as Division_Master_Name,Sect FROM  Emp_Details 
                        INNER JOIN hrms_emp_mas on EmpID=Emp_Mas_Emp_Id and Emp_Mas_Term_Flg='N' 
                        WHERE  (DeptID = '" + departmentCode + "') and (EmpID = '" + employeeCode + "') order by EmpID ";

            DataTable dtEmployee = Process.Run(strSql);
            GridViewEmployeeDetails.DataSource = null;
            GridViewEmployeeDetails.DataBind();
            PanelForSearchControl.Visible = false;
            ddlOfficeLocation.Items.Clear();

            if (dtEmployee.Rows.Count > 0)
            {
                GridViewEmployeeDetails.DataSource = dtEmployee;
                GridViewEmployeeDetails.DataBind();
                PanelForSearchControl.Visible = true;
                LoadSectionCode(departmentCode);
                LoadOfficeLocation(departmentCode, ddlSection.SelectedValue);
            }
        }

        private void SearchEmployeeByLoce_Sec(string departmentId, string officeLocation, string sectionCode)
        {
            var dtEmployee = new DataTable();
            var myConnection = new SqlConnection(connectionString);
            var myCommand = myConnection.CreateCommand();
            myConnection.Open();
            myCommand.CommandText = "exec [spProcessSearchEmployeeByLoce_Sec]'" + departmentId + "','" + officeLocation + "','" + sectionCode + "'";
            myCommand.ExecuteNonQuery();
            var daEmployee = new SqlDataAdapter(myCommand);
            daEmployee.Fill(dtEmployee);
            GridViewEmployeeDetails.DataSource = null;
            GridViewEmployeeDetails.DataBind();
            if (dtEmployee.Rows.Count > 0)
            {
                GridViewEmployeeDetails.DataSource = dtEmployee;
                GridViewEmployeeDetails.DataBind();
            }
            myConnection.Close();
        }

        public void LoadRefNoIntoGrid(string PId, int PFId, string DeptId)
        {
            string strSql = "SELECT DISTINCT PH.ReferenceNo as Reference,PH.[ProcessName] as Team,PD.ProcessDescription as Process,PF.FlowDescription as [Process Flow],Emp_Details.Dept as Department FROM [ProcessHeaderConfigurationbyDepartment] AS PH INNER JOIN ProcessDescription AS PD ON PH .ProcessId = PD.ProcessId inner join ProcessFlowDefinition	as PF ON PH.ProcessFlowId = PF.ProcessFlowId  INNER JOIN Emp_Details ON PH.DepartmentId =  Emp_Details.DeptID WHERE PH.ProcessId = '" + PId + "' AND PH.ProcessFlowId = " + PFId + " AND PH.DepartmentId = '" + DeptId + "'";
            GridViewRefNO.DataSource = Process.Run(strSql);
            GridViewRefNO.DataBind();
        }

        public void LoadRefNoIntoGrid(string PId, int PFId, string DeptId, string employeeCode)
        {
            string strSql = @"SELECT DISTINCT PH.ReferenceNo as Reference,PH.[ProcessName] as Team,
            PD.ProcessDescription as Process,PF.FlowDescription as [Process Flow],
            Emp_Details.Dept as Department FROM [ProcessHeaderConfigurationbyDepartment] 
            AS PH INNER JOIN ProcessDescription AS PD ON PH.ProcessId = PD.ProcessId 
            inner join ProcessFlowDefinition	as PF ON PH.ProcessId=PF.ProcessId and PH.ProcessFlowId = PF.ProcessFlowId  
            INNER JOIN Emp_Details ON PH.DepartmentId =  Emp_Details.DeptID 
            WHERE PH.ProcessId = '" + PId + "' AND PH.ProcessFlowId = " + PFId + " AND  PH.DepartmentId = '" + DeptId + "' AND PH.ProcessName = '" + employeeCode + "'";
            GridViewRefNO.DataSource = Process.Run(strSql);
            GridViewRefNO.DataBind();
        }

        public void LoadDataIntoGridViewControlLoad(string RefNo)
        {
            ViewState.Clear();

            DataTable dt = new DataTable();

            if ((DataTable)ViewState["vdt"] != null)
            {
                dt = (DataTable)ViewState["vdt"];
            }
            if (dt.Columns.Count == 0)
            {
                dt.Columns.Add("Line", typeof(int));
                dt.Columns.Add("Level Id", typeof(string));
                dt.Columns.Add("Level IdValue", typeof(int));
                dt.Columns.Add("Access Id", typeof(string));
                dt.Columns.Add("Access Permission", typeof(string));
                dt.Columns.Add("Access PermissionValue ", typeof(string));
                dt.Columns.Add("SubAccess Id", typeof(string));
                dt.Columns.Add("SubAccess Permission", typeof(string));
                dt.Columns.Add("SubAccess PermissionValue", typeof(string));
                dt.Columns.Add("SuperUser Id", typeof(string));
                dt.Columns.Add("Monitoring Id", typeof(string));
            }
            string AccessPermission = string.Empty;
            string AccessPermissionValue = string.Empty;
            string SubAccessPermission = string.Empty;
            string SubAccessPermissionValue = string.Empty;
            string FinalAccessPermission = string.Empty;
            string FinalSubAccessPermission = string.Empty;
            DataTable DT = new DataTable();
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.Connection = myConnection;
            List<ProcessHeader> lstProcessHeader = new List<ProcessHeader>();
            ProcessHeader objProcessHeader = new ProcessHeader();
            objProcessHeader.ReferenceNo = RefNo;
            lstProcessHeader.Add(objProcessHeader);
            Process objProcess = new Process();
            DT = objProcess.GetDataFromProcessDetailsConfigurationbyDepartment(lstProcessHeader, myCommand);
            myConnection.Close();
            foreach (DataRow r in DT.Rows)
            {
                string value = (string)r["Access PermissionValue "];
                if (value != "")
                {
                    string[] separator = { "," };
                    string[] words = value.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var word in words)
                    {
                        if (word != "&nbsp;" && word != "&amp;nbsp;")
                        {
                            string SqlString = "SELECT Action FROM ProcessActionType WHERE (ActionTypeId = " + Convert.ToInt32(word) + ")";
                            string ActionType = Process.Run(SqlString).Rows[0][0].ToString();
                            if (ActionType != "")
                            {
                                FinalAccessPermission += ActionType + ",";
                            }
                        }
                    }
                    FinalAccessPermission = FinalAccessPermission.TrimEnd(',');
                }
                string valueSubAccess = (string)r["SubAccess PermissionValue"];
                if (valueSubAccess != "")
                {
                    string[] separator = { "," };
                    string[] wordsSubAccess = valueSubAccess.Split(separator, StringSplitOptions.RemoveEmptyEntries); //&nbsp;
                    foreach (var wordSubAccess in wordsSubAccess)
                    {
                        if (wordSubAccess != "&nbsp;" && wordSubAccess != "&amp;nbsp;")
                        {
                            string SqlString = "SELECT Action FROM ProcessActionType WHERE (ActionTypeId = " + Convert.ToInt32(wordSubAccess) + ")";

                            string SubActionType = Process.Run(SqlString).Rows[0][0].ToString();
                            if (SubActionType != "")
                            {
                                FinalSubAccessPermission += SubActionType + ",";
                            }
                        }
                    }
                    FinalSubAccessPermission = FinalSubAccessPermission.TrimEnd(',');
                }
                dt.Rows.Add
                    (
                    Convert.ToInt32(r["Line"]),
                    (string)r["Level Id"] == "" ? "" : (string)r["Level Id"],
                    Convert.ToInt32(r["Level IdValue"]),
                    (string)r["Access Id"] == "" ? "" : (string)r["Access Id"],
                    FinalAccessPermission == "" ? "" : FinalAccessPermission,
                    (string)r["Access PermissionValue "] == "" ? "" : (string)r["Access PermissionValue "],
                    (string)r["SubAccess Id"] == "" ? "" : (string)r["SubAccess Id"],
                    FinalSubAccessPermission == "" ? "" : FinalSubAccessPermission,
                    (string)r["SubAccess PermissionValue"] == "" ? "" : (string)r["SubAccess PermissionValue"],
                    (string)r["SuperUser Id"] == "" ? "" : (string)r["SuperUser Id"],
                    (string)r["Monitoring Id"] == "" ? "" : (string)r["Monitoring Id"]
                    );
                FinalAccessPermission = string.Empty;
                FinalSubAccessPermission = string.Empty;
            }
            ViewState["vdt"] = dt;
            grdViewForBindControl.DataSource = dt;
            grdViewForBindControl.DataBind();
        }

        public void LoadListBoxForActionTypeId(string Processid)
        {
            string SqlString = "SELECT ActionTypeId, Action FROM ProcessActionType where ProcessId='" + Processid + "'";
            ChkLisBoxAccessPermissionType.DataSource = Process.Run(SqlString);
            ChkLisBoxAccessPermissionType.DataTextField = "Action";
            ChkLisBoxAccessPermissionType.DataValueField = "ActionTypeId";
            ChkLisBoxAccessPermissionType.DataBind();
        }

        public void LoadListBoxForSubAccessPermissionTypeID(string Processid)
        {
            string SqlString = "SELECT ActionTypeId, Action FROM ProcessActionType where ProcessId='" + Processid + "'";
            chklistboxAccessSubPermission.DataSource = Process.Run(SqlString);
            chklistboxAccessSubPermission.DataTextField = "Action";
            chklistboxAccessSubPermission.DataValueField = "ActionTypeId";
            chklistboxAccessSubPermission.DataBind();
        }

        private void SaveDataForProcessLevelDescription()
        {
            DataTable ValuesForUpdate = CheckDuplicateValue.DuplicateCheckForUpdate("LevelDescription", "ProcessLevelId", "ProcessLevelDescription", txtLevelDescription.Text.ToString() == "" ? "" : txtLevelDescription.Text.ToString());
            if (btnSaveLevelDescription.Text == "Save")
            {
                if (ValuesForUpdate.Rows.Count == 0)
                {
                    SqlConnection myConnection = new SqlConnection(connectionString);
                    myConnection.Open();
                    SqlCommand myCommand = myConnection.CreateCommand();
                    SqlTransaction myTrans;
                    string retValue = "";
                    myTrans = myConnection.BeginTransaction("SaveAllTransaction");
                    myCommand.Connection = myConnection;
                    myCommand.Transaction = myTrans;
                    try
                    {
                        List<ProcessHeader> lstProcessHeader = new List<ProcessHeader>();
                        ProcessHeader objProcessHeader = new ProcessHeader();
                        objProcessHeader.ProcessId = ddlProcessIdForLevel.SelectedValue;
                        objProcessHeader.LevelDescription = txtLevelDescription.Text.ToString() == "" ? "" : txtLevelDescription.Text.ToString();
                        objProcessHeader.ProcessLevelId = 1;
                        objProcessHeader.Tag = "INSERT";
                        lstProcessHeader.Add(objProcessHeader);
                        Process objProcess = new Process();
                        retValue = objProcess.SaveProcessLevelDescription(lstProcessHeader, myCommand);
                        if (retValue.ToString() == "")
                        {
                            myTrans.Rollback("SaveAllTransaction");
                        }
                        else
                        {
                            myTrans.Commit();
                        }
                    }
                    catch (Exception ex)
                    {
                        myTrans.Rollback("SaveAllTransaction");
                    }
                    finally
                    {
                        myConnection.Close();
                    }
                }
                else
                {
                    Response.Write(@"<script language='javascript'>alert('Level Description already exists pleae choose different Level Description')</script>");
                }
            }
            else if (btnSaveLevelDescription.Text != "Save")
            {
                if (ValuesForUpdate.Rows.Count == 0 || Convert.ToInt32(ValuesForUpdate.Rows[0][1].ToString()) == Convert.ToInt32(txtProcessLevelId.Text.ToString()))
                {
                    SqlConnection myConnection = new SqlConnection(connectionString);
                    myConnection.Open();
                    SqlCommand myCommand = myConnection.CreateCommand();
                    SqlTransaction myTrans;
                    string retValue = "";
                    myTrans = myConnection.BeginTransaction("SaveAllTransaction");
                    myCommand.Connection = myConnection;
                    myCommand.Transaction = myTrans;
                    try
                    {
                        List<ProcessHeader> lstProcessHeader = new List<ProcessHeader>();
                        ProcessHeader objProcessHeader = new ProcessHeader();
                        objProcessHeader.ProcessId = ddlProcessIdForLevel.SelectedValue;
                        objProcessHeader.LevelDescription = txtLevelDescription.Text.ToString() == "" ? "" : txtLevelDescription.Text.ToString();
                        objProcessHeader.ProcessLevelId = Convert.ToInt32(txtProcessLevelId.Text);
                        objProcessHeader.Tag = "UPDATE";
                        lstProcessHeader.Add(objProcessHeader);
                        Process objProcess = new Process();
                        retValue = objProcess.SaveProcessLevelDescription(lstProcessHeader, myCommand);
                        if (retValue.ToString() == "")
                        {
                            myTrans.Rollback("SaveAllTransaction");
                        }
                        else
                        {
                            myTrans.Commit();
                        }
                    }
                    catch (Exception ex)
                    {
                        myTrans.Rollback("SaveAllTransaction");
                    }
                    finally
                    {
                        myConnection.Close();
                    }
                    btnSaveLevelDescription.Text = "Save";
                }
                else
                {
                    Response.Write(@"<script language='javascript'>alert('Level Description already exists pleae choose different Level Description')</script>");
                }
            }
        }

        private void SaveDataForProcessActionType()
        {
            DataTable ValuesForUpdate = CheckDuplicateValue.DuplicateCheckForUpdateNew("Action", "ActionTypeId", "ProcessId", "ProcessActionType", txtActionType.Text.ToString() == "" ? "" : txtActionType.Text.ToString(), ddlProcessIdForAction.SelectedItem.Value.ToString());
            if (btnSaveProcessActionType.Text == "Save")
            {
                if (ValuesForUpdate.Rows.Count == 0)
                {
                    SqlConnection myConnection = new SqlConnection(connectionString);
                    myConnection.Open();
                    SqlCommand myCommand = myConnection.CreateCommand();
                    SqlTransaction myTrans;
                    string retValue = "";
                    myTrans = myConnection.BeginTransaction("SaveAllTransaction");
                    myCommand.Connection = myConnection;
                    myCommand.Transaction = myTrans;
                    try
                    {
                        List<ProcessHeader> lstProcessHeader = new List<ProcessHeader>();
                        ProcessHeader objProcessHeader = new ProcessHeader();
                        objProcessHeader.ProcessId = ddlProcessIdForAction.SelectedValue;
                        objProcessHeader.Action = txtActionType.Text.ToString() == "" ? "" : txtActionType.Text.ToString();
                        objProcessHeader.ActionTypeId = 1;
                        objProcessHeader.Tag = "INSERT";
                        lstProcessHeader.Add(objProcessHeader);
                        Process objProcess = new Process();
                        retValue = objProcess.SaveProcessActionType(lstProcessHeader, myCommand);
                        if (retValue.ToString() == "")
                        {
                            myTrans.Rollback("SaveAllTransaction");
                        }
                        else
                        {
                            myTrans.Commit();
                        }
                    }
                    catch (Exception ex)
                    {
                        myTrans.Rollback("SaveAllTransaction");
                    }
                    finally
                    {
                        myConnection.Close();
                    }
                }
                else
                {
                    Response.Write(@"<script language='javascript'>alert('Action Type already exists pleae choose different Action Type')</script>");
                }
            }
            else if (btnSaveProcessActionType.Text != "Save")
            {
                if (ValuesForUpdate.Rows.Count == 0 || Convert.ToInt32(ValuesForUpdate.Rows[0][1].ToString()) == Convert.ToInt32(txtActionTypeId.Text.ToString()))
                {
                    SqlConnection myConnection = new SqlConnection(connectionString);
                    myConnection.Open();
                    SqlCommand myCommand = myConnection.CreateCommand();
                    SqlTransaction myTrans;
                    string retValue = "";
                    myTrans = myConnection.BeginTransaction("SaveAllTransaction");
                    myCommand.Connection = myConnection;
                    myCommand.Transaction = myTrans;
                    try
                    {
                        List<ProcessHeader> lstProcessHeader = new List<ProcessHeader>();
                        ProcessHeader objProcessHeader = new ProcessHeader();
                        objProcessHeader.ProcessId = ddlProcessIdForAction.SelectedValue;
                        objProcessHeader.Action = txtActionType.Text.ToString() == "" ? "" : txtActionType.Text.ToString();
                        objProcessHeader.ActionTypeId = Convert.ToInt32(txtActionTypeId.Text);
                        objProcessHeader.Tag = "UPDATE";
                        lstProcessHeader.Add(objProcessHeader);
                        Process objProcess = new Process();
                        retValue = objProcess.SaveProcessActionType(lstProcessHeader, myCommand);
                        if (retValue.ToString() == "")
                        {
                            myTrans.Rollback("SaveAllTransaction");
                        }
                        else
                        {
                            myTrans.Commit();
                        }
                    }
                    catch (Exception ex)
                    {
                        myTrans.Rollback("SaveAllTransaction");
                    }
                    finally
                    {
                        myConnection.Close();
                    }
                    btnSaveProcessActionType.Text = "Save";
                }
                else
                {
                    Response.Write(@"<script language='javascript'>alert('Action Type already exists pleae choose different Action Type')</script>");
                }
            }
        }

        private void SaveDataForProcessFlowConfigurationbyDepartmentEmployee1(string flag, string refno)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    string ProcessId = ddlProcessIdForConfiguration.SelectedValue;
                    int ProcessFlowId = Convert.ToInt32(ddlProcessFlowId.SelectedValue);
                    string DepartmentId = ddlDepartmentId.SelectedValue;
                    string ReferenceNo;
                    if (flag.ToString() == "N")
                    {
                        ReferenceNo = Session["RefNumber"].ToString();
                    }
                    else
                    {
                        SqlConnection myConnection = new SqlConnection(connectionString);
                        myConnection.Open();
                        SqlCommand myCommand = myConnection.CreateCommand();
                        myCommand.Connection = myConnection;
                        Process objProcess = new Process();
                        ReferenceNo = objProcess.GetReferenceNoFromProcessHeaderConfigurationbyDepartment(myCommand).ToString();
                        myConnection.Close();
                    }
                    if (grdViewForBindControl.Rows.Count > 0)
                    {
                        SqlConnection myConnection = new SqlConnection(connectionString);
                        myConnection.Open();
                        SqlCommand myCommand = myConnection.CreateCommand();
                        SqlTransaction myTrans;
                        string retValue = "";
                        myTrans = myConnection.BeginTransaction("SaveAllTransaction");
                        myCommand.Connection = myConnection;
                        myCommand.Transaction = myTrans;
                        try
                        {
                            List<ProcessHeader> lstProcessHeader = new List<ProcessHeader>();
                            ProcessHeader objProcessHeader = new ProcessHeader();

                            objProcessHeader.ReferenceNo = ReferenceNo;
                            objProcessHeader.ProcessName = txtProcessName.Text;
                            objProcessHeader.ProcessId = ProcessId;
                            objProcessHeader.ProcessFlowId = ProcessFlowId;
                            objProcessHeader.DepartmentId = DepartmentId;
                            lstProcessHeader.Add(objProcessHeader);
                            Process objProcess = new Process();
                            retValue = objProcess.SaveProcessHeaderConfigurationbyDepartment(lstProcessHeader, myCommand, flag);
                            if (retValue.ToString() == "")
                            {
                                myTrans.Rollback("SaveAllTransaction");
                            }
                            else
                            {
                                myTrans.Commit();
                            }
                        }
                        catch (Exception ex)
                        {
                            myTrans.Rollback("SaveAllTransaction");
                        }
                        finally
                        {
                            myConnection.Close();
                        }
                    }
                    foreach (GridViewRow gdr in grdViewForBindControl.Rows)
                    {
                        int ProcessLevelid = Convert.ToInt32(gdr.Cells[2].Text.ToString());
                        string AccessId = gdr.Cells[3].Text.ToString() == "&nbsp;" ? "" : gdr.Cells[3].Text.ToString();
                        string AccessPermissionTypeID = gdr.Cells[5].Text.ToString() == "&nbsp;" ? "" : gdr.Cells[5].Text.ToString();
                        string SubAccessId = gdr.Cells[6].Text.ToString() == "&nbsp;" ? "" : gdr.Cells[6].Text.ToString();
                        string SubAccessPermissionTypeID = gdr.Cells[8].Text.ToString() == "&nbsp;" ? "" : gdr.Cells[8].Text.ToString();
                        string SuperUserID = gdr.Cells[9].Text.ToString() == "&nbsp;" ? "" : gdr.Cells[9].Text.ToString();
                        string MonitoringId = gdr.Cells[10].Text.ToString() == "&nbsp;" ? "" : gdr.Cells[10].Text.ToString();

                        SqlConnection myConnection = new SqlConnection(connectionString);
                        myConnection.Open();
                        SqlCommand myCommand = myConnection.CreateCommand();
                        SqlTransaction myTrans;
                        string retValue = "";
                        myTrans = myConnection.BeginTransaction("SaveAllTransaction");
                        myCommand.Connection = myConnection;
                        myCommand.Transaction = myTrans;
                        try
                        {
                            List<ProcessHeader> lstProcessHeader = new List<ProcessHeader>();
                            ProcessHeader objProcessHeader = new ProcessHeader();
                            objProcessHeader.ReferenceNo = ReferenceNo;
                            objProcessHeader.ProcessLevelId = ProcessLevelid;
                            objProcessHeader.AccessId = AccessId;
                            objProcessHeader.SubAccessId = SubAccessId;
                            objProcessHeader.AccessPermissionTypeID = AccessPermissionTypeID;
                            objProcessHeader.SubAccessPermissionTypeID = SubAccessPermissionTypeID;
                            objProcessHeader.SuperUserID = SuperUserID;
                            objProcessHeader.MonitoringId = MonitoringId;
                            lstProcessHeader.Add(objProcessHeader);
                            Process objProcess = new Process();
                            retValue = objProcess.SaveProcessDetailsConfigurationbyDepartment(lstProcessHeader, myCommand);
                            if (retValue.ToString() == "")
                            {
                                myTrans.Rollback("SaveAllTransaction");
                            }
                            else
                            {
                                myTrans.Commit();
                            }
                        }
                        catch (Exception ex)
                        {
                            myTrans.Rollback("SaveAllTransaction");
                        }
                        finally
                        {
                            myConnection.Close();
                        }
                        foreach (GridViewRow grdForApplicationId in GridViewEmployeeDetails.Rows)
                        {
                            string ApplicantID = grdForApplicationId.Cells[0].Text.ToString() == "" ? "" : grdForApplicationId.Cells[0].Text.ToString();
                            CheckBox chk = (CheckBox)grdForApplicationId.Cells[3].FindControl("chkchild");
                            if (chk.Checked)
                            {
                                myConnection.Open();
                                myTrans = myConnection.BeginTransaction("SaveAllTransaction");
                                myCommand.Connection = myConnection;
                                myCommand.Transaction = myTrans;
                                try
                                {
                                    List<ProcessHeader> lstProcessHeader = new List<ProcessHeader>();
                                    ProcessHeader objProcessHeader = new ProcessHeader();
                                    objProcessHeader.ReferenceNo = ReferenceNo;
                                    objProcessHeader.ApplicantID = ApplicantID;
                                    objProcessHeader.ProcessLevelId = ProcessLevelid;
                                    objProcessHeader.AccessId = AccessId;
                                    objProcessHeader.SubAccessId = SubAccessId;
                                    objProcessHeader.AccessPermissionTypeID = AccessPermissionTypeID;
                                    objProcessHeader.SubAccessPermissionTypeID = SubAccessPermissionTypeID;
                                    objProcessHeader.SuperUserID = SuperUserID;
                                    objProcessHeader.MonitoringId = MonitoringId;
                                    lstProcessHeader.Add(objProcessHeader);
                                    Process objProcess = new Process();
                                    retValue = objProcess.SaveProcessFlowConfigurationbyEmployee(lstProcessHeader, myCommand);
                                    if (retValue.ToString() == "")
                                    {
                                        myTrans.Rollback("SaveAllTransaction");
                                    }
                                    else
                                    {
                                        myTrans.Commit();
                                    }
                                }
                                catch (Exception ex)
                                {
                                    myTrans.Rollback("SaveAllTransaction");
                                }
                                finally
                                {
                                    myConnection.Close();
                                }
                            }
                        }
                    }
                    tran.Commit();

                }
                catch (Exception)
                {
                    tran.Rollback();
                }
                finally
                {
                    conn.Close();

                }
            }
        }

        private void SaveDataForProcessFlowConfigurationbyDepartmentEmployee(string flag, string refno)
        {
            bool comit = true;
            string retValue = "";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            SqlCommand myCommand = myConnection.CreateCommand();
            SqlTransaction myTrans;
            myTrans = myConnection.BeginTransaction("SaveAllTransaction");
            myCommand.Connection = myConnection;
            myCommand.Transaction = myTrans;
            try
            {
                string ProcessId = ddlProcessIdForConfiguration.SelectedValue;
                int ProcessFlowId = Convert.ToInt32(ddlProcessFlowId.SelectedValue);
                string DepartmentId = ddlDepartmentId.SelectedValue;
                string ReferenceNo;
                if (flag.ToString() == "N")
                {
                    ReferenceNo = refno.ToString();
                }
                else
                {
                    Process objProcess = new Process();
                    ReferenceNo = objProcess.GetReferenceNoFromProcessHeaderConfigurationbyDepartment(myCommand).ToString();
                }

                #region Header

                if (grdViewForBindControl.Rows.Count > 0)
                {
                    List<ProcessHeader> lstProcessHeader = new List<ProcessHeader>();
                    ProcessHeader objProcessHeader = new ProcessHeader();
                    objProcessHeader.ReferenceNo = ReferenceNo;
                    objProcessHeader.ProcessId = ProcessId;
                    objProcessHeader.ProcessFlowId = ProcessFlowId;
                    objProcessHeader.DepartmentId = DepartmentId;
                    lstProcessHeader.Add(objProcessHeader);
                    Process objProcess = new Process();
                    retValue = objProcess.SaveProcessHeaderConfigurationbyDepartment(lstProcessHeader, myCommand, flag);
                    if (retValue.ToString() == "")
                    {
                        comit = false;
                    }
                }

                #endregion header

                #region ProcessLevelpermissiongrid

                foreach (GridViewRow gdr in grdViewForBindControl.Rows)
                {
                    #region departmentdetails

                    int ProcessLevelid = Convert.ToInt32(gdr.Cells[2].Text.ToString());
                    string AccessId = gdr.Cells[3].Text.ToString() == "" ? "" : gdr.Cells[3].Text.ToString();
                    string AccessPermissionTypeID = gdr.Cells[5].Text.ToString() == "" ? "" : gdr.Cells[5].Text.ToString();
                    string SubAccessId = gdr.Cells[6].Text.ToString() == "" ? "" : gdr.Cells[6].Text.ToString();
                    string SubAccessPermissionTypeID = gdr.Cells[8].Text.ToString() == "" ? "" : gdr.Cells[8].Text.ToString();
                    string SuperUserID = gdr.Cells[9].Text.ToString() == "" ? "" : gdr.Cells[9].Text.ToString();
                    string MonitoringId = gdr.Cells[10].Text.ToString() == "" ? "" : gdr.Cells[10].Text.ToString();

                    List<ProcessHeader> lstProcessHeaderl = new List<ProcessHeader>();
                    ProcessHeader objProcessHeaderl = new ProcessHeader();
                    objProcessHeaderl.ReferenceNo = ReferenceNo;
                    objProcessHeaderl.ProcessLevelId = ProcessLevelid;
                    objProcessHeaderl.AccessId = AccessId;
                    objProcessHeaderl.SubAccessId = SubAccessId;
                    objProcessHeaderl.AccessPermissionTypeID = AccessPermissionTypeID;
                    objProcessHeaderl.SubAccessPermissionTypeID = SubAccessPermissionTypeID;
                    objProcessHeaderl.SuperUserID = SuperUserID;
                    objProcessHeaderl.MonitoringId = MonitoringId;
                    lstProcessHeaderl.Add(objProcessHeaderl);

                    Process objProcessl = new Process();
                    retValue = objProcessl.SaveProcessDetailsConfigurationbyDepartment(lstProcessHeaderl, myCommand);
                    if (retValue.ToString() == "")
                    {
                        comit = false;
                    }

                    #endregion departmentdetails

                    #region employeedetailstable

                    List<ProcessHeader> lstProcessHeaderemp = new List<ProcessHeader>();
                    foreach (GridViewRow grdForApplicationId in GridViewEmployeeDetails.Rows)
                    {
                        string ApplicantID = grdForApplicationId.Cells[0].Text.ToString() == "" ? "" : grdForApplicationId.Cells[0].Text.ToString();
                        CheckBox chk = (CheckBox)grdForApplicationId.Cells[3].FindControl("chkchild");
                        if (chk.Checked)
                        {
                            ProcessHeader objProcessHeaderemp = new ProcessHeader();
                            objProcessHeaderemp.ReferenceNo = ReferenceNo;
                            objProcessHeaderemp.ApplicantID = ApplicantID;
                            objProcessHeaderemp.ProcessLevelId = ProcessLevelid;
                            objProcessHeaderemp.AccessId = AccessId;
                            objProcessHeaderemp.SubAccessId = SubAccessId;
                            objProcessHeaderemp.AccessPermissionTypeID = AccessPermissionTypeID;
                            objProcessHeaderemp.SubAccessPermissionTypeID = SubAccessPermissionTypeID;
                            objProcessHeaderemp.SuperUserID = SuperUserID;
                            objProcessHeaderemp.MonitoringId = MonitoringId;
                            lstProcessHeaderemp.Add(objProcessHeaderemp);
                        }
                    }
                    Process objProcessemp = new Process();
                    retValue = objProcessemp.SaveProcessFlowConfigurationbyEmployee(lstProcessHeaderemp, myCommand);
                    if (retValue.ToString() == "")
                    {
                        comit = false;
                    }

                    #endregion employeedetailstable
                }

                #endregion ProcessLevelpermissiongrid

                if (comit == true)
                {
                    myTrans.Commit();
                }
                else
                {
                    myTrans.Rollback("SaveAllTransaction");

                }

            }
            catch (Exception ex)
            {
                // myTrans.Rollback("SaveAllTransaction");
            }
            finally
            {
                myConnection.Close();
            }
        }

        private void SaveDataForProcessFlowDefinition()
        {
            DataTable ValuesForUpdate = CheckDuplicateValue.DuplicateCheckForUpdate("FlowDescription", "ProcessFlowId", "ProcessFlowDefinition", txtProcessFlowDescription.Text == "" ? "" : txtProcessFlowDescription.Text);
            if (btnSaveProcessFlowDescription.Text == "Save")
            {
                if (ValuesForUpdate.Rows.Count == 0)
                {
                    SqlConnection myConnection = new SqlConnection(connectionString);
                    myConnection.Open();
                    SqlCommand myCommand = myConnection.CreateCommand();
                    SqlTransaction myTrans;
                    string retValue = "";
                    myTrans = myConnection.BeginTransaction("SaveAllTransaction");
                    myCommand.Connection = myConnection;
                    myCommand.Transaction = myTrans;
                    try
                    {
                        List<ProcessHeader> lstProcessHeader = new List<ProcessHeader>();
                        ProcessHeader objProcessHeader = new ProcessHeader();
                        objProcessHeader.ProcessId = ddlProcessId.SelectedValue;
                        objProcessHeader.CategoryId = Convert.ToInt32(ddlCategoryId.SelectedValue);
                        objProcessHeader.ProcessFlowId = 1;
                        objProcessHeader.FlowDescription = txtProcessFlowDescription.Text == "" ? "" : txtProcessFlowDescription.Text;
                        objProcessHeader.Tag = "INSERT";
                        lstProcessHeader.Add(objProcessHeader);
                        Process objProcess = new Process();
                        retValue = objProcess.SaveProcessFlowDefinition(lstProcessHeader, myCommand);
                        if (retValue.ToString() == "")
                        {
                            myTrans.Rollback("SaveAllTransaction");
                        }
                        else
                        {
                            myTrans.Commit();
                        }
                    }
                    catch (Exception ex)
                    {
                        myTrans.Rollback("SaveAllTransaction");
                    }
                    finally
                    {
                        myConnection.Close();
                    }
                }
                else
                {
                    Response.Write(@"<script language='javascript'>alert('Flow Description already exists pleae choose different Flow Description')</script>");
                }
            }
            else if (btnSaveProcessFlowDescription.Text != "Save")
            {
                if (ValuesForUpdate.Rows.Count == 0 || Convert.ToInt32(ValuesForUpdate.Rows[0][1].ToString()) == Convert.ToInt32(txtProcessFlowId.Text.ToString()))
                {
                    SqlConnection myConnection = new SqlConnection(connectionString);
                    myConnection.Open();
                    SqlCommand myCommand = myConnection.CreateCommand();
                    SqlTransaction myTrans;
                    string retValue = "";
                    myTrans = myConnection.BeginTransaction("SaveAllTransaction");
                    myCommand.Connection = myConnection;
                    myCommand.Transaction = myTrans;
                    try
                    {
                        List<ProcessHeader> lstProcessHeader = new List<ProcessHeader>();
                        ProcessHeader objProcessHeader = new ProcessHeader();
                        objProcessHeader.ProcessId = ddlProcessId.SelectedValue;
                        objProcessHeader.CategoryId = Convert.ToInt32(ddlCategoryId.SelectedValue);
                        objProcessHeader.ProcessFlowId = Convert.ToInt32(txtProcessFlowId.Text);
                        objProcessHeader.FlowDescription = txtProcessFlowDescription.Text == "" ? "" : txtProcessFlowDescription.Text;
                        objProcessHeader.Tag = "UPDATE";
                        lstProcessHeader.Add(objProcessHeader);
                        Process objProcess = new Process();
                        retValue = objProcess.SaveProcessFlowDefinition(lstProcessHeader, myCommand);
                        if (retValue.ToString() == "")
                        {
                            myTrans.Rollback("SaveAllTransaction");
                        }
                        else
                        {
                            myTrans.Commit();
                        }
                    }
                    catch (Exception ex)
                    {
                        myTrans.Rollback("SaveAllTransaction");
                    }
                    finally
                    {
                        myConnection.Close();
                    }
                    btnSaveProcessFlowDescription.Text = "Save";
                }
                else
                {
                    Response.Write(@"<script language='javascript'>alert('Flow Description already exists pleae choose different Flow Description')</script>");
                }
            }
        }

        private int Maxlineno(GridView gdv, int index)
        {
            int maxline = 0;
            if (gdv.Rows.Count == 0)
            {
                maxline = 1;
            }
            else
            {
                maxline = gdv.Rows.Count + 1;
            }
            return maxline;
        }

        private void BindGrid()
        {
            try
            {
                DataTable dt = new DataTable();
                if (btnAdd.Text == "Add")
                {
                    if ((DataTable)ViewState["vdt"] != null)
                    {
                        dt = (DataTable)ViewState["vdt"];
                    }
                    if (dt.Columns.Count == 0)
                    {
                        dt.Columns.Add("Line", typeof(int));
                        dt.Columns.Add("Level Id", typeof(string));
                        dt.Columns.Add("Level IdValue", typeof(int));
                        dt.Columns.Add("Access Id", typeof(string));
                        dt.Columns.Add("Access Permission", typeof(string));
                        dt.Columns.Add("Access PermissionValue ", typeof(string));
                        dt.Columns.Add("SubAccess Id", typeof(string));
                        dt.Columns.Add("SubAccess Permission", typeof(string));
                        dt.Columns.Add("SubAccess PermissionValue", typeof(string));
                        dt.Columns.Add("SuperUser Id", typeof(string));
                        dt.Columns.Add("Monitoring Id", typeof(string));
                    }
                    string AccessPermission = string.Empty;
                    string AccessPermissionValue = string.Empty;
                    string SubAccessPermission = string.Empty;
                    string SubAccessPermissionValue = string.Empty;

                    foreach (ListItem item in this.ChkLisBoxAccessPermissionType.Items)
                    {
                        if (item.Selected)
                        {
                            AccessPermissionValue += item.Value + ",";
                            AccessPermission += item.Text + ",";
                        }
                    }
                    AccessPermissionValue = AccessPermissionValue.TrimEnd(',');
                    AccessPermission = AccessPermission.TrimEnd(',');
                    foreach (ListItem item in this.chklistboxAccessSubPermission.Items)
                    {
                        if (item.Selected)
                        {
                            SubAccessPermissionValue += item.Value + ",";
                            SubAccessPermission += item.Text + ",";
                        }
                    }
                    SubAccessPermissionValue = SubAccessPermissionValue.TrimEnd(',');
                    SubAccessPermission = SubAccessPermission.TrimEnd(',');
                    int Line = Maxlineno(grdViewForBindControl, 0);
                    bool IsExists = false;
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (Convert.ToString(dr["Level IdValue"]).Trim() == ddlProcessLevelId.SelectedValue.Trim())
                        {
                            IsExists = true;
                            break;
                        }
                    }
                    if (!IsExists)
                    {
                        dt.Rows.Add(Line, ddlProcessLevelId.SelectedItem, ddlProcessLevelId.SelectedValue, txtAccessId.Text == "" ? "" : txtAccessId.Text, AccessPermission, AccessPermissionValue, txtSubAccessId0.Text == "" ? "" : txtSubAccessId0.Text, SubAccessPermission, SubAccessPermissionValue, txtSuperUserId1.Text == "" ? "" : txtSuperUserId1.Text, txtMonitoringId1.Text == "" ? "" : txtMonitoringId1.Text);
                        ClearControlsAfterAddLevel();
                    }
                    else
                    {
                        Response.Write(@"<script language='javascript'>alert('ERROR: " + ddlProcessLevelId.SelectedItem + " Already exists in the Table')</script>");
                    }
                    ViewState["vdt"] = dt;
                    grdViewForBindControl.DataSource = dt;
                    grdViewForBindControl.DataBind();
                }
                else if (btnAdd.Text != "Add")
                {
                    dt = (DataTable)ViewState["vdt"];
                    int i = 0;
                    foreach (System.Data.DataColumn col in dt.Columns) col.ReadOnly = false;
                    foreach (DataRow dr in dt.Rows)
                    {
                        string AccessPermission = string.Empty;
                        string AccessPermissionValue = string.Empty;
                        string SubAccessPermission = string.Empty;
                        string SubAccessPermissionValue = string.Empty;
                        foreach (ListItem item in this.ChkLisBoxAccessPermissionType.Items)
                        {
                            if (item.Selected)
                            {
                                AccessPermissionValue += item.Value + ",";
                                AccessPermission += item.Text + ",";
                            }
                        }
                        AccessPermissionValue = AccessPermissionValue.TrimEnd(',');
                        AccessPermission = AccessPermission.TrimEnd(',');
                        foreach (ListItem item in this.chklistboxAccessSubPermission.Items)
                        {
                            if (item.Selected)
                            {
                                SubAccessPermissionValue += item.Value + ",";
                                SubAccessPermission += item.Text + ",";
                            }
                        }
                        SubAccessPermissionValue = SubAccessPermissionValue.TrimEnd(',');
                        SubAccessPermission = SubAccessPermission.TrimEnd(',');
                        if (Convert.ToInt32(Session["index"].ToString()) == i)
                        {
                            dr["Level Id"] = ddlProcessLevelId.SelectedItem;
                            dr["Level IdValue"] = ddlProcessLevelId.SelectedValue;
                            dr["Access Id"] = txtAccessId.Text == "" ? "" : txtAccessId.Text;
                            dr["Access Permission"] = AccessPermission;
                            dr["Access PermissionValue "] = AccessPermissionValue;
                            dr["SubAccess Id"] = txtSubAccessId0.Text == "" ? "" : txtSubAccessId0.Text;
                            dr["SubAccess Permission"] = SubAccessPermission;
                            dr["SubAccess PermissionValue"] = SubAccessPermissionValue;
                            dr["SuperUser Id"] = txtSuperUserId1.Text == "" ? "" : txtSuperUserId1.Text;
                            dr["Monitoring Id"] = txtMonitoringId1.Text == "" ? "" : txtMonitoringId1.Text;
                        }
                        i = i + 1;
                    }
                    int RowCount = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        if ((Convert.ToString(dr["Level IdValue"]).Trim() == ddlProcessLevelId.SelectedValue.Trim()))
                        {
                            RowCount++;
                        }
                    }
                    if (RowCount < 2)
                    {
                        ViewState["vdt"] = dt;
                        grdViewForBindControl.DataSource = dt;
                        grdViewForBindControl.DataBind();
                        rearrangeGridLine(grdViewForBindControl);
                        btnAdd.Text = "Add";
                        ClearControlsAfterAddLevel();
                    }
                    else
                    {
                        Response.Write(@"<script language='javascript'>alert('ERROR: " + ddlProcessLevelId.SelectedItem + " Already exists in the Table')</script>");
                    }

                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ClearControlsAfterAddLevel()
        {
            ddlProcessLevelId.ClearSelection();
            txtAccessId.Text = string.Empty;
            ChkLisBoxAccessPermissionType.ClearSelection();
            txtSubAccessId0.Text = string.Empty;
            chklistboxAccessSubPermission.ClearSelection();
            txtSuperUserId1.Text = string.Empty;
            txtMonitoringId1.Text = string.Empty;
        }

        private void rearrangeGridLine(GridView gdv)
        {
            for (int i = 0; i < gdv.Rows.Count; i++)
            {
                gdv.Rows[i].Cells[0].Text = Convert.ToString(i + 1);
            }
        }

        public void EditRowForConfigurationbyDepartment(int rowNo)
        {
            ddlProcessLevelId.SelectedValue = grdViewForBindControl.Rows[rowNo].Cells[2].Text;
            txtAccessId.Text = (grdViewForBindControl.Rows[rowNo].Cells[3].Text == "&nbsp;" ? "" : grdViewForBindControl.Rows[rowNo].Cells[3].Text);
            txtSubAccessId0.Text = (grdViewForBindControl.Rows[rowNo].Cells[6].Text == "&nbsp;" ? "" : grdViewForBindControl.Rows[rowNo].Cells[6].Text);
            txtSuperUserId1.Text = (grdViewForBindControl.Rows[rowNo].Cells[9].Text == "&nbsp;" ? "" : grdViewForBindControl.Rows[rowNo].Cells[9].Text);
            txtMonitoringId1.Text = (grdViewForBindControl.Rows[rowNo].Cells[10].Text == "&nbsp;" ? "" : grdViewForBindControl.Rows[rowNo].Cells[10].Text);
            string valueOfAccessPermission = (grdViewForBindControl.Rows[rowNo].Cells[5].Text == "&nbsp;" ? "" : grdViewForBindControl.Rows[rowNo].Cells[5].Text);
            string valueOfSubAccessPermission = (grdViewForBindControl.Rows[rowNo].Cells[8].Text == "&nbsp;" ? "" : grdViewForBindControl.Rows[rowNo].Cells[8].Text);
            CheckboxListAssign(ChkLisBoxAccessPermissionType, valueOfAccessPermission);
            CheckboxListAssign(chklistboxAccessSubPermission, valueOfSubAccessPermission);
            btnAdd.Text = "Edit";
        }

        public void CheckboxListAssign(CheckBoxList chkBoxListName, string value)
        {
            if (value != "")
            {
                string[] separators = { ",", ".", "!", "?", ";", ":", " " };
                string[] separator = { "," };
                string[] words = value.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                foreach (var word in words)
                {
                    if (word != "&nbsp;" && word != "&amp;nbsp;")
                    {
                        chkBoxListName.Items.FindByValue(word).Selected = true;
                    }
                }
            }
        }

        protected void GetSelected(object sender, EventArgs e)
        {
            Response.Write("<h3>Selected records</h3>");
            foreach (GridViewRow row in GridViewEmployeeDetails.Rows)
            {
                CheckBox chk = (CheckBox)row.FindControl("chkSelect");
                if (chk.Checked)
                {
                    Response.Write(GridViewEmployeeDetails.DataKeys[row.RowIndex].Value + ",");
                }
            }
        }

        public void GetProcessDescriptionIntoControl(int row)
        {
            try
            {
                txtProcessId.Text = grdViewProcessDescription.Rows[row].Cells[0].Text == "" ? "" : grdViewProcessDescription.Rows[row].Cells[0].Text;
                txtProcessDescription.Text = grdViewProcessDescription.Rows[row].Cells[1].Text == "" ? "" : grdViewProcessDescription.Rows[row].Cells[1].Text;
                string StatusValue = grdViewProcessDescription.Rows[row].Cells[2].Text;
                if (StatusValue != "&nbsp;")
                {
                    if (StatusValue == "Active")
                    {
                        chkActive.Checked = true;
                        chkInactive.Checked = false;
                    }
                    else if (StatusValue == "Inactive")
                    {
                        chkInactive.Checked = true;
                        chkActive.Checked = false;
                    }
                }
                else
                {
                    chkActive.Checked = false;
                    chkInactive.Checked = false;
                }
                btnSave.Text = "Update";
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void GetProcessFlowDefinitionIntoControl(int row)
        {
            try
            {
                ddlProcessId.SelectedValue = grdViewProcessFlowDefinition.Rows[row].Cells[0].Text == "" ? "" : grdViewProcessFlowDefinition.Rows[row].Cells[0].Text;
                ddlCategoryId.SelectedValue = grdViewProcessFlowDefinition.Rows[row].Cells[2].Text == "" ? "" : grdViewProcessFlowDefinition.Rows[row].Cells[2].Text;
                txtProcessFlowId.Text = grdViewProcessFlowDefinition.Rows[row].Cells[4].Text == "" ? "" : grdViewProcessFlowDefinition.Rows[row].Cells[4].Text;
                txtProcessFlowDescription.Text = grdViewProcessFlowDefinition.Rows[row].Cells[5].Text == "" ? "" : grdViewProcessFlowDefinition.Rows[row].Cells[5].Text;
                btnSaveProcessFlowDescription.Text = "Update";
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void GetProcessLevelDescriptionIntoControl(int row)
        {
            try
            {
                ddlProcessIdForLevel.SelectedValue = grdViewProcessLevelDescription.Rows[row].Cells[0].Text == "" ? "" : grdViewProcessLevelDescription.Rows[row].Cells[0].Text;
                txtProcessLevelId.Text = grdViewProcessLevelDescription.Rows[row].Cells[2].Text == "" ? "" : grdViewProcessLevelDescription.Rows[row].Cells[2].Text;
                txtLevelDescription.Text = grdViewProcessLevelDescription.Rows[row].Cells[3].Text == "" ? "" : grdViewProcessLevelDescription.Rows[row].Cells[3].Text;
                btnSaveLevelDescription.Text = "Update";
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void GetProcessActionTypeIntoControl(int row)
        {
            ddlProcessIdForAction.SelectedValue = grdViewProcessActionType.Rows[row].Cells[0].Text == "" ? "" : grdViewProcessActionType.Rows[row].Cells[0].Text;
            txtActionTypeId.Text = grdViewProcessActionType.Rows[row].Cells[2].Text == "" ? "" : grdViewProcessActionType.Rows[row].Cells[2].Text;
            txtActionType.Text = grdViewProcessActionType.Rows[row].Cells[3].Text == "" ? "" : grdViewProcessActionType.Rows[row].Cells[3].Text;
            btnSaveProcessActionType.Text = "Update";
        }

        #endregion

        #region Events

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtProcessDescription.Text != string.Empty)
            {
                SaveDataForProcessDescription();
                LoadProcessDescription();
            }
            else
            {
                Response.Write(@"<script language='javascript'>alert('Please type Process Description')</script>");
            }
        }

        protected void btnSaveLevelDescription_Click(object sender, EventArgs e)
        {
            if (CheckDropDownList.DDLNameEmptyCheck(ddlProcessIdForLevel) == false)
            {
                if (txtLevelDescription.Text != string.Empty)
                {
                    SaveDataForProcessLevelDescription();
                    LoadProcessLevelDescription();
                    LoadProcessLevelId();
                    txtLevelDescription.Text = string.Empty;
                    ddlProcessIdForLevel.ClearSelection();
                }
                else
                {
                    Response.Write("<script>confirm('Please type Level Description')</script>");
                }
            }
            else
            {
                Response.Write("<script>confirm('Please Select Correctly')</script>");
            }
        }

        protected void btnSaveProcessActionType_Click(object sender, EventArgs e)
        {
            if (CheckDropDownList.DDLNameEmptyCheck(ddlProcessIdForAction) == false)
            {
                if (txtActionType.Text != string.Empty)
                {
                    SaveDataForProcessActionType();
                    LoadProcessActionType();
                    LoadListBoxForActionTypeId("");
                    LoadListBoxForSubAccessPermissionTypeID("");
                    txtActionType.Text = string.Empty;
                    ddlProcessIdForAction.ClearSelection();
                }
                else
                {
                    Response.Write("<script>confirm('Please type Action Type')</script>");
                }
            }
            else
                Response.Write("<script>confirm('Please Select Correctly')</script>");
        }

        protected void btnSaveConfigurationbyDepartmentEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckDropDownList.DDLNameEmptyCheck3(ddlProcessIdForConfiguration, ddlProcessFlowId, ddlDepartmentId) == false)
                {
                    if (grdViewForBindControl.Rows.Count != 0)
                    {
                        //int CountSelectedEmployee = 0;

                        //foreach (GridViewRow grdForApplicationId in GridViewEmployeeDetails.Rows)
                        //{
                        //    CheckBox chk = (CheckBox)grdForApplicationId.Cells[3].FindControl("chkchild");
                        //    if (chk.Checked)
                        //    {
                        //        CountSelectedEmployee += CountSelectedEmployee + 1;
                        //    }
                        //}
                        //if (CountSelectedEmployee != 0)
                        //{
                        string flag = rblProcessType.SelectedValue.ToString();

                        SaveDataForProcessFlowConfigurationbyDepartmentEmployee1(flag, refno);

                        grdViewForBindControl.DataSource = "";
                        grdViewForBindControl.DataBind();
                        GridViewEmployeeDetails.DataSource = "";
                        GridViewEmployeeDetails.DataBind();
                        string Pvalue = ddlProcessIdForConfiguration.SelectedValue == "" ? "" : ddlProcessIdForConfiguration.SelectedValue;
                        int PFvalue = Convert.ToInt32(ddlProcessFlowId.SelectedValue);
                        string Deptvalue = ddlDepartmentId.SelectedValue == "" ? "" : ddlDepartmentId.SelectedValue;
                        LoadRefNoIntoGrid(Pvalue, PFvalue, Deptvalue);
                        refno = string.Empty;
                        Session["RefNumber"] = string.Empty;
                        rblProcessType.Items.FindByValue("Y").Selected = true;
                        rblProcessType.Items.FindByValue("N").Selected = false;
                        txtProcessName.Text = string.Empty;
                        txtEmployeeSearch.Text = string.Empty;
                        //}
                        //else
                        //    Response.Write("<script>confirm('Please Select Employee Correctly')</script>");
                    }
                    else
                       

                    clsTopMostMessageBox.Show("Please Configure any process Correctly");

                    
                }
                else
                {
                   

                    clsTopMostMessageBox.Show("Please Select Information Correctly");
                }

                clsTopMostMessageBox.Show("Data Save Successful");
                
            }
            catch (Exception ex)
            {

                clsTopMostMessageBox.Show(ex.Message);
            }

        }

        protected void btnSaveProcessFlowDescription_Click(object sender, EventArgs e)
        {
            if (CheckDropDownList.DDLNameEmptyCheck2(ddlProcessId, ddlCategoryId) == false)
            {
                if (txtProcessFlowDescription.Text != string.Empty)
                {
                    SaveDataForProcessFlowDefinition();
                    LoadProcessFlowDefinition();
                    LoadProcessFlowId();
                    txtProcessFlowDescription.Text = string.Empty;
                    ddlProcessId.ClearSelection();
                    ddlCategoryId.ClearSelection();
                }
                else
                {
                    Response.Write("<script>confirm('Please type Flow Description')</script>");
                }
            }
            else
            {
                Response.Write("<script>confirm('Please Select Correctly')</script>");
            }
        }

        protected void ddlDepartmentId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CheckDropDownList.DDLNameEmptyCheck3(ddlProcessIdForConfiguration, ddlProcessFlowId, ddlDepartmentId) == false)
            {
                ViewState.Clear();

                string Pvalue = ddlProcessIdForConfiguration.SelectedValue == "" ? "" : ddlProcessIdForConfiguration.SelectedValue;
                int PFvalue = Convert.ToInt32(ddlProcessFlowId.SelectedValue);
                string Deptvalue = ddlDepartmentId.SelectedValue == "" ? "" : ddlDepartmentId.SelectedValue;

                LoadGridViewAccordingToDeptId(Deptvalue);   //List of employee 
                //LoadDataIntoGridViewControlLoad("");            // Approval flow           
                LoadRefNoIntoGrid(Pvalue, PFvalue, Deptvalue);  //List of Team                       
                rblProcessType.Items.FindByValue("Y").Selected = true;
                rblProcessType.Items.FindByValue("N").Selected = false;

                grdViewForBindControl.DataSource = null;
                grdViewForBindControl.DataBind();

            }
            else
            {
                GridViewRefNO.DataSource = null;
                GridViewRefNO.DataBind();
                GridViewEmployeeDetails.DataSource = null;
                GridViewEmployeeDetails.DataBind();
                PanelForSearchControl.Visible = false;
                Response.Write("<script>confirm('Please Select Correctly')</script>");
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (CheckDropDownList.DDLNameEmptyCheck(ddlProcessLevelId) == false)
            {
                BindGrid();
            }
            else
                Response.Write("<script>confirm('Please Select Correctly')</script>");
        }

        protected void grdViewForBindControl_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
        }

        protected void grdViewForBindControl_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int con = Convert.ToInt32(e.CommandArgument.ToString());
            if (e.CommandName.Equals("Delete"))
            {
                if ((DataTable)ViewState["vdt"] != null)
                {
                    dt = (DataTable)ViewState["vdt"];
                }
                dt.Rows[con].Delete();
                dt.AcceptChanges();
                ViewState["vdt"] = dt;
                grdViewForBindControl.DataSource = dt;
                grdViewForBindControl.DataBind();
            }
            else if (e.CommandName.Equals("Select"))
            {
                int indx = con;
                if (indx == -1) return;
                Session["index"] = con;
                EditRowForConfigurationbyDepartment(con);
                Session["Line"] = grdViewForBindControl.Rows[con].Cells[0].Text.ToString();
            }
        }

        protected void txtAccessId_TextChanged(object sender, EventArgs e)
        {
            if (txtAccessId.Text != "")
            {
                txtAccessId.Text = txtAccessId.Text.ToString().Split(':')[0].ToString().Trim();
            }
        }

        protected void txtSubAccessId0_TextChanged(object sender, EventArgs e)
        {
            if (txtSubAccessId0.Text != "")
            {
                txtSubAccessId0.Text = txtSubAccessId0.Text.ToString().Split(':')[0].ToString().Trim();
            }
        }

        protected void txtSuperUserId1_TextChanged(object sender, EventArgs e)
        {
            if (txtSuperUserId1.Text != "")
            {
                txtSuperUserId1.Text = txtSuperUserId1.Text.ToString().Split(':')[0].ToString().Trim();
            }
        }

        protected void txtMonitoringId1_TextChanged(object sender, EventArgs e)
        {
            if (txtMonitoringId1.Text != "")
            {
                txtMonitoringId1.Text = txtMonitoringId1.Text.ToString().Split(':')[0].ToString().Trim();
            }
        }

        protected void grdViewForBindControl_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void GridViewEmployeeDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string EmpId = e.Row.Cells[0].Text;
                CheckBox chk = (CheckBox)e.Row.FindControl("chkchild");

                string Pvalue = ddlProcessIdForConfiguration.SelectedValue == "" ? "" : ddlProcessIdForConfiguration.SelectedValue;
                int PFvalue = Convert.ToInt32(ddlProcessFlowId.SelectedValue);
                string Deptvalue = ddlDepartmentId.SelectedValue == "" ? "" : ddlDepartmentId.SelectedValue;
                string refnumber = refno.ToString();

                string SqlStringForCheck = "SELECT COUNT(*) AS Expr1 FROM ProcessFlowConfigurationbyEmployee a inner join ProcessHeaderConfigurationbyDepartment b on a.ReferenceNo=b.ReferenceNo and b.DepartmentId=(select DeptID from Emp_Details where EmpID='" + EmpId + "')"
                + " WHERE ApplicantID ='" + EmpId + "' and b.ProcessId='" + Pvalue + "' and b.ProcessFlowId='" + PFvalue + "'";
                DataTable ApplicantIdCheck = Process.Run(SqlStringForCheck);
                if (Convert.ToInt32(ApplicantIdCheck.Rows[0][0].ToString()) != 0)
                {
                    chk.Enabled = false;
                    chk.BackColor = System.Drawing.Color.White;
                }

                string SqlString = "SELECT COUNT(*) AS Expr1 FROM ProcessFlowConfigurationbyEmployee WHERE (ApplicantID = '" + EmpId + "') AND (ReferenceNo= '" + refnumber + "')";
                DataTable ApplicantId = Process.Run(SqlString);
                if (Convert.ToInt32(ApplicantId.Rows[0][0].ToString()) != 0)
                {
                    chk.Checked = true;
                    chk.Enabled = true;
                }
                if (chk.Enabled == true && chk.Checked == false)
                {
                    chk.BackColor = System.Drawing.Color.Red;
                }
            }
        }


        protected void chkheader_CheckedChanged(object sender, EventArgs e)
        {
        }

        protected void grdViewForBindControl_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void ddlProcessIdForLevel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void txtActionType_TextChanged(object sender, EventArgs e)
        {

        }

        protected void grdViewForBindControl_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
            e.Row.Cells[2].Visible = false;
            e.Row.Cells[5].Visible = false;
            e.Row.Cells[8].Visible = false;
        }

        protected void ddlProcessFlowId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CheckDropDownList.DDLNameEmptyCheck3(ddlProcessIdForConfiguration, ddlProcessFlowId, ddlDepartmentId) == false)
            {
                ViewState.Clear();
                string Pvalue = ddlProcessIdForConfiguration.SelectedValue == "" ? "" : ddlProcessIdForConfiguration.SelectedValue;
                int PFvalue = Convert.ToInt32(ddlProcessFlowId.SelectedValue);
                string Deptvalue = ddlDepartmentId.SelectedValue == "" ? "" : ddlDepartmentId.SelectedValue;
                LoadRefNoIntoGrid(Pvalue, PFvalue, Deptvalue);
                LoadGridViewAccordingToDeptId(Deptvalue);
                LoadDataIntoGridViewControlLoad("");
                rblProcessType.Items.FindByValue("Y").Selected = true;
                rblProcessType.Items.FindByValue("N").Selected = false;
            }
            else
            {
                GridViewRefNO.DataSource = null;
                GridViewRefNO.DataBind();
            }
        }

        protected void ddlProcessIdForConfiguration_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadListBoxForActionTypeId(ddlProcessIdForConfiguration.SelectedValue);
            LoadListBoxForSubAccessPermissionTypeID(ddlProcessIdForConfiguration.SelectedValue);

            if (CheckDropDownList.DDLNameEmptyCheck3(ddlProcessIdForConfiguration, ddlProcessFlowId, ddlDepartmentId) == false)
            {

                ViewState.Clear();

                string Pvalue = ddlProcessIdForConfiguration.SelectedValue == "" ? "" : ddlProcessIdForConfiguration.SelectedValue;
                int PFvalue = Convert.ToInt32(ddlProcessFlowId.SelectedValue);
                string Deptvalue = ddlDepartmentId.SelectedValue == "" ? "" : ddlDepartmentId.SelectedValue;
                LoadRefNoIntoGrid(Pvalue, PFvalue, Deptvalue);
                LoadGridViewAccordingToDeptId(Deptvalue);
                LoadDataIntoGridViewControlLoad("");
                rblProcessType.Items.FindByValue("Y").Selected = true;
                rblProcessType.Items.FindByValue("N").Selected = false;


            }
            else
            {
                GridViewRefNO.DataSource = null;
                GridViewRefNO.DataBind();
            }
        }

        protected void ddlProcessIdForAction_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grdViewProcessDescription_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int con = Convert.ToInt32(e.CommandArgument.ToString());
            if (e.CommandName.Equals("Select"))
            {
                GetProcessDescriptionIntoControl(con);
            }
        }

        protected void grdViewProcessDescription_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void grdViewProcessDescription_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
        }

        protected void grdViewProcessFlowDefinition_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int con = Convert.ToInt32(e.CommandArgument.ToString());
            if (e.CommandName.Equals("Select"))
            {
                GetProcessFlowDefinitionIntoControl(con);
            }
        }

        protected void grdViewProcessFlowDefinition_RowEditing(object sender, GridViewEditEventArgs e)
        {
        }

        protected void grdViewProcessFlowDefinition_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
            e.Row.Cells[2].Visible = false;
            e.Row.Cells[4].Visible = false;
        }

        protected void grdViewProcessLevelDescription_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
            e.Row.Cells[2].Visible = false;
        }

        protected void grdViewProcessLevelDescription_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void grdViewProcessLevelDescription_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int con = Convert.ToInt32(e.CommandArgument.ToString());
            if (e.CommandName.Equals("Select"))
            {
                GetProcessLevelDescriptionIntoControl(con);
            }
        }

        protected void grdViewProcessActionType_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int con = Convert.ToInt32(e.CommandArgument.ToString());
            if (e.CommandName.Equals("Select"))
            {
                GetProcessActionTypeIntoControl(con);
            }
        }
        protected void grdViewProcessActionType_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void grdViewProcessActionType_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
            e.Row.Cells[2].Visible = false;
        }

        protected void rblProcessType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblProcessType.SelectedIndex == 0)
            {
                ViewState.Clear();
                string Deptvalue = ddlDepartmentId.SelectedValue == "" ? "" : ddlDepartmentId.SelectedValue;
                LoadDataIntoGridViewControlLoad("");
                LoadGridViewAccordingToDeptId(Deptvalue);
            }
        }

        protected void ddlOfficeLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblProcessType.SelectedValue == "N")
            {
                refno = Session["RefNumber"].ToString();
            }
            SearchEmployeeByLoce_Sec(ddlDepartmentId.SelectedValue, ddlOfficeLocation.SelectedValue, ddlSection.SelectedValue);
        }

        protected void GridViewEmployeeDetails_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblProcessType.SelectedValue == "N")
            {
                refno = Session["RefNumber"].ToString();
            }

            LoadOfficeLocation(ddlDepartmentId.SelectedValue, ddlSection.SelectedValue);

            SearchEmployeeByLoce_Sec(ddlDepartmentId.SelectedValue, ddlOfficeLocation.SelectedValue, ddlSection.SelectedValue);
        }

        protected void GridViewRefNO_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indx = GridViewRefNO.SelectedIndex;
            refno = GridViewRefNO.Rows[indx].Cells[0].Text.ToString();
            string Deptvalue = ddlDepartmentId.SelectedValue == "" ? "" : ddlDepartmentId.SelectedValue;
            if (indx == -1) return;
            Session["RefNumber"] = refno;
            LoadDataIntoGridViewControlLoad(refno);
            string teamName = GridViewRefNO.Rows[indx].Cells[1].Text.ToString() == "&nbsp;" ? "" : GridViewRefNO.Rows[indx].Cells[1].Text.ToString();
            txtProcessName.Text = teamName;
            LoadGridViewAccordingToDeptId(Deptvalue);
            rblProcessType.Items.FindByValue("Y").Selected = false;
            rblProcessType.Items.FindByValue("N").Selected = true;

        }

        #endregion
        protected void GridViewRefNO_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
        protected void GridViewRefNO_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';this.style.color='blue';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.color='black';";
                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.GridViewRefNO, "Select$" + e.Row.RowIndex);
            }
        }
        protected void GridViewRefNO_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
        protected void txtEmployeeSearch_TextChanged(object sender, EventArgs e)
        {
            if (CheckDropDownList.DDLNameEmptyCheck3(ddlProcessIdForConfiguration, ddlProcessFlowId, ddlDepartmentId) == false)
            {
                ViewState.Clear();
                string Pvalue = ddlProcessIdForConfiguration.SelectedValue == "" ? "" : ddlProcessIdForConfiguration.SelectedValue;
                int PFvalue = Convert.ToInt32(ddlProcessFlowId.SelectedValue);
                string Deptvalue = ddlDepartmentId.SelectedValue == "" ? "" : ddlDepartmentId.SelectedValue;
                string employeeCode = null;
                if (txtEmployeeSearch.Text != string.Empty)
                {
                    txtEmployeeSearch.Text = txtEmployeeSearch.Text.Split(':')[0].Trim() == "" ? "" : txtEmployeeSearch.Text.Split(':')[0].Trim();
                    employeeCode = txtEmployeeSearch.Text;
                    txtProcessName.Text = employeeCode.ToString();

                    string refnosql = @"SELECT DISTINCT PH.ReferenceNo AS PH from ProcessHeaderConfigurationbyDepartment PH
                                INNER JOIN ProcessDescription AS PD ON PH .ProcessId = PD.ProcessId 
                                inner join ProcessFlowDefinition	as PF ON PH.ProcessFlowId = PF.ProcessFlowId  
                                INNER JOIN Emp_Details ON PH.DepartmentId =  Emp_Details.DeptID 
                                WHERE PH.ProcessId = '" + Pvalue + "' AND PH.ProcessFlowId = " + PFvalue + " AND PH.ProcessName = '" + employeeCode + "'";

                    DataTable dtref = new DataTable();
                    dtref = DataProcess.GetData(connectionString, refnosql);
                    if (dtref.Rows.Count > 0)
                    {
                        refno = dtref.Rows[0]["PH"].ToString();
                        rblProcessType.Items.FindByValue("Y").Selected = false;
                        rblProcessType.Items.FindByValue("N").Selected = true;
                    }
                    Session["RefNumber"] = refno;
                    LoadGridViewAccordingToEmployeeId(Deptvalue, employeeCode);
                    LoadRefNoIntoGrid(Pvalue, PFvalue, Deptvalue, employeeCode);
                    LoadDataIntoGridViewControlLoad(refno);

                }
            }
            else
            {
                GridViewRefNO.DataSource = null;
                GridViewRefNO.DataBind();
                GridViewEmployeeDetails.DataSource = null;
                GridViewEmployeeDetails.DataBind();
                PanelForSearchControl.Visible = false;
                Response.Write("<script>confirm('Please Select Correctly')</script>");
            }

        }
        protected void GridViewRefNO_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewRefNO.PageIndex = e.NewPageIndex;
            string Pvalue = ddlProcessIdForConfiguration.SelectedValue == "" ? "" : ddlProcessIdForConfiguration.SelectedValue;
            int PFvalue = Convert.ToInt32(ddlProcessFlowId.SelectedValue);
            string Deptvalue = ddlDepartmentId.SelectedValue == "" ? "" : ddlDepartmentId.SelectedValue;

            LoadRefNoIntoGrid(Pvalue, PFvalue, Deptvalue);  //List of Team          
        }
        protected void btnProcessView_Click(object sender, EventArgs e)
        {
            string Pvalue = DropDownListProcessId.SelectedValue == "" ? "" : DropDownListProcessId.SelectedValue;
            string deptid = DropDownListdept.SelectedValue;
            string empid = txtEmployeeSearchProcessView.Text != "" ? txtEmployeeSearchProcessView.Text.Split(':')[0].ToString() : "";
            DataTable dt = new DataTable();
            dt = DataProcess.GetData(connectionString, Sqlgenerate.SqlGetProcessView(Pvalue, empid, deptid));

            if (dt.Rows.Count > 0)
            {
                GridProcessView.DataSource = dt;
                GridProcessView.DataBind();
            }
            else
            {
                GridProcessView.DataSource = null;
                GridProcessView.DataBind();
            }

        }
    }
}