using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.Data.Validation;

namespace Winner.Consignee.Entities
{
    public class ConsigneeInfo
    {
        public int Consignee_Id { get; set; }
        [RangeNumber(1, int.MaxValue, ErrorMessage = "请输入有效的市行政区ID"), Display(Name = "市行政区ID", GroupName = "create")]
        public int Region_Id { get; set; }
        [Required(ErrorMessage = "{0}不能为空"), Display(Name = "详细地址", GroupName = "create")]
        public string Address { get; set; }
        public string Post_Code { get; set; }
        [Required, Display(Name = "收货人姓名", GroupName = "create")]
        public string Consignee_Name { get; set; }
        [Required, Display(Name = "收货人联系电话", GroupName = "create")]
        public string Mobile_No { get; set; }
        public string Remarks { get; set; }
        public DateTime Create_Time { get; set; }

    }
}
