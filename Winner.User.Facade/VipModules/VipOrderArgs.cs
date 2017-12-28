using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.User.Entities;

namespace Winner.User.Facade.VipModules
{
    public class VipOrderArgs
    {
        public int UserId { get; set; }
        public PayType PayType { get; set; }
        public OrderType OrderType { get; set; }
        public string[] UserCollection { get; set; }
        public int? ConsigneeId { get; set; }
        public int DeviceModel { get; set; }
        public string Org_Code { get; set; }
    }
}
