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
    /// 更新收货地址
    /// </summary>
    public class ConsigneeUpdateProvider : FacadeBase
    {
        private ShippingAddress _address;
        /// <summary>
        /// 更新收货地址
        /// </summary>
        /// <param name="address"></param>
        public ConsigneeUpdateProvider(ShippingAddress address)
        {
            this._address = address;
        }
        /// <summary>
        /// 执行更新操作
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            if (_address == null)
            {
                Alert("收货地址信息不能为空");
                return false;
            }
            if (_address.Consignee == null)
            {
                _address.Consignee = new ConsigneeInfo();
            }
            var vres0 = ModelVerify.Verify(_address, "update");
            if (!vres0.IsSuccess)
            {
                Alert(vres0.Verifys.FirstOrDefault().ErrorMessage);
                return false;
            }
            int addressId = _address.Address_Id;
            Tnet_Shipping_Address daShippingAddress = new Tnet_Shipping_Address();
            if (!daShippingAddress.SelectByPk(addressId))
            {
                Alert("收货地址信息不存在");
                return false;
            }
            if (_address.Owner_Id > 0 && daShippingAddress.Owner_Id != _address.Owner_Id)
            {
                Alert("操作不允许");
                return false;
            }
            _address.Owner_Id = daShippingAddress.Owner_Id;
            _address.Owner_Type = (Address_Owner_Type)daShippingAddress.Owner_Type;
            Tnet_Consignee daConsignee = new Tnet_Consignee();
            if (!daConsignee.SelectByPk(daShippingAddress.Consignee_Id))
            {
                Alert("收件人信息有误");
                return false;
            }
            //如果收货人信息传入null，表示不需要修改此项，则将已有的收货人信息写入 _address.Consignee
            Extend(_address.Consignee, daConsignee);
            var oldAddressId = _address.Address_Id;
            BeginTransaction();
            ConsigneeCreationProvider creationProvider = new ConsigneeCreationProvider(_address);
            creationProvider.ReferenceTransactionFrom(Transaction);
            if (!creationProvider.Create())
            {
                Rollback();
                Alert("更新收货地址失败，请重试！");
                return false;
            }

            this._address = creationProvider.ShippingAddress;//new shipping address
            
            Commit();
            OnSuccess(this._address);
            return true;
        }
        private static void Extend(ConsigneeInfo consignee, Tnet_Consignee dao)
        {
            if (string.IsNullOrEmpty(consignee.Address))
            {
                consignee.Address = dao.Address;
            }
            if (string.IsNullOrEmpty(consignee.Post_Code))
            {
                consignee.Post_Code = dao.Post_Code;
            }
            if (string.IsNullOrEmpty(consignee.Consignee_Name))
            {
                consignee.Consignee_Name = dao.Consignee_Name;
            }
            if (string.IsNullOrEmpty(consignee.Remarks))
            {
                consignee.Remarks = dao.Remarks;
            }
            if (consignee.Region_Id == 0)
            {
                consignee.Region_Id = dao.Region_Id;
            }
            if (string.IsNullOrEmpty(consignee.Mobile_No))
            {
                consignee.Mobile_No = dao.Mobile_No;
            }
        }

        private ConsigneeInfo GetConsigneeInfo(int consigneeId)
        {
            Tnet_Consignee daConsignee = new Tnet_Consignee();
            if (!daConsignee.SelectByPk(consigneeId))
            {
                return null;
            }
            ConsigneeInfo consignee = MapProvider.Map<ConsigneeInfo>(daConsignee.DataRow);
            return consignee;
        }
        /// <summary>
        /// 当前操作的收货地址信息
        /// </summary>
        public ShippingAddress ShippingAddress { get { return _address; } }

        /// <summary>
        /// 成功事件
        /// </summary>
        public event Action<ShippingAddress> Success;
        /// <summary>
        /// 更新成功时调用
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
