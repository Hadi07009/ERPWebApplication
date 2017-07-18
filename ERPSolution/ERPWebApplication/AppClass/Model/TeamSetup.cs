using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebApplication.AppClass.Model
{
    public class TeamSetup : SectionSetup
    {
        private int _teamID;

        public int TeamID
        {
            get { return _teamID; }
            set { _teamID = value; }
        }
    }
}