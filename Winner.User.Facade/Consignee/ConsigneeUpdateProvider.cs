using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.Framework.Core.Facade;
using Winner.User.DataAccess;
using Winner.User.Entities.Consignee;

namespace Winner.User.Facade.Consignee
{
    public class ConsigneeUpdateProvider : FacadeBase
    {
        private UserShippingAddress _address;
        public ConsigneeUpdateProvider(UserShippingAddress address)
        {
            this._address = address;
        }
        public bool Update()
        {
            int cid = _address.Consignee_Id;
            Tnet_Consignee daConsignee = new Tnet_Consignee();
            if (!daConsignee.SelectByPk(cid))
            {
                Alert("指定修改的收货人信息不存在");
                return false;
            }
            BeginTransaction();
            ConsigneeCreationProvider creationProvider = new ConsigneeCreationProvider(_address);
            creationProvider.ReferenceTransactionFrom(Transaction);
            if (!creationProvider.Create())
            {
                Rollback();
                Alert("更新收货地址失败，请重试！");
                return false;
            }
            var oldAddress = _address;
            this._address = creationProvider.ShippingAddress;//new shipping address
            ConsigneeDeleteProvider deleteProvider = new ConsigneeDeleteProvider(oldAddress.Address_Id, oldAddress.User_Id);//delete old shipping address
            deleteProvider.ReferenceTransactionFrom(Transaction);
            if (!deleteProvider.Delete())
            {
                Rollback();
                Alert("更新收货地址失败，请重试！");
                return false;
            }
            Commit();
            return true;
        }

        public bool SetDefault()
        {
            BeginTransaction();
            //first of all, set all address default property to false
            Tnet_Shipping_AddressCollection daShippingUpdate = new Tnet_Shipping_AddressCollection();
            daShippingUpdate.ReferenceTransactionFrom(Transaction);
            if (!daShippingUpdate.ListDefaultAddress(_address.User_Id, Address_Owner_Type.个人用户))
            {
                Rollback();
                Alert("系统异常");
                return false;
            }
            int rowCount = daShippingUpdate.Count;
            if (rowCount > 0)
            {
                if (!daShippingUpdate.UpdateAllAddressNotDefault(_address.User_Id, Address_Owner_Type.个人用户, rowCount))
                {
                    Rollback();
                    Alert("更新默认地址失败");
                    return false;
                }
            }
            //set the specific address to default address
            Tnet_Shipping_Address daAddress = new Tnet_Shipping_Address();
            daAddress.ReferenceTransactionFrom(Transaction);
            daAddress.Is_Default = 1;
            daAddress.Address_Id = _address.Address_Id;
            if (daAddress.Update())
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
