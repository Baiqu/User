using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.Data.Validation;

namespace Winner.Consignee.ViewModels
{
    public class ConsigneeUpdateArgs : ConsigneeCreationArgs
    {
        [RangeNumber, Display(Name = "收货地址ID")]
        public int AddressId { get; set; }
    }
}
