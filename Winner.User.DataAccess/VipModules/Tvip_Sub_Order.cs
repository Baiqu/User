using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winner.User.DataAccess
{
    public partial class Tvip_Sub_Order
    {
        public bool SetSubOrderDealed()
        {
            string sql = "UPDATE TVIP_SUB_ORDER SET DEAL_TIME=SYSDATE,IS_DEALED=1 WHERE SUB_ID=:SUB_ID";
            AddParameter("SUB_ID", this.Sub_Id);
            return UpdateBySql(sql);
        }
    }
    public partial class Tvip_Sub_OrderCollection
    {
    }
}
