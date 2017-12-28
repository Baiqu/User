using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Winner.User.Api.Models;
using Winner.WebApi.Contract;

namespace Winner.User.Api.Controllers
{
    public class CreditController : ApiControllerBase
    {
        public ActionResult Index(int id)
        {
            //授信协议
            CreditProtocol protocol = null;
            return View(protocol);
        }
        public ActionResult Protocols()
        {
            List<CreditProtocol> list = new List<CreditProtocol>();
            return SuccessResultList(list);
        }
        public ActionResult Loans()
        {
            //授信列表
            return FailResult("not implement");
        }

        public ActionResult CurrentBill()
        {
            //本期账单
            return FailResult("not implement");
        }

        public ActionResult BillList()
        {
            //账单列表
            return FailResult("not implement");
        }
    }
}