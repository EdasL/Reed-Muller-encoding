using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using A7;


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
            expectedResult2.Add(new int[] { 1, 2, 3 });
            expectedResult2.Add(new int[] { 1, 4 });
            expectedResult2.Add(new int[] { 2, 4 });
            expectedResult2.Add(new int[] { 1, 2, 4 });
            expectedResult2.Add(new int[] { 3, 4 });
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
    }
}
