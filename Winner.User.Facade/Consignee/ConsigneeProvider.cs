using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.Framework.Core.Interface;
using Winner.Framework.Utils;
using Winner.User.DataAccess;
using Winner.User.Entities.Consignee;

namespace Winner.User.Facade.Consignee
{
    public class ConsigneeProvider
    {
        public bool Create(UserShippingAddress address)
        {
            ConsigneeCreationProvider creationProvider = new ConsigneeCreationProvider(address);
            return creationProvider.Create();
        }
        public bool Update(UserShippingAddress address)
        {
            ConsigneeUpdateProvider updateProvider = new ConsigneeUpdateProvider(address);
            return updateProvider.Update();
        }
        public bool Delete(int address_id, int userId)
        {
            ConsigneeDeleteProvider deleteProvider = new ConsigneeDeleteProvider(address_id, userId);
            return deleteProvider.Delete();
        }
        public bool SetDefault(int address_id)
        {
            UserShippingAddress address = new UserShippingAddress();
            address.Address_Id = address_id;
            ConsigneeUpdateProvider updateProvider = new ConsigneeUpdateProvider(address);
            return updateProvider.SetDefault();
        }
        public List<UserShippingAddress> List(int userId, IChangePage changePage = null)
        {
            Vnet_User_ConsigneeCollection daAddressCollection = new Vnet_User_ConsigneeCollection();
            daAddressCollection.ChangePage = changePage;
            daAddressCollection.ListByUserId(userId);
            var list = MapProvider.Map<UserShippingAddress>(daAddressCollection.DataTable);
            return list;
        }
    }
}
