using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Winner.Framework.Utils;
using Winner.Framework.Utils.Model;
using Winner.User.Api.Models;
using Winner.User.Api.Models.Mvc;
using Winner.User.Entities;
using Winner.User.Interface;
using Winner.User.Interface.Enums;
using Winner.WebApi.Contract;
using Javirs.Common;
using Winner.User.Facade;

namespace Winner.User.Api.Controllers
{

    public class UserController : ApiControllerBase
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult Info()
        {
            UserFacade userFacade = new UserFacade();
            var dic = userFacade.GetUserInfo(this.Package.UserCode);
            FuncResult<object> result = new FuncResult<object>();
            result.Success = true;
            result.Message = null;
            result.StatusCode = 1;
            result.Content = dic;
            return Json(result);
        }
        public JsonResult Modify(Entities.ViewModels.UserModifyModel model)
        {
            FuncResult result = new FuncResult();
            UserFacade uf = new UserFacade();
            result.Success = uf.ModifyUserProfile(model);
            result.Message = result.Success ? null : uf.PromptInfo.CustomMessage;
            result.StatusCode = result.Success ? 1 : (int)uf.PromptInfo.ResultType;
            return Json(result);
        }
        [IgnoreUserToken]
        public JsonResult SendValidCode(int PwdType, string NodeCode)
        {
            Log.Info("PWDTYPE={0}", PwdType);
            string nodecode = string.IsNullOrEmpty(Package.UserCode) ? NodeCode : Package.UserCode;
            FuncResult result = new FuncResult();
            ValidateCodeProvider valid = new ValidateCodeProvider(nodecode, (PasswordType)PwdType);
            result.Success = valid.SendCode();
            result.Message = result.Success ? null : valid.PromptInfo.CustomMessage;
            result.StatusCode = result.Success ? 1 : (int)valid.PromptInfo.ResultType;
            return Json(result);
        }
        [IgnoreUserToken]
        public JsonResult ResetPassword(PasswordResetModel model,string NodeCode)
        {
            Log.Debug(model.ToLineText());
            var fac = UserModuleFactory.GetUserModuleInstance();
            if (fac == null)
            {
                return Json(FuncResult.FailResult("系统错误", 500));
            }
            string nodecode = string.IsNullOrEmpty(Package.UserCode) ? NodeCode : Package.UserCode;
            string newPwd = model.New_Pwd;
            string validateCode = model.ValidateCode;
            if (model.PwdType == (int)PasswordType.支付密码)
            {
                if (!xUtils.RsaDecryptPayPwd(model.New_Pwd, out newPwd))
                {
                    return Json(FuncResult.FailResult("新密码解密失败", (int)ApiStatusCode.DECRYPT_PASSWORD_FAIL));
                }
                if (model.ValidateType == (int)IdentityValidateType.旧密码验证)
                {
                    if (!xUtils.RsaDecryptPayPwd(model.ValidateCode, out validateCode))
                    {
                        return Json(FuncResult.FailResult("旧密码解密失败", (int)ApiStatusCode.DECRYPT_PASSWORD_FAIL));
                    }
                }
            }
            IUser user = fac.GetUserByCode(nodecode);
            if (user == null)
            {
                return FailResult("用户账号[" + nodecode + "]不存在");
            }
            PasswordType passwordType = (PasswordType)model.PwdType;
            var validateType = (IdentityValidateType)model.ValidateType;
            IIdentityVerification verification = IdentityVerificationFactory.GetVerification(validateType, user, passwordType, validateCode);
            if (verification == null)
            {
                return Json(FuncResult.FailResult("指定的身份验证方式不正确", 409));
            }

            IPasswordManager pwdmgt = fac.GetPasswordManager(user);
            PasswordManagerArgs arg = new PasswordManagerArgs
            {
                AlterSource = xUtils.GetClientSource(this.Package.ClientSource),
                NewPassword = newPwd,
                Pwd_Manager = pwdmgt,
                Pwd_Type = passwordType,
                Remarks = string.Format("通过{0}修改", validateType.ToString()),
                UserId = user.UserId,
                Use_Place = this.Package.ClientSystem,
                Verification = verification
            };
            FuncResult result = new FuncResult();
            UserPasswordManager manager = new UserPasswordManager(arg);
            result.Success = manager.Alter();
            result.Message = result.Success ? null : manager.PromptInfo.CustomMessage;
            result.StatusCode = result.Success ? 1 : (int)manager.PromptInfo.ResultType;
            return Json(result);
        }
    }
}