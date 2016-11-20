using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebApplication.AppClass
{
    public class AccountType
    {
        public enum AccountTypeID: byte
        {
            Sale = 1,
            COGS,
            SalesReturn,
            Stock 
        };
    }
}