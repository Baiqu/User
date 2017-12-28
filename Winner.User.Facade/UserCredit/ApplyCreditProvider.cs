using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.Framework.Core.Facade;

namespace Winner.User.Facade.UserCredit
{
    /// <summary>
    /// 申请授信
    /// </summary>
    public class ApplyCreditProvider : FacadeBase
    {
        private int _protocol_id, _userId;
        /// <summary>
        /// 申请授信
        /// </summary>
        /// <param name="protocol_id">授信协议ID</param>
        /// <param name="userId">会员ID</param>
        public ApplyCreditProvider(int protocol_id, int userId)
        {
            this._protocol_id = protocol_id;
            this._userId = userId;
        }

        public bool ApplyCredit()
        {
            throw new NotImplementedException();
        }
    }
}
