using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.Framework.Utils;

namespace Winner.User.Entities
{
    public class BankCardInfo
    {
        public int BankId { get; set; }
        [Required(ErrorMessage = "{0}不能为空"), Display(Name = "银行卡号")]
        public string CardNo { get; set; }
        [Required(ErrorMessage = "{0}不能为空"), Display(Name = "持卡人姓名")]
        public string CardHolder { get; set; }

        public string BranchName { get; set; }
        public string BranchNo { get; set; }
        [Required(ErrorMessage = "{0}不能为空"), Display(Name = "银行卡照片")]
        [RegularExpression("^http://.+$", ErrorMessage = "银行卡照片错误")]
        public string CardImage { get; set; }
        public int City_Id { get; set; }

        public string UserCode { get; set; }

    }
}
