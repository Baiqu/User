using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.Framework.Utils;
using Winner.User.DataAccess;
using Winner.User.Interface;

namespace Winner.User.Facade.User
{
    public class UserAscriptionProfile : IUserProfile
    {
        public string PropertyName
        {
            get
            {
                return "Ascription";
            }
        }

        public object GetProfile(IUser user)
        {
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            Tnet_User_Profile daProfile = new Tnet_User_Profile();
            if (!daProfile.SelectOrgInfoByUserId(user.UserId))
            {
                return dictionary;
            }
            dictionary.Add("Org_Code", daProfile.DataRow["ORG_CODE"]);
            dictionary.Add("Org_Name", daProfile.DataRow["ORG_NAME"]);
            dictionary.Add("Org_Type", daProfile.DataRow["ORG_TYPE"]);
            //dictionary.Add("User_Name", daProfile.DataRow["USER_NAME"]);
            //dictionary.Add("User_Code", daProfile.DataRow["User_Code"].ToString().ToMask(3, "****", 4));
            return dictionary;
        }
    }
}
