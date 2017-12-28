using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.GlobalPayUnit.Client;

namespace Winner.User.Entities
{
    [Flags]
    public enum PayType
    {
        金币支付 = 1,
        现金支付 = 2,
        [CashPayment]
        安子刷卡支付 = 4,
        [CashPayment]
        手机银联支付 = 8,
        [CashPayment]
        微信公众号支付 = 64,
        [CashPayment]
        微信APP支付 = 128,
        [CashPayment]
        畅捷扫码支付 = 512,
        [CashPayment]
        乾恩扫码支付 = 1024,
        俱乐部缴费 = 2097152
    }
}
