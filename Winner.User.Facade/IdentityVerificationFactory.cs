using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.User.Entities;
using Winner.User.Interface;
using Winner.User.Interface.Enums;

namespace Winner.User.Facade
{
    /// <summary>
    /// 身份验证器工厂
    /// </summary>
    public class IdentityVerificationFactory
    {
        /// <summary>
        /// 获取身份验证器
        /// </summary>
        /// <param name="type"></param>
        /// <param name="user"></param>
        /// <param name="passwordType"></param>
        /// <param name="validateCode"></param>
        /// <returns></returns>
        public static IIdentityVerification GetVerification(IdentityValidateType type, IUser user, PasswordType passwordType, string validateCode)
        {
            IIdentityVerification verification = null;
            switch (type)
            {
                case IdentityValidateType.短信验证:
                    verification = new SmsValidCodeVerification(user.UserCode, validateCode, passwordType);
                    break;
                case IdentityValidateType.旧密码验证:
                    verification = new PasswordValidVerification(user, validateCode, passwordType);
                    break;
                default:
                    break;
            }
            return verification;
        }
    }
}
