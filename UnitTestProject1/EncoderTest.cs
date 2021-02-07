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
        public void TestCreateSubsetsMethod()
        {
            List<int[]> exampleArrays = new List<int[]>();
            exampleArrays.Add(new int[] { 1, 2, 3 });
            exampleArrays.Add(new int[] { 1, 2, 3, 4 });

            List<List<int[]>> expectedResults = new List<List<int[]>>();

            List<int[]> expectedResult1 = new List<int[]>();
            expectedResult1.Add(new int[] { 1, 2 });
            expectedResult1.Add(new int[] { 1, 3 });
            expectedResult1.Add(new int[] { 2, 3 });
            expectedResult1.Add(new int[] { 1, 2, 3 });

            List<int[]> expectedResult2 = new List<int[]>();
            expectedResult2.Add(new int[] { 1, 2 });
            expectedResult2.Add(new int[] { 1, 3 });
            expectedResult2.Add(new int[] { 2, 3 });
            expectedResult2.Add(new int[] { 1, 4 });
            expectedResult2.Add(new int[] { 2, 4 });
            expectedResult2.Add(new int[] { 3, 4 });
            expectedResult2.Add(new int[] { 1, 2, 3 });
            expectedResult2.Add(new int[] { 1, 2, 4 });
            expectedResult2.Add(new int[] { 1, 3, 4 });
            expectedResult2.Add(new int[] { 2, 3, 4 });
            expectedResult2.Add(new int[] { 1, 2, 3, 4 });

            expectedResults.Add(expectedResult1);
            expectedResults.Add(expectedResult2);

            Encoder encoder = new Encoder("test message", 2, 4);

            List<int[]> actualResult1 = encoder.CreateSubsets(exampleArrays[0]);
            CollectionAssert.AreEqual(expectedResult1[0], actualResult1[0]);
            CollectionAssert.AreEqual(expectedResult1[1], actualResult1[1]);
            CollectionAssert.AreEqual(expectedResult1[2], actualResult1[2]);
            CollectionAssert.AreEqual(expectedResult1[3], actualResult1[3]);

            List<int[]> actualResult2 = encoder.CreateSubsets(exampleArrays[1]);
            CollectionAssert.AreEqual(expectedResult2[0], actualResult2[0]);
            CollectionAssert.AreEqual(expectedResult2[1], actualResult2[1]);
            CollectionAssert.AreEqual(expectedResult2[2], actualResult2[2]);
            CollectionAssert.AreEqual(expectedResult2[3], actualResult2[3]);
            CollectionAssert.AreEqual(expectedResult2[4], actualResult2[4]);
            CollectionAssert.AreEqual(expectedResult2[5], actualResult2[5]);
            CollectionAssert.AreEqual(expectedResult2[6], actualResult2[6]);
            CollectionAssert.AreEqual(expectedResult2[7], actualResult2[7]);
            CollectionAssert.AreEqual(expectedResult2[8], actualResult2[8]);
            CollectionAssert.AreEqual(expectedResult2[9], actualResult2[9]);
            CollectionAssert.AreEqual(expectedResult2[10], actualResult2[10]);
        }

        [TestMethod]
        public void TestGetGeneratingVariables()
        {
            int[] maxValues = new int[] { 1, 3, 7, 15 };

            List<int[]> expectedResults1 = new List<int[]>();
            expectedResults1.Add(new int[] { 0 });
            expectedResults1.Add(new int[] { 1 });
            Encoder encoder1 = new Encoder("test message", 1, 0);
            List<int[]> actualResult1 = encoder1.GetGeneratingVariables(maxValues[0]);
            CollectionAssert.AreEqual(expectedResults1[0], actualResult1[0]);
            CollectionAssert.AreEqual(expectedResults1[1], actualResult1[1]);

            List<int[]> expectedResults2 = new List<int[]>();
            expectedResults2.Add(new int[] { 0, 0 });
            expectedResults2.Add(new int[] { 0, 1 });
            expectedResults2.Add(new int[] { 1, 0 });
            expectedResults2.Add(new int[] { 1, 1 });
            Encoder encoder2 = new Encoder("test message", 2, 0);
            List<int[]> actualResult2 = encoder2.GetGeneratingVariables(maxValues[1]);
            CollectionAssert.AreEqual(expectedResults2[0], actualResult2[0]);
            CollectionAssert.AreEqual(expectedResults2[1], actualResult2[1]);
            CollectionAssert.AreEqual(expectedResults2[2], actualResult2[2]);
            CollectionAssert.AreEqual(expectedResults2[3], actualResult2[3]);

            List<int[]> expectedResults3 = new List<int[]>();
            expectedResults3.Add(new int[] { 0, 0, 0 });
            expectedResults3.Add(new int[] { 0, 0, 1 });
            expectedResults3.Add(new int[] { 0, 1, 0 });
            expectedResults3.Add(new int[] { 0, 1, 1 });
            expectedResults3.Add(new int[] { 1, 0, 0 });
            expectedResults3.Add(new int[] { 1, 0, 1 });
            expectedResults3.Add(new int[] { 1, 1, 0 });
            expectedResults3.Add(new int[] { 1, 1, 1 });
            Encoder encoder3 = new Encoder("test message", 3, 0);
            List<int[]> actualResult3 = encoder3.GetGeneratingVariables(maxValues[2]);
            CollectionAssert.AreEqual(expectedResults3[0], actualResult3[0]);
            CollectionAssert.AreEqual(expectedResults3[1], actualResult3[1]);
            CollectionAssert.AreEqual(expectedResults3[2], actualResult3[2]);
            CollectionAssert.AreEqual(expectedResults3[3], actualResult3[3]);
            CollectionAssert.AreEqual(expectedResults3[4], actualResult3[4]);
            CollectionAssert.AreEqual(expectedResults3[5], actualResult3[5]);
            CollectionAssert.AreEqual(expectedResults3[6], actualResult3[6]);
            CollectionAssert.AreEqual(expectedResults3[7], actualResult3[7]);
        }

        [TestMethod]
        public void TestCreateVectorIntArray()
        {
            List<int[]> generatorValues1 = new List<int[]>();
            generatorValues1.Add(new int[] { 0 });
            generatorValues1.Add(new int[] { 1 });

            List<int[]> expectedVectors1 = new List<int[]>();
            expectedVectors1.Add(new int[] { 1, 1 });
            expectedVectors1.Add(new int[] { 1, 0 });

            Encoder encoder1 = new Encoder("test message", 1, 0);

            int[] actualVector10 = encoder1.CreateVectorIntArray(generatorValues1, 0);
            CollectionAssert.AreEqual(expectedVectors1[0], actualVector10);

            int[] actualVector11 = encoder1.CreateVectorIntArray(generatorValues1, 1);
            CollectionAssert.AreEqual(expectedVectors1[1], actualVector11);

            List<int[]> generatorValues2 = new List<int[]>();
            generatorValues2.Add(new int[] { 0, 0 });
            generatorValues2.Add(new int[] { 0, 1 });
            generatorValues2.Add(new int[] { 1, 0 });
            generatorValues2.Add(new int[] { 1, 1 });

            List<int[]> expectedVectors2 = new List<int[]>();
            expectedVectors2.Add(new int[] { 1, 1, 1, 1 });
            expectedVectors2.Add(new int[] { 1, 1, 0, 0 });
            expectedVectors2.Add(new int[] { 1, 0, 1, 0 });

            Encoder encoder2 = new Encoder("test message", 2, 0);
            
            int[] actualVector20 = encoder2.CreateVectorIntArray(generatorValues2, 0);
            CollectionAssert.AreEqual(expectedVectors2[0], actualVector20);

            int[] actualVector21 = encoder2.CreateVectorIntArray(generatorValues2, 1);
            CollectionAssert.AreEqual(expectedVectors2[1], actualVector21);

            int[] actualVector22 = encoder2.CreateVectorIntArray(generatorValues2, 2);
            CollectionAssert.AreEqual(expectedVectors2[2], actualVector22);

            List<int[]> generatorValues3 = new List<int[]>();
            generatorValues3.Add(new int[] { 0, 0, 0 });
            generatorValues3.Add(new int[] { 0, 0, 1 });
            generatorValues3.Add(new int[] { 0, 1, 0 });
            generatorValues3.Add(new int[] { 0, 1, 1 });
            generatorValues3.Add(new int[] { 1, 0, 0 });
            generatorValues3.Add(new int[] { 1, 0, 1 });
            generatorValues3.Add(new int[] { 1, 1, 0 });
            generatorValues3.Add(new int[] { 1, 1, 1 });


            List<int[]> expectedVectors3 = new List<int[]>();
            expectedVectors3.Add(new int[] { 1, 1, 1, 1, 1, 1, 1, 1 });
            expectedVectors3.Add(new int[] { 1, 1, 1, 1, 0, 0, 0, 0 });
            expectedVectors3.Add(new int[] { 1, 1, 0, 0, 1, 1, 0, 0 });
            expectedVectors3.Add(new int[] { 1, 0, 1, 0, 1, 0, 1, 0 });

            Encoder encoder3 = new Encoder("test message", 3, 0);

            int[] actualVector30 = encoder3.CreateVectorIntArray(generatorValues3, 0);
            CollectionAssert.AreEqual(expectedVectors3[0], actualVector30);

            int[] actualVector31 = encoder3.CreateVectorIntArray(generatorValues3, 1);
            CollectionAssert.AreEqual(expectedVectors3[1], actualVector31);

            int[] actualVector32 = encoder3.CreateVectorIntArray(generatorValues3, 2);
            CollectionAssert.AreEqual(expectedVectors3[2], actualVector32);

            int[] actualVector33 = encoder3.CreateVectorIntArray(generatorValues3, 3);
            CollectionAssert.AreEqual(expectedVectors3[3], actualVector33);
        }

        [TestMethod]
        public void TestMultiplyVectors()
        {
            Encoder encoder = new Encoder("test message", 2, 0);

            int[] vector1 = new int[] { 1, 0, 1, 0 };
            int[] vector2 = new int[] { 1, 1, 1, 1 };
            int[] expectedResult = new int[] { 1, 0, 1, 0 };

            int[] actualResult = encoder.MultiplyVectors(vector1, vector2);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestMultiplyMessageWithGeneratorMatrix()
        {
            Encoder encoder = new Encoder("test message", 3, 3);

            List<int[]> generatorMatrix = new List<int[]>();
            generatorMatrix.Add(new int[] { 1, 1, 1, 1, 1, 1, 1, 1 });
            generatorMatrix.Add(new int[] { 1, 1, 1, 1, 0, 0, 0, 0 });
            generatorMatrix.Add(new int[] { 1, 1, 0, 0, 1, 1, 0, 0 });
            generatorMatrix.Add(new int[] { 1, 0, 1, 0, 1, 0, 1, 0 });
            generatorMatrix.Add(new int[] { 1, 1, 0, 0, 0, 0, 0, 0 });
            generatorMatrix.Add(new int[] { 1, 0, 1, 0, 0, 0, 0, 0 });
            generatorMatrix.Add(new int[] { 1, 0, 0, 0, 1, 0, 0, 0 });
            generatorMatrix.Add(new int[] { 1, 0, 0, 0, 0, 0, 0, 0 });

            List<int[]> message1 = new List<int[]>();
            message1.Add(new int[] { 1, 1, 1, 1, 0, 0, 0, 1 });

            List<int> expectedResult1 = new List<int>();
            expectedResult1.Add(1);
            expectedResult1.Add(1);
            expectedResult1.Add(1);
            expectedResult1.Add(0);
            expectedResult1.Add(1);
            expectedResult1.Add(0);
            expectedResult1.Add(0);
            expectedResult1.Add(1);

            List<int> actualResult1 = encoder.MultiplyMessageWithGeneratorMatrix(message1, generatorMatrix);
            CollectionAssert.AreEqual(expectedResult1, actualResult1);

            List<int[]> message2 = new List<int[]>();
            message2.Add(new int[] { 1, 1, 1, 1, 0, 0, 0, 1 });
            message2.Add(new int[] { 1, 1, 1, 1, 0, 0, 0, 0 });
            message2.Add(new int[] { 1, 0, 0, 0, 0, 0, 0, 1 });

            List<int> expectedResult2 = new List<int>();
            expectedResult2.Add(1);
            expectedResult2.Add(1);
            expectedResult2.Add(1);
            expectedResult2.Add(0);
            expectedResult2.Add(1);
            expectedResult2.Add(0);
            expectedResult2.Add(0);
            expectedResult2.Add(1);

            expectedResult2.Add(0);
            expectedResult2.Add(1);
            expectedResult2.Add(1);
            expectedResult2.Add(0);
            expectedResult2.Add(1);
            expectedResult2.Add(0);
            expectedResult2.Add(0);
            expectedResult2.Add(1);

            expectedResult2.Add(0);
            expectedResult2.Add(1);
            expectedResult2.Add(1);
            expectedResult2.Add(1);
            expectedResult2.Add(1);
            expectedResult2.Add(1);
            expectedResult2.Add(1);
            expectedResult2.Add(1);

            List<int> actualResult2 = encoder.MultiplyMessageWithGeneratorMatrix(message2, generatorMatrix);;

            CollectionAssert.AreEqual(expectedResult2, actualResult2);
        }

        [TestMethod]
        public void TestEncode()
        {
            Encoder encoder1 = new Encoder("11110001", 3, 3);
            encoder1.Encode();
            string expectedResult1 = "11101001";
            Assert.AreEqual(expectedResult1, encoder1.encodedMessage);

            Encoder encoder2 = new Encoder("1111000", 3, 3);
            encoder2.Encode();
            string expectedResult2 = "01101001";
            Assert.AreEqual(expectedResult2, encoder2.encodedMessage);
        }
    }
}
