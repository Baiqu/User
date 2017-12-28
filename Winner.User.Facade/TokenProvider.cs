using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winner.User.Facade
{
    public class TokenProvider
    {
        public TokenProvider(string userCode,string token)
        {

        }

        public bool IsValid
        {
            get;set;
        }
    }
}
