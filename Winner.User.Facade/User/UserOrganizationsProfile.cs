using Javirs.Common;
using OAuth2.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.Framework.Utils;
using Winner.Framework.Utils.Model;
using Winner.User.Entities;
using Winner.User.Interface;

namespace Winner.User.Facade.User
{
    public class UserOrganizationsProfile : IUserProfile
    {
        public string PropertyName
        {
            get
            {
                return "Orgs";
            }
        }

        public object GetProfile(IUser user)
        {
            UserToken token = new UserToken
            {
                UserCode = user.UserCode,
                UserId = user.UserId,
                Expire_Time = DateTime.Now.AddMinutes(5)
            };
            TimeStamp timestamp = DateTime.Now;
            var dictionary = new Dictionary<string, string>();
            string merchantNo = "yxhv3_android";
            string secret_key = "f8ca3c0c3c2c4883b000d929837225bc";
            ApiContract.Client.ApiContractClient client = new ApiContract.Client.ApiContractClient(merchantNo, secret_key, AppConfig.OrganizationApiUrl);
            client.Put("Device_Id", Computer.Instance.ComputerName);
            client.SetToken(token.ToCipherToken());
            var result = client.Post<List<OrganizationInfo>>();

            if (!result.Success)
            {
                return null;
            }
            MaskSensitiveData(result.Content);
            return result.Content;
        }

        private static void MaskSensitiveData(List<OrganizationInfo> list)
        {
            if (list == null || list.Count <= 0)
            {
                return;
            }
            foreach (var org in list)
            {
                org.UserCode = org.UserCode.ToMask(3, "****", 4);
            }
        }
    }

    public class OrganizationInfo
    {
        public string Org_Code { get; set; }
        public string Org_Name { get; set; }
        public int Org_Type { get; set; }
        public DateTime Createtime { get; set; }
        public string UserName { get; set; }
        public string UserCode { get; set; }
    }
}
