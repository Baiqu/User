using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.Framework.Utils;

namespace Winner.Consignee.Entities
{
    /// <summary>
    /// 收货地址信息
    /// </summary>
    public class AddressInfo
    {
        /// <summary>
        /// 收货地址ID
        /// </summary>
        public int AddressId { get; set; }
        /// <summary>
        /// 地址拥有者
        /// </summary>
        public int OwnerId { get; set; }
        /// <summary>
        /// 拥有者类型
        /// </summary>
        public Address_Owner_Type OwnerType { get; set; }
        /// <summary>
        /// 是否默认，非默认=0，默认=1
        /// </summary>
        public int IsDefault { get; set; }
        /// <summary>
        /// 标签
        /// </summary>
        public string TagName { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 是否已删除
        /// </summary>
        public int IsDel { get; set; }
        /// <summary>
        /// 详细地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 邮政编码
        /// </summary>
        public string PostCode { get; set; }
        /// <summary>
        /// 收件人姓名
        /// </summary>
        public string ConsigneeName { get; set; }
        /// <summary>
        /// 收件人联系电话
        /// </summary>
        public string MobileNo { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }
        /// <summary>
        /// 市区ID
        /// </summary>
        public int RegionId { get; set; }
        /// <summary>
        /// 市区名称
        /// </summary>
        public string RegionName { get; set; }
        /// <summary>
        /// 城市ID
        /// </summary>
        public int CityId { get; set; }
        /// <summary>
        /// 城市名称
        /// </summary>
        public string CityName { get; set; }
        /// <summary>
        /// 省份ID
        /// </summary>
        public int ProvinceId { get; set; }
        /// <summary>
        /// 省份名称
        /// </summary>
        public string ProvinceName { get; set; }

    }
}
