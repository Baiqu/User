using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.Balance.Facade;
using Winner.Balance.GlobalCurrency;
using Winner.Framework.Core.Facade;
using Winner.Framework.Utils;
using Winner.User.DataAccess;
using Winner.User.Entities;
using Winner.WebApi.Contract;

namespace Winner.User.Facade.VipModules
{
    /// <summary>
    /// 领取VIP奖励
    /// </summary>
    public class ReceiveRewardProvider : FacadeBase
    {
        private int _dateCode, _userId;
        public ReceiveRewardProvider(int dateCode, int userId)
        {
            this._dateCode = dateCode;
            this._userId = userId;
        }
        public bool ReceiveReward()
        {
            BeginTransaction();
            Tvip_Reward daReward = new Tvip_Reward();
            daReward.ReferenceTransactionFrom(Transaction);
            if (!daReward.SelectByUserId_Datecode(_userId, _dateCode))
            {
                Rollback();
                Alert((ResultType)ApiStatusCode.OPERATOR_FORBIDDEN, "今日无奖励可领取");
                return false;
            }
            if (daReward.Status == 1)
            {
                Rollback();
                Alert((ResultType)ApiStatusCode.OPERATOR_FORBIDDEN, "今日奖励已领取");
                return false;
            }
            int transferId;
            if (!DoTransfer(daReward.User_Id, daReward.Amount, out transferId))
            {
                Rollback();
                return false;
            }
            if (!daReward.UpdateReceiveById(transferId))
            {
                Rollback();
                Alert((ResultType)ApiStatusCode.DATA_REFRESH_FAIL, "系统繁忙，请稍后再试！");
                return false;
            }
            Commit();
            return true;
        }

        private bool DoTransfer(int userId, decimal amount, out int transferId)
        {
            UserPurse goldPurse = PurseFactory.UserGoldCoinPurse(userId);
            UserPurse outPurse = PurseFactory.SystemWelfarePurse();
            Currency currency = new Currency(CurrencyType.RMB, amount);
            BeginTransaction();
            Transfer transfer = new Transfer();
            transfer.ReferenceTransactionFrom(Transaction);
            if (!transfer.DoTransfer(outPurse, goldPurse, currency, (int)TransferReason.VIP金币奖励, "VIP金币奖励"))
            {
                Rollback();
                Alert(transfer.PromptInfo);
                transferId = -1;
                return false;
            }
            Commit();
            transferId = transfer.TransferId;
            return true;
        }
    }
}
