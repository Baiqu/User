using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winner.User.Entities
{
    /// <summary>
    /// 身份验证类型
    /// </summary>
    public enum IdentityValidateType
    {
        短信验证 = 1,
        旧密码验证 = 2
    }
}
