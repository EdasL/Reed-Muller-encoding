using Microsoft.VisualStudio.TestTools.UnitTesting;
using A7;

namespace DecoderTests
{
    [TestClass]
    public class DecoderTest
    {
        [TestMethod]
        public void TestDecode()
        {
            Decoder decoder3 = new Decoder("01010000", 3, 2);
            decoder3.Decode();
            string expectedResult3 = "0100010";
            Assert.AreEqual(expectedResult3, decoder3.decodedMessage);

            //Decoder decoder1 = new Decoder("11101001", 3, 3);
            //decoder1.Decode();
            //string expectedResult1 = "11110001";
           // Assert.AreEqual(expectedResult1, decoder1.decodedMessage);

           // Decoder decoder2 = new Decoder("01101001", 3, 3);
           // decoder2.Decode();
           // string expectedResult2 = "1111000";
           // Assert.AreEqual(expectedResult2, decoder2.decodedMessage);
        }
    }
}
