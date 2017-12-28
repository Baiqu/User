using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winner.User.Entities
{
    public class BranchBankInfo : BankInfo
    {
        public string BranchNo { get; set; }
        public string BranchName { get; set; }
    }
}
