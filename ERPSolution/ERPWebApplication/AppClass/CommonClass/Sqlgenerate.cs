using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

    public class Sqlgenerate
    {
        public Sqlgenerate() { }       

        public static string SqlGetCompanyByUserandNodeid(string Userid,string Nodeid)
        {
            string sql = "SELECT a.COMP_CODE, a.COMP_NAME, a.COMP_HRM, a.COMP_HO, a.COMP_FO"
                        + " FROM SYM_ADM_CCM a"
                        + " inner join [tblUserCompany] b on a.COMP_CODE=b.CompanyID"
                        + " where [COMP_HRM]='Y'  and b.UserID='" + Userid + "' and NodeID='" + Nodeid + "'";
            return sql;
        }

        #region Login

        public static string SqlGetUserById(string userId, string companyCode)
        {
            return "SELECT UserId, UserName, UserDiaplayName, CompanyCode, UserPassword, UserEmpId, UserDesignation, UserDepartment, UserEmail, UserMob, UserImage, UserCreateDate, UserLastAccessed, UserStatus, UserClass, UserHtml FROM tblUserInfo WHERE (UserId = '" + userId +"') AND (CompanyCode = '"+companyCode+"')";
 
        }

        public static string SqlGetUserByIdPass(string userId, string passWord, string companyCode)
        {
            return "SELECT UserId, UserName, UserDiaplayName, CompanyCode, UserPassword, UserEmpId, UserDesignation, UserDepartment, UserEmail, UserMob, UserImage, UserCreateDate, UserLastAccessed, UserStatus FROM tblUserInfo where UserId= '"+userId+"' and UserPassword='"+passWord+"' and UserStatus=1 and CompanyCode='"+companyCode+"'";
        }

        #endregion Login
        
        #region AdvanceTypeSetup

        public static string SqlGetAdvanceTypeRecord(string companyCode, string advanceCode)
        {
            return "SELECT * FROM HRMS_AdvanceTypeSetup WHERE companyCode = '" + companyCode + "' AND advanceCode = '" + advanceCode+ "'";
        }

        public static string SqlDeleteAdvanceTypeRecord(string companyCode, string advanceCode)
        {
            return "DELETE FROM HRMS_AdvanceTypeSetup WHERE companyCode = '" + companyCode + "' AND advanceCode = '" + advanceCode + "'";
        }

        #endregion AdvanceTypeSetup

        #region HolidaySetup

        public static string SqlGetOfficeLocationIntoDDL()
        {
            return "SELECT DISTINCT Division_Master_Code,Division_Master_Name FROM HRMS_DIVISION_MASTER WHERE T_C1 = '1' ORDER BY Division_Master_Name";
        }

        public static string SqlGetShiftTypeIntoDDL()
        {
            return " select Shift_Mas_Code as [Shift Code],Shift_Mas_Desc as Shift from hrms_shift_mas";
        }

        public static string SqlGetShiftTypeBySection(string officeid,string deptid,string sectid)
        {
            string sql="";
            return sql=@"select Shift_Mas_Code as [Shift Code],Shift_Mas_Desc as Shift from hrms_shift_mas a 
                        inner join Hrms_Shift_Mas_Link b on a.T_C1=b.refno
                        where b.officeid='" + officeid + "' and b.deptid='" + deptid + "' and b.sectid='" + sectid + "' order by T_In";
        }
        public static string SqlGetEmpOfficeInfo(string empid)
        {
            string sql = "";
            return sql = @"select * from emp_details where EmpID='" + empid  + "'";
        }


        public static string SqlDeleteHolidayRecord(string refNo)
        {
            return "DELETE FROM Hrms_HolidaySetup WHERE ReferenceNo = '" + refNo + "'; DELETE FROM Hrms_HolidaySetupEmpWise WHERE ReferenceNo = '" + refNo + "'  ";
        }

        public static string SqlDeleteHolidayRecord(string refNo, string employeeID)
        {
            return "DELETE FROM Hrms_HolidaySetupEmpWise WHERE ReferenceNo = '" + refNo + "' AND EmployeeID = '" + employeeID + "' ";
        }

        public static string SqlCheckHolidayData(string companyCode, string officeLocation, string shiftId, string holidayDate)
        {
            return "select ReferenceNo from Hrms_HolidaySetup WHERE CompanyCode = '" + companyCode + "' AND OfficeLocationCode = '" + officeLocation + "' AND ShiftID = '" + shiftId + "' AND CONVERT(DATE, HolidayDate,103) = CONVERT(DATE, '" + holidayDate + "',103)";
        }

        public static string SqlCheckHolidayData(string referenceNumber)
        {
            return "select * from Hrms_HolidaySetup where ReferenceNo = '" + referenceNumber + "'";

        }

        public static string SqlEmployeeHolidayData(string employeeCode, string holidayDate)
        {
            return "select ReferenceNo from Hrms_HolidaySetupEmpWise where EmployeeID = '" + employeeCode + "' and CONVERT(DATE, HolidayDate ,103) = CONVERT(DATE, '" + holidayDate + "',103)";

        }

        public static string SqlEmployeeHolidayData(string referenceNumber)
        {
            return "select * from Hrms_HolidaySetupEmpWise where ReferenceNo = '" + referenceNumber + "'";

        }

        #endregion HolidaySetup

        #region LeaveTypeSetup

        public static string SqlGetLeaveTypeRecord(string companyCode, string leaveCode,string emptype)
        {
            return "select * from HRMS_Leave_Mas WHERE CompanyCode = '" + companyCode + "' AND Leave_Mas_Code = '" + leaveCode + "' and T_C2='" + emptype + "'";
        }
        
        public static string SqlDeleteLeaveTypeRecord(string companyCode, string leaveCode,string emptype)
        {
            return "DELETE FROM HRMS_Leave_Mas WHERE CompanyCode = '" + companyCode + "' AND Leave_Mas_Code = '" + leaveCode + "' and T_C2='" + emptype + "'";
        }

        #endregion LeaveTypeSetup

        #region JobTypeSetup

        public static string SqlGetJobTypeRecord(string jobTypeTitle, string jobTypeCode)
        {
            return "SELECT DISTINCT JobTypeCode, JobTypeTitle FROM Hrms_Job_Type WHERE (JobTypeTitle  = '" + jobTypeTitle + "')OR (JobTypeCode = '" + jobTypeCode + "')";
        }

        public static string SqlDeleteJobTypeRecord(string jobTypeCode)
        {
            return "DELETE FROM Hrms_Job_Type WHERE JobTypeCode = '" + jobTypeCode + "'";
        }

        #endregion JobTypeSetup

        #region SectionSetup

        public static string SqlGetDepartmentIntoDDL()
        {
            return "SELECT DISTINCT Dept_Code,Dept_Name FROM Hrms_Dept_Master ORDER BY Dept_Name";
        }

        public static string SqlDeleteSection(string companyCode, string officeLocationCode, string departmentCode, string sectionCode, string sectionName)
        {
            return "DELETE FROM Hrms_Sect_Mas WHERE Sect_Comp_Code = '" + companyCode + "' AND Sect_Div_Code = '" + officeLocationCode + "' AND Sect_Dept_Code = '" + departmentCode + "' AND Sect_Code = '" + sectionCode + "' AND Sect_Name = '" + sectionName + "'";
        }
        public static string SqlGetSectionCode(string sectionName)
        {
            return "SELECT Sect_Code FROM Hrms_Sect_Mas WHERE Sect_Name = '" + sectionName + "'";
        }

        #endregion SectionSetup

        #region DesignationSetup

        public static string SqlGetEmployeeTypeIntoDDL()
        {
            return "SELECT DISTINCT EmpTCode, EmpType FROM HRMS_EMP_TYPE where T_C1=1 ORDER BY EmpType";
        }

        public static string SqlGetJobTypeIntoDDL()
        {
            return "SELECT DISTINCT JobTypeCode, JobTypeTitle FROM Hrms_Job_Type ORDER BY JobTypeTitle";
        }

        public static string SqlDeleteDesignation(string designationCode, string designation)
        {
            return "DELETE FROM Hrms_Job_Master WHERE JobCode = '" + designationCode + "' AND JobTitle = '" + designation + "'";
        }

        public static string SqlGetMngLevelIntoDDL()
        {
            return "SELECT DISTINCT [mngLevelCode],[mngLevelTitle]  FROM [HRMS_MngLevel_Setup] ORDER BY [mngLevelTitle]";
        }

        #endregion DesignationSetup

        #region DivisionSetup

        public static string SqlDeleteDivision(string companyCode, string division_Master_Code)
        {
            return "DELETE FROM Hrms_Division_Master WHERE Division_Master_CompCode = '" + companyCode + "' AND Division_Master_Code = '" + division_Master_Code + "'";
        }

        #endregion DivisionSetup

        #region GradeSetup

        public static string SqlSearchGradeValue(string gradeDescription)
        {
            return "select * from hrms_grade_def WHERE	Grade_Def_Desc = '" + gradeDescription + "'";
        }

        public static string SqlSearchGradeValuebyCode(string gradeCode)
        {
            return "select * from hrms_grade_def WHERE	Grade_Def_Code = '" + gradeCode + "'";
        }

        public static string SqlGetGradeDescription()
        {
            return "select Grade_Def_Code,Grade_Def_Desc from hrms_grade_def order by Grade_Def_Desc";
        }

        public static string SqlGetFormulaDescription()
        {
            return "select For_Mas_Cal_Code,For_Mas_Cal_Name from HrMs_For_Mas order by For_Mas_Cal_Name";
        }

        public static string SqlDeleteGradeDescription(string gradeCode)
        {
            return "DELETE from hrms_grade_def WHERE Grade_Def_Code = '" + gradeCode + "'";
        }

        public static string SqlDeleteGradeDescription(string gradeValue, string formulaValue)
        {
            return "DELETE FROM hrms_grade_det WHERE Det_Code = '" + gradeValue + "' AND Det_For = '" + formulaValue + "'";
        }

        #endregion GradeSetup

        #region FormulaSetup

        public static string SqlSearchFormulaRecord(string formulaCode)
        {
            return "select * from HrMs_For_Mas WHERE For_Mas_Cal_Code = '" + formulaCode + "'";
        }

        public static string SqlDeleteFormulaRecord(string formulaCode)
        {
            return "DELETE FROM HrMs_For_Mas WHERE For_Mas_Cal_Code = '" + formulaCode + "'";
        }

        #endregion FormulaSetup

        #region Pay Setup

        public static string SqlGetEmployeeGrade(string employeeCode)
        {
            return "select det_grade from hrms_emp_grd_det where det_empid = '" + employeeCode + "'";
        }

        public static string SqlGetFormula(string employeeCode)
        {
            return "SELECT For_Mas_Cal_Code,For_Mas_Cal_Name FROM HrMs_For_Mas a INNER JOIN hrms_grade_det b ON a.For_Mas_Cal_Code = b.Det_For INNER JOIN hrms_emp_grd_det c ON b.Det_Code = c.det_grade WHERE c.det_empid = '" + employeeCode + "' order by For_Mas_Cal_Code ";
        }        
        public static string SqlGetEmployeeForDet(string employeeCode, string gradeCode)
        {
            return "select DISTINCT a.For_Det_Empid, a.For_Det_ForCode,b.For_Mas_Cal_Name, ROUND(a.For_Det_Value,2) AS For_Det_Value,a.For_Det_ValFlg,a.for_det_sno,c.Det_val2,CASE WHEN (a.formulaStatus = '1')  THEN 'Active'  WHEN (a.formulaStatus = '0')  THEN 'Inactive'  ELSE '' END AS formulaStatus,b.For_Mas_Acc from hrms_emp_for_det a INNER JOIN HrMs_For_Mas b ON a.For_Det_ForCode = b.For_Mas_Cal_Code INNER JOIN hrms_grade_det c ON a.For_Det_ForCode = c.Det_For where For_Det_Empid='" + employeeCode + "' and c.Det_Code='" + gradeCode + "' order by a.for_det_sno";
        }

        public static string SqlInsertPaySetupLogTable(string detEmpId, string detCode, double detValue, string operationType, string userId)
        {
            return "INSERT INTO [HRMS_PAYSETUP_LOG] ([For_Det_Empid],[For_Det_ForCode],[For_Det_Value],[For_Det_EntryUserId],[For_Det_EntryDate],[For_Det_Operation]) VALUES ('" + detEmpId + "','" + detCode + "'," + detValue + ",'" + userId + "','" + DateTime.Now.ToString("dd-MMM-yyyy") + "','" + operationType + "')";
        }

        public static string SqlGetFormula()
        {
            return "SELECT For_Mas_Cal_Code,For_Mas_Cal_Name FROM HrMs_For_Mas a INNER JOIN hrms_grade_det b ON a.For_Mas_Cal_Code = b.Det_For order by For_Mas_Cal_Code ";
        }

        public static string SqlGetFormulaByGrade(string gradeCode)
        {
            return "SELECT For_Mas_Cal_Code,For_Mas_Cal_Name FROM HrMs_For_Mas a INNER JOIN hrms_grade_det b ON a.For_Mas_Cal_Code = b.Det_For WHERE b.Det_Code = '" + gradeCode + "' order by For_Mas_Cal_Code";
        }
        public static string SqlGetFormulaDetailsByFormulaCode(string formulaCode,string GrdaeCode)
        {
            string sql = "";
            return sql="SELECT For_Mas_Cal_Code,For_Mas_Base_Val,For_Mas_Mul FROM HrMs_For_Mas a INNER JOIN hrms_grade_det b ON a.For_Mas_Cal_Code = b.Det_For WHERE b.Det_Code = '" + GrdaeCode + "' and For_Mas_Base_Val='" + formulaCode + "' order by For_Mas_Cal_Code";
        }

        public static string Gettaxbyempid(string empcode)
        {
            string sql = "";
            return sql = "select [dbo].[functionTaxcalculationByempid]('" + empcode + "') as Taxamt";
        }

        #endregion Pay Setup

        #region CompanySetup

        public static string SqlSearchCompanyRecord(string companyName, string companyID)
        {
            return "SELECT DISTINCT CompanyName, CompanyId FROM Hrms_Company_Master WHERE (CompanyName  = '" + companyName + "')OR (CompanyId = '" + companyID + "')";
        }

        public static string SqlDeleteCompanyRecord(string companyID)
        {
            return "DELETE FROM hrms_company_master WHERE CompanyId ='" + companyID + "'";
        }
        public static string SqlGetCompanyLogo(string companyid)
        {
            return "select top 1 CompanyLogo from Hrms_Company_Master ";
        }

        #endregion CompanySetup

        # region Employee Information Setup

        public static string SqlGetDesignationIntoDDL()
        {
            return "SELECT DISTINCT JobCode,JobTitle FROM Hrms_Job_Master WHERE T_C1 = '1' ORDER BY JobTitle";
        }

        public static string SqlGetLeaveTypeIntoDDL()
        {
            return "SELECT DISTINCT Leave_Mas_Code,Leave_Mas_Name FROM HRMS_Leave_Mas ORDER BY Leave_Mas_Name";
        }
        public static string SqlGetLeaveTypeIntoDDLByEmpid(string empcode)
        {
            string sql = "select distinct Leave_mas_code,Leave_mas_Name from hrms_leave_mas a"
                    + " inner join HrMs_Emp_mas b on b.Emp_Mas_Emp_Type=a.T_C2 and b.Emp_Mas_Emp_Id='" + empcode + "'"                   
                    + " where a.T_FL=1 and Leave_Mas_Code not in"
                    + " ("
                    + " select case when Emp_Mas_Gender='M' then 'ML' else ''end from hrms_leave_mas a"
                    + " inner join HrMs_Emp_mas b on b.Emp_Mas_Emp_Type=a.T_C2 and b.Emp_Mas_Emp_Id='" + empcode + "') order by Leave_mas_Name";

            return sql;
        }

        public static string SqlGetBankNameIntoDDL()
        {
            return "SELECT DISTINCT Bnk_info_Bnk_code,Bnk_info_Bnk_Name FROM FA_BNK_INFO ORDER BY Bnk_info_Bnk_Name";
        }

        public static string  SqlGetBranchName(string bankCode)
        {
            return "SELECT DISTINCT Bnk_info_Branch_Code,Bnk_info_Branch_name FROM FA_BNK_INFO WHERE Bnk_info_Bnk_code='" + bankCode + "' ORDER BY Bnk_info_Branch_name";
        }

        public static string SqlGetWorkLocationIntoDDL()
        {
            return "SELECT DISTINCT WorkLocationId,WorkLocationName FROM HRMS_WORK_LOCATION_MASTER ORDER BY WorkLocationName";
        }

        public static string SqlGetDepartmentCodeByOfficeLocation(string officeLocationCode)
        {
            return "SELECT DISTINCT Dept_Code,Dept_Name FROM Hrms_Dept_Master WHERE T_C1='1' AND Dept_Division_Code = '" + officeLocationCode + "' ORDER BY Dept_Name";
        }

        public static string SqlGetSectionIntoDDL(string departmentCode, string officeLocationCode)
        {
            return "SELECT DISTINCT Sect_Code,Sect_Name FROM Hrms_Sect_Mas WHERE T_C1 = '1' AND Sect_Dept_Code='" + departmentCode + "' AND Sect_Div_Code='" + officeLocationCode + "' ORDER BY Sect_Name";
        }       

        public static string SqlGetDivisionIntoDDL()
        {
            return "SELECT DISTINCT DivisionName FROM HRMS_ADDRESS_MASTER ORDER BY DivisionName";
        }

        public static string SqlGetDistrictIntoDDL(string divisionName)
        {
            return "SELECT DISTINCT DistrictName FROM HRMS_ADDRESS_MASTER WHERE DivisionName = '" + divisionName + "'";
        }

        public static string SqlGetReportingPersonIdIntoDDL(string officeLocation, string deptCode, string empCode)
        {
            return "SELECT Trans_Det_Emp_Id FROM Hrms_Trans_Det WHERE Trans_Det_DivID = '" + officeLocation + "' AND Trans_det_DeptID = '" + deptCode + "'except SELECT Trans_Det_Emp_Id FROM Hrms_Trans_Det WHERE Trans_Det_DivID = '" + officeLocation + "' AND Trans_det_DeptID = '" + deptCode + "' AND Trans_Det_Emp_Id = '" + empCode + "' ORDER BY Trans_Det_Emp_Id ";
        }

        public static string SqlGetCompanyIntoDDL()
        {
            return "SELECT DISTINCT CompanyName,CompanyId FROM Hrms_Company_Master ORDER BY CompanyName";
        }

        public static string SqlGetDepartmentCodeByCompany(string companyCode)
        {
            return "SELECT DISTINCT Dept_Name, Dept_Code FROM Hrms_Dept_Master WHERE Dept_Comp_Code = '" + companyCode + "' ORDER BY Dept_Name";
        }

        public static string SqlTrainingIntoDDL()
        {
            return "SELECT DISTINCT [trainingCode],[trainingTitle]  FROM [HRMS_Training_Setup] ORDER BY [trainingTitle]";
        }

        public static string SqlCertificateIntoDDL()
        {
            return "SELECT DISTINCT [certificateCode],[certificateTitle]  FROM [HRMS_Certificate_Type] ORDER BY [certificateTitle]";
        }
        public static string SqlFundTypeIntoDDL()
        {
            return "SELECT DISTINCT [fundCode],[fundTitle]  FROM [HRMS_Fund_Type] ORDER BY [fundTitle]";
        }
        public static string SqlGetWorkLocationIntoDDL(string officeLocation)
        {
            return "SELECT DISTINCT WorkLocationId,WorkLocationName FROM HRMS_WORK_LOCATION_MASTER WHERE OfficeLocationId = '" + officeLocation + "' ORDER BY WorkLocationName";
        }

        #endregion Employee Information Setup

        #region Employee Transfer / Promotion

        public static string SqlGetRecordFromHrms_Trans_Det(string employeeCode, int rowNo)
        {
            return "select * from Hrms_Trans_Det where Trans_Det_Emp_Id = '" + employeeCode + "' AND Trans_Emp_Pos = " + rowNo + "";
        }

        #endregion Employee Transfer / Promotion

        #region AdvanceDetailsEntry

        public static string SqlGetAdvanceTypeIntoDDL()
        {
            return "SELECT DISTINCT advanceCode,advanceName FROM HRMS_AdvanceTypeSetup ORDER BY advanceName";
        }

        public static string SqlGetRecordFromHrMs_Emp_Adv_Det(string referenceNo)
        {
            return "select * from HrMs_Emp_Adv_Det WHERE referenceNo='" + referenceNo + "'";
        }

        #endregion AdvanceDetailsEntry

        #region Manual Leave Entry

        public static string SqlGetEmployeeLeaveRecord(string employeeCode, string leaveStartDate)
        {
            return "select Leave_Det_Emp_Id,Leave_Det_Sta_Date from  HrMs_Emp_Leave_Det WHERE Leave_Det_Emp_Id ='" + employeeCode + "' AND Leave_Det_Sta_Date = '" + leaveStartDate + "'";
        }

        public static string SqlGetLeaveRecord(string employeeCode, DateTime leaveStartDate)
        {
            return "select Leave_Det_Emp_Id,Leave_Det_Sta_Date from  HrMs_Emp_Leave_Det WHERE Leave_Det_Emp_Id ='" + employeeCode + "' AND Leave_Det_Sta_Date = Convert(datetime,'" + leaveStartDate + "',103)";
        }

        public static string SqlDeleteEmployeeLeaveRecord(string employeeCode, string leaveStartDate)
        {
            return "DELETE from  HrMs_Emp_Leave_Det WHERE	Leave_Det_Emp_Id='" + employeeCode + "' AND Leave_Det_Sta_Date = '" + leaveStartDate + "';" + "DELETE from hrms_atnd_det WHERE Atnd_Det_Emp_Id='" + employeeCode + "'AND Atnd_det_date = '" + leaveStartDate + "'";
        }

        #endregion Manual Leave Entry

        #region Manual Attendance Entry

        public static string SqlGetEmployeeAttendanceRecord(string employeeCode, string dateForAttendance)
        {
            return "select * from hrms_atnd_det where Atnd_Det_Emp_Id = '" + employeeCode + "' AND Atnd_det_date = '" + dateForAttendance + "'";
        }

        public static string SqlGetEmployeeAttendanceRecord(string employeeCode, string dateForAttendance, string attendanceFlag)
        {
            return "select * from hrms_atnd_det where Atnd_det_offlg = '" + attendanceFlag + "' AND Atnd_Det_Emp_Id = '" + employeeCode + "' AND Atnd_det_date = '" + dateForAttendance + "'";
        }

        public static string SqlDeleteEmployeeAttendanceRecord(string employeeCode, string dateForAttendance)
        {
            return "DELETE from hrms_atnd_det WHERE Atnd_Det_Emp_Id='" + employeeCode + "'AND Atnd_det_date = '" + dateForAttendance + "'";
        }
        #endregion Manual Attendance Entry


        #region Employee Settlement

        public static string SqlGetSettlementRecord(string employeeCode)
        {
            return "select * from hrms_emp_Settlement WHERE Emp_id = '" + employeeCode + "'";
        }

        #endregion Employee Settlement

        #region Shift Allocation

        public static string SqlGetEmployeeDepartment()
        {
            return "SELECT distinct DeptID, Dept FROM Emp_Details INNER JOIN Hrms_Emp_Mas on Emp_Details.EmpId = Hrms_Emp_Mas .Emp_Mas_Emp_Id and Emp_Mas_Term_Flg = 'N' ORDER BY Dept  ASC";
        }
        public static string SqlGetEmpdetailsByEmployee(string empid)
        {
            return "SELECT * FROM Emp_Details INNER JOIN Hrms_Emp_Mas on Emp_Details.EmpId = Hrms_Emp_Mas .Emp_Mas_Emp_Id and Emp_Mas_Term_Flg = 'N' and EmpId='" + empid + "' ORDER BY Dept  ASC";
        }
        public static string SqlGetDepartmentByEmployee(string empid)
        {
            return "SELECT distinct DeptID, Dept FROM Emp_Details INNER JOIN Hrms_Emp_Mas on Emp_Details.EmpId = Hrms_Emp_Mas .Emp_Mas_Emp_Id and Emp_Mas_Term_Flg = 'N' and EmpId='" + empid + "' ORDER BY Dept  ASC";
        }
        

        public static string SqlGetShiftType()
        {
            return "select Shift_Mas_Code as [Shift Code],Shift_Mas_Desc as Shift,Shift_Mas_From as [From],Shift_Mas_To as [To] from hrms_shift_mas";
        }

        public static string SqlGetEmployeeByDepartment(string departmentCode)
        {
            return "select EmpID,EmpName,Designation from Emp_Details a inner join HrMs_Emp_mas b on a.EmpID=b.Emp_Mas_Emp_Id where DeptID='" + departmentCode + "' and Emp_Mas_Term_Flg='N'";
        }

        public static string SqlGetEmployeeName(string employeeCode)
        {
            return "select EmpName from Emp_Details where EmpID ='" + employeeCode + "'";
        }

        #endregion Shift Allocation

        #region Department Setup

        public static string SqlDeleteDepartment(string companyCode, string officeLocationCode, string departmentCode, string departmetName)
        {
            return "DELETE FROM Hrms_Dept_Master WHERE Dept_Comp_Code = '" + companyCode + "' AND Dept_Division_Code = '" + officeLocationCode + "' AND Dept_Code = '" + departmentCode + "' AND Dept_Name = '" + departmetName + "'";
        }
        public static string SqlGetDepartmentCode(string departmentName)
        {
            return "SELECT Dept_Code FROM Hrms_Dept_Master WHERE Dept_Name = '" + departmentName + "'";
        }

        public static string SqlGetDepartmentName(string departmentCode)
        {
            return "SELECT Dept_Name FROM Hrms_Dept_Master WHERE Dept_Code = '" + departmentCode + "'";
        }

        #endregion Department Setup

        #region Payroll

        public static string SqlGetLastSalaryMonth()
        {
            return "SELECT max(salmonth) FROM hrms_salary where SalGrade<>'50'";
        }

        public static string SqlGetLastBonusMonth()
        {
            return "SELECT max(salmonth) FROM hrms_salary where SalGrad='50'";
        }


        #region PAYROLL CALCULATION (CYCLIC)



        #endregion PAYROLL CALCULATION (CYCLIC)

        #region PayrollHold

        public static string SqlGetPayrollHoldRecord(string employeeCode,string payflag)
        {
            string sql = "";
            return sql = "SELECT * FROM [Hrms_Salary_Hold] WHERE [Empcode] = '" + employeeCode + "' AND [HoldStatus] = 'Y' and payflag='" + payflag + "'";
        }

        public static string SqlGetPayrollHoldRecord(string employeeCode, int autoNumber)
        {
            return "  SELECT * FROM [Hrms_Salary_Hold] WHERE ([Empcode] = '" + employeeCode + "' AND convert(DATE,[Holddate], 103)  = convert(DATE, GETDATE(), 103) AND [HoldStatus] = 'Y') OR Autono = " + autoNumber + "";
        }

        public static string SqlUpdateHoldStatus(int autoNumber)
        {
            return "UPDATE Hrms_Salary_Hold	SET HoldStatus	= ISNULL('N',HoldStatus) WHERE	Autono = " + autoNumber + "";
        }

        #endregion PayrollHold

        #endregion Payroll

        #region Node Permission
        public static string SqlDeleteNodePermission(string companyId, string empId, string nodeId)
        {
            return "DELETE FROM [tbl_adm_list] WHERE adm_id = '" + empId + "' AND adm_det = '" + nodeId + "' AND Comp_Code = '" + companyId + "';" +
                   "DELETE FROM tblUserCompany WHERE UserID = '" + empId + "' AND NodeID = '" + nodeId + "' AND CompanyID = '" + companyId + "';" +
                   "DELETE FROM tblUserCompanyDepartment WHERE UserId = '" + empId + "' AND  NodeID = '" + nodeId + "' AND CompanyID = '" + companyId + "'";
        }
        #endregion Node Permission

        #region Payment Configuration

        public static string SqlGetDepartment()
        {
            return "SELECT DISTINCT Dept_Code, Dept_Name FROM Hrms_Dept_Master a inner join Hrms_Trans_Det b on a.Dept_Code=b.Trans_det_DeptID "
                    + " inner join hrms_emp_las_pos_view c on c.Trans_Det_Emp_Id=b.Trans_Det_Emp_Id and c.MaxPos=b.Trans_Emp_Pos "
                    + " inner join HrMs_Emp_mas d on d.Emp_Mas_Emp_Id=c.Trans_Det_Emp_Id and d.Emp_Mas_Term_Flg<>'Y' "
                    + " ORDER BY Dept_Name ASC";
        }

        public static string SqlGetAllDesignation()
        {           

            return "select distinct JobCode,JobTitle from Hrms_Job_Master a inner join Hrms_Trans_Det b on a.JobCode=b.Trans_Det_JobID "
                    + " inner join hrms_emp_las_pos_view c on c.Trans_Det_Emp_Id=b.Trans_Det_Emp_Id and c.MaxPos=b.Trans_Emp_Pos "
                    + " inner join HrMs_Emp_mas d on d.Emp_Mas_Emp_Id=c.Trans_Det_Emp_Id and d.Emp_Mas_Term_Flg<>'Y' "
                    + " order by JobTitle ";
        }

        public static string GetDatabyDepartmentCode(string departmentCode)
        {
            return "select distinct JobCode,JobTitle from Hrms_Job_Master a inner join Hrms_Trans_Det b on a.JobCode=b.Trans_Det_JobID "
                    + " inner join hrms_emp_las_pos_view c on c.Trans_Det_Emp_Id=b.Trans_Det_Emp_Id and c.MaxPos=b.Trans_Emp_Pos "
                    + " inner join HrMs_Emp_mas d on d.Emp_Mas_Emp_Id=c.Trans_Det_Emp_Id and d.Emp_Mas_Term_Flg<>'Y' "
                    + " where b.Trans_det_DeptID = '" + departmentCode + "'  order by JobTitle ";

        }

        public static string GetDataByConfigureType(string ctype, string value)
        {
            return "SELECT ConfigureType, DepartmentCode, Designationcode, Rate, ActiveDateFrom, ActiveDateTo, EntryUserId, EntryDate, UpdateUserID, UpdateDate "
                   + " FROM Hrms_Additional_Configure WHERE (ConfigureType = '" + ctype + "') AND (DepartmentCode = '" + value + "')";
        }

        public static string DeleteDataByConfigureType(string configureType, string deptcode)
        {
            return "DELETE FROM Hrms_Additional_Configure WHERE (ConfigureType = '" + configureType + "') AND (DepartmentCode = '" + deptcode + "')";
        }

        public static string InsertAdditionalConfigure(string configureType, string deptcode, string desigvalue, decimal p1, DateTime dateTime1, DateTime dateTime2, string p2, DateTime dateTime3, string p3, DateTime dateTime4)
        {
            return "INSERT INTO [Hrms_Additional_Configure] ([ConfigureType], [DepartmentCode], [Designationcode], [Rate], [ActiveDateFrom], [ActiveDateTo], [EntryUserId], [EntryDate], [UpdateUserID], [UpdateDate]) "
                   + " VALUES ('" + configureType + "','" + deptcode + "' ,'" + desigvalue + "'," + p1 + ",CONVERT(DATETIME, '" + dateTime1 + "',103),CONVERT(DATETIME, '" + dateTime2 + "',103),'" + p2 + "',CONVERT(DATETIME, '" + dateTime3 + "',103),'" + p3 + "',CONVERT(DATETIME, '" + dateTime4 + "',103)); "
                   + " SELECT ConfigureType, DepartmentCode, Designationcode, Rate, ActiveDateFrom, ActiveDateTo, EntryUserId, EntryDate, UpdateUserID, UpdateDate FROM Hrms_Additional_Configure WHERE (ConfigureType = '" + configureType + "') AND (DepartmentCode = '" + deptcode + "') AND (Designationcode = '" + desigvalue + "')";
        }
        #endregion Payment Configuration

        #region Active Employee Information
        public static string SqlGetSearchArea()
        {
            string sql = "";
            return sql = "SELECT [searchID],[searchText] FROM [tblActiveEmployeeSearch] order by [searchText]";
        }

        public static string SqlGetSectionIntoDDL(string departmentCode)
        {
            string sql = "";
            return sql = "SELECT DISTINCT Sect_Code,Sect_Name FROM Hrms_Sect_Mas WHERE T_C1 = '1' AND  Sect_Dept_Code='" + departmentCode + "' ORDER BY Sect_Name";
        }
        #endregion Active Employee Information

        #region Shift Setup

        public static string SqlDeleteShift(string shiftCode)
        {
            return "DELETE FROM hrms_shift_mas WHERE Shift_Mas_Code = '" + shiftCode + "'";
        }

        public static string SqlGetShift(string shiftCode, string shiftTitle)
        {
            return "select distinct Shift_Mas_Code from hrms_shift_mas  where Shift_Mas_Code = '" + shiftCode + "' or Shift_Mas_Desc = '" + shiftTitle + "'";
        }

        #endregion Shift Setup

        #region Loan Type Setup

        public static string SqlDeleteLoanType(string loanCode)
        {
            return "DELETE FROM HRMS_LoanType_Setup WHERE loanCode = '" + loanCode + "'";
        }

        public static string SqlGetLoanType(string loanCode, string loanTitle)
        {
            return "SELECT loanCode FROM HRMS_LoanType_Setup WHERE loanCode = '" + loanCode + "' OR loanTitle = '" + loanTitle + "'";
        }


        public static string SqlGetLoanType(string loanTitle)
        {
            return "SELECT loanTitle FROM HRMS_LoanType_Setup WHERE loanTitle = '" + loanTitle + "'";
        }
        #endregion Loan Type Setup

        #region Late Reason Setup

        public static string SqlDeleteLateReason(string attendanceDate, string shiftCode)
        {
            return "DELETE FROM HRMS_LateReason_Record WHERE CONVERT(DATE, attendanceDate ,103)  = CONVERT(DATE, '" + attendanceDate + "',103) AND shiftCode = '" + shiftCode + "'";
        }

        public static string SqlCheckhrms_atnd_det(DateTime attendanceDate, string shiftCode)
        {
            return "select count(Atnd_det_date) from hrms_atnd_det where CONVERT(DATE, Atnd_det_date ,103)  = CONVERT(DATE, '" + attendanceDate + "',103) AND Atnd_Det_sftID = '" + shiftCode + "'";
        }
        #endregion Late Reason Setup

        #region Disciplanary Action

        internal static string SqlDeleteDisciplanaryAction(string caseCode, string employeeCode)
        {
            return "DELETE FROM [HRMSDisciplanaryAction] WHERE [caseCode] = '" + caseCode + "' AND employeeCode = '" + employeeCode + "'";
        }
        #endregion Disciplanary Action

        internal static string SqlGetEmployeeCode()
        {
            return "select distinct EmpID from Emp_Details Order by EmpID";
        }

        #region Document Upload
        public static string SqlGetDocumentTypeIntoDDL()
        {
            return "SELECT DISTINCT [documentTypeCode],[documentTypeText]  FROM [HRMS_DocumentType] ORDER BY [documentTypeText]";
        }
        #endregion Document Upload


        internal static string SqlGetEmployeeCode(string officeLocation)
        {
            return "select distinct EmpID from Emp_Details where OfficeID = '" + officeLocation + "' Order by EmpID";
        }

        public static string UpdateUserInformationByempidCompanyCode(string userid, string userempid, string username, string userdesig, string userdept, string useremail, string usermobile, string usershortname, int userstatus, string companyCode)
        {
            string sql = "";
            sql = @"UPDATE tblUserInfo SET UserId ='" + userid + "', UserName ='" + username + "', UserDiaplayName ='" + usershortname + "', CompanyCode ='" + companyCode + "', UserDesignation ='" + userdesig + "',"
                         + " UserDepartment ='" + userdept + "', UserEmail ='" + useremail + "', UserMob ='" + usermobile + "', UserStatus ='" + userstatus + "'"
                         + " WHERE (UserEmpId ='" + userempid + "') AND (CompanyCode ='" + companyCode + "')";

            return sql;
        }

        public static string SqlGetUserinfoByuserid(string userid, string companyCode)
        {
            return "select * from tblUserInfo where UserId='" + userid + "' and CompanyCode ='" + companyCode + "'";
        }
        public static string SqlGetUserinfoByuseridEmpid(string userid, string companyCode,string empid)
        {
            return "select * from tblUserInfo where UserId='" + userid + "' and CompanyCode ='" + companyCode + "' and UserEmpId<>'" + empid + "'";
        }
        public static string SqlGetApprovalFlowEmpid(string userid, string processid, string flowid)
        {
            string sql="";
            return sql = @"select ProcessId,ProcessFlowId,ProcessLevelid,EmpID,EmpName,Designation from ProcessAccessPermission a
                        inner join Emp_Details b on a.AccessId=b.EmpID 
                        and a.DepartmentId=(select distinct DeptID from Emp_Details where EmpID='" + userid + "') where ApplicantID='" + userid + "' and ProcessId='" + processid + "' and ProcessFlowId='" + flowid + "' order by ProcessLevelid";
        }
        public static string SqlGetAccessRestriction(string processid, string userid)
        {
            string sql = "";
            return sql = @"select * from hrms_employeeSearch_restriction where Processid='" + processid + "' and EntryUserid='" + userid + "'";
        }
        public static string SqlGetEmpidByAccess(string processid, string userid,string empid)
        {
            string sql = "";            
            return sql = @"select * from hrms_employeeSearch_restriction a "
                           + " inner join Emp_Details b on b.EmpID='" + empid + "'"
                           + " and a.OfficeLocationID=(case when a.OfficeLocationID='' then b.OfficeID else a.OfficeLocationID end)"
                           + " and b.DeptID=(case when a.DepartmentID='' then b.DeptID else a.DepartmentID end)"
                           + " and b.SectID=(case when a.Sectionid='' then b.sectid else a.sectionid end)" 
                           + " and b.DesgID=(case when a.Designationid='' then b.DesgID else a.Designationid end)" 
                           + " where Processid='" + processid + "' and EntryUserid='" + userid + "'";
        }

        public static string SqlGetLeaveDetails(DateTime Fromdate, DateTime Todate, String Empid)
        {

            string sql = "";
            if (Empid.Equals("") == true)
            {
                sql = @"select Leave_Det_Emp_Id,EmpName,Designation,Dept,Emp_Mas_Join_Date,Leave_Det_LCode,Leave_Mas_Name,Leave_Det_Sta_Date,Leave_Det_Emp_Days 
                        from HrMs_Emp_Leave_Det a 
                        inner join Emp_Details b on a.Leave_Det_Emp_Id=b.EmpID
                        inner join HrMs_Emp_mas d on d.Emp_Mas_Emp_Id=a.Leave_Det_Emp_Id
                        inner join HRMS_Leave_Mas c on c.Leave_Mas_Code=a.Leave_Det_LCode and c.T_C2=d.Emp_Mas_Emp_Type
                        where Leave_Det_Sta_Date between CONVERT(Datetime,'" + Fromdate + "',103) and CONVERT(Datetime,'" + Todate + "',103) order by Leave_Det_Emp_Id,Leave_Det_Sta_Date";
 
            }
            else
            {
                sql = @"select Leave_Det_Emp_Id,EmpName,Designation,Dept,Emp_Mas_Join_Date,Leave_Det_LCode,Leave_Mas_Name,Leave_Det_Sta_Date,Leave_Det_Emp_Days 
                        from HrMs_Emp_Leave_Det a 
                        inner join Emp_Details b on a.Leave_Det_Emp_Id=b.EmpID
                        inner join HrMs_Emp_mas d on d.Emp_Mas_Emp_Id=a.Leave_Det_Emp_Id
                        inner join HRMS_Leave_Mas c on c.Leave_Mas_Code=a.Leave_Det_LCode and c.T_C2=d.Emp_Mas_Emp_Type
                        where Leave_Det_Sta_Date between CONVERT(Datetime,'" + Fromdate + "',103) and CONVERT(Datetime,'" + Todate + "',103) and Leave_Det_Emp_Id='" + Empid + "' order by Leave_Det_Emp_Id,Leave_Det_Sta_Date";
            }

            return sql;
        }
        public static string SqlGetProcessView(string Processid,String Empid,string Deptid)
        {

            string sql = "";
            if (Deptid.Equals("") == true)
            {
                sql = @"select a.ApplicantID,c.EmpName,c.Designation,c.Office,c.DeptID,c.Dept,c.Sect,ProcessLevelid,d.EmpID as Accessid,d.EmpName as AccessName,"
                        + " b.ProcessName,b.DepartmentId,b.ReferenceNo "
                        + " from ProcessFlowConfigurationbyEmployee a "
                        + " inner join ProcessHeaderConfigurationbyDepartment b on a.ReferenceNo=b.ReferenceNo and b.ProcessId='" + Processid + "'"
                        + " inner join Emp_Details c on a.ApplicantID=c.EmpID"
                        + " inner join Emp_Details d on a.AccessId=d.EmpID"
                        + " where b.ProcessId='" + Processid + "' order by ApplicantID,ProcessLevelid";

            }
            if (Deptid.Equals("") == false)
            {
                sql = @"select a.ApplicantID,c.EmpName,c.Designation,c.Office,c.DeptID,c.Dept,c.Sect,ProcessLevelid,d.EmpID as Accessid,d.EmpName as AccessName,"
                        + " b.ProcessName,b.DepartmentId,b.ReferenceNo "
                        + " from ProcessFlowConfigurationbyEmployee a "
                        + " inner join ProcessHeaderConfigurationbyDepartment b on a.ReferenceNo=b.ReferenceNo and b.ProcessId='" + Processid + "'"
                        + " inner join Emp_Details c on a.ApplicantID=c.EmpID"
                        + " inner join Emp_Details d on a.AccessId=d.EmpID"
                        + " where b.ProcessId='" + Processid + "' and b.DepartmentId='" + Deptid + "' order by ApplicantID,ProcessLevelid";

            }
            if (Empid.Equals("") == false)
            {
                sql = @"select a.ApplicantID,c.EmpName,c.Designation,c.Office,c.DeptID,c.Dept,c.Sect,ProcessLevelid,d.EmpID as Accessid,d.EmpName as AccessName,"
                        + " b.ProcessName,b.DepartmentId,b.ReferenceNo "
                        + " from ProcessFlowConfigurationbyEmployee a "
                        + " inner join ProcessHeaderConfigurationbyDepartment b on a.ReferenceNo=b.ReferenceNo and b.ProcessId='" + Processid + "'"
                        + " inner join Emp_Details c on a.ApplicantID=c.EmpID"
                        + " inner join Emp_Details d on a.AccessId=d.EmpID"
                        + " where b.ProcessId='" + Processid + "' and a.ApplicantID='" + Empid + "' order by ApplicantID,ProcessLevelid";
            }

            return sql;

        }

        public static string SqlGetCheckDate(string processid,string empid,DateTime dtchk)
        {
            string sql = "";
            return sql = @"select * from ProcessFlowDetAttendance a 
                            inner join ProcessFlowdet b on a.TransactionNo=b.TransactionNo
                            where b.ProcessID='" + processid + "' and a.ApplicantID='" + empid + "' and Trndate=Convert(Datetime,'" + dtchk + "',103) and ActionTypeId in(1,2,5)";
        }

        public static string SqlGetpendingSql(string processid, string empid, DateTime dtchk)
        {
            string sql = "";
            return sql = @"";
        }

        public static string SqlGetProcessIntoDDL()
        {
            return "SELECT DISTINCT ProcessId,ProcessDescription FROM ProcessDescription WHERE Status = 'Active' ORDER BY ProcessDescription";
        }
        public static string SqlGetProcesspermissionData(string userid,string processid)
        {
            string sql="";
            return sql = @"select Autono,EntryUserid,f.ProcessDescription as Processid,
                        b.Division_Master_Name as OfficeLocationID,
                        isnull(c.Dept_Name,'ALL') as DepartmentID,
                        isnull(d.Sect_Name,'ALL') as Sectionid,
                        isnull(e.JobTitle,'ALL') as Designationid
                        from HRMS_EmployeeSearch_Restriction a
                        left outer join Hrms_Division_Master b on a.OfficeLocationID=b.Division_Master_Code
                        left outer join Hrms_Dept_Master c on c.Dept_Division_Code=b.Division_Master_Code and c.Dept_Code=a.DepartmentID
                        left outer join Hrms_Sect_Mas d on d.Sect_Comp_Code=c.Dept_Comp_Code 
                        and d.Sect_Div_Code=b.Division_Master_Code and d.Sect_Dept_Code=c.Dept_Code and d.Sect_Code=a.Sectionid
                        left outer join Hrms_Job_Master e on e.JobCode=a.Designationid
                        inner join ProcessDescription f on f.ProcessId=a.Processid
                        where EntryUserid='" + userid + "' and a.Processid='" + processid + "'";


        }

        public static string Gettrainigdetails(string trainingname)
        {
            string sql = "";
            sql = @"select * from HRMS_Training_Master where Training_Name='" + trainingname + "'";
            return sql;
 
        }

        public static string GetJDdetails(string trainingname)
        {
            string sql = "";
            sql = @"select * from Hrms_Job_Description where Training_Name='" + trainingname + "'";
            return sql;

        }

    }

