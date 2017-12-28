using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winner.Consignee.DataAccess
{
    public partial class Tnet_Consignee
    {
        /// <summary>
        /// 获取收件人信息一致的数据
        /// </summary>
        /// <param name="regionId"></param>
        /// <param name="address"></param>
        /// <param name="postCode"></param>
        /// <param name="name"></param>
        /// <param name="mobileno"></param>
        /// <returns></returns>
        public bool SelectByRid_Address_PostCode_Name_Mobile(int regionId, string address, string name, string mobileno, string postCode)
        {
            string sql_condition = string.Format("{0}=:{0} AND {1}=:{1} AND {2}=:{2} AND {3}=:{3}",
                _REGION_ID, _ADDRESS, _CONSIGNEE_NAME, _MOBILE_NO);
            AddParameter(_REGION_ID, regionId);
            AddParameter(_ADDRESS, address);
            AddParameter(_CONSIGNEE_NAME, name);
            AddParameter(_MOBILE_NO, mobileno);
            if (!string.IsNullOrEmpty(postCode))
            {
                sql_condition += string.Concat(" AND ", _POST_CODE, "=:", _POST_CODE);
                AddParameter(_POST_CODE, postCode);
            }
            else
            {
                sql_condition += string.Concat(" AND ", _POST_CODE, " IS NULL");
            }
            return SelectByCondition(sql_condition);

        }
    }
}
