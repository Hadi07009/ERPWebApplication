using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPWebApplication.AppClass.Model;
using System.Web.UI.WebControls;
using ERPWebApplication.AppClass.CommonClass;

namespace ERPWebApplication.AppClass.DataAccess
{
    public class VehicleInformationController : DataAccessBase
    {
        private TwoColumnsTableData _objTwoColumnsTableData = new TwoColumnsTableData();
        internal void LoadVehicleTypeDDL(DropDownList givenDDLID, CompanySetup objCompanySetup)
        {
            try
            {
                _objTwoColumnsTableData.TableName = "VehicleType";
                ClsDropDownListController.LoadDropDownList(this.ConnectionString, this.SqlVehicleProperty(objCompanySetup), givenDDLID, "FieldOfName", "FieldOfID");

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
        internal void LoadVehicleCategoryDDL(DropDownList givenDDLID, CompanySetup objCompanySetup)
        {
            try
            {
                _objTwoColumnsTableData.TableName = "VehicleCategory";
                ClsDropDownListController.LoadDropDownList(this.ConnectionString, this.SqlVehicleProperty(objCompanySetup), givenDDLID, "FieldOfName", "FieldOfID");

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
        internal void LoadVehicleTransmissionDDL(DropDownList givenDDLID, CompanySetup objCompanySetup)
        {
            try
            {
                _objTwoColumnsTableData.TableName = "VehicleTransmission";
                ClsDropDownListController.LoadDropDownList(this.ConnectionString, this.SqlVehicleProperty(objCompanySetup), givenDDLID, "FieldOfName", "FieldOfID");

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
        internal void LoadVehicleBodyTypeDDL(DropDownList givenDDLID, CompanySetup objCompanySetup)
        {
            try
            {
                _objTwoColumnsTableData.TableName = "VehicleBodyType";
                ClsDropDownListController.LoadDropDownList(this.ConnectionString, this.SqlVehicleProperty(objCompanySetup), givenDDLID, "FieldOfName", "FieldOfID");

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
        private string SqlVehicleProperty(CompanySetup objCompanySetup)
        {
            try
            {
                string sqlString = null;
                sqlString = @"SELECT [FieldOfID]
                          ,[FieldOfName]
                      FROM " + _objTwoColumnsTableData.TableName + " WHERE DataUsed = 'A' AND CompanyID = " + objCompanySetup.CompanyID + " ORDER BY FieldOfName  ";
                return sqlString;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
    }
}