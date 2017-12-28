using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.Consignee.Entities;

namespace Winner.Consignee.DataAccess
{
    public partial class Vnet_Full_Address
    {
        /// <summary>
        /// 根据AddressId查询收货地址信息
        /// </summary>
        /// <param name="addressId"></param>
        /// <returns></returns>
        public bool SelectByAddressId(int addressId)
        {
            string sql_condition = string.Format("{0}=:{0}", _ADDRESS_ID);
            AddParameter(_ADDRESS_ID, addressId);
            return SelectByCondition(sql_condition);
        }
    }
    public partial class Vnet_Full_AddressCollection
    {
        /// <summary>
        /// 查询指定拥有者的所有收货地址信息，默认地址排最前，按添加时间降序
        /// </summary>
        /// <param name="ownerId">拥有者ID</param>
        /// <param name="ownerType">拥有者类型</param>
        /// <param name="includeDel">是否包含已删除的数据</param>
        /// <returns></returns>
        public bool ListByOwnerId_OwnerType(int ownerId, Address_Owner_Type ownerType, bool includeDel = false)
        {
            string sql = "SELECT * FROM VNET_FULL_ADDRESS WHERE OWNER_ID=:OWNERID AND OWNER_TYPE=:OWNERTYPE";
            if (!includeDel)
            {
                sql += " AND IS_DEL=0";
            }
            sql += " ORDER BY IS_DEFAULT DESC,CREATE_TIME DESC";
            AddParameter("OWNERID", ownerId);
            AddParameter("OWNERTYPE", ownerType);
            return ListBySql(sql);
        }
    }
}
