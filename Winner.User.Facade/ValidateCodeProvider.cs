using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.Framework.Core.Facade;
using Winner.SmsCenter.Client;
using Winner.User.Entities;
using Winner.User.Interface;
using Winner.User.Interface.Enums;

namespace Winner.User.Facade
{
    public class ValidateCodeProvider : FacadeBase
    {
        private PasswordType _codeType;
        private string _userCode;
        private string _sms_account_code;
        private string _sms_account_pwd;
        public const string SMS_ACCOUNT_SETTING_NAME = "SMS.ACCOUNT";
        public const string SMS_PWD_SETTING_NAME = "SMS.PASSWORD";
        protected ValidateCodeProvider()
        {
            _sms_account_code = Winner.ConfigurationManager.ConfigurationProvider.GetString(SMS_ACCOUNT_SETTING_NAME);
            _sms_account_pwd = Winner.ConfigurationManager.ConfigurationProvider.GetString(SMS_PWD_SETTING_NAME);
        }
        public ValidateCodeProvider(string userCode, PasswordType codeType) : this()
        {
            this._codeType = codeType;
            this._userCode = userCode;
        }
        public ValidateCodeProvider(int userId, PasswordType codeType) : this()
        {
            this._codeType = codeType;
            try
            {
                var fac = UserModuleFactory.GetUserModuleInstance();
                var user = fac.GetUserByID(userId);
                this._userCode = user.UserCode;
            }
            catch (Exception ex)
            {
                this._userCode = null;
            }
        }
        public bool SendCode()
        {
            SmsServiceClient client = new SmsServiceClient(_sms_account_code, _sms_account_pwd);
            if (!client.SendValidateCode(_userCode, GetSmsTemplateGid(_codeType), null))
            {
                Alert(client.Message);
                return false;
            }
            return true;
        }

        public bool VerifyCode(string code)
        {
            SmsServiceClient client = new SmsServiceClient(_sms_account_code, _sms_account_pwd);
            if (!client.ValidateCode(_userCode, GetSmsTemplateGid(_codeType), code))
            {
                Alert(client.Message);
                return false;
            }
            return true;
        }

        private static string GetSmsTemplateGid(PasswordType codeType)
        {
            string gid = null;
            switch (codeType)
            {
                case PasswordType.支付密码:
                    gid = "E894BC5B790E92F8DD4EBE71F4F2B831";
                    break;
                case PasswordType.登录密码:
                    gid = "2F8DD4EBE71F4F2B831E894BC5B790E9";
                    break;
                default:
#if DEBUG
                    gid = "2F8DD4EBE71F4F2B831E894BC5B790E9";
#endif
                    break;
            }
            return gid;
        }
    }
}
