using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Winner.User.Api.Models
{
    public class CreditProtocol
    {
        public string Protocol_Id { get; set; }
        public string Protocol_Name { get; set; }
        public string ViewName { get; set; }
        public string Installment { get; set; }
        public string Fee_Ratio { get; set; }
        public string Ratio_Type { get; set; }
        public string Overdue_Rate { get; set; }
        public string Billing_Cycle { get; set; }
        public string Free_Interest_Days { get; set; }
        public string Is_Targeted { get; set; }
        public string Createtime { get; set; }
        public string Remarks { get; set; }
        public string Status { get; set; }
        public string Link_Url { get; set; }

    }
}