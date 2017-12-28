using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.Framework.Core.Facade;
using Winner.Framework.Utils;
using Winner.Framework.Utils.Model;
using Winner.Job.Master.Interface;
using Winner.User.DataAccess;

namespace Winner.User.Facade.Services
{
    public class VipRewardCreationService : IJob
    {
        public JobResult Run(DateTime runTime)
        {
            Vnet_UserCollection daUserCollection = new Vnet_UserCollection();
            if (!daUserCollection.ListByUserLevel(Entities.UserLevel.VIP会员))
            {
                return JobResult.FailResult("查询数据失败");
            }
            if (daUserCollection.Count <= 0)
            {
                Log.Info("没有需要处理的数据");
                return JobResult.SuccessResult("没有需要处理的数据");
            }
            int errCount = 0;
            StringBuilder errText = new StringBuilder();
            foreach (Vnet_User user in daUserCollection)
            {
                VipModules.CreateVipDailyRewardProvider rewardProvider = new VipModules.CreateVipDailyRewardProvider(user.User_Id);
                bool res = rewardProvider.DoCreate(runTime);
                if (!res) errCount++;
                errText.AppendLine($"{user.User_Id},  生成奖励{res}， {rewardProvider.PromptInfo.CustomMessage}");
            }
            Log.Info(errText);
            return errCount == 0 ? JobResult.SuccessResult() : JobResult.FailResult("部分失败");
        }
    }
}
