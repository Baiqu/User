using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Winner.User.WebAdmin.Models
{
    public class BankAccountViewModel
    {
        public int ID { get; set; }
        public int BANK_ID { get; set; }
        public int USER_ID { get; set; }
        public string ACCOUNT_NAME { get; set; }
        public string CARD_NO { get; set; }
        public string BRANCH_NO { get; set; }
        public string BRANCH_BANK { get; set; }
        public string PROVINCE_NAME { get; set; }
        public string CITY_NAME { get; set; }
        public string BANK_NAME { get; set; }
        public string ACCOUNT_TYPE { get; set; }
        public int STATUS { get; set; }        
        public string IMAGE_FULLPATH { get; set; }
        public string REMARKS { get; set; }
        public string CREATETIME { get; set; }
        public int PROVINCE_ID { get; set; }
        public int CITY_ID { get; set; }

    }
}