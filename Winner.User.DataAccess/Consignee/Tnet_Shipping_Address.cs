using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.User.Entities.Consignee;

namespace Winner.User.DataAccess
{
    public partial class Tnet_Shipping_Address
    {

    }
    public partial class Tnet_Shipping_AddressCollection
    {
        /// <summary>
        /// 将默认地址设置为非默认
        /// </summary>
        /// <param name="owner_id"></param>
        /// <param name="owner_Type"></param>
        /// <param name="rowCount"></param>
        /// <returns></returns>
        public bool UpdateAllAddressNotDefault(int owner_id, Address_Owner_Type owner_Type, int rowCount)
        {
            string updateSql = "UPDATE TNET_SHIPPING_ADDRESS SET {0}=0 WHERE {1}=:{1} AND {2}=:{2} AND {0}=1";
            updateSql = string.Format(updateSql, Tnet_Shipping_Address._IS_DEFAULT, Tnet_Shipping_Address._OWNER_ID, Tnet_Shipping_Address._OWNER_TYPE);
            AddParameter(Tnet_Shipping_Address._OWNER_ID, owner_id);
            AddParameter(Tnet_Shipping_Address._OWNER_TYPE, owner_Type);
            return ExecuteNonQuery(updateSql) == rowCount;
        }
        /// <summary>
        /// 列出指定用户的所有默认地址（一般来说，一个会员只有一个默认地址，以列表方式查询以防数据有问题）
        /// </summary>
        /// <param name="owner_id"></param>
        /// <param name="owner_type"></param>
        /// <returns></returns>
        public bool ListDefaultAddress(int owner_id, Address_Owner_Type owner_type)
        {
            string sql_condition = string.Format("{0}=:{0} and {1}=:{1} and {2}=1", Tnet_Shipping_Address._OWNER_ID, Tnet_Shipping_Address._OWNER_TYPE, Tnet_Shipping_Address._IS_DEFAULT);
            AddParameter(Tnet_Shipping_Address._OWNER_ID, owner_id);
            AddParameter(Tnet_Shipping_Address._OWNER_TYPE, owner_type);
            return ListByCondition(sql_condition);
        }
    }
}
