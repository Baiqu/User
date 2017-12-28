using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.Consignee.Entities;
using Winner.Data.Validation;
using System.ComponentModel.DataAnnotations;

namespace Winner.Consignee.ViewModels
{
    public class ConsigneeCreationArgs
    {
        public int OwnerId { get; set; }
        public Address_Owner_Type OwnerType { get; set; }
        [Required, Display(Name = "详细地址")]
        public string Address { get; set; }
        [Required, Display(Name = "收货人")]
        public string ConsigneeName { get; set; }
        [Required, Display(Name = "收货人电话")]
        public string MobileNo { get; set; }
        [RangeNumber]
        public int RegionId { get; set; }
        public int IsDefault { get; set; }
        [Display(Name = "收货地址标签")]
        public string TagName { get; set; }
        [Display(Name = "邮政编码")]
        public string PostCode { get; internal set; }
    }
}
