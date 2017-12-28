using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.Framework.Core.Interface;
using Winner.Framework.Utils;
using Winner.Consignee.DataAccess;
using Winner.Consignee.Entities;
using Winner.Consignee.Providers;
using Winner.Framework.Core.Facade;
using Winner.Consignee.Interfaces;

namespace Winner.Consignee
{
    /// <summary>
    /// 收货地址操作提供程序
    /// </summary>
    public class ConsigneeProvider : FacadeBase
    {
        private static IOwnerVerification OwnerVerify { get; set; }
        /// <summary>
        /// 创建收货地址
        /// </summary>
        /// <param name="address">收货地址信息</param>
        /// <returns></returns>
        public bool Create(ShippingAddress address)
        {
            ConsigneeCreationProvider creationProvider = new ConsigneeCreationProvider(address, OwnerVerify);
            creationProvider.ReferenceTransactionFrom(Transaction);
            if (!creationProvider.Create())
            {
                Alert(creationProvider.PromptInfo);
                return false;
            }
            return true;
        }
        /// <summary>
        /// 创建收货地址
        /// </summary>
        /// <param name="ownerId">收货地址拥有者</param>
        /// <param name="ownerType">收货地址拥有者类型</param>
        /// <param name="isDefault">是否设置为默认地址</param>
        /// <param name="address">详细地址信息</param>
        /// <param name="consigneeName">收件人姓名</param>
        /// <param name="mobileno">收件人联系电话</param>
        /// <param name="regionId">城市行政区ID</param>
        /// <param name="postCode">邮政编码</param>
        /// <param name="tagName">收货地址标签，家，公司等等地址标签</param>
        /// <returns></returns>
        public bool Create(int ownerId, Address_Owner_Type ownerType, bool isDefault, string address, string consigneeName, string mobileno, int regionId, string postCode = null, string tagName = null)
        {
            ShippingAddress shippingAddress = new ShippingAddress
            {
                Is_Default = isDefault ? 1 : 0,
                Is_Del = 0,
                Owner_Id = ownerId,
                Owner_Type = ownerType,
                Tag_Name = tagName,
                Consignee = new ConsigneeInfo
                {
                    Address = address,
                    Consignee_Name = consigneeName,
                    Mobile_No = mobileno,
                    Region_Id = regionId,
                    Post_Code = postCode,
                }
            };
            return Create(shippingAddress);
        }
        /// <summary>
        /// 更新收货地址
        /// </summary>
        /// <param name="address">收货地址信息</param>
        /// <returns></returns>
        public bool Update(ShippingAddress address)
        {
            ConsigneeUpdateProvider updateProvider = new ConsigneeUpdateProvider(address);
            updateProvider.ReferenceTransactionFrom(Transaction);
            if (!updateProvider.Update())
            {
                Alert(updateProvider.PromptInfo);
                return false;
            }
            return true;
        }
        /// <summary>
        /// 更新收货地址
        /// </summary>
        /// <param name="addressId">收货地址ID</param>
        /// <param name="ownerId">拥有者ID，[不更新字段，检查用]</param>
        /// <param name="ownerType">拥有者类型，[不更新字段，检查用]</param>
        /// <param name="isDefault">设置为默认地址</param>
        /// <param name="address">详细地址</param>
        /// <param name="consigneName">收件人姓名</param>
        /// <param name="mobileno">收件人联系电话</param>
        /// <param name="regionId">城市行政区ID</param>
        /// <param name="postCode">邮政编码</param>
        /// <param name="tagName">地址标签</param>
        /// <returns></returns>
        public bool Update(int addressId, bool isDefault, string address, string consigneName, string mobileno, int regionId, string postCode = null, string tagName = null)
        {
            ShippingAddress shippingAddress = new ShippingAddress
            {
                Address_Id = addressId,
                Is_Default = isDefault ? 1 : 0,
                Tag_Name = tagName,
                Consignee = new ConsigneeInfo
                {
                    Address = address,
                    Consignee_Name = consigneName,
                    Mobile_No = mobileno,
                    Post_Code = postCode,
                    Region_Id = regionId,
                }
            };
            return Update(shippingAddress);
        }
        /// <summary>
        /// 删除收货地址
        /// </summary>
        /// <param name="address_id">收货地址ID</param>
        /// <param name="ownerId">拥有者id</param>
        /// <returns></returns>
        public bool Delete(int address_id)
        {
            ConsigneeDeleteProvider deleteProvider = new ConsigneeDeleteProvider(address_id);
            deleteProvider.ReferenceTransactionFrom(Transaction);
            if (!deleteProvider.Delete())
            {
                Alert(deleteProvider.PromptInfo);
                return false;
            }
            return true;
        }
        /// <summary>
        /// 设置收货地址为默认
        /// </summary>
        /// <param name="addressId">收货地址ID</param>
        /// <returns></returns>
        public bool SetDefault(int addressId)
        {
            ConsigneeDefaultProvider updateProvider = new ConsigneeDefaultProvider(addressId);
            updateProvider.ReferenceTransactionFrom(Transaction);
            if (!updateProvider.SetDefault())
            {
                Alert(updateProvider.PromptInfo);
                return false;
            }
            return true;
        }
        /// <summary>
        /// 获取指定的收货地址列表，分页使用 IChangePage 
        /// </summary>
        /// <param name="ownerId">拥有者ID</param>
        /// <param name="ownerType">拥有者类型</param>
        /// <param name="includeDel">是否包含已删除的数据</param>
        /// <returns></returns>
        public List<AddressInfo> List(int ownerId, Address_Owner_Type ownerType, bool includeDel = false)
        {
            var daAddressCollection = new Vnet_Full_AddressCollection();
            daAddressCollection.ChangePage = this.ChangePage;
            daAddressCollection.ListByOwnerId_OwnerType(ownerId, ownerType, includeDel);
            var list = MapProvider.Map<AddressInfo>(daAddressCollection.DataTable);
            return list;
        }
        /// <summary>
        /// 获取指定的默认收货地址（如会员没有默认地址，首选最近添加的地址）
        /// </summary>
        /// <param name="ownerId">拥有者ID</param>
        /// <param name="ownerType">拥有者类型</param>
        /// <returns></returns>
        public AddressInfo GetDefault(int ownerId, Address_Owner_Type ownerType)
        {
            List<AddressInfo> list = List(ownerId, ownerType);
            if (list == null || list.Count == 0)
            {
                return null;
            }
            AddressInfo defaultAddress = list.Find(it => it.IsDefault == 1);
            if (defaultAddress == null)
            {
                defaultAddress = list[0];
            }
            return defaultAddress;
        }
        /// <summary>
        /// 注册拥有者检查程序
        /// </summary>
        /// <param name="verification"></param>
        public static void RegisterOwnerVerification(IOwnerVerification verification)
        {
            OwnerVerify = verification;
        }
        /// <summary>
        /// 根据收货地址ID获取收货地址信息
        /// </summary>
        /// <param name="addressId"></param>
        /// <returns></returns>
        public AddressInfo GetAddressById(int addressId)
        {
            Vnet_Full_Address daAddress = new Vnet_Full_Address();
            if (!daAddress.SelectByAddressId(addressId))
            {
                return null;
            }
            AddressInfo address = MapProvider.Map<AddressInfo>(daAddress.DataRow);
            return address;
        }
    }
}
