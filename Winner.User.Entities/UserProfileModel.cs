using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winner.User.Entities
{
    /// <summary>
    /// 用户基础资料
    /// </summary>
    public class UserProfileModel
    {
        /// <summary>
        /// 账号
        /// </summary>
        public string NodeCode { get; set; }
        /// <summary>
        /// 名字
        /// </summary>
        public string NodeName { get; set; }
        /// <summary>
        /// 认证状态【0：未认证，1：认证中，2：已认证】
        /// </summary>
        public int Auth_Status { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string Avatar { get; set; }
        /// <summary>
        /// 用户级别
        /// </summary>
        public int User_Level { get; set; }
        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime Register_Time { get; set; }
        /// <summary>
        /// 认证通过时间
        /// </summary>
        public DateTime? Auth_Time { get; set; }
    }
    public class AccountInfo
    {
        public decimal Balance { get; set; }
        public int PurseType { get; set; }
        public string PurseName { get; set; }
        public decimal FreezeValue { get; set; }
    }
}
