using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winner.User.DataAccess
{
    public partial class Tnet_Bankinfo
    {
    }
    public partial class Tnet_BankinfoCollection
    {
        public bool ListByStatus(int status)
        {
            string sql = "SELECT * FROM TNET_BANKINFO WHERE STATUS=:STATUS ORDER BY RANK DESC";
            AddParameter("STATUS", status);
            return ListBySql(sql);
        }
    }
}
