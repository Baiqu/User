using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Winner.Framework.Utils.Model;
using Winner.User.DataAccess;
using Winner.User.Entities;
using Winner.User.Facade;
using Winner.WebApi.Contract;

namespace Winner.User.Api.Controllers
{
    public class BankCardController : ApiControllerBase
    {
        // GET: BankCard
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Bind(BankCardInfo card)
        {
            FuncResult result = new FuncResult();
            BankCardProvider provider = new BankCardProvider();
            result.Success = provider.Bind(card);
            result.StatusCode = result.Success ? 1 : (int)provider.PromptInfo.ResultType;
            result.Message = result.Success ? null : provider.PromptInfo.CustomMessage;
            return Json(result);
        }

        public JsonResult List()
        {
            var user = xUtils.GetUserByCode(Package.UserCode);
            if (user == null)
            {
                return Json(FuncResult.FailResult("用户未注册", 404));
            }
            Tnet_Bank_AccountCollection daAcctColl = new Tnet_Bank_AccountCollection();
            daAcctColl.ListByUserId(user.UserId);
            List<object> list = new List<object>();
            foreach (Tnet_Bank_Account acct in daAcctColl)
            {
                var card = new
                {
                    Card_Id = acct.Id,
                    CardHolder = acct.Account_Name,
                    Card_No = acct.Card_No,
                    Bank_Id = acct.Bank_Id,
                    Branch_Name = acct.Branch_Bank,
                    Branch_No = acct.Branch_No,
                    Bank_Name = acct.Bank_Name,
                    Province_Name = acct.Province_Name,
                    City_Name = acct.City_Name,
                    Status = acct.Status,
                    Createtime = acct.Createtime,
                    RefuseReason = xUtils.GetValidateRemarks(acct.Remarks),
                };
                list.Add(card);
            }
            FuncResult<object> result = new FuncResult<object>();
            result.Success = true;
            result.Message = null;
            result.StatusCode = 1;
            result.Content = list;
            return Json(result);
        }
        public JsonResult Delete(int Card_Id)
        {
            return Json(FuncResult.FailResult("not implement", 304));
        }
        [IgnoreUserToken]
        public JsonResult SupportBanks()
        {
            Tnet_BankinfoCollection daBankCollection = new Tnet_BankinfoCollection();
            daBankCollection.ListByStatus(1);
            FuncResult<List<object>> result = new FuncResult<List<object>>();
            result.Content = new List<object>();
            foreach (Tnet_Bankinfo bnk in daBankCollection)
            {
                var data = new
                {
                    Bank_Id = bnk.Bank_Info_Id,
                    Bank_Name = bnk.Bank_China_Name,
                    Icon = bnk.Logo
                };
                result.Content.Add(data);
            }
            result.Success = true;
            result.StatusCode = 1;
            return Json(result);
        }
    }
}