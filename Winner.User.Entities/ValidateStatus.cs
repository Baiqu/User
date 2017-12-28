using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winner.User.Entities
{
    [Flags]
    public enum ValidateStatus
    {
        审核中 = 1,
        审核通过 = 2,
        审核未通过 = 4,
        已删除 = 8
    }
}
