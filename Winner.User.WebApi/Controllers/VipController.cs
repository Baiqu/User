using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Winner.User.DataAccess;
using Winner.User.Entities;
using Winner.User.Facade;
using Winner.User.Facade.VipModules;
using Winner.User.Interface;
using Winner.WebApi.Contract;

namespace Winner.User.Api.Controllers
{
    /// <summary>
    /// VIP相关业务控制器
    /// </summary>
    public class VipController : ApiControllerBase
    {
        /// <summary>
        /// 创建VIP缴费订单   POST: /vip/order
        /// </summary>
        /// <returns></returns>
        public ActionResult Order(VipOrderArgs arg)
        {
            arg.UserId = Package.UserId;
            OrderCreationProvider creationProvider = new OrderCreationProvider(arg);
            if (!creationProvider.CreateOrder())
            {
                return FailResult(creationProvider.PromptInfo.CustomMessage, (int)creationProvider.PromptInfo.ResultType);
            }
            var data = new
            {
                OrderNo = creationProvider.OrderNo,
                Voucher = creationProvider.Voucher,
                Amount = creationProvider.Amount,
                PayUrl = creationProvider.PayUrl
            };
            return SuccessResult(data);
        }
        /// <summary>
        /// 支付vip订单   POST: /vip/orderpayment
        /// </summary>
        /// <returns></returns>
        public ActionResult OrderPayment([Display(Name = "订单号"), Required(ErrorMessage = "{0}不能为空")]string OrderNo,
            [Display(Name = "支付密码"), Required]string PayPwd)
        {
            string plainPwd;
            if (!xUtils.RsaDecryptPayPwd(PayPwd, out plainPwd))
            {
                return FailResult("密码解密失败", (int)ApiStatusCode.DECRYPT_PASSWORD_FAIL);
            }
            var fac = UserModuleFactory.GetUserModuleInstance();
            if (fac == null)
            {
                return FailResult("会员模块加载失败", (int)ApiStatusCode.MODULE_LOAD_FAIL);
            }
            IUser user = fac.GetUserByID(Package.UserId);
            if (user == null)
            {
                return FailResult("会员信息加载失败，请重试", (int)ApiStatusCode.DATA_NOT_FOUND);
            }
            if (!user.CheckPayPassword(plainPwd))
            {
                return FailResult(user.PromptInfo.Message);
            }

            OrderPaymentProvider paymentProvider = new OrderPaymentProvider(Package.UserId, OrderNo, Entities.PayType.金币支付, true);
            if (!paymentProvider.Pay())
            {
                return FailResult(paymentProvider.PromptInfo.CustomMessage, (int)paymentProvider.PromptInfo.ResultType);
            }
            return SuccessResult();
        }
        /// <summary>
        /// 用户vip过期时间   POST: /vip/expiretime
        /// </summary>
        /// <returns></returns>
        public ActionResult ExpireTime(int UserLevel)
        {
            Tnet_User_Role daInfo = new Tnet_User_Role();
            if (!daInfo.SelectByUserId_UserLevel(Package.UserId, UserLevel))
            {
                return FailResult("会员还未成为VIP", (int)ApiStatusCode.PARAMETER_CONFLICT);
            }
            var data = new
            {
                ExpireTime = daInfo.Expire_Time,
            };
            return SuccessResult(data);
        }
        /// <summary>
        /// 领取每日奖励   POST: /vip/receivereward
        /// </summary>
        /// <returns></returns>
        public ActionResult ReceiveReward()
        {
            int dateCode = Convert.ToInt32(DateTime.Now.ToString("yyyyMMdd"));
            ReceiveRewardProvider rrp = new ReceiveRewardProvider(dateCode, Package.UserId);
            if (!rrp.ReceiveReward())
            {
                return FailResult(rrp.PromptInfo.CustomMessage, (int)rrp.PromptInfo.ResultType);
            }
            return SuccessResult();
        }
        /// <summary>
        /// VIP奖励信息｛时间，佣金，预期，应收，是否已领取｝
        /// </summary>
        /// <returns></returns>
        public ActionResult RewardInfo()
        {
            object data = null;
            int dateCode = Convert.ToInt32(DateTime.Now.ToString("yyyyMMdd"));
            Tvip_Reward daReward = new Tvip_Reward();

            if (!daReward.SelectByUserId_Datecode(Package.UserId, dateCode))
            {
                data = new
                {
                    Date = dateCode,
                    Commission = 0m,
                    Expect = 0m,
                    Reward = 0m,
                    Is_Received = true
                };
            }
            else
            {
                data = new
                {
                    Date = dateCode,
                    Commission = daReward.Yesterday,
                    Expect = daReward.Expect,
                    Reward = daReward.Amount,
                    Is_Received = daReward.Status == 1,
                };
            }
            return SuccessResult(data);
        }
        /// <summary>
        /// 获取VIP价格列表
        /// </summary>
        /// <returns></returns>
        [IgnoreUserToken]
        public ActionResult SupportDevice()
        {
            List<HandselDevice> list = HandselDeviceCollection.Instance.FindAll(it => it.Status == 1);
            return this.JsonSuccessList(list);
        }
    }
}