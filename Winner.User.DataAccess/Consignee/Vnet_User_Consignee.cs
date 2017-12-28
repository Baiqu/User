using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winner.User.DataAccess
{
    public partial class Vnet_User_Consignee
    {
    }
    public partial class Vnet_User_ConsigneeCollection
    {
        public bool ListByUserId(int userId)
        {
            string sql = "SELECT * FROM VNET_USER_CONSIGNEE WHERE USER_ID=:USER_ID ORDER BY CREATE_TIME DESC";
            AddParameter("USER_ID", userId);
            return ListBySql(sql);
        }
    }
}
