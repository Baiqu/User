using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Winner.Data.Validation;

namespace Winner.Consignee.Entities
{
    /// <summary>
    /// 收货地址信息
    /// </summary>
    public class ShippingAddress
    {
        /// <summary>
        /// 收货地址ID，更新、删除时必须填写
        /// </summary>
        [RangeNumber(1, int.MaxValue), Display(Name = "收货地址编号", GroupName = "update|delete")]
        public int Address_Id { get; set; }
        /// <summary>
        /// 拥有者ID，新增时必须填写
        /// </summary>
        [RangeNumber(1, int.MaxValue), Display(Name = "收货地址拥有者ID", GroupName = "create")]
        public int Owner_Id { get; set; }
        /// <summary>
        /// 拥有者类型
        /// </summary>
        public Address_Owner_Type Owner_Type { get; set; }
        /// <summary>
        /// 是否默认地址，取值0或1
        /// </summary>
        [RangeNumber(0, 1), Display(Name = "是否默认地址")]
        public int Is_Default { get; set; }
        /// <summary>
        /// 收货地址标签
        /// </summary>
        public string Tag_Name { get; set; }

        /// <summary>
        /// 收货人信息
        /// </summary>
        [Required, Display(Name = "收货人信息", GroupName = "create")]
        public ConsigneeInfo Consignee { get; set; }

        /// <summary>
        /// 收货地址创建时间
        /// </summary>
        public DateTime Create_Time { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public int Is_Del { get; set; }

    }
}
