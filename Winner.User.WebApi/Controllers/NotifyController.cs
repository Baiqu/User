using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Winner.Framework.Utils.Model;
using Winner.GlobalPayUnit.Client;
using Winner.User.Api.Models.Mvc;
using Winner.User.Facade;

namespace Winner.User.Api.Controllers
{
    public class NotifyController : Controller
    {
        [LogRequest("GPU通知")]
        public ActionResult Gpu()
        {
            GpuNotifyProcessProvider notify = new GpuNotifyProcessProvider();
            FuncResult result = notify.Process(Request.InputStream);
            if (result.StatusCode == 200)
            {
                return Content(result.Message);
            }
            else
            {
                return new HttpStatusCodeResult(result.StatusCode, result.Message);
            }

        }
    }
}