using Javirs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Winner.Framework.MVC;
using Winner.Framework.MVC.Controllers;
using Winner.Framework.Utils.Model;
using Winner.User.DataAccess;
using Winner.User.Facade;
using Winner.User.Interface;

namespace Winner.User.WebAdmin.Controllers
{
    [AuthRight]
    public class IdentityController : TopControllerBase
    {
        // GET: Identity
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetIdentities(string username, string usercode, int? usergrade, DateTime? startdate, DateTime? enddate)
        {
            var daIdentityColl = new Vnet_IdentityCollection();
            daIdentityColl.ChangePage = this.ChangePage();
            if (!daIdentityColl.ListByAdmin(usercode, username, startdate, enddate))
            {
                return FailResult("查询失败");
            }

            List<object> list = daIdentityColl.DataTable.ToDynamic(OnFieldGenerating: (nvp) =>
            {
                if ("remarks".Equals(nvp.Name, StringComparison.OrdinalIgnoreCase))
                {
                    nvp.Value = xUtils.GetValidateRemarks(nvp.Value.ToString());
                }
                return nvp;
            });
            return SuccessResultList(list, daIdentityColl.ChangePage);
        }

        public JsonResult IdentityValidate(int docs_id, bool isValid, string refuseReason)
        {
            AuthenticationProvider provider = new AuthenticationProvider();
            bool res = provider.Validate(docs_id, isValid, SysUser.UserId, refuseReason);
            return res ? this.SuccessResult() : this.FailResult(provider.PromptInfo.CustomMessage);
        }
        public ActionResult Details(int? id)
        {
            return View();
        }
        public JsonResult GetIdentityDetails(int userId)
        {
            var fac = UserModuleFactory.GetUserModuleInstance();
            if (fac == null)
            {
                return FailResult("用户模块加载失败");
            }
            IUser user = fac.GetUserByID(userId);
            if (user == null)
            {
                return FailResult("找不到会员信息");
            }
            Vnet_Identity daIdentity = new Vnet_Identity();
            if (!daIdentity.SelectByUser_Id(user.UserId))
            {
                return FailResult("找不到认证信息");
            }
            var data = new
            {
                User = user,
                IdentityInfo = daIdentity.DataRow.Table.ToDynamic(forceToCollection: false, OnFieldGenerating: nvp =>
                {
                    if ("remarks".Equals(nvp.Name, StringComparison.OrdinalIgnoreCase))
                    {
                        nvp.Value = xUtils.GetValidateRemarks(nvp.Value.ToString());
                    }
                    return nvp;
                })
            };
            return SuccessResult(data);
        }
    }
}