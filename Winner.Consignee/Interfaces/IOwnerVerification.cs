using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.Consignee.Entities;

namespace Winner.Consignee.Interfaces
{
    /// <summary>
    /// 拥有者验证器
    /// </summary>
    public interface IOwnerVerification
    {
        /// <summary>
        /// 是否有效
        /// </summary>
        /// <param name="ownerId"></param>
        /// <param name="ownerType"></param>
        /// <returns></returns>
        bool IsValid(int ownerId, Address_Owner_Type ownerType);
    }
}
