using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.Framework.Core.Facade;
using Winner.User.DataAccess;
using Winner.User.Entities;

namespace Winner.User.Facade.VipModules
{
    /// <summary>
    /// VIP到期降级
    /// </summary>
    public class DowngradeVipProvider : FacadeBase
    {
        public bool Downgrade(int userId)
        {
            BeginTransaction();
            Tnet_User dao = new Tnet_User();
            dao.ReferenceTransactionFrom(Transaction);
            if (!dao.SelectByPk(userId))
            {
                Rollback();
                Alert("查询会员信息失败");
                return false;
            }
            int before = dao.User_Level;
            if (((UserLevel)dao.User_Level & UserLevel.VIP会员) != UserLevel.VIP会员)
            {
                Alert("该会员已不是VIP");
                return true;
            }
            dao.User_Id = userId;
            dao.User_Level = (dao.User_Level ^ (int)UserLevel.VIP会员);
            if (!dao.Update())
            {
                Rollback();
                Alert("更新会员级别失败");
                return false;
            }
            Tnet_Role_Expires daExpires = new Tnet_Role_Expires();
            daExpires.ReferenceTransactionFrom(Transaction);
            daExpires.User_Id = userId;
            daExpires.User_Level = (int)UserLevel.VIP会员;
            daExpires.Before_Level = before;
            daExpires.After_Level = (before ^ (int)UserLevel.VIP会员);
            daExpires.Remarks = "VIP到期系统自动降级";
            if (!daExpires.Insert())
            {
                Rollback();
                Alert("写入降级历史失败");
                return false;
            }
            Commit();
            return true;
        }
    }
}
