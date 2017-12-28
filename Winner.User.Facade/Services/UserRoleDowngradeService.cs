using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.Framework.Utils;
using Winner.Job.Master.Interface;
using Winner.User.DataAccess;

namespace Winner.User.Facade.Services
{
    /// <summary>
    /// 会员降级服务
    /// </summary>
    public class UserRoleDowngradeService : IJob
    {
        public JobResult Run(DateTime runTime)
        {
            Vnet_UserCollection daUserCollection = new Vnet_UserCollection();
            if (!daUserCollection.ListExpireByUserLevel(Entities.UserLevel.VIP会员))
            {
                Log.Info("查询数据库失败，请检查SQL或连接字符串");
                return JobResult.FailResult("查询数据库失败，请检查SQL或连接字符串");
            }
            if (daUserCollection.Count <= 0)
            {
                Log.Info("没有到期的VIP");
                return JobResult.SuccessResult("没有到期的VIP");
            }
            int errCount = 0;
            foreach (Vnet_User user in daUserCollection)
            {
                var provider = new VipModules.DowngradeVipProvider();
                bool res = provider.Downgrade(user.User_Id);
                string str = "成功";
                if (!res)
                {
                    str = "失败";
                    errCount++;
                }
                Log.Info($"{user.User_Id}VIP降级{str},附加信息：{provider.PromptInfo.CustomMessage}");
            }
            return errCount == 0 ? JobResult.SuccessResult() : JobResult.FailResult("VIP降级失败");
        }
    }
}
