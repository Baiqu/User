using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Winner.User.Facade;
using System.Diagnostics;
using Winner.CU.Cache.CommonFacade;
using Winner.User.Interface;
using System.Collections.Generic;
using Javirs.Common;

namespace Winner.User.UnitTest
{
    [TestClass]
    public class BizTest
    {
        [TestMethod]
        public void IdentityValidateTest()
        {
            int docs_id = 12;
            AuthenticationProvider auth = new AuthenticationProvider();
            bool res = auth.Validate(docs_id, true, 1, null);
            string message = auth.PromptInfo.CustomMessage;
            Debug.WriteLine(message);
            Assert.IsTrue(res);
        }

        [TestMethod]
        public void CheckPaypwdTest()
        {
            UserClient client = new UserClient("18675534882");
            if (!client.IsExist)
            {
                Assert.Fail();
            }
            var res = client.CheckUserPayPwd("123456");
            Assert.IsTrue(res != null && res.IsSuccess);
        }

        [TestMethod]
        public void UserInfoPayPwdCheckTest()
        {
            var fac = UserModuleFactory.GetUserModuleInstance();
            IUser user = fac.GetUserByCode("18675534882");
            bool res = user.CheckPayPassword("123456");
            Assert.IsTrue(res);
        }

        [TestMethod]
        public void GlobalConsumeTest()
        {
            const string merchantNo = "GlobalConsume";
            const string secret = "6DCEBE1382D144FA9E1EFF169D4D325E";
            var client = new WebApi.Contract.ApiContractClient(merchantNo, secret, "http://api.aiwsb.com/consume/globalconsume");
            var option = new
            {
                User_Id = "1292",
                Store_Id = "19",
                Subject = "测试混合支付分账",
                Order_No = "TEST201705100001",
                Amount = "1000",
                Profit = "200",
                ConsumePlace = "4",
                Bills = new List<object>
                {
                    new { Amount = 400m, PayType=eBankAccountType.E币 },
                    new { Amount = 600m, PayTYpe=eBankAccountType.现金 }
                }
            };
            var result = client.Put(option).Post<OrderInfo>();
            Assert.IsTrue(result != null && result.Success);
        }

        [TestMethod]
        public void ChangeRefereeTest()
        {
            UserFacade userFacade = new UserFacade();
            bool res = userFacade.ChangeReferee(1297, "13422893527", 1);
            Assert.IsTrue(res);
        }
        public enum eBankAccountType
        {
            积分 = 1,
            爱心 = 2,
            E币 = 3,
            现金 = 4,
        }
        [TestMethod]
        public void UserClientTest()
        {
            UserClient client = new UserClient(1238);
            bool res = client.IsExist;
            Assert.IsTrue(res);
        }

        [TestMethod]
        public void TestTimestamp()
        {
            TimeStamp timestamp = DateTime.Now;
            WebApi.Contract.TimeStampValidationAttribute attr = new WebApi.Contract.TimeStampValidationAttribute();
            bool res = attr.IsValid("1495421925");
            if (timestamp - 1495421925 > 600)
            {
                Debug.Write("ffff");
            }
            Assert.IsTrue(res);
        }
        public class OrderInfo
        {
            /// <summary>
            /// 订单ID
            /// <para>
            /// defaultValue:    Length: 22Byte
            /// </para>
            /// </summary>
            public int Order_Id { get; set; }
            /// <summary>
            /// 用户ID
            /// <para>
            /// defaultValue:    Length: 22Byte
            /// </para>
            /// </summary>
            public int User_Id { get; set; }
            /// <summary>
            /// 商户ID
            /// <para>
            /// defaultValue:    Length: 22Byte
            /// </para>
            /// </summary>
            public int Store_Id { get; set; }
            /// <summary>
            /// 消费主题
            /// <para>
            /// defaultValue:    Length: 100Byte
            /// </para>
            /// </summary>
            public string Subject { get; set; }
            /// <summary>
            /// 全局消费单号$AUTOINCREASE$
            /// <para>
            /// defaultValue:    Length: 50Byte
            /// </para>
            /// </summary>
            public string Sys_Order_No { get; set; }
            /// <summary>
            /// 消费订单号
            /// <para>
            /// defaultValue:    Length: 50Byte
            /// </para>
            /// </summary>
            public string Mer_Order_No { get; set; }
            /// <summary>
            /// 消费金额，单位元
            /// <para>
            /// defaultValue:    Length: 22Byte
            /// </para>
            /// </summary>
            public decimal Amount { get; set; }
            /// <summary>
            /// 订单利润，单位元
            /// <para>
            /// defaultValue:    Length: 22Byte
            /// </para>
            /// </summary>
            public decimal Profit { get; set; }
            /// <summary>
            /// 消费场景
            /// <para>
            /// defaultValue:    Length: 22Byte
            /// </para>
            /// </summary>
            public int Consume_Place { get; set; }
            /// <summary>
            /// 是否结算
            /// <para>
            /// defaultValue: 0    Length: 22Byte
            /// </para>
            /// </summary>
            public int Is_Settled { get; set; }
            /// <summary>
            /// 创建时间
            /// <para>
            /// defaultValue: SYSDATE    Length: 7Byte
            /// </para>
            /// </summary>
            public DateTime Createtime { get; set; }
        }
    }
}
