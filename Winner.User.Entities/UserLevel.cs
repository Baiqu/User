using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winner.User.Entities
{
    [Flags]
    public enum UserLevel
    {
        普通会员 = 0,
        VIP会员 = 1,
        DIP会员 = 2,
    }
}
