using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Winner.User.Api.Models
{
    public class RechargeOrderArgs
    {
        public int AccountType { get; set; }
        public int PayType { get; set; }
        public decimal Amount { get; set; }
    }
}