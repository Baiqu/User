using Javirs.Common.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Winner.Framework.Encrypt;
using Winner.Framework.Utils;
using Winner.Framework.Utils.Model;
using Winner.User.DataAccess;
using Winner.User.Entities;
using Winner.WebApi.Contract;

namespace Winner.User.Api.Models.Mvc
{
    public class ApiVerification : DefaultApiVerification
    {
        public override bool VerifySignature(ActionParameter para)
        {
            OAuth2.Merchant.OAuthApp app = OAuth2.Merchant.OAuthApp.GetOAuthApp(para.MerchantNo);
            if (app == null)
            {
                return false;
            }
            string secretKey = app.Secret_Key;
            //签名数据
            string signValue = para.Data + secretKey;
            //签名结果
            string signResult = MD5Provider.Encode(signValue);

            //验证签名
            if (!signResult.Equals(para.Sign, StringComparison.CurrentCultureIgnoreCase))
            {
                Log.Info("签名错误：");
                Log.Info("签名数据：" + signValue);
                Log.Info("签名结果：" + signResult);
                return false;
            }
            return true;
        }
    }
}