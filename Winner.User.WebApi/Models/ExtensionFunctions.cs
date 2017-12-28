using Javirs.Common.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Winner.Framework.MVC.Controllers;
using Winner.Framework.MVC.Models;
using Winner.Framework.Utils.Model;
using Winner.WebApi.Contract;

namespace Winner.User.Api
{
    public static class ExtensionFunctions
    {
        public static JsonResult JsonSuccessList<T>(this Controller controller, List<T> list)
        {
            FuncResult<List<T>> data = new FuncResult<List<T>>();
            data.Success = true;
            data.StatusCode = 1;
            data.Message = null;
            data.Content = list;
            JsonNetResult result = new JsonNetResult();
            result.Data = data;
            result.JsonRequestBehavior = JsonRequestBehavior.DenyGet;
            return result;
        }

        public static MvcChangePage ChangePage(this ApiControllerBase ac)
        {
            string data = ac.Request.Form["Data"];
            JsonObject jsobj = JsonObject.Parse(data);
            int PageIndex = jsobj.GetInt(nameof(PageIndex));
            int PageSize = jsobj.GetInt(nameof(PageSize));
            MvcChangePage change = new MvcChangePage(PageIndex, PageSize, null, Framework.Core.SortType.DESC);
            return change;
        }
    }
}