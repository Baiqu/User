using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Winner.WebApi.Contract;
using System.Web.Mvc;
using Winner.User.Facade.Recharge;
using Winner.User.Api.Models;
using Winner.User.Entities;
using Winner.User.DataAccess;
using Winner.Data.Validation;

namespace Winner.User.Api.Controllers
{
    public class RechargeController : ApiControllerBase
    {
        public ActionResult CreateOrder(RechargeOrderArgs arg)
        {
            string notifyUrl = AppConfig.GpuNotifyReceiveUrl;
            RechargeOrderCreationProvider orderCreation = new RechargeOrderCreationProvider(Package.UserId, (eBankAccountType)arg.AccountType, (PayType)arg.PayType, arg.Amount, notifyUrl);
            if (!orderCreation.CreateOrder())
            {
                return FailResult(orderCreation.PromptInfo.CustomMessage, (int)orderCreation.PromptInfo.ResultType);
            }
            var data = new
            {
                OrderNo = orderCreation.OrderNo,
                Voucher = orderCreation.Voucher,
                Amount = orderCreation.Amount,
                PayUrl = orderCreation.PayUrl,
            };
            return SuccessResult(data);
        }

        public ActionResult List([EnumDefine(typeof(eBankAccountType))]int accountType)
        {
            Tnet_RechargeCollection daRechargeCollection = new Tnet_RechargeCollection();
            daRechargeCollection.ChangePage = this.ChangePage();
            daRechargeCollection.ListByUserId_AccountType(Package.UserId, (eBankAccountType)accountType);
            List<object> data = new List<object>();
            foreach (Tnet_Recharge recharge in daRechargeCollection)
            {
                var obj = new
                {
                    Amount = recharge.Amount,
                    Subject = recharge.Subject,
                    PayStatus = recharge.Pay_Status,
                    PayType = recharge.Pay_Type,
                    Createtime = recharge.Create_Time,
                };
                data.Add(obj);
            }
            return SuccessResultList(data, daRechargeCollection.ChangePage);
        }
    }
}