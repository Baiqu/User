using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.User.Entities;

namespace Winner.User.DataAccess
{
    public partial class Tnet_User_Profile
    {
        public bool SelectOrgInfoByUserId(int userId)
        {
            string sql = @"SELECT ORG.USER_ID AS OWNERID,ORG.USER_CODE,ORG.USER_NAME,ORG.ORG_ID,ORG.ORG_CODE,ORG.ORG_NAME,ORG.ORG_TYPE,ORG.REFER_ID,
ORG.STATUS,ORG.CREATETIME,ORG.PROVINCE_ID,ORG.CITY_ID,ORG.REGION_ID,ORG.IS_FULL_MONEY, TP.* FROM TNET_USER_PROFILE TP 
JOIN VNET_ORGANIZATION ORG ON ORG.ORG_ID=TP.ORG_ID WHERE TP.USER_ID=:USER_ID";
            AddParameter("USER_ID", userId);
            return SelectBySql(sql);
        }


    }
    public partial class Tnet_User_ProfileCollection
    {

    }
}
