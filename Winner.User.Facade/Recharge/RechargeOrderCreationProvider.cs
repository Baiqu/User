using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.Framework.Core.Facade;
using Winner.User.DataAccess;
using Winner.User.Entities;
using Winner.User.Facade.GpuQuickPay;
using Winner.Balance.GlobalCurrency;
using Winner.User.Interface;
using Winner.GlobalPayUnit.Client;

namespace Winner.User.Facade.Recharge
{
    public class RechargeOrderCreationProvider : FacadeBase
    {
        private int _userId;
        private eBankAccountType _rechargeType;
        private PayType _payType;
        private decimal _amount;
        private string _notifyUrl;
        public RechargeOrderCreationProvider(int userId, eBankAccountType rechargeType, PayType payType, decimal amount, string notifyUrl)
        {
            this._userId = userId;
            this._rechargeType = rechargeType;
            this._payType = payType;
            this._amount = amount;
            this._notifyUrl = notifyUrl;
        }
        public bool CreateOrder()
        {
            if (!xUtils.IsCashPayment(this._payType))
            {
                Alert("不支持的支付方式");
                return false;
            }
            var fac = UserModuleFactory.GetUserModuleInstance();
            IUser user = fac?.GetUserByID(this._userId);
            if (user == null)
            {
                Alert("用户账号数据有误");
                return false;
            }
            string subject = string.Concat(this._rechargeType.ToString(), "充值");
            BeginTransaction();
            Tnet_Recharge daRecharge = new Tnet_Recharge();
            daRecharge.ReferenceTransactionFrom(Transaction);
            daRecharge.Amount = this._amount;
            daRecharge.Pay_Status = (int)OrderStatus.等待支付;
            daRecharge.Pay_Type = (int)this._payType;
            daRecharge.Recharge_Type = (int)this._rechargeType;
            daRecharge.User_Id = this._userId;
            daRecharge.Subject = subject;
            string orderNo;
            if (!daRecharge.Insert("R", out orderNo))
            {
                Rollback();
                Alert("创建订单失败");
                return false;
            }

            Currency currency = new Currency(CurrencyType.RMB, this._amount);
            GpuQuickPaymentProvider provider = new GpuQuickPaymentProvider(user, subject, orderNo, currency, (GpuPayType)this._payType, TransferReason.充值金币, _notifyUrl);
            provider.SetPrivateValue(AppConfig.RECHARGE_PRIVATE_VALUE);
            GpuOrder order = provider.CreateOrder();
            if (order == null)
            {
                Rollback();
                Alert(provider.PromptInfo);
                return false;
            }
            daRecharge.Voucher = order.Voucher;
            if (!daRecharge.Update())
            {
                Rollback();
                Alert("保存订单凭证失败");
                return false;
            }
            Commit();
            this.Voucher = order.Voucher;
            this.Amount = this._amount;
            this.OrderNo = orderNo;
            this.PayUrl = order.PayUrl;
            return true;
        }

        public string Voucher { get; private set; }
        public string OrderNo { get; private set; }
        public decimal Amount { get; private set; }
        public string PayUrl { get; private set; }
    }
}
