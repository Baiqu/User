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
    public class ConsigneeCreationProvider : FacadeBase
    {
        private UserShippingAddress _address;
        public ConsigneeCreationProvider(UserShippingAddress address)
        {
            this._address = address;
        }
        public bool Create()
        {
            BeginTransaction();
            Tnet_Consignee daConsignee = new Tnet_Consignee();
            daConsignee.ReferenceTransactionFrom(Transaction);
            daConsignee.Address = _address.Address;
            daConsignee.Consignee_Name = _address.Consignee_Name;
            daConsignee.Mobile_No = _address.Mobile_No;
            daConsignee.Post_Code = _address.Post_Code;
            daConsignee.Region_Id = _address.Region_Id;
            if (!daConsignee.Insert())
            {
                Rollback();
                Alert("添加收货人信息失败");
                return false;
            }

            Tnet_Shipping_Address daShipping = new Tnet_Shipping_Address();
            daShipping.ReferenceTransactionFrom(Transaction);
            daShipping.Consignee_Id = daConsignee.Consignee_Id;
            daShipping.Is_Default = 0;
            daShipping.Is_Del = 0;
            daShipping.Owner_Id = _address.User_Id;
            daShipping.Owner_Type = 1;
            daShipping.Tag_Name = _address.Tag_Name;
            if (!daShipping.Insert())
            {
                Rollback();
                Alert("新建收货地址失败");
                return false;
            }
            //update object property to lastest value
            _address.Address_Id = daShipping.Address_Id;
            _address.Consignee_Id = daConsignee.Consignee_Id;
            if (_address.Is_Default == 1)
            {
                ConsigneeUpdateProvider updateProvider = new ConsigneeUpdateProvider(_address);
                updateProvider.ReferenceTransactionFrom(Transaction);
                if (!updateProvider.SetDefault())
                {
                    Rollback();
                    Alert(updateProvider.PromptInfo);
                    return false;
                }
            }
            Commit();
            return true;
        }

        public UserShippingAddress ShippingAddress
        {
            get
            {
                return _address;
            }
        }
    }
}
