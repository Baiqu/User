using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winner.User.DataAccess
{
    public partial class Tnet_Lock
    {

    }
    public partial class Tnet_LockCollection
    {
        public bool ListLockedByUser_id(int user_id)
        {
            string sql_condition = string.Format("{0}=:{0} AND {1}>SYSDATE", Tnet_Lock._USER_ID, Tnet_Lock._AUTO_UNLOCK_TIME);
            AddParameter(Tnet_Lock._USER_ID, user_id);
            return ListByCondition(sql_condition);
        }
    }
}
