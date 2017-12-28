using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Winner.Data.Validation;
using Winner.User.DataAccess;
using Winner.User.Facade.User;
using Winner.WebApi.Contract;

namespace Winner.User.Api.Controllers
{
    public class RelationshipController : ApiControllerBase
    {
        /// <summary>
        /// 查询我推荐的会员
        /// </summary>
        /// <returns></returns>
        public ActionResult Recommend()
        {
            var list = RecommendList.GetRecommend(Package.UserId, this.ChangePage());
            return SuccessResultList(list);
        }
        /// <summary>
        /// 分享报告
        /// </summary>
        /// <returns></returns>
        public ActionResult ShareReport([EnumDefine(typeof(Entities.ShareType))]int ShareType)
        {
            Tnet_Share_Report daReport = new Tnet_Share_Report();
            daReport.User_Id = Package.UserId;
            daReport.Share_Type = ShareType;
            daReport.Share_Name = ((Entities.ShareType)ShareType).ToString();
            if (!daReport.Insert())
            {
                return FailResult("保存分享报告失败", (int)ApiStatusCode.DATA_PERSIST_FAIL);
            }
            return SuccessResult();
        }
    }
}