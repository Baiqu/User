using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.Framework.Core.Facade;
using Winner.User.DataAccess;

namespace Winner.User.Facade.Consignee
{
    public class ConsigneeDeleteProvider : FacadeBase
    {
        private int _address_id;
        private int _userId;
        public ConsigneeDeleteProvider(int address_id, int userId)
        {
            this._address_id = address_id;
            this._userId = userId;
        }

        public bool Delete()
        {
            BeginTransaction();
            Tnet_Shipping_Address daAddress = new Tnet_Shipping_Address();
            daAddress.ReferenceTransactionFrom(Transaction);
            if (!daAddress.SelectByPk(_address_id) || daAddress.Is_Del == 1)
            {
                Rollback();
                Alert("指定的收货地址不存在或已删除");
                return false;
            }
            if (daAddress.Owner_Id != _userId)
            {
                Rollback();
                Alert("操作不允许");
                return false;
            }
            daAddress.Is_Del = 1;
            if (!daAddress.Update())
            {
                Rollback();
                Alert("删除收货地址失败");
                return false;
            }
            Commit();
            return true;
        }
    }
}
