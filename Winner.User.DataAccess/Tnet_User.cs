using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.User.Entities;

namespace Winner.User.DataAccess
{
    public partial class Tnet_User
    {
        public bool UpdateUserLevel(int userId, UserLevel userLevel)
        {
            string sql = "UPDATE TNET_USER SET USER_LEVEL=:USER_LEVEL WHERE USER_ID=:USER_ID";
            AddParameter("USER_LEVEL", userLevel);
            AddParameter("USER_ID", userId);
            return UpdateBySql(sql);
        }
    }
    public partial class Tnet_UserCollection
    {

    }
}
