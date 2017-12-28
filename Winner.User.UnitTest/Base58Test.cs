using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Javirs.Common;

namespace Winner.User.UnitTest
{
    [TestClass]
    public class Base58Test
    {
        [TestMethod]
        public void Base58EncodeTest()
        {
            string plainText = "58db3b7c56d7eb3756dda94bac9986a59fae695164a890f4190eb165f541c50f98fe663eb7b6b73a";
            string base58 = Base58.Encode(plainText.HexString2ByteArray());
            Debug.WriteLine(base58);
            //5R5EAtaejib8s4Wm89f9ctCs1CYrtSMNvR85ZaVtY841cq4u1QxPXyK
        }
        [TestMethod]
        public void Base58DecodeTest()
        {
            string cipherText = "5R5EAtaejib8s4Wm89f9ctCs1CYrtSMNvR85ZaVtY841cq4u1QxPXyK";
            byte[] res = Base58.Decode(cipherText);
            string plainText = res.Byte2HexString(); //Encoding.UTF8.GetString(res);
            Debug.WriteLine(plainText);
        }
    }
}
