using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winner.User.Entities
{
    /// <summary>
    /// 身份验证
    /// </summary>
    public interface IIdentityVerification
    {
        bool Verify();
        string ErrorMessage { get; }
    }
}
