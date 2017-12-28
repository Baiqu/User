using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Winner.WebApi.Contract;
using Winner.Consignee.ViewModels;
using Winner.Consignee.Entities;
using Winner.Consignee;

namespace Winner.User.Api.Controllers
{
    /// <summary>
    /// 收货地址API控制器
    /// </summary>
    public class ConsigneeController : ApiControllerBase
    {
        /// <summary>
        /// 创建收货地址
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public ActionResult Create(ConsigneeCreationArgs arg)
        {
            ShippingAddress address = new ShippingAddress
            {
                Is_Default = arg.IsDefault,
                Owner_Id = arg.OwnerType == Address_Owner_Type.个人用户 ? Package.UserId : arg.OwnerId,
                Owner_Type = arg.OwnerType,
                Tag_Name = arg.TagName,
                Is_Del = 0,
                Consignee = new ConsigneeInfo
                {
                    Address = arg.Address,
                    Consignee_Name = arg.ConsigneeName,
                    Mobile_No = arg.MobileNo,
                    Post_Code = arg.PostCode,
                    Region_Id = arg.RegionId
                }
            };
            ConsigneeProvider provider = new ConsigneeProvider();
            if (!provider.Create(address))
            {
                return FailResult(provider.PromptInfo.CustomMessage, (int)provider.PromptInfo.ResultType);
            }
            return SuccessResult();
        }
        /// <summary>
        /// 查询所有收货地址
        /// </summary>
        /// <param name="OwnerId"></param>
        /// <param name="OwnerType"></param>
        /// <returns></returns>
        public ActionResult List(int OwnerId, int OwnerType)
        {
            if (OwnerType == (int)Address_Owner_Type.个人用户)
            {
                OwnerId = Package.UserId;
            }
            ConsigneeProvider provider = new ConsigneeProvider();
            provider.ChangePage = this.ChangePage();
            var list = provider.List(OwnerId, (Address_Owner_Type)OwnerType);
            return SuccessResultList(list, provider.ChangePage);
        }
        /// <summary>
        /// 更新收货地址
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public ActionResult Update(ConsigneeUpdateArgs arg)
        {
            ShippingAddress address = new ShippingAddress
            {
                Address_Id = arg.AddressId,
                Is_Default = arg.IsDefault,
                Is_Del = 0,
                Tag_Name = arg.TagName,
                Owner_Id = arg.OwnerType == Address_Owner_Type.个人用户 ? Package.UserId : arg.OwnerId,
                Consignee = new ConsigneeInfo
                {
                    Address = arg.Address,
                    Mobile_No = arg.MobileNo,
                    Post_Code = arg.PostCode,
                    Region_Id = arg.RegionId,
                    Consignee_Name = arg.ConsigneeName
                }
            };
            ConsigneeProvider provider = new ConsigneeProvider();
            if (!provider.Update(address))
            {
                return FailResult(provider.PromptInfo.CustomMessage, (int)provider.PromptInfo.ResultType);
            }
            return SuccessResult();
        }
        /// <summary>
        /// 删除收货地址
        /// </summary>
        /// <param name="AddressId"></param>
        /// <param name="OwnerId"></param>
        /// <param name="OwnerType"></param>
        /// <returns></returns>
        public ActionResult Delete(int AddressId, int OwnerId, int OwnerType)
        {
            if (OwnerType == (int)Address_Owner_Type.个人用户)
            {
                OwnerId = Package.UserId;
            }
            ConsigneeProvider provider = new ConsigneeProvider();
            if (!provider.Delete(AddressId))
            {
                return FailResult(provider.PromptInfo.CustomMessage, (int)provider.PromptInfo.ResultType);
            }
            return SuccessResult();
        }
        /// <summary>
        /// 设置默认收货地址
        /// </summary>
        /// <param name="AddressId"></param>
        /// <returns></returns>
        public ActionResult SetDefault(int AddressId)
        {
            ConsigneeProvider provider = new ConsigneeProvider();
            if (!provider.SetDefault(AddressId))
            {
                return FailResult(provider.PromptInfo.CustomMessage, (int)provider.PromptInfo.ResultType);
            }
            return SuccessResult();
        }
    }
}
