using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Winner.MsgCenter.Client;

namespace Winner.User.UnitTest
{
    [TestClass]
    public class ApnsTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            //string merchantNo = "4008278768000001";
            //string secret = "a1a3e1728ecc9bfe4ca64599f0e661df";
            //MsgCenterClient client = new MsgCenterClient(merchantNo, secret);//, "http://localhost:22806/send");
            //Message message = new Message
            //{
            //    Receiver = "1238",
            //    Parameter = new Dictionary<string, string>
            //    {
            //        {"STORENAME","POS测试商家" },
            //        {"AMOUNT","5000" },
            //        {"INTEGRAL","5000" },
            //    },
            //    SendTime = DateTime.Now,
            //    TemplateNo = "4ac81459c19a7a1844033d92d50808d8",
            //};
            //var res = client.Send("积分到账通知", message);
            //Assert.IsTrue(res);
        }

        [TestMethod]
        public void EncodePassword()
        {
            string cipher = Winner.Framework.Encrypt.SafePassword.Encode(1323, "000123");
            Debug.WriteLine("密码：" + cipher);
        }

        [TestMethod]
        public void DictionaryTest()
        {
            Dictionary<long, int> dictionary = new Dictionary<long, int>();
            for (int i = 0; i < 50; i++)
            {
                Random r = new Random(i);
                int val = r.Next(100000, 999999);
                dictionary.Add(DateTime.Now.Ticks + i, val);

            }
            var firstKey = dictionary.Keys.FirstOrDefault();
            var firstValue = dictionary.Values.FirstOrDefault();
            if (firstValue != dictionary[firstKey])
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void xOrTest()
        {
            int x = 3;//00000011
            int o = 1;//00000001
            int r = x ^ o;
            Assert.IsTrue(r == 2);
        }
    }
}
