using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winner.User.DataAccess
{
    public partial class Vnet_Identity
    {
        public bool SelectByUser_Id(int userId)
        {
            string sql_condition = "USER_ID=:USER_ID";
            AddParameter("USER_ID", userId);
            return SelectByCondition(sql_condition);
        }
    }
    public partial class Vnet_IdentityCollection
    {
        public bool ListByAdmin(string usercode, string username, DateTime? startdate, DateTime? enddate)
        {
            string sql = "SELECT USR.USER_CODE,USR.AUTH_STATUS,VI.* FROM VNET_IDENTITY VI LEFT JOIN TNET_USER USR ON VI.USER_ID=USR.USER_ID WHERE 1=1";
            if (!string.IsNullOrEmpty(username))
            {
                sql += " AND VI.USER_NAME LIKE '%'||:USERNAME||'%'";
                AddParameter("USERNAME", username);
            }
            if (!string.IsNullOrEmpty(usercode))
            {
                sql += " AND USR.USER_CODE=:USERCODE";
                AddParameter("USERCODE", usercode);
            }
            if (startdate.HasValue)
            {
                sql += " AND VI.CREATE_TIME>=TRUNC(:STARTDATE)";
                AddParameter("STARTDATE", startdate.Value);
            }
            if (enddate.HasValue)
            {
                sql += " AND VI.CREATE_TIME<TRUNC(:ENDDATE)+1";
                AddParameter("ENDDATE", enddate.Value);
            }
            sql += " ORDER BY VI.VALIDATE_STATUS ASC, VI.CREATE_TIME DESC";
            return ListBySql(sql);
        }
    }
}
