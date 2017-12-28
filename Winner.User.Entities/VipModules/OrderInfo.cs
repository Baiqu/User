using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winner.User.Entities.VipModules
{
    public class OrderInfo
    {
        public int OrderId { get; set; }
        public string Order_No { get; set; }
        public decimal Amount { get; set; }
        public OrderStatus Status { get; set; }
        public PayType PayType { get; set; }
        public OrderType OrderType { get; set; }
        public int UserId { get; set; }
        public int Device_Id { get; set; }
        public int Delivery_Type { get; set; }
        public string Voucher { get; set; }
        public int? Payer_Org_Id { get; set; }
        public DateTime Createtime { get; set; }
        public string Biz_Args { get; set; }
        public List<SubOrder> SubOrders { get; set; }
    }
    public class SubOrder
    {
        public int Sub_Id { get; set; }
        public int Order_Id { get; set; }
        public int User_Id { get; set; }
        public DateTime Createtime { get; set; }
        public DateTime? Deal_Time { get; set; }
        public string Remarks { get; set; }
    }
}
