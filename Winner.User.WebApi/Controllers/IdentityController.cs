using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Winner.Framework.Utils;
using Winner.Framework.Utils.Model;
using Winner.User.Entities;
using Winner.User.Facade;
using Winner.WebApi.Contract;

namespace Winner.User.Api.Controllers
{
    public class IdentityController : ApiControllerBase
    {
        // GET: Identity
        public ActionResult Index()
        {
            return View();
        }
        //提交认证申请
        public JsonResult Auth(AuthIdentityInfo identity)
        {
            AuthenticationProvider provider = new AuthenticationProvider();
            bool res = provider.Authencate(this.Package.UserCode, identity);
            FuncResult result = new FuncResult();
            result.Success = res;
            result.Message = res ? null : provider.PromptInfo.CustomMessage;
            result.StatusCode = res ? 1 : (int)provider.PromptInfo.ResultType;
            Log.Info(JsonProvider.ToJson(result));
            return Json(result);
        }
        //获取提交的认证申请内容
        public JsonResult Info()
        {
            AuthenticationProvider provider = new AuthenticationProvider();
            object info = provider.IdentityInfo(Package.UserCode);
            FuncResult<object> result = new FuncResult<object>();
            result.Success = true;
            result.StatusCode = 1;
            result.Message = null;
            result.Content = info;
            return Json(result);
        }

        public JsonResult RelateAuth(
            [Display(Name = "关联账号"), Required(ErrorMessage = "{0}不能为空")]string RelateUserCode,
            [Display(Name = "支付密码"), Required(ErrorMessage = "{0}不能为空")]string PayPwd)
        {
            string plainPwd;
            if (!xUtils.RsaDecryptPayPwd(PayPwd, out plainPwd))
            {
                return FailResult("支付密码验证失败", (int)ApiStatusCode.DECRYPT_PASSWORD_FAIL);
            }
            AuthenticationProvider provider = new AuthenticationProvider();
            if (!provider.RelateAuth(RelateUserCode, plainPwd, Package.UserCode))
            {
                return FailResult(provider.PromptInfo.CustomMessage, (int)provider.PromptInfo.ResultType);
            }
            return SuccessResult();
        }
    }
}