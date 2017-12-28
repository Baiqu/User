using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.User.Entities;
using Winner.User.Interface.Enums;

namespace Winner.User.Facade
{
    public class SmsValidCodeVerification : IIdentityVerification
    {
        private string _mobileno;
        private string _validCode;
        private PasswordType _codeType;
        public SmsValidCodeVerification(string mobileno, string validCode, PasswordType codeType)
        {
            this._mobileno = mobileno;
            this._validCode = validCode;
            this._codeType = codeType;
        }
        public string ErrorMessage
        {
            get; private set;
        }

        public bool Verify()
        {
            ValidateCodeProvider provider = new ValidateCodeProvider(_mobileno, _codeType);
            if (!provider.VerifyCode(_validCode))
            {
                this.ErrorMessage = provider.PromptInfo.CustomMessage;
                return false;
            }
            return true;
        }
    }
}
