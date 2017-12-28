using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winner.User.Entities.ViewModels
{
    public class UserModifyModel
    {
        public string UserCode { get; set; }
        public string Avatar { get; set; }
        public int? City_Id { get; set; }
        public int? Org_Id { get; set; }
        public string Industry { get; set; }
    }
}
