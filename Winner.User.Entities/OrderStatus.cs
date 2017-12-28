using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winner.User.Entities
{
    public enum OrderStatus
    {
        等待支付 = 0,
        支付成功 = 1,
        支付失败 = 2
    }
}
