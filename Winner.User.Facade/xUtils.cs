using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.Framework.Utils;
using Winner.User.DataAccess;
using Winner.User.Entities;
using Winner.User.Interface;
using Javirs.Common;
using System.Reflection;
using Winner.GlobalPayUnit.Client;

namespace Winner.User.Facade
{
    public static class xUtils
    {
        private static List<BankInfo> _bankinfoList;
        public static BankInfo GetBankInfoById(int bankid)
        {
            if (_bankinfoList == null || _bankinfoList.Count == 0)
            {
                Tnet_BankinfoCollection daBankinfoCOll = new Tnet_BankinfoCollection();
                daBankinfoCOll.ListAll();
                _bankinfoList = MapProvider.Map<BankInfo>(daBankinfoCOll.DataTable);
            }
            return _bankinfoList.Find(it => it.BankId == bankid);
        }
        public static IUser GetUserByCode(string code)
        {
            var fac = UserModuleFactory.GetUserModuleInstance();
            if (fac == null)
            {
                return null;
            }
            return fac.GetUserByCode(code);
        }

        public static string GetClientSource(int source)
        {
            string comsource = "UNKNOWN";
            switch (source)
            {
                case 1:
                    comsource = "Android";
                    break;
                case 2:
                    comsource = "iOS";
                    break;
                case 3:
                    comsource = "PC";
                    break;
            }
            return comsource;
        }

        public static bool RsaDecryptPayPwd(string Hex_password, out string plainText)
        {
            try
            {
                string fullpath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data", "yxhpaypwd_private_key.pem");
                Log.Debug("证书保存路径：" + fullpath);
                var rsa = Javirs.Common.Security.PemCertificate.ReadFromPemFile(fullpath);
                byte[] cipherBytes = Hex_password.HexString2ByteArray();
                string base64 = Convert.ToBase64String(cipherBytes);
                plainText = rsa.Decrypt(base64);
                return true;
            }
            catch (Exception ex)
            {
                Log.Error("支付密码解密失败", ex);
                plainText = null;
                return false;
            }
        }

        public static string GetValidateRemarks(string remarks)
        {
            if (string.IsNullOrEmpty(remarks))
            {
                return remarks;
            }
            if (!remarks.Contains("|"))
            {
                return remarks;
            }
            return remarks.Substring(remarks.LastIndexOf('|') + 1);
        }

        public static bool DesEncode(string plainText, out string cipherText)
        {
            string secret = "8FD018F7186343AA84D2538769F6578A";
            try
            {
                var des = new Javirs.Common.Security.DesEncodeDecode(secret, System.Security.Cryptography.CipherMode.ECB, System.Security.Cryptography.PaddingMode.PKCS7, true);
                string base64 = des.DesEncrypt(plainText);
                byte[] bytes = Convert.FromBase64String(base64);
                cipherText = bytes.Byte2HexString();
                return true;
            }
            catch (Exception ex)
            {
                cipherText = null;
                Log.Error("DES加密失败", ex);
                return false;
            }
        }
        private static PayType _cashTypes = 0;
        /// <summary>
        /// 是否是现金支付（刷卡，网银，微信）
        /// </summary>
        /// <param name="payType"></param>
        /// <returns></returns>
        public static bool IsCashPayment(PayType payType)
        {
            if (_cashTypes == 0)
            {
                Type t = typeof(PayType);
                var array = Enum.GetValues(t);
                for (int i = 0; i < array.Length; i++)
                {
                    var value = array.GetValue(i);
                    var name = Enum.GetName(t, value);
                    FieldInfo field = t.GetField(name);
                    var attr = field.GetCustomAttributes(typeof(CashPaymentAttribute), true);
                    if (attr != null && attr.Length > 0)
                    {
                        _cashTypes = _cashTypes | (PayType)value;
                    }
                }
            }
            return (_cashTypes & payType) == payType;
        }
    }
}
//how much money i have to earn to be my self?