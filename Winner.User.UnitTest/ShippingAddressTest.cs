using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Winner.Consignee;
using Winner.Consignee.Entities;
using System.Diagnostics;

namespace Winner.User.UnitTest
{
    [TestClass]
    public class ShippingAddressTest
    {
        [TestMethod]
        public void CreateTest()
        {
            int ownerId = 3999999;
            Address_Owner_Type ownerType = Address_Owner_Type.个人用户;
            string address = "新安街道留仙一路高新奇科技园";
            string consigneeName = "Jason";
            string mobileno = "18600001111";
            int regionId = 2334;
            ConsigneeProvider provider = new ConsigneeProvider();
            bool res = provider.Create(ownerId, ownerType, false, address, consigneeName, mobileno, regionId);
            Assert.IsTrue(res);
        }

        [TestMethod]
        public void UpdateTest()
        {
            bool isDefault = false;
            string tagName = "英雄会公司";
            string postCode = null;
            string address = null;//"a new address";
            string consigneName = null;// "张先生";
            string mobileno = "18600001221";
            int regionId = 0;
            int addressId = 11;

            ConsigneeProvider provider = new ConsigneeProvider();
            bool res = provider.Update(addressId, isDefault, address, consigneName, mobileno, regionId, postCode, tagName);
            if (!res)
            {
                Debug.WriteLine(provider.PromptInfo.Message);
            }
            Assert.IsTrue(res);
        }

        [TestMethod]
        public void SetDefaultTest()
        {
            int addressId = 2;
            ConsigneeProvider provider = new ConsigneeProvider();
            bool res = provider.SetDefault(addressId);
            Assert.IsTrue(res);
        }

        [TestMethod]
        public void DeleteTest()
        {
            int addressId = 1;
            ConsigneeProvider provider = new ConsigneeProvider();
            bool res = provider.Delete(addressId);
            Assert.IsTrue(res);
        }
        [TestMethod]
        public void GetListTest()
        {
            int ownerId = 3999999;
            Address_Owner_Type ownerType = Address_Owner_Type.个人用户;
            ConsigneeProvider provider = new ConsigneeProvider();
            List<Winner.Consignee.Entities.AddressInfo> list = provider.List(ownerId, ownerType);
            Assert.IsTrue(list != null && list.Count > 0);
        }
    }
}
