using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.User.Entities;

namespace Winner.User.DataAccess
{
    public partial class Vnet_User
    {
        public bool SelectByUserid(int userId)
        {
            string sql_condition = $"{_USER_ID}=:{_USER_ID}";
            AddParameter(_USER_ID, userId);
            return SelectByCondition(sql_condition);
        }
        public int GetRecommendUserCount(int userId)
        {
            string sql = "SELECT COUNT(0) FROM VNET_USER WHERE USER_LEVEL=:USER_LEVEL AND FATHER_ID=:USER_ID";
            AddParameter("USER_LEVEL", UserLevel.VIP会员);//VIP=1
            AddParameter("USER_ID", userId);
            var val = GetIntValue(sql);
            return val.HasValue ? val.Value : 0;
        }
    }

    public partial class Vnet_UserCollection
    {
        public bool ListByAdmin(string username, string usercode, int? usergrade, DateTime? startdate, DateTime? enddate)
        {
            string sql = "SELECT * FROM VNET_USER USR WHERE 1=1";
            if (!string.IsNullOrEmpty(username))
            {
                sql += " AND USER_NAME LIKE '%'||:USERNAME||'%'";
                AddParameter("USERNAME", username);
            }
            if (!string.IsNullOrEmpty(usercode))
            {
                sql += " AND USR.USER_CODE=:USERCODE";
                AddParameter("USERCODE", usercode);
            }
            if (usergrade.HasValue)
            {
                sql += " AND USR.USER_LEVEL=:USERLEVEL";
                AddParameter("USERLEVEL", usergrade.Value);
            }
            if (startdate.HasValue)
            {
                sql += " AND USR.CREATE_TIME>=TRUNC(:STARTDATE)";
                AddParameter("STARTDATE", startdate.Value);
            }
            if (enddate.HasValue)
            {
                sql += " AND USR.CREATE_TIME<TRUNC(:ENDDATE)+1";
                AddParameter("ENDDATE", enddate.Value);
            }
            sql += " ORDER BY USR.CREATE_TIME DESC";
            return ListBySql(sql);
        }

        public bool ListByReferee(int refereeId)
        {
            string sql = "SELECT * FROM VNET_USER WHERE FATHER_ID=:FATHER_ID ORDER BY USER_ID DESC";
            AddParameter(Vnet_User._FATHER_ID, refereeId);
            return ListBySql(sql);
        }

        public bool ListByUserLevel(UserLevel level)
        {
            string sql = @"SELECT USR.*,TUR.EXPIRE_TIME FROM VNET_USER USR 
JOIN TNET_USER_ROLE TUR ON USR.USER_ID=TUR.USER_ID AND TUR.USER_LEVEL=:USER_LEVEL 
WHERE BITAND(USR.USER_LEVEL , :USER_LEVEL)=USR.USER_LEVEL AND TUR.EXPIRE_TIME > SYSDATE 
ORDER BY TUR.EXPIRE_TIME ASC";
            AddParameter("USER_LEVEL", level);
            return ListBySql(sql);
        }

        public bool ListExpireByUserLevel(UserLevel level)
        {
            string sql = @"SELECT USR.*,TUR.EXPIRE_TIME FROM VNET_USER USR 
JOIN TNET_USER_ROLE TUR ON USR.USER_ID=TUR.USER_ID AND TUR.USER_LEVEL=:USER_LEVEL 
WHERE BITAND(USR.USER_LEVEL , :USER_LEVEL)=USR.USER_LEVEL AND TUR.EXPIRE_TIME < SYSDATE 
ORDER BY TUR.EXPIRE_TIME ASC";
            AddParameter("USER_LEVEL", level);
            return ListBySql(sql);
        }
    }
}
