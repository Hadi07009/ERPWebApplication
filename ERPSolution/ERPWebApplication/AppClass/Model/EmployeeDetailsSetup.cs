using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ERPWebApplication.AppClass.Model
{
    public class EmployeeDetailsSetup : EmployeeSetup
    {
        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        private string _middleName;

        public string MiddleName
        {
            get { return _middleName; }
            set { _middleName = value; }
        }
        private string _lastName;

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        

        public EmployeeTypeSetup EmployeeTypeSetup
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public EmployeeCategorySetup EmployeeCategorySetup
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public DesignationSetup DesignationSetup
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
        //full name()
        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public int EmployeeSerialNo { get; set; }

        public int EmployeeTitle { get; set; }
        public DataTable dtEmployeeChart;
    }
}