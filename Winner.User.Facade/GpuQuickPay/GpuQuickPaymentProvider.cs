using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.Balance.GlobalCurrency;
using Winner.Framework.Core.Facade;
using Winner.Framework.Utils;
using Winner.Framework.Utils.Model;
using Winner.GlobalPayUnit.Client;
using Winner.User.Entities;
using Winner.User.Interface;

namespace Winner.User.Facade.GpuQuickPay
{
    public class GpuQuickPaymentProvider : FacadeBase
    {
        private string _orderNo, _notifyUrl, _returnUrl, _subject;
        private IUser _user;
        private Currency _currency;
        private GpuPayType _payType;
        private string _privateValue;
        private TransferReason _bizType;

        public GpuQuickPaymentProvider(IUser user, string subject, string orderNo, Currency currency, GpuPayType payType, TransferReason bizType, string notifyUrl, string returnUrl = null)
        {
            this._user = user;
            this._subject = subject;
            this._orderNo = orderNo;
            this._notifyUrl = notifyUrl;
            this._returnUrl = returnUrl;
            this._payType = payType;
            this._currency = currency;
            this._bizType = bizType;
        }
        public void SetPrivateValue(string privateValue)
        {
            this._privateValue = privateValue;
        }
        public GpuOrder CreateOrder()
        {
            try
            {
                return CreateRemoteOrder();
            }
            catch (Exception ex)
            {
                Log.Error("创建GPU订单失败", ex);
                return null;
            }
        }
        private GpuOrder CreateRemoteOrder()
        {
            if (this._user == null)
            {
                Alert("用户信息不能为空");
                return null;
            }
            int storeId = Winner.ConfigurationManager.ConfigurationProvider.GetInt("GPU.STORE_ID");
            string safeCode = Winner.ConfigurationManager.ConfigurationProvider.GetString("GPU.SAFECODE");
            PayUnit payunit = new PayUnit
            {
                Amount = (int)(this._currency.ConvertTo(CurrencyType.RMB, 2).Amount * 100),
                DeathTime = null,
                OrderNo = this._orderNo,
                NotifyUrl = this._notifyUrl,
                PayType = (int)_payType,
                PrivateValue = this._privateValue,
                ReturnUrl = this._returnUrl,
                StoreId = storeId,
                Subject = this._subject,
                UserCode = this._user.UserCode,
                BusinessType = (int)this._bizType,
                UserName = this._user.UserName,
            };
            var proxy = PaymentFactory.GetTradeObject(storeId.ToString(), safeCode);
            FuncResult<Order> result = proxy.CreateOrder(payunit);
            if (result == null)
            {
                Alert("远程订单创建失败");
                return null;
            }
            if (!result.Success)
            {
                Alert(result.Message);
                return null;
            }
            GpuOrder order = new GpuOrder
            {
                Voucher = result.Content.RetriveCode,
                Order_No = result.Content.MerOrderNo,
                Amount = result.Content.Amount,
                PayUrl = result.Content.PayUrl

            };
            return order;
        }
    }
}
