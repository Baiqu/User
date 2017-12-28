using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Winner.Framework.Utils;

namespace Winner.User.Api.Models.Mvc
{
    public class LogRequestAttribute : ActionFilterAttribute
    {
        private string _apiName;
        public LogRequestAttribute(string apiName)
        {
            _apiName = apiName;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            Log.Info($"===================={_apiName}======================START");
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);

            if (filterContext.Result is JsonResult)
            {
                var result = filterContext.Result as JsonResult;
                Log.Info(JsonProvider.ToJson(result.Data));
            }
            else if (filterContext.Result is ContentResult)
            {
                var content = filterContext.Result as ContentResult;
                Log.Info(content.Content);
            }
            Log.Info($"===================={_apiName}======================END");
        }
    }
}