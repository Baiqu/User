using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.Framework.Core.Facade;
using Winner.Consignee.DataAccess;
using Winner.Consignee.Entities;
using Winner.Consignee.Interfaces;

namespace Winner.Consignee.Providers
{
    /// <summary>
    /// 收货地址创建程序
    /// </summary>
    public class ConsigneeCreationProvider : FacadeBase
    {
        private ShippingAddress _address;
        private IOwnerVerification _verification;
        /// <summary>
        /// 收货地址创建程序
        /// </summary>
        /// <param name="address">地址信息</param>
        /// <param name="verification">拥有者验证器</param>
        public ConsigneeCreationProvider(ShippingAddress address, IOwnerVerification verification = null)
        {
            this._address = address;
            this._verification = verification;
        }
        /// <summary>
        /// 执行创建收货地址操作
        /// </summary>
        /// <returns></returns>
        public bool Create()
        {
            if (_address == null || _address.Consignee == null)
            {
                Alert("收货地址信息不能为空");
                return false;
            }
            var vres0 = Winner.Framework.Utils.ModelVerify.Verify(_address, "create");
            if (!vres0.IsSuccess)
            {
                Alert(vres0.Verifys.FirstOrDefault().ErrorMessage);
                return false;
            }
            var vres1 = Winner.Framework.Utils.ModelVerify.Verify(_address.Consignee, "create");
            if (!vres1.IsSuccess)
            {
                Alert(vres1.Verifys.FirstOrDefault().ErrorMessage);
                return false;
            }
            if (!CheckOwner())
            {
                return false;
            }
            BeginTransaction();
            Tnet_Consignee daConsignee = new Tnet_Consignee();
            daConsignee.ReferenceTransactionFrom(Transaction);
            if (!daConsignee.SelectByRid_Address_PostCode_Name_Mobile(
                _address.Consignee.Region_Id,
                _address.Consignee.Address,
                _address.Consignee.Consignee_Name,
                _address.Consignee.Mobile_No,
                _address.Consignee.Post_Code))
            {
                daConsignee.Address = _address.Consignee.Address;
                daConsignee.Consignee_Name = _address.Consignee.Consignee_Name;
                daConsignee.Mobile_No = _address.Consignee.Mobile_No;
                daConsignee.Post_Code = _address.Consignee.Post_Code;
                daConsignee.Region_Id = _address.Consignee.Region_Id;
                if (!daConsignee.Insert())
                {
                    Rollback();
                    Alert("添加收货人信息失败");
                    return false;
                }
            }
            Tnet_Shipping_Address daShipping = new Tnet_Shipping_Address();
            daShipping.ReferenceTransactionFrom(Transaction);
            if (_address.Address_Id > 0)
            {
                if (!daShipping.SelectByPk(_address.Address_Id))
                {
                    Rollback();
                    Alert("修改的收货地址信息不存在");
                    return false;
                }
            }
            daShipping.Consignee_Id = daConsignee.Consignee_Id;
            daShipping.Is_Default = 0;
            daShipping.Is_Del = 0;
            daShipping.Owner_Id = _address.Owner_Id;
            daShipping.Owner_Type = (int)_address.Owner_Type;
            daShipping.Tag_Name = _address.Tag_Name;
            if (_address.Address_Id <= 0)
            {
                if (!daShipping.Insert())
                {
                    Rollback();
                    Alert("新建收货地址失败");
                    return false;
                }
            }
            else
            {
                daShipping.Address_Id = _address.Address_Id;
                if (!daShipping.Update())
                {
                    Rollback();
                    Alert("新建收货地址失败");
                    return false;
                }
            }
            //update object property to lastest value
            _address.Address_Id = daShipping.Address_Id;
            _address.Consignee.Consignee_Id = daConsignee.Consignee_Id;
            if (_address.Is_Default == 1)
            {
                var updateProvider = new ConsigneeDefaultProvider(daShipping.Address_Id);
                updateProvider.ReferenceTransactionFrom(Transaction);
                if (!updateProvider.SetDefault())
                {
                    Rollback();
                    Alert(updateProvider.PromptInfo);
                    return false;
                }
            }
            Commit();
            OnSuccess();
            return true;
        }
        /// <summary>
        /// 成功事件
        /// </summary>
        public event Action<ShippingAddress> Success;
        /// <summary>
        /// 执行成功时调用
        /// </summary>
        protected void OnSuccess()
        {
            if (Success != null)
            {
                Delegate[] list = Success.GetInvocationList();
                foreach (Delegate d in list)
                {
                    try
                    {
                        Action<ShippingAddress> action = (Action<ShippingAddress>)d;
                        action.BeginInvoke(this.ShippingAddress, null, null);
                    }
                    catch
                    {
                    }
                }
            }
        }
        /// <summary>
        /// 添加完成的地址信息
        /// </summary>
        public ShippingAddress ShippingAddress
        {
            get
            {
                return _address;
            }
        }
        /// <summary>
        /// 检查拥有者信息
        /// </summary>
        /// <returns></returns>
        protected virtual bool CheckOwner()
        {
            if (_verification != null)
            {
                return _verification.IsValid(_address.Owner_Id, _address.Owner_Type);
            }
            return true;
        }
    }
}
