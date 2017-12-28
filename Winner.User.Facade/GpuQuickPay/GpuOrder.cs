using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winner.User.Facade.GpuQuickPay
{
    public class GpuOrder
    {
        public decimal Amount { get; set; }
        public string Voucher { get; set; }
        public string Order_No { get; set; }

        public string PayUrl { get; set; }
    }
}
