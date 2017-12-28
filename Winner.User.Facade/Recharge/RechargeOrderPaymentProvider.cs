using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.Balance.Facade;
using Winner.Balance.GlobalCurrency;
using Winner.Framework.Core.Facade;
using Winner.User.DataAccess;
using Winner.User.Entities;

namespace Winner.User.Facade.Recharge
{
    public class RechargeOrderPaymentProvider : FacadeBase
    {
        private string _orderNo;
        private bool _isSuccess;
        private Currency _currency;
        public RechargeOrderPaymentProvider(string orderNo, bool isSuccess, Currency currency)
        {
            this._orderNo = orderNo;
            this._isSuccess = isSuccess;
            this._currency = currency;
        }

        public bool Pay()
        {
            Tnet_Recharge daRecharge = new Tnet_Recharge();
            if (!daRecharge.SelectByOrderNo(this._orderNo))
            {
                Alert("订单号不存在");
                return false;
            }
            Currency rechargeCurrency = new Currency(CurrencyType.RMB, daRecharge.Amount);
            Currency diff = rechargeCurrency - this._currency;
            decimal absAmt = Math.Abs(diff.ConvertTo(CurrencyType.RMB, 2).Amount);
            if (absAmt != 0)
            {
                Alert("支付金额与订单金额不匹配，差额:" + absAmt + "元");
                return false;
            }
            int transferId;
            BeginTransaction();
            if (!DoRechargeTransfer(daRecharge.User_Id, rechargeCurrency, (eBankAccountType)daRecharge.Recharge_Type, daRecharge.Subject, out transferId))
            {
                Rollback();
                return false;
            }
            var alter = new Dictionary<Tnet_RechargeCollection.Field, object>
            {
                { Tnet_RechargeCollection.Field.Deal_Time, DateTime.Now },
                { Tnet_RechargeCollection.Field.Pay_Status, (int)(this._isSuccess?OrderStatus.支付成功:OrderStatus.支付失败) },
                { Tnet_RechargeCollection.Field.Transfer_Id, transferId }
            };
            var condition = new Dictionary<Tnet_RechargeCollection.Field, object>
            {
                { Tnet_RechargeCollection.Field.Recharge_Id, daRecharge.Recharge_Id },
                { Tnet_RechargeCollection.Field.Pay_Status, (int)OrderStatus.等待支付 }
            };
            daRecharge.ReferenceTransactionFrom(Transaction);
            if (!daRecharge.Update(alter, condition))
            {
                Rollback();
                Alert("订单信息更新失败");
                return false;
            }
            Commit();
            return true;
        }
        private bool DoRechargeTransfer(int userId, Currency currency, eBankAccountType accountType, string remarks, out int transferId)
        {
            bool result = false;
            transferId = -1;
            switch (accountType)
            {
                case eBankAccountType.金币:
                    result = RechargeGoldCoin(userId, currency, remarks, out transferId);
                    break;
                case eBankAccountType.现金:
                    result = RechargeCash(userId, currency, remarks, out transferId);
                    break;
            }
            return result;
        }

        private bool RechargeGoldCoin(int userId, Currency currency, string remarks, out int transferId)
        {
            UserPurse goldCoinPurse = PurseFactory.UserGoldCoinPurse(userId);
            UserPurse centerBank = PurseFactory.CenterBankPurse();
            BeginTransaction();
            Transfer transfer = new Transfer();
            transfer.ReferenceTransactionFrom(Transaction);
            if (!transfer.DoTransfer(centerBank, goldCoinPurse, currency, (int)TransferReason.充值金币, remarks))
            {
                Rollback();
                Alert(transfer.PromptInfo);
                transferId = -1;
                return false;
            }
            transferId = transfer.TransferId;
            Commit();
            return true;
        }
        private bool RechargeCash(int userId, Currency currency, string remarks, out int transferId)
        {
            UserPurse cashPurse = PurseFactory.UserCashPurse(userId);
            UserPurse centerBank = PurseFactory.CenterBankPurse();
            BeginTransaction();
            Transfer transfer = new Transfer();
            transfer.ReferenceTransactionFrom(Transaction);
            if (!transfer.DoTransfer(centerBank, cashPurse, currency, (int)TransferReason.充值余额, remarks))
            {
                Rollback();
                Alert(transfer.PromptInfo);
                transferId = -1;
                return false;
            }
            transferId = transfer.TransferId;
            Commit();
            return true;
        }
    }
}
