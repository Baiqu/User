using Javirs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Winner.Framework.Core.Interface;
using Winner.User.DataAccess;

namespace Winner.User.Facade.User
{
    public class RecommendList
    {
        public static List<object> GetRecommend(int userId, IChangePage changePage)
        {
            Vnet_UserCollection daUserCollection = new Vnet_UserCollection();
            daUserCollection.ChangePage = changePage;
            daUserCollection.ListByReferee(userId);
            string[] columnSelector = new string[] { "USER_CODE", "USER_NAME", "USER_LEVEL", "AUTH_STATUS", "PHOTO_URL", "IS_LOCKED", "CREATE_TIME" };

            List<object> data = daUserCollection.DataTable.ToDynamic(filterColumns: columnSelector, keyCase: DynamicConverter.KeyType.PascalCase, OnFieldGenerating: MaskedSensitiveData);
            return data;
        }

        private static NameValuePair MaskedSensitiveData(NameValuePair nvp)
        {
            if (nvp.Name.Equals("USER_CODE", StringComparison.OrdinalIgnoreCase))
            {
                nvp.Value = Regex.Replace(nvp.Value.ToString(), "(\\d{2})\\d{5}(\\d{4})", "$1*****$2");
            }
            return nvp;
        }
    }
}
