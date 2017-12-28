using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winner.User.DataAccess
{
    public partial class Tapp_Account
    {
        public bool SelectByAppid_Code(int appid, string account_code)
        {
            string sql_condition = string.Format("{0}=:{0} and UPPER({1})=UPPER(:{1})", _APP_ID, _ACCOUNT_CODE);
            AddParameter(_APP_ID, appid);
            AddParameter(_ACCOUNT_CODE, account_code);
            return SelectByCondition(sql_condition);
        }
    }
}
