using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.Framework.Core.Facade;
using Winner.Framework.Utils;
using Winner.User.DataAccess;
using Winner.WebApi.Contract;

namespace Winner.User.Facade.VipModules
{
    public class CreateVipDailyRewardProvider : FacadeBase
    {
        private int _userId;
        public CreateVipDailyRewardProvider(int userId)
        {
            this._userId = userId;
        }

        public bool DoCreate(DateTime runTime)
        {
            const decimal basicReward = 20m;
            Vnet_User daUser = new Vnet_User();
            int recommendCount = daUser.GetRecommendUserCount(this._userId);//直推VIP数量

            //消费数据
            decimal consumeRebate = 0m;
            //预期奖励
            decimal expect = basicReward + (basicReward * 0.2m * recommendCount);
            //实际应得奖励
            decimal infact = expect - consumeRebate;

            Tvip_Reward daReward = new Tvip_Reward
            {
                Amount = infact,
                Expect = expect,
                Datecode = Convert.ToInt32(runTime.ToString("yyyyMMdd")),
                Recommend = recommendCount,
                Status = 0,
                Yesterday = consumeRebate,
                User_Id = this._userId,
            };
            daReward.ReferenceTransactionFrom(Transaction);
            if (!daReward.Insert())
            {
                Alert((ResultType)ApiStatusCode.DATA_PERSIST_FAIL, "创建VIP每日奖励失败");
                return false;
            }
            return true;
        }
    }
}
