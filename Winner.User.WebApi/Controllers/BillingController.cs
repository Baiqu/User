using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Winner.Balance.WebService.Client;
using Winner.Framework.Utils.Model;
using Winner.User.Api.Models;
using Winner.User.Entities;
using Winner.WebApi.Contract;

namespace Winner.User.Api.Controllers
{
    public class BillingController : ApiControllerBase
    {
        /// <summary>
        /// 获取账单
        /// </summary>
        /// <returns></returns>
        public ActionResult List(TradeDetailsArgs arg)
        {
            UserPurseProvider upp = new UserPurseProvider();
            FuncResult<Winner.Balance.WebService.Client.Modes.UserPurse> purseResult = null;
            eBankAccountType acctType = (eBankAccountType)arg.AccountType;
            switch (acctType)
            {
                case eBankAccountType.金币:
                    purseResult = upp.UserGoldCoinPurse(Package.UserId);
                    break;
                case eBankAccountType.现金:
                    purseResult = upp.UserCashPurse(Package.UserId);
                    break;
            }
            if (purseResult == null)
            {
                return Json(FuncResult.FailResult("未找到账单信息", (int)ApiStatusCode.DATA_QUERY_FAIL));
            }

            if (!purseResult.Success)
            {
                return Json(purseResult);
            }

            QueryProvider qp = new QueryProvider();
            var purseHisResult = qp.PurseHis(purseResult.Content.PurseCode, null, arg.PageIndex, arg.PageSize, arg.StartDate, arg.EndDate);
            if (!purseHisResult.Success)
            {
                return Json(purseHisResult);
            }
            FuncResult<object> listResult = new FuncResult<object>();
            listResult.Success = true;
            listResult.Message = null;
            listResult.StatusCode = 1;
            if (purseHisResult.Content != null && purseHisResult.Content.Data != null)
            {
                List<object> list = new List<object>();
                foreach (var item in purseHisResult.Content.Data)
                {
                    var li = new
                    {
                        Createtime = item.Createtime,
                        Amount = item.Amount,
                        Remarks = item.Remarks
                    };
                    list.Add(li);
                }
                listResult.Content = PageList<object>.Instance(arg.PageIndex, arg.PageSize, purseHisResult.Content.Count, list);
            }
            return Json(listResult);
        }
    }
}