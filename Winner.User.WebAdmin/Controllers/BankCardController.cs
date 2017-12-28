using Javirs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Winner.Areas;
using Winner.Framework.MVC;
using Winner.Framework.MVC.Controllers;
using Winner.Framework.Utils;
using Winner.Framework.Utils.Model;
using Winner.User.DataAccess;
using Winner.User.Facade;
using Winner.User.WebAdmin.Models;

namespace Winner.User.WebAdmin.Controllers
{
    [AuthRight]
    public class BankCardController : TopControllerBase
    {
        // GET: BackCard
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAuthCards(string userCode, string userName, DateTime? startdate, DateTime? enddate)
        {
            Tnet_Bank_AccountCollection daAccountColl = new Tnet_Bank_AccountCollection();
            daAccountColl.ChangePage = this.ChangePage();
            daAccountColl.ListByAdmin(userCode, userName, startdate, enddate);

            List<object> dataList = daAccountColl.DataTable.ToDynamic();
            return SuccessResultList(dataList, daAccountColl.ChangePage);
        }

        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("index");
            }
            var model = new FuncResult<BankAccountViewModel>();
            var daAcct = new Tnet_Bank_Account();
            if (!daAcct.SelectByPk(id.Value))
            {
                model.Message = "未找到银行卡详细信息";
                model.StatusCode = (int)404;
            }
            else
            {
                model.Success = true;
                model.StatusCode = 1;
                model.Message = null;
                model.Content = MapProvider.Map<BankAccountViewModel>(daAcct.DataRow);
                if (string.IsNullOrEmpty(model.Content.BRANCH_NO))
                {
                    model.Content.BRANCH_NO = "请填写联行号";
                }
                if (!string.IsNullOrEmpty(model.Content.REMARKS))
                {
                    model.Content.REMARKS = xUtils.GetValidateRemarks(model.Content.REMARKS);
                }
            }
            return View(model);
        }
        public JsonResult UpdateBankCardInfo(int id, string cardholder, string cardno, string branch_bank, string branch_no, int? cityId, int? bank_id)
        {
            Tnet_Bank_Account daAcct = new Tnet_Bank_Account();
            if (!daAcct.SelectByPk(id))
            {
                return FailResult("更新失败，找不到银行卡信息");
            }
            if (!string.IsNullOrEmpty(cardholder))
            {
                daAcct.Account_Name = cardholder;
            }
            if (!string.IsNullOrEmpty(cardno))
            {
                daAcct.Card_No = cardno;
            }
            if (!string.IsNullOrEmpty(branch_bank))
            {
                daAcct.Branch_Bank = branch_bank;
            }
            if (!string.IsNullOrEmpty(branch_no))
            {
                daAcct.Branch_No = branch_no;
            }
            if (cityId.HasValue)
            {
                City city = ChinaArea.GetCity(cityId.Value);
                Province province = ChinaArea.GetProvince(city.Province_ID);
                daAcct.City_Id = cityId.Value;
                daAcct.Province_Id = city.Province_ID;
                daAcct.City_Name = city.City_Name;
                daAcct.Province_Name = province.Province_Name;
            }
            if (bank_id.HasValue)
            {
                daAcct.Bank_Id = bank_id.Value;
            }
            if (!daAcct.Update())
            {
                return FailResult("更新银行卡信息失败");
            }
            return SuccessResult();
        }

        public JsonResult AuthBankCard(int id, bool isValid, string refuseReason)
        {
            BankCardProvider card = new BankCardProvider();
            if (!card.Validate(id, isValid, refuseReason, SysUser.UserId))
            {
                return FailResult(card.PromptInfo.CustomMessage);
            }
            return SuccessResult();
        }
    }
}