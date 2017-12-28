using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Winner.Framework.Utils;
using Winner.Framework.Utils.Model;
using Winner.WebApi.Contract;

namespace Winner.User.Api.Models.Mvc
{
    public class CustomizeHandleErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            string currentUrl = filterContext.HttpContext.Request.Url.AbsoluteUri;
            Log.Error(currentUrl + "异常", filterContext.Exception);
            if (filterContext.Controller is ApiControllerBase)
            {
                string errorMessage = Debuger.IsDebug ? filterContext.Exception.Message : "服务器异常";
                filterContext.Result = new Javirs.Common.MVC.NewtonJsonResult
                {
                    Data = FuncResult.FailResult(errorMessage, 500)
                };
                filterContext.ExceptionHandled = true;

                return;
            }
            base.OnException(filterContext);
        }
    }
}