using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebApplication.AppClass.Model
{
    public class IsUser
    {
        private int _userPermission;

        public int UserPermission
        {
            get { return _userPermission; }
            set {
                if (value == -1)
                {
                    throw new Exception("User permission is required ");
                    
                } _userPermission = value;
            }
        }

        
    }
}