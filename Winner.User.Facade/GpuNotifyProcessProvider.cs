using Javirs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.Balance.GlobalCurrency;
using Winner.Framework.Utils;
using Winner.GlobalPayUnit.Client;
using Winner.User.Entities;

namespace Winner.User.Facade
{
    public class GpuNotifyProcessProvider : NotifyProcessProvider
    {
        public GpuNotifyProcessProvider() : base(AppConfig.GpuStoreId.ToString(), AppConfig.GpuSafeCode, 1)
        {
        }

        protected override bool ProcessOrder(NotifyUnit unit, out string message)
        {
            Log.Info(unit.ToLineText());
            Currency currency = new Currency(CurrencyType.RMB, unit.Amount / 100m);
            message = "OK";
            if (unit.Status == GpuPayStatus.支付成功)
            {
                if (string.Equals(unit.PrivateValue, AppConfig.RECHARGE_PRIVATE_VALUE, StringComparison.OrdinalIgnoreCase))
                {
                    Recharge.RechargeOrderPaymentProvider provider = new Recharge.RechargeOrderPaymentProvider(unit.Orderno, true, currency);
                    if (!provider.Pay())
                    {
                        message = provider.PromptInfo.CustomMessage;
                        return false;
                    }
                    return true;
                }
                else if (string.Equals(unit.PrivateValue, AppConfig.VIPORDER_PRIVATE_VALUE, StringComparison.OrdinalIgnoreCase))
                {
                    VipModules.OrderPaymentProvider payment = new VipModules.OrderPaymentProvider(null, unit.Orderno, null, true);
                    if (!payment.Pay())
                    {
                        message = payment.PromptInfo.CustomMessage;
                        return false;
                    }
                    return true;
                }
                else
                {
                    message = "订单类型未识别";
                    return false;
                }
            }
            else
            {
                message = "不是支付成功的通知";
                return true;
            }
        }
    }
}
