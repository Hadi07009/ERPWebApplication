using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

/// <summary>
/// Summary description for ClsCompanySetup
/// </summary>
public class ClsCompanySetup
{
	public ClsCompanySetup()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public string pCompanyID { get; set; }
    public string pBranchID { get; set; }
    public string pCountryID { get; set; }
    public string pCompanyName { get; set; }
    public string pCompanyShortName { get; set; }
    public string pBusinessTypeID { get; set; }
    public string pOwnershipTypeID { get; set; }

    public string pHouse { get; set; }
    public string pRoad { get; set; }
    public string pSector { get; set; }
    public string pLandMark { get; set; }

    public string pCompanySlogun { get; set; }
    public string pAreaGroup { get; set; }
    public string pAreaID { get; set; }
    public string pDistrictID { get; set; }
    public string pContactPersonName { get; set; }
    public string pContactPersonDesignation { get; set; }
    public string pContactPersonContactNumber { get; set; }
    public string pAlternateContactPersonName { get; set; }
    public string pAlternateContactPersonDesignation { get; set; }
    public string pAlternateContactPersonContactNumber { get; set; }
    public string pCompanyPhones { get; set; }
    public string pCompanyMobile { get; set; }
    public string pCompanyFax { get; set; }
    public string pCompanyEmail { get; set; }
    public string pCompanyURL { get; set; }
    public string pFaceBookURL { get; set; }
    public string pLinkedInURL { get; set; }
    public string pTwitterURL { get; set; }
    public string pYouTubeURL { get; set; }
    public string pALPHABETSoftwareProduct { get; set; }

    public string pDescription { get; set; }
    public string pDataused { get; set; }
    public string pUserid { get; set; }
    public DateTime pCurrentdate { get; set; }
    public int pFlag { get; set; }



    public void loadCompanySetup(string colname, string tablename, string whereclause, string headername, GridView gv, SqlCommand myCommand)
    {
        string qr = @"SELECT " + colname + " FROM " + tablename + " where " + whereclause;
        //DataLoadProcess.LoadDataInGridViewWeb(ref gv, qr, headername, myCommand);
    }


    public DataTable loadCompanySetupFromGridDet(string colname, string tablename, string whereclause,SqlCommand myCommand)
    {
        DataTable ControlData = new DataTable();
        string query =  @"SELECT " + colname + " FROM " + tablename + " where " + whereclause;
        ControlData=clsDataManipulation.GetData(myCommand, query);
        return ControlData;
    }


    public bool CommandGenerator(string proname, string values, SqlCommand myCommand)
    {
        string qr = @"exec  " + proname + " " + values;
        return clsDataManipulation.ExecuteCommand(myCommand, qr);
    }

 

    public string searchoneitem(string ComapanyName, SqlCommand myCommand)
    {
        string countval = string.Empty;

        //countval = DataManipulation.GetTotalValueFromtableColumn(myCommand, "pCompanySetup", "CompanyName", "countcol", "where " + ComapanyName + "");
        return countval;

    }

    public void showbysearchitem(string BusinessType, GridView gv, SqlCommand myCommand)
    {
        //string qr = @"SELECT BusinessTypeID,BusinessType,Description FROM [BusinessTypeSetup] where " + BusinessType + " and DataUsed='A' order by BusinessType asc";

        //string colname = "BusinessTypeID,BusinessType,Description";
        //DataLoadProcess.LoadDataInGridViewWeb(ref gv, qr, colname, myCommand);
    }




    public string CompanySetupWhereClause(string CompanyName,string BranchID,string CountryID)
    {
        string ReturnQuery = "where [uCompanyWiseUserList.CompanyName]='"+CompanyName+"' and [uCompanyWiseUserList.BranchID]='"+BranchID+"' and uCompanyWiseUserList.CountryID='"+Convert.ToInt32(CountryID)+"'";
        return ReturnQuery;
    }


    public void dropdownElements(DropDownList ddl, string BusinessTypecolumn, string tablenam, string whrclause, SqlCommand myCommad)
    {

        string[] colnam = BusinessTypecolumn.Split(',');
        string qr = string.Empty;

        if (whrclause != string.Empty)
        {
            qr = @"SELECT " + BusinessTypecolumn + " FROM " + tablenam + " where " + whrclause + " order by " + colnam[1] + " asc";
        }
        else
        {
            qr = @"SELECT " + BusinessTypecolumn + " FROM " + tablenam + "  order by " + colnam[1] + " asc";
        }
        //DataLoadProcess.LoadDataInComboBox(ref ddl, qr, myCommad);

    }

}