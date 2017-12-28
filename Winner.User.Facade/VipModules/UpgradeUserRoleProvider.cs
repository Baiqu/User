using Javirs.Common.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.Framework.Core.Facade;
using Winner.Framework.Utils;
using Winner.User.DataAccess;
using Winner.User.Entities;
using Winner.User.Entities.VipModules;

namespace Winner.User.Facade.VipModules
{
    public class UpgradeUserRoleProvider : FacadeBase
    {
        private int _orderId;
        private OrderInfo Order;
        public UpgradeUserRoleProvider(int orderId)
        {
            this._orderId = orderId;
        }
        public bool Upgrade()
        {
            Tvip_Order daOrder = new Tvip_Order();
            if (!daOrder.SelectByPk(this._orderId))
            {
                Alert("找不到指定的订单信息[OrderId=" + this._orderId + "]");
                return false;
            }
            if (daOrder.Status != (int)OrderStatus.支付成功)
            {
                Alert("订单未支付");
                return false;
            }
            Tvip_Sub_OrderCollection daSubOrderCollection = new Tvip_Sub_OrderCollection();
            if (!daSubOrderCollection.ListByOrder_Id(this._orderId))
            {
                Alert("找不到指定的订单信息[OrderId=" + this._orderId + "]");
                return false;
            }
            this.Order = MapProvider.Map<OrderInfo>(daOrder.DataRow);
            this.Order.SubOrders = MapProvider.Map<SubOrder>(daSubOrderCollection.DataTable);

            if (!DoUpgrade())
            {
                return false;
            }
            return true;
        }
        private bool DoUpgrade()
        {
            UserLevel level = 0;
            switch (this.Order.OrderType)
            {
                case OrderType.VIP订单:
                    level = UserLevel.VIP会员;
                    break;
                case OrderType.DIP订单:
                    level = UserLevel.DIP会员;
                    break;
            }
            if (level == 0)
            {
                Alert("未识别的订单类型");
                return false;
            }
            BeginTransaction();
            foreach (SubOrder sub in this.Order.SubOrders)
            {
                if (!UpgradeUserRole(sub, level))
                {
                    Rollback();
                    return false;
                }
                if (!SetSubOrderDealed(sub))
                {
                    Rollback();
                    return false;
                }
            }
            Commit();
            return true;
        }
        private bool SetSubOrderDealed(SubOrder order)
        {
            BeginTransaction();
            Tvip_Sub_Order daSubOrder = new Tvip_Sub_Order();
            daSubOrder.ReferenceTransactionFrom(Transaction);
            if (!daSubOrder.SelectByPk(order.Sub_Id))
            {
                Rollback();
                return false;
            }
            if (!daSubOrder.SetSubOrderDealed())
            {
                Rollback();
                return false;
            }
            Commit();
            return true;

        }
        private bool UpgradeUserRole(SubOrder subOrder, UserLevel level)
        {
            DateTime start = DateTime.Now;
            BeginTransaction();
            Tnet_User_Role daVip = new Tnet_User_Role();
            daVip.ReferenceTransactionFrom(Transaction);
            if (!daVip.SelectByUserId_UserLevel(subOrder.User_Id, (int)level))
            {
                daVip.User_Id = subOrder.User_Id;
                daVip.Expire_Time = start.AddYears(1);
                daVip.Last_Modify_Time = DateTime.Now;
                daVip.User_Level = (int)level;
                daVip.Role_Name = UserLevel.VIP会员.ToString();
                if (!daVip.Insert())
                {
                    Rollback();
                    return false;
                }
            }
            else
            {
                if (daVip.Expire_Time > start)
                {
                    start = daVip.Expire_Time;
                }
                daVip.Expire_Time = start.AddYears(1);
                daVip.Last_Modify_Time = DateTime.Now;
                if (!daVip.Update())
                {
                    Rollback();
                    return false;
                }
            }
            if (!string.IsNullOrEmpty(this.Order.Biz_Args))
            {
                JsonObject arg = JsonObject.Parse(this.Order.Biz_Args);
                string org_code = arg.GetString("Org_Code");
                if (!string.IsNullOrEmpty(org_code))
                {
                    Tnet_Organization daOrg = new Tnet_Organization();
                    if (!daOrg.SelectByOrgCode(org_code))
                    {
                        Rollback();
                        Alert("归属俱乐部未找到");
                        return false;
                    }
                    Tnet_User_Profile daProfile = new Tnet_User_Profile();
                    daProfile.ReferenceTransactionFrom(Transaction);
                    daProfile.User_Id = daVip.User_Id;
                    daProfile.Org_Id = daOrg.Org_Id;
                    daProfile.Last_Modify_Time = DateTime.Now;
                    if (!daProfile.Update())
                    {
                        Rollback();
                        Alert("修改归属信息失败");
                        return false;
                    }
                }
            }
            Tnet_User daUser = new Tnet_User();
            daUser.ReferenceTransactionFrom(Transaction);
            if (!daUser.UpdateUserLevel(subOrder.User_Id, level))
            {
                Rollback();
                Alert("更新会员角色失败");
                return false;
            }
            Commit();
            return true;
        }
    }
}
