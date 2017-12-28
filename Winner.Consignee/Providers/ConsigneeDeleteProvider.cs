using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.Framework.Core.Facade;
using Winner.Consignee.DataAccess;
using Winner.Consignee.Entities;
using Winner.Framework.Utils;

namespace Winner.Consignee.Providers
{
    /// <summary>
    /// 删除收货地址
    /// </summary>
    public class ConsigneeDeleteProvider : FacadeBase
    {
        private int _address_id;
        private bool _forceDelete;
        /// <summary>
        /// 删除收货地址
        /// </summary>
        /// <param name="addressId"></param>
        public ConsigneeDeleteProvider(int addressId) : this(addressId, false)
        {
        }
        /// <summary>
        /// 删除收货地址
        /// </summary>
        /// <param name="addressId">地址ID</param>
        /// <param name="forceDelete">强制删除，执行物理删除，从数据库抹除记录</param>
        public ConsigneeDeleteProvider(int addressId, bool forceDelete)
        {
            this._address_id = addressId;
            this._forceDelete = forceDelete;
        }
        /// <summary>
        /// 执行删除操作，除非forceDelete=true，否则只是将is_del字段置为1
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            BeginTransaction();
            Tnet_Shipping_Address daAddress = new Tnet_Shipping_Address();
            daAddress.ReferenceTransactionFrom(Transaction);
            if (!daAddress.SelectByPk(_address_id))
            {
                Rollback();
                Alert("指定的收货地址不存在或已删除");
                return false;
            }
            if (_forceDelete)
            {
                if (!daAddress.Delete())
                {
                    Rollback();
                    Alert("删除收货地址失败[force]");
                    return false;
                }
            }
            else
            {
                if (daAddress.Is_Del == 1)
                {
                    Commit();
                    return true;
                }
                daAddress.Is_Del = 1;
                if (!daAddress.Update())
                {
                    Rollback();
                    Alert("删除收货地址失败");
                    return false;
                }
            }
            Commit();
            ShippingAddress address = MapProvider.Map<ShippingAddress>(daAddress.DataRow);
            OnSuccess(address);
            return true;
        }
        /// <summary>
        /// 删除成功的事件
        /// </summary>
        public event Action<ShippingAddress> Success;
        /// <summary>
        /// 操作成功时调用
        /// </summary>
        /// <param name="address"></param>
        protected void OnSuccess(ShippingAddress address)
        {
            if (Success != null)
            {
                Delegate[] list = Success.GetInvocationList();
                foreach (Delegate d in list)
                {
                    try
                    {
                        Action<ShippingAddress> action = (Action<ShippingAddress>)d;
                        action.BeginInvoke(address, null, null);
                    }
                    catch
                    {
                    }
                }
            }
        }
    }
}
