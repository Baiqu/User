using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winner.User.DataAccess
{
    public partial class Tvip_Reward
    {
        /// <summary>
        /// 更新为已领取状态
        /// </summary>
        /// <returns></returns>
        public bool UpdateReceiveById(int transferId)
        {
            string sql = string.Format("UPDATE TVIP_REWARD SET {0}=:AFTER_{0},{1}=SYSDATE,{3}=:{3} WHERE {2}=:{2} AND {0}=:BEFORE_{0}", _STATUS, _RECEIVE_TIME, _REWARD_ID,_TRANSFER_ID);
            AddParameter("AFTER_" + _STATUS, 1);
            AddParameter(_REWARD_ID, this.Reward_Id);
            AddParameter("BEFORE_" + _STATUS, 0);
            AddParameter(_TRANSFER_ID, transferId);
            return UpdateBySql(sql);
        }
    }
    public partial class Tvip_RewardCollection
    {

    }
}
