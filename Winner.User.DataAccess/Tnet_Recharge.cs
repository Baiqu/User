using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.User.Entities;

namespace Winner.User.DataAccess
{
    public partial class Tnet_Recharge
    {

    }
    public partial class Tnet_RechargeCollection
    {
        public bool ListByUserId_AccountType(int userId, eBankAccountType accountType)
        {
            string condition = string.Format("{0}=:{0} AND {1}=:{1} ORDER BY {2} DESC", Tnet_Recharge._RECHARGE_TYPE, Tnet_Recharge._USER_ID, Tnet_Recharge._CREATE_TIME);
            AddParameter(Tnet_Recharge._RECHARGE_TYPE, accountType);
            AddParameter(Tnet_Recharge._USER_ID, userId);
            return ListByCondition(condition);
        }
    }
}
