using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winner.User.Entities
{
    public class AuthIdentityInfo
    {
        /// <summary>
        /// 认证姓名
        /// </summary>
        [Required(ErrorMessage = "{0}不能为空"), Display(Name = "真实姓名")]
        public string RealName { get; set; }
        /// <summary>
        /// 证件号码
        /// </summary>
        [Required(ErrorMessage = "{0}不能为空"), Display(Name = "证件号码")]
        public string ID_NO { get; set; }
        /// <summary>
        /// 证件正面照片
        /// </summary>
        [Required(ErrorMessage = "{0}不能为空"), Display(Name = "证件照片")]
        public string Front_Photo { get; set; }
        /// <summary>
        /// 证件反面照片
        /// </summary>
        [Required(ErrorMessage = "{0}不能为空"), Display(Name = "证件照片")]
        public string Back_Photo { get; set; }
        /// <summary>
        /// 手持证件照片
        /// </summary>
        [Required(ErrorMessage = "{0}不能为空"), Display(Name = "证件照片")]
        public string Scene_Photo { get; set; }
        /// <summary>
        /// 户籍所在地址
        /// </summary>
        [Display(Name = "户籍所在地址")]
        public string Address { get; set; }
        /// <summary>
        /// 签发机关
        /// </summary>
        [Display(Name = "签发机关")]
        public string Issuing { get; set; }
        /// <summary>
        /// 证件生效时间
        /// </summary>
        [Display(Name = "证件生效时间")]
        public DateTime? Begin_Date { get; set; }
        /// <summary>
        /// 证件过期时间
        /// </summary>
        [Display(Name = "证件过期时间")]
        public DateTime? EndDate { get; set; }
        [Display(Name = "民族")]
        public string Nation { get; set; }
        /// <summary>
        /// 市区ID
        /// </summary>        
        public int Region_Id { get; set; }
        /// <summary>
        /// 活体验证得分
        /// </summary>
        public int Score { get; set; }
    }
}
