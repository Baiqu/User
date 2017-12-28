using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.Framework.Core.Facade;
using Winner.Framework.Utils;
using Winner.Job.Master.Interface;
using Winner.User.DataAccess;
using Winner.User.Facade.VipModules;

namespace Winner.User.Facade.Services
{
    public class UserRoleUpgradeService : FacadeBase, IJob
    {
        public JobResult Run(DateTime runTime)
        {
            Tvip_OrderCollection daOrderCollection = new Tvip_OrderCollection();
            if (!daOrderCollection.ListUndealedOrder())
            {
                return JobResult.FailResult("查询失败");
            }
            if (daOrderCollection.Count <= 0)
            {
                Log.Info("没有需要处理的订单");
                return JobResult.SuccessResult("没有需要处理的订单");
            }
            int errCount = 0;
            foreach (Tvip_Order order in daOrderCollection)
            {
                UpgradeUserRoleProvider provider = new UpgradeUserRoleProvider(order.Order_Id);
                bool res = provider.Upgrade();
                if (!res)
                {
                    errCount++;
                }
                Log.Info("订单号：{0}，处理结果：{1}，错误信息：{2}", order.Order_No, (res ? "成功" : "失败"), provider.PromptInfo.CustomMessage);
            }
            return errCount == 0 ? JobResult.SuccessResult() : JobResult.FailResult("处理失败");
        }
    }
}
