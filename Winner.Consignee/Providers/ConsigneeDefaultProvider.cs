using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.Consignee.DataAccess;
using Winner.Consignee.Entities;
using Winner.Framework.Core.Facade;

namespace Winner.Consignee.Providers
{
    /// <summary>
    /// 默认收货地址管理
    /// </summary>
    public class ConsigneeDefaultProvider : FacadeBase
    {
        private int _addressId;
        /// <summary>
        /// 默认收货地址管理
        /// </summary>
        /// <param name="addressId"></param>
        public ConsigneeDefaultProvider(int addressId)
        {
            this._addressId = addressId;
        }
        /// <summary>
        /// 将收货地址设置为默认
        /// </summary>
        /// <param name="remarks"></param>
        /// <returns></returns>
        public bool SetDefault(string remarks = null)
        {
            BeginTransaction();
            //set the specific address to default address
            Tnet_Shipping_Address daAddress = new Tnet_Shipping_Address();
            daAddress.ReferenceTransactionFrom(Transaction);
            if (!daAddress.SelectByPk(_addressId))
            {
                Rollback();
                Alert("收货地址不存在");
                return false;
            }
            //first of all, set all address default property to false
            Tnet_Shipping_AddressCollection daShippingUpdate = new Tnet_Shipping_AddressCollection();
            daShippingUpdate.ReferenceTransactionFrom(Transaction);
            if (!daShippingUpdate.ListDefaultAddress(daAddress.Owner_Id, (Address_Owner_Type)daAddress.Owner_Type))
            {
                Rollback();
                Alert("系统异常");
                return false;
            }
            int rowCount = daShippingUpdate.Count;
            if (rowCount > 0)
            {
                if (!daShippingUpdate.UpdateAllAddressNotDefault(daAddress.Owner_Id, (Address_Owner_Type)daAddress.Owner_Type, rowCount))
                {
                    Rollback();
                    Alert("更新默认地址失败");
                    return false;
                }
            }
            if (!daAddress.SetDefault(_addressId))
            {
                Rollback();
                Alert("设置默认地址失败");
                return false;
            }
            Commit();
            return true;
        }
    }
}
