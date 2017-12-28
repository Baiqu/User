using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.Balance.Facade;
using Winner.Balance.GlobalCurrency;
using Winner.User.Entities;
using Winner.User.Interface;

namespace Winner.User.Facade.User
{
    public class UserAccountProfile : IUserProfile
    {
        public string PropertyName
        {
            get
            {
                return "Accounts";
            }
        }

        public object GetProfile(IUser user)
        {
            int userId = user.UserId;
            return GetProfile(userId);
        }
        public List<AccountInfo> GetProfile(int userId)
        {
            List<AccountInfo> accounts = new List<AccountInfo>();
            accounts.Add(GetGoldCoinAccount(userId));
            return accounts;
        }

        private static AccountInfo GetGoldCoinAccount(int userId)
        {
            UserPurse goldCoinPurse = PurseFactory.UserGoldCoinPurse(userId);
            var freezeCurrency = new Currency(goldCoinPurse.CurrencyType, goldCoinPurse.FreezeValue);
            AccountInfo account = new AccountInfo();
            account.PurseName = "金币";
            account.PurseType = (int)eBankAccountType.金币;
            account.Balance = goldCoinPurse.UsableCurrency.ConvertTo(CurrencyType.RMB, 2).Amount;
            account.FreezeValue = freezeCurrency.ConvertTo(CurrencyType.RMB, 2).Amount;
            return account;
        }
    }

}
