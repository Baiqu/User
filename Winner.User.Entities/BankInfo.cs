using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.Framework.Utils;

namespace Winner.User.Entities
{
    public class BankInfo
    {
        [MapMember("BANK_INFO_ID")]
        public int BankId { get; set; }
        [MapMember("BANK_CHINA_NAME")]
        public string BankName { get; set; }
        public string Bank_Logo { get; set; }
        public int Rank { get; set; }
    }
}
