using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Winner.Data.Validation;
using Winner.User.Entities;

namespace Winner.User.Api.Models
{
    public class TradeDetailsArgs
    {
        [Range(1, int.MaxValue, ErrorMessage = "页码格式不正确")]
        public int PageIndex { get; set; }
        [Range(1, 100, ErrorMessage = "每页数据限制在（1-100）")]
        public int PageSize { get; set; }
        [EnumDefine(typeof(eBankAccountType), ErrorMessage = "未定义的账户类型")]
        public int AccountType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}