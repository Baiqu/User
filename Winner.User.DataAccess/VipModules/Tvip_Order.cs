using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.User.Entities;

namespace Winner.User.DataAccess
{
    public partial class Tvip_Order
    {
        public bool UpdatePaymentByOrderId(int orderId, OrderStatus after, OrderStatus before, PayType? paytype)
        {
            string sql = "UPDATE TVIP_ORDER SET STATUS=:AFTER_STATUS";
            if (paytype.HasValue)
            {
                sql += ",PAY_TYPE=:PAY_TYPE ";
                AddParameter("PAY_TYPE", paytype.Value);
            }
            sql += " WHERE ORDER_ID=:ORDER_ID AND STATUS=:BEFORE_STATUS";
            AddParameter("AFTER_STATUS", after);
            AddParameter(_ORDER_ID, orderId);
            AddParameter("BEFORE_" + _STATUS, before);
            return UpdateBySql(sql);
        }
    }
    public partial class Tvip_OrderCollection
    {
        public bool ListUndealedOrder()
        {
            string sql = "SELECT * FROM TVIP_ORDER ORD WHERE ORD.STATUS=1 AND ORD.ORDER_ID IN (SELECT SUB.ORDER_ID FROM TVIP_SUB_ORDER SUB WHERE SUB.IS_DEALED = 0) ORDER BY CREATETIME ASC";
            return ListBySql(sql);
        }
    }
}
