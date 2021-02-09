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
            Decoder decoder5 = new Decoder("00100010", 3, 2);
            decoder5.Decode();
            string expectedResult5 = "0001001";
            Assert.AreEqual(expectedResult5, decoder5.decodedMessage);

            Decoder decoder1 = new Decoder("11101001", 3, 3);
            decoder1.Decode();
            string expectedResult1 = "11110001";
            Assert.AreEqual(expectedResult1, decoder1.decodedMessage);

            Decoder decoder2 = new Decoder("01101001", 3, 3);
            decoder2.Decode();
            string expectedResult2 = "11110000";
            Assert.AreEqual(expectedResult2, decoder2.decodedMessage);

            Decoder decoder3 = new Decoder("01010000", 3, 2);
            decoder3.Decode();
            string expectedResult3 = "0100010";
            Assert.AreEqual(expectedResult3, decoder3.decodedMessage);

            Decoder decoder4 = new Decoder("01010000010100000101000001010000", 3, 2);
            decoder4.Decode();
            string expectedResult4 = "0100010010001001000100100010";
            Assert.AreEqual(expectedResult4, decoder4.decodedMessage);
        }
    }
}
