using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebApplication.AppClass.Model
{
    public class UserPermission
    {
        private string _roleType;

        public string RoleType
        {
            get { return _roleType; }
            set {
                if (value == null)
                {
                    throw new Exception("Role type is required ");
                    
                } _roleType = value;
            }
        }
        private int _roleID;

        public int RoleID
        {
            get { return _roleID; }
            set { _roleID = value; }
        }
        private string _roleName;

        public string RoleName
        {
            get { return _roleName; }
            set { _roleName = value; }
        }
        private int _nodeID;

        public int NodeID
        {
            get { return _nodeID; }
            set { _nodeID = value; }
        }
        public List<int> nodeList;
        public List<int> roleList;

        public List<int> RelatedUserRoleList { get; set; }
    }
}