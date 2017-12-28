using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.Framework.Utils;
using Winner.User.DataAccess;

namespace Winner.User.Facade.VipModules
{    
    public class HandselDeviceCollection
    {
        public static List<HandselDevice> _deviceCollection = new List<HandselDevice>();
        public static HandselDeviceCollection Instance
        {
            get
            {
                if (_deviceCollection == null)
                {
                    _deviceCollection = new List<HandselDevice>();
                }
                if (_deviceCollection.Count <= 0)
                {
                    Tvip_DeviceCollection daDeviceCollection = new Tvip_DeviceCollection();
                    daDeviceCollection.ListAll();
                    _deviceCollection = MapProvider.Map<HandselDevice>(daDeviceCollection.DataTable);
                }
                return new HandselDeviceCollection();
            }
        }

        public List<HandselDevice> FindAll(Predicate<HandselDevice> match)
        {
            return _deviceCollection.FindAll(match);
        }
        public HandselDevice Find(Predicate<HandselDevice> match)
        {
            return _deviceCollection.Find(match);
        }
    }
    /// <summary>
    /// 赠送设备
    /// </summary>
    public class HandselDevice
    {
        public int Device_Id { get; set; }
        public string Device_Name { get; set; }
        public decimal Price { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public int Status { get; set; }
        public string Link_Url { get; set; }
        public string Image_Url { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public DateTime Createtime { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public string Remarks { get; set; }
    }
}
