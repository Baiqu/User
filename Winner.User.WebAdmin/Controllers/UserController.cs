using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Winner.Framework.MVC;
using Winner.Framework.MVC.Controllers;
using Winner.User.DataAccess;
using Javirs.Common;
using Winner.Framework.Utils.Model;
using Winner.User.Facade;
using Winner.User.Facade.User;
using Winner.User.Interface;
using Winner.User.Entities;

namespace Winner.User.WebAdmin.Controllers
{
    [AuthRight]
    public class UserController : TopControllerBase
    {
        #region 会员信息
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetUsers(string username, string usercode, int? usergrade, DateTime? startdate, DateTime? enddate)
        {
            var daUser = new Vnet_UserCollection();
            daUser.ChangePage = this.ChangePage();
            daUser.ListByAdmin(username, usercode, usergrade, startdate, enddate);

            List<object> list = daUser.DataTable.ToDynamic();
            return SuccessResultList(list, daUser.ChangePage);
        }
        #endregion
        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("index");
            }
            return View();
        }

        public JsonResult GetUserInfo(int userId)
        {
            var fac = UserModuleFactory.GetUserModuleInstance();
            if (fac == null)
            {
                return FailResult("系统错误");
            }
            IUser user = fac.GetUserByID(userId);
            if (user == null)
            {
                return FailResult("找不到用户信息");
            }
            IUser referUser = null;
            if (user.Refer_ID.HasValue)
            {
                referUser = fac.GetUserByID(user.Refer_ID.Value);
            }
            Vnet_Identity daIdentity = new Vnet_Identity();
            bool isAuth = daIdentity.SelectByUser_Id(userId) && daIdentity.Validate_Status == (int)ValidateStatus.审核通过;
            var data = new
            {
                user_id = user.UserId,
                user_name = user.UserName,
                user_code = user.UserCode,
                email = user.Email,
                auth_status = user.Auth_Status,
                status = user.Status,
                avatar = user.Avatar,
                grade_level = user.Grade.Level,
                grade_name = user.Grade.Name,
                register_time = user.Register_Time,
                refer_id = user.Refer_ID,
                refer_code = referUser == null ? null : referUser.UserCode,
                refer_name = referUser == null ? null : referUser.UserName,
                real_name = isAuth ? daIdentity.User_Name : null,
                identity_no = isAuth ? daIdentity.Identity_No : null,
                auth_time = isAuth ? daIdentity.Create_Time : null,
                gender = isAuth ? daIdentity.Gender : null,
                birthday = isAuth ? daIdentity.Birthday : null
            };
            return SuccessResult(data);
        }
        public JsonResult GetUserBankCard(int userId)
        {
            Tnet_Bank_AccountCollection daAccountColl = new Tnet_Bank_AccountCollection();
            daAccountColl.ListByUserId(userId);
            List<object> data = daAccountColl.DataTable.ToDynamic();
            return SuccessResultList(data);
        }
        public JsonResult GetUserAccountInfo(int userId)
        {
            UserAccountProfile account = new UserAccountProfile();
            var list = account.GetProfile(userId);
            return SuccessResultList(list);
        }

        public JsonResult ChangeReferUser(int userId, string refereeCode)
        {
            UserFacade userFacade = new UserFacade();
            if (!userFacade.ChangeReferee(userId, refereeCode, SysUser.UserId))
            {
                return FailResult(userFacade.PromptInfo.CustomMessage);
            }
            return SuccessResult();
        }

        public JsonResult Disable(int user_id, int days, string reason)
        {
            if (days < 0)
            {
                return FailResult("请选择封禁时间");
            }
            if (string.IsNullOrEmpty(reason))
            {
                return FailResult(days == 0 ? "请输入解除封禁的原因" : "请输入封禁原因");
            }
            UserFacade uf = new UserFacade();
            if (days > 0)
            {
                if (!uf.DisableUser(user_id, days, reason, SysUser.UserId))
                {
                    return FailResult(uf.PromptInfo.CustomMessage);
                }
            }
            else
            {
                if (!uf.EnableUser(user_id, reason, SysUser.UserId))
                {
                    return FailResult(uf.PromptInfo.CustomMessage);
                }
            }
            return SuccessResult();
        }
    }
}