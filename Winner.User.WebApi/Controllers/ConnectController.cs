using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Winner.User.Api.Controllers
{
    public class ConnectController : Controller
    {
        // GET: Connect/service/identity
        // GET: connect/service/bankcard
        // GET: connect/loginpwd/reset
        // GET: connect/loginpwd/change
        // GET: connect/loginpwd/forget
        // GET: connect/paypwd/reset
        // GET: http://api.user.aiwsb.com/user/info
        // GET: http://api.user.aiwsb.com/user/modify
        // GET: http://api.user.aiwsb.com/bankcard/bind
        // GET: http://api.user.aiwsb.com/bankcard/list
        // GET: http://api.user.aiwsb.com/bankcard/delete
        // GET: http://api.user.aiwsb.com/identity/auth
        // GET: http://api.user.aiwsb.com/identity/info
        // GET: http://api.user.aiwsb.com/consignee/create
        // GET: http://api.user.aiwsb.com/consignee/list
        // GET: http://api.user.aiwsb.com/consignee/delete

        public ActionResult Service(string interfaceName)
        {
            return View();
        }
    }
}