using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.User.Entities;

namespace Winner.User.DataAccess
{
    public partial class Tnet_Bank_Account
    {

    }

    public partial class Tnet_Bank_AccountCollection
    {
        public bool ListByUserId(int userid)
        {
            string sql_condition = string.Concat(Tnet_Bank_Account._USER_ID, "=:", Tnet_Bank_Account._USER_ID, " AND BITAND(", Tnet_Bank_Account._STATUS, ",:", Tnet_Bank_Account._STATUS, ")=", Tnet_Bank_Account._STATUS);
            AddParameter(Tnet_Bank_Account._USER_ID, userid);
            AddParameter(Tnet_Bank_Account._STATUS, ValidateStatus.审核中 | ValidateStatus.审核未通过 | ValidateStatus.审核通过);
            return ListByCondition(sql_condition);
        }

        public bool ListByAdmin(string userCode, string userName, DateTime? startdate, DateTime? enddate)
        {
            string sql = "SELECT USR.USER_CODE,USR.USER_NAME,USR.USER_STATUS,USR.AUTH_STATUS, TBA.* FROM TNET_BANK_ACCOUNT TBA LEFT JOIN TNET_USER USR ON TBA.USER_ID=USR.USER_ID WHERE BITAND(TBA.STATUS,:CARDSTATUS)=TBA.STATUS";
            AddParameter("CARDSTATUS", ValidateStatus.审核中 | ValidateStatus.审核未通过 | ValidateStatus.审核通过);
            if (!string.IsNullOrEmpty(userCode))
            {
                sql += " AND USR.USER_CODE=:USER_CODE";
                AddParameter("USER_CODE", userCode);
            }
            if (!string.IsNullOrEmpty(userName))
            {
                sql += " AND USR.USER_NAME LIKE '%'||:USER_NAME||'%'";
                AddParameter("USER_NAME", userName);
            }
            if (startdate.HasValue)
            {
                sql += " AND TBA.CREATETIME>=TRUNC(:STARTDATE)";
                AddParameter("STARTDATE", startdate.Value);
            }
            if (enddate.HasValue)
            {
                sql += " AND TBA.CREATETIME<TRUNC(:ENDDATE)";
                AddParameter("ENDDATE", enddate.Value);
            }
            sql += " ORDER BY TBA.STATUS ASC,TBA.CREATETIME DESC";
            return ListBySql(sql);
        }
        /// <summary>
        /// 删除除指定银行卡外的其他银行卡
        /// </summary>
        /// <returns></returns>
        public bool DeleteAllExceptById(int id, int userId)
        {
            string sql = "UPDATE TNET_BANK_ACCOUNT SET STATUS=8 WHERE USER_ID=:USER_ID AND ID<>:CARD_ID";
            AddParameter("USER_ID", userId);
            AddParameter("CARD_ID", id);
            return ExecuteNonQuery(sql) > 0;
        }
    }
}
