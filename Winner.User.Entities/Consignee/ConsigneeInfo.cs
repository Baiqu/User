using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winner.User.Entities.Consignee
{
    public class ConsigneeInfo
    {
        public int Consignee_Id { get; set; }
        public int Region_Id { get; set; }
        public string Address { get; set; }
        public string Post_Code { get; set; }
        public string Consignee_Name { get; set; }
        public string Mobile_No { get; set; }
        public string Remarks { get; set; }
        public DateTime Create_Time { get; set; }

    }
}
