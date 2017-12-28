using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.User.Interface;

namespace Winner.User.Facade
{
    /// <summary>
    /// 用户资料
    /// </summary>
    public interface IUserProfile
    {
        string PropertyName { get; }
        object GetProfile(IUser user);
    }
}
