using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.Balance.Facade;
using Winner.Balance.GlobalCurrency;
using Winner.Framework.Core.Facade;
using Winner.Framework.Utils;
using Winner.User.DataAccess;
using Winner.User.Entities;
using Winner.WebApi.Contract;

namespace Winner.User.Facade.VipModules
{
    public class OrderPaymentProvider : FacadeBase
    {
        private string _orderNo;
        private bool _isSuccess;
        private PayType? _payType;
        private int? _userId;
        public OrderPaymentProvider(int? userId, string order_no, PayType? payType, bool isSuccess)
        {
            this._orderNo = order_no;
            this._isSuccess = isSuccess;
            this._payType = payType;
            this._userId = userId;
        }
        public bool Pay()
        {
            BeginTransaction();
            Tvip_Order daOrder = new Tvip_Order();
            daOrder.ReferenceTransactionFrom(Transaction);
            if (!daOrder.SelectByOrderNo(_orderNo))
            {
                Rollback();
                Alert((ResultType)ApiStatusCode.DATA_NOT_FOUND, "订单号不存在");
                return false;
            }
            if (daOrder.Status == 1)
            {
                Rollback();
                Alert((ResultType)ApiStatusCode.REQUEST_ALREADY_PROCCEED, "订单已支付，请不要重复支付");
                return false;
            }
            if (this._userId.HasValue && daOrder.User_Id != this._userId.Value)
            {
                Rollback();
                Alert((ResultType)ApiStatusCode.OPERATOR_FORBIDDEN, "操作不允许");
                return false;
            }
            int transferId;
            if (!DoTransfer(daOrder.User_Id, daOrder.Amount, out transferId))
            {
                Rollback();
                return false;
            }
            if (!daOrder.UpdatePaymentByOrderId(daOrder.Order_Id, OrderStatus.支付成功, OrderStatus.等待支付, this._payType))
            {
                Rollback();
                Alert((ResultType)ApiStatusCode.DATA_REFRESH_FAIL, "更新订单信息失败");
                return false;
            }
            Commit();
            Task.Factory.StartNew(() =>
            {
                int order_id = daOrder.Order_Id;
                UpgradeUserRoleProvider provider = new UpgradeUserRoleProvider(order_id);
                bool res = provider.Upgrade();
                Log.Info("异步立即执行升级程序，订单号：{0}，处理结果：{1}，错误信息：{2}", order_id, res ? "成功" : "失败", provider.PromptInfo.CustomMessage);
            });
            return true;
        }

        private bool DoTransfer(int userId, decimal amount, out int transferId)
        {
            transferId = 0;
            if (this._payType == PayType.金币支付)
            {
                UserPurse goldCoinPurse = PurseFactory.UserGoldCoinPurse(userId);
                UserPurse storePurse = PurseFactory.StoreIncomePurse(AppConfig.GpuStoreId);
                Currency currency = new Currency(CurrencyType.RMB, amount);
                BeginTransaction();
                Transfer transfer = new Transfer();
                transfer.ReferenceTransactionFrom(Transaction);
                if (!transfer.DoTransfer(goldCoinPurse, storePurse, currency, (int)TransferReason.升级VIP, "金币升级VIP"))
                {
                    Rollback();
                    Alert(transfer.PromptInfo);
                    return false;
                }
                Commit();
                transferId = transfer.TransferId;
                return true;
            }
            else if (this._payType == PayType.现金支付)
            {
                Alert("不支持的支付方式");
                return false;
            }
            return true;
        }
    }
}
