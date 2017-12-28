using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.Balance.GlobalCurrency;
using Winner.Consignee;
using Winner.Consignee.Entities;
using Winner.Framework.Core.Facade;
using Winner.Framework.Utils.Model;
using Winner.GlobalPayUnit.Client;
using Winner.User.DataAccess;
using Winner.User.Entities;
using Winner.User.Facade.GpuQuickPay;
using Winner.User.Interface;

namespace Winner.User.Facade.VipModules
{
    public class OrderCreationProvider : FacadeBase
    {
        private VipOrderArgs _arg;
        public OrderCreationProvider(VipOrderArgs arg)
        {
            this._arg = arg;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool CreateOrder()
        {
            if (_arg == null || _arg.UserCollection == null || _arg.UserCollection.Length <= 0)
            {
                Alert("请指定VIP升级会员");
                return false;
            }
            decimal amount = GetOrderAmount(_arg.DeviceModel) * _arg.UserCollection.Length;
            if (amount <= 0)
            {
                Alert("指定型号的设备已停止赠送");
                return false;
            }
            IUser user = GetUserById(_arg.UserId);
            if (user == null)
            {
                Alert("付款账号不存在");
                return false;
            }
            string order_no;
            BeginTransaction();
            Tvip_Order daOrder = new Tvip_Order();
            daOrder.ReferenceTransactionFrom(Transaction);
            daOrder.Amount = amount;
            daOrder.Order_Type = (int)_arg.OrderType;
            daOrder.Pay_Type = (int)_arg.PayType;
            daOrder.Status = 0;
            daOrder.User_Id = _arg.UserId;
            daOrder.Device_Id = _arg.DeviceModel;
            if (!string.IsNullOrEmpty(_arg.Org_Code))
            {
                daOrder.Biz_Args = "{\"Org_Code\":\"" + _arg.Org_Code + "\"}";
            }
            if (_arg.ConsigneeId.HasValue)
            {
                daOrder.Delivery_Type = 1;

            }
            if (!daOrder.Insert("VIP", out order_no))
            {
                Rollback();
                Alert("创建订单失败");
                return false;
            }
            if (_arg.ConsigneeId.HasValue)
            {
                ConsigneeProvider consignee = new ConsigneeProvider();
                AddressInfo address = consignee.GetAddressById(_arg.ConsigneeId.Value);
                if (address == null)
                {
                    Rollback();
                    Alert("无效的收货地址");
                    return false;
                }
                Tvip_Express daExpress = new Tvip_Express();
                daExpress.ReferenceTransactionFrom(Transaction);
                daExpress.Order_Id = daOrder.Order_Id;
                daExpress.Receiver = address.ConsigneeName;
                daExpress.Contract_Phone = address.MobileNo;
                daExpress.Province_Name = address.ProvinceName;
                daExpress.City_Name = address.CityName;
                daExpress.Region_Name = address.RegionName;
                daExpress.Full_Address = address.Address;
                daExpress.Status = 0;
                if (!daExpress.Insert())
                {
                    Rollback();
                    Alert("收货地址保存失败");
                    return false;
                }
            }
            foreach (string userCode in _arg.UserCollection)
            {
                IUser vipUser = GetUserByCode(userCode);
                if (vipUser == null)
                {
                    Rollback();
                    Alert(userCode + "不存在");
                    return false;
                }
                //if (vipUser.Grade.Level == (int)UserLevel.DIP会员 || vipUser.Grade.Level == (int)UserLevel.VIP会员)
                //{
                //    Alert("您已经是VIP，不能重复申请");
                //    Rollback();
                //    return false;
                //}
                Tvip_Sub_Order daSub = new Tvip_Sub_Order();
                daSub.ReferenceTransactionFrom(Transaction);
                daSub.Order_Id = daOrder.Order_Id;
                daSub.User_Id = vipUser.UserId;
                if (!daSub.Insert())
                {
                    Rollback();
                    Alert("创建订单失败");
                    return false;
                }
            }
            string voucher = order_no;
            if (xUtils.IsCashPayment(_arg.PayType))
            {
                var gpuRes = CreateGpuOrder(user, order_no, amount, _arg.PayType);
                if (!gpuRes.Success)
                {
                    Rollback();
                    Alert(gpuRes.Message);
                    return false;
                }
                voucher = gpuRes.Content.Voucher;
                this.PayUrl = gpuRes.Content.PayUrl;
            }
            daOrder.Voucher = voucher;
            if (!daOrder.Update())
            {
                Rollback();
                Alert("获取支付凭证号失败");
                return false;
            }
            Commit();
            this.OrderNo = order_no;
            this.Voucher = voucher;
            this.Amount = amount;

            return true;
        }
        private IUser GetUserByCode(string userCode)
        {
            var fac = UserModuleFactory.GetUserModuleInstance();
            return fac?.GetUserByCode(userCode);
        }
        private IUser GetUserById(int userId)
        {
            var fac = UserModuleFactory.GetUserModuleInstance();
            return fac?.GetUserByID(userId);
        }
        /// <summary>
        /// 获取俱乐部信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        private static object GetOrganizationByUserId(int userId)
        {
            return null;
        }
        /// <summary>
        /// 创建GPU订单
        /// </summary>
        /// <returns></returns>
        private FuncResult<GpuOrder> CreateGpuOrder(IUser user, string order_no, decimal amount, PayType PayType)
        {
            string subject = string.Concat(_arg.OrderType, "升级");
            var currency = new Currency(CurrencyType.RMB, amount);
            string notifyUrl = AppConfig.GpuNotifyReceiveUrl;
            var gpuPay = new GpuQuickPaymentProvider(user, subject, order_no, currency, (GpuPayType)PayType, TransferReason.升级VIP, notifyUrl);
            gpuPay.SetPrivateValue(AppConfig.VIPORDER_PRIVATE_VALUE);
            GpuOrder order = gpuPay.CreateOrder();
            if (order == null)
            {
                return FuncResult.FailResult<GpuOrder>(gpuPay.PromptInfo.CustomMessage);
            }
            return FuncResult.SuccessResult(order);
        }
        /// <summary>
        /// 获取订单类型
        /// </summary>
        /// <param name="device_id">设备ID</param>
        /// <returns></returns>
        private static decimal GetOrderAmount(int device_id)
        {
            Tvip_Device daDevice = new Tvip_Device();
            if (!daDevice.SelectByPk(device_id))
            {
                return 0;
            }
            return daDevice.Status == 1 ? daDevice.Price : 0;
        }

        public string OrderNo { get; private set; }
        public string Voucher { get; private set; }
        public decimal Amount { get; private set; }
        public string PayUrl { get; private set; }
    }
}
