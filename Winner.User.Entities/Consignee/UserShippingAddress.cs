using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Winner.User.Entities.Consignee
{
    public class UserShippingAddress
    {

        public int Address_Id { get; set; }
        public int User_Id { get; set; }
        [Required(ErrorMessage = "{0}不能为空"), Display(Name = "收货人姓名")]
        public string Consignee_Name { get; set; }
        [Required(ErrorMessage = "{0}不能为空"), Display(Name = "收货人电话")]
        public string Mobile_No { get; set; }
        [Required(ErrorMessage = "{0}不能为空"), Display(Name = "详细地址")]
        public string Address { get; set; }
        public string Post_Code { get; set; }
        public string Create_Time { get; set; }
        public int Is_Default { get; set; }
        public string Tag_Name { get; set; }
        public int Is_Del { get; set; }
        [Range(0.1, int.MaxValue, ErrorMessage = "{0}不能为空"), Display(Name = "城市ID")]
        public int Region_Id { get; set; }
        public string Region_Name { get; set; }
        public int City_Id { get; set; }
        public string City_Name { get; set; }
        public int Province_Id { get; set; }
        public string Province_Name { get; set; }
        public int Consignee_Id { get; set; }

    }
}
