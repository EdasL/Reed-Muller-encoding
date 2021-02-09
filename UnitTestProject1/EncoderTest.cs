using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using A7;
using System.Collections;

namespace UnitTestProject1
{
    [TestClass]
    public class EncoderTest
    {
        [TestMethod]
        public void TestEncode()
        {
            Encoder encoder1 = new Encoder("11110001", 3, 3);
            encoder1.Encode();
            string expectedResult1 = "11101001";
            Assert.AreEqual(expectedResult1, encoder1.encodedMessage);

            Encoder encoder2 = new Encoder("11110000", 3, 3);
            encoder2.Encode();
            string expectedResult2 = "01101001";
            Assert.AreEqual(expectedResult2, encoder2.encodedMessage);

            Encoder encoder3 = new Encoder("01000100", 3, 2);
            encoder3.Encode();
            string expectedResult3 = "0101000000000000";
            Assert.AreEqual(expectedResult3, encoder3.encodedMessage);
        }
    }
}
