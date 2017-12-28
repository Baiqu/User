using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.Framework.Utils;

namespace Winner.User.Entities
{
    public static class AppConfig
    {
        public const string RECHARGE_PRIVATE_VALUE = "RECHARGE";
        public const string VIPORDER_PRIVATE_VALUE = "VIPORDER";
        /// <summary>
        /// 允许绑定银行卡的最多张数
        /// </summary>
        public static int MaxBankCardQuota
        {
            get
            {
                return Winner.ConfigurationManager.ConfigurationProvider.GetInt("MaxBankCardQuota", 0);
            }
        }

        public static int GpuStoreId
        {
            get
            {
                int storeId = Winner.ConfigurationManager.ConfigurationProvider.GetInt("GPU.STORE_ID");
                return storeId;
            }
        }
        public static string GpuSafeCode
        {
            get
            {
                string safeCode = Winner.ConfigurationManager.ConfigurationProvider.GetString("GPU.SAFECODE");
                return safeCode;
            }
        }
        public static string FileSystem_AppID
        {
            get
            {
                return "1001";
            }
        }

        public static string FileSystem_AppSecret
        {
            get
            {
                return "qmgy";
            }
        }

        public static string OrganizationApiUrl
        {
            get
            {
             
                return GetConfigSetting("OrganizationApiUrl", defaultUrl);

            }
        }

        public static string GpuNotifyReceiveUrl
        {
            get
            {
                return GetConfigSetting("GpuNotifyReceiveUrl");
            }
        }

        public class SmsProvider
        {
            public static string UserCode
            {
                get
                {
                    return GetConfigSetting("SmsProvider.UserCode");
                }
            }

            public static string UserPwd
            {
                get
                {
                    return GetConfigSetting("SmsProvider.UserPwd");
                }
            }
        }
        private static string GetConfigSetting(string key, string defaultValue = null)
        {
            var temp = System.Configuration.ConfigurationManager.AppSettings[key];
            if (string.IsNullOrEmpty(temp) && !string.IsNullOrEmpty(defaultValue))
            {
                return defaultValue;
            }
            return temp;
        }
    }
}
