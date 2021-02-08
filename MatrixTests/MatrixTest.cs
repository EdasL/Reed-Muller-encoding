using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using A7;

namespace MatrixTests
{
    [TestClass]
    public class MatrixTest
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

            Matrix matrix = new Matrix(2, 4);

            List<int[]> actualResult1 = matrix.CreateSubsets(exampleArrays[0]);
            CollectionAssert.AreEqual(expectedResult1[0], actualResult1[0]);
            CollectionAssert.AreEqual(expectedResult1[1], actualResult1[1]);
            CollectionAssert.AreEqual(expectedResult1[2], actualResult1[2]);
            CollectionAssert.AreEqual(expectedResult1[3], actualResult1[3]);

            List<int[]> actualResult2 = matrix.CreateSubsets(exampleArrays[1]);
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
            Matrix matrix1 = new Matrix(1, 0);
            List<int[]> actualResult1 = matrix1.GetGeneratingVariables(maxValues[0], 1);
            CollectionAssert.AreEqual(expectedResults1[0], actualResult1[0]);
            CollectionAssert.AreEqual(expectedResults1[1], actualResult1[1]);

            List<int[]> expectedResults2 = new List<int[]>();
            expectedResults2.Add(new int[] { 0, 0 });
            expectedResults2.Add(new int[] { 0, 1 });
            expectedResults2.Add(new int[] { 1, 0 });
            expectedResults2.Add(new int[] { 1, 1 });
            Matrix matrix2 = new Matrix(2, 0);
            List<int[]> actualResult2 = matrix2.GetGeneratingVariables(maxValues[1], 2);
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

            Matrix matrix3 = new Matrix(3, 0);
            List<int[]> actualResult3 = matrix3.GetGeneratingVariables(maxValues[2], 3);
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
            List<int[]> expectedVectors1 = new List<int[]>();
            expectedVectors1.Add(new int[] { 1, 1 });
            expectedVectors1.Add(new int[] { 1, 0 });

            Matrix matrix1 = new Matrix(1, 0);
            matrix1.CreateGeneratorMatrix();

            int[] actualVector10 = matrix1.CreateVectorIntArray(0);
            CollectionAssert.AreEqual(expectedVectors1[0], actualVector10);

            int[] actualVector11 = matrix1.CreateVectorIntArray(1);
            CollectionAssert.AreEqual(expectedVectors1[1], actualVector11);

            List<int[]> expectedVectors2 = new List<int[]>();
            expectedVectors2.Add(new int[] { 1, 1, 1, 1 });
            expectedVectors2.Add(new int[] { 1, 1, 0, 0 });
            expectedVectors2.Add(new int[] { 1, 0, 1, 0 });

            Matrix matrix2 = new Matrix(2, 0);
            matrix2.CreateGeneratorMatrix();

            int[] actualVector20 = matrix2.CreateVectorIntArray(0);
            CollectionAssert.AreEqual(expectedVectors2[0], actualVector20);

            int[] actualVector21 = matrix2.CreateVectorIntArray(1);
            CollectionAssert.AreEqual(expectedVectors2[1], actualVector21);

            int[] actualVector22 = matrix2.CreateVectorIntArray(2);
            CollectionAssert.AreEqual(expectedVectors2[2], actualVector22);

            List<int[]> expectedVectors3 = new List<int[]>();
            expectedVectors3.Add(new int[] { 1, 1, 1, 1, 1, 1, 1, 1 });
            expectedVectors3.Add(new int[] { 1, 1, 1, 1, 0, 0, 0, 0 });
            expectedVectors3.Add(new int[] { 1, 1, 0, 0, 1, 1, 0, 0 });
            expectedVectors3.Add(new int[] { 1, 0, 1, 0, 1, 0, 1, 0 });

            Matrix matrix3 = new Matrix(3, 0);
            matrix3.CreateGeneratorMatrix();

            int[] actualVector30 = matrix3.CreateVectorIntArray(0);
            CollectionAssert.AreEqual(expectedVectors3[0], actualVector30);

            int[] actualVector31 = matrix3.CreateVectorIntArray(1);
            CollectionAssert.AreEqual(expectedVectors3[1], actualVector31);

            int[] actualVector32 = matrix3.CreateVectorIntArray(2);
            CollectionAssert.AreEqual(expectedVectors3[2], actualVector32);

            int[] actualVector33 = matrix3.CreateVectorIntArray(3);
            CollectionAssert.AreEqual(expectedVectors3[3], actualVector33);
        }

        [TestMethod]
        public void TestMultiplyVectors()
        {
            Matrix matrix = new Matrix(2, 0);

            int[] vector1 = new int[] { 1, 0, 1, 0 };
            int[] vector2 = new int[] { 1, 1, 1, 1 };
            int[] expectedResult = new int[] { 1, 0, 1, 0 };

            int[] actualResult = matrix.MultiplyVectors(vector1, vector2);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestMultiplyMessageWithGeneratorMatrix()
        {
            Matrix matrix = new Matrix(3, 3);
            matrix.CreateGeneratorMatrix();

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

            List<int> actualResult1 = matrix.MultiplyMessageWithGeneratorMatrix(message1);
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

            List<int> actualResult2 = matrix.MultiplyMessageWithGeneratorMatrix(message2); ;

            CollectionAssert.AreEqual(expectedResult2, actualResult2);
        }

        [TestMethod]
        public void TestCreateGeneratorMatrix()
        {
            Matrix matrix = new Matrix(3, 3);
            matrix.CreateGeneratorMatrix();

            List<int[]> expectedGeneratorMatrix = new List<int[]>();
            expectedGeneratorMatrix.Add(new int[] { 1, 1, 1, 1, 1, 1, 1, 1 });
            expectedGeneratorMatrix.Add(new int[] { 1, 1, 1, 1, 0, 0, 0, 0 });
            expectedGeneratorMatrix.Add(new int[] { 1, 1, 0, 0, 1, 1, 0, 0 });
            expectedGeneratorMatrix.Add(new int[] { 1, 0, 1, 0, 1, 0, 1, 0 });
            expectedGeneratorMatrix.Add(new int[] { 1, 1, 0, 0, 0, 0, 0, 0 });
            expectedGeneratorMatrix.Add(new int[] { 1, 0, 1, 0, 0, 0, 0, 0 });
            expectedGeneratorMatrix.Add(new int[] { 1, 0, 0, 0, 1, 0, 0, 0 });
            expectedGeneratorMatrix.Add(new int[] { 1, 0, 0, 0, 0, 0, 0, 0 });

            CollectionAssert.AreEqual(expectedGeneratorMatrix[0], matrix.generatorMatrix[0]);
            CollectionAssert.AreEqual(expectedGeneratorMatrix[1], matrix.generatorMatrix[1]);
            CollectionAssert.AreEqual(expectedGeneratorMatrix[2], matrix.generatorMatrix[2]);
            CollectionAssert.AreEqual(expectedGeneratorMatrix[3], matrix.generatorMatrix[3]);
            CollectionAssert.AreEqual(expectedGeneratorMatrix[4], matrix.generatorMatrix[4]);
            CollectionAssert.AreEqual(expectedGeneratorMatrix[5], matrix.generatorMatrix[5]);
            CollectionAssert.AreEqual(expectedGeneratorMatrix[6], matrix.generatorMatrix[6]);
            CollectionAssert.AreEqual(expectedGeneratorMatrix[7], matrix.generatorMatrix[7]);

            Matrix matrix2 = new Matrix(2, 2);
            matrix2.CreateGeneratorMatrix();

            List<int[]> expectedGeneratorMatrix2 = new List<int[]>();
            expectedGeneratorMatrix2.Add(new int[] { 1, 1, 1, 1 });
            expectedGeneratorMatrix2.Add(new int[] { 1, 1, 0, 0 });
            expectedGeneratorMatrix2.Add(new int[] { 1, 0, 1, 0 });
            expectedGeneratorMatrix2.Add(new int[] { 1, 0, 0, 0 });

            CollectionAssert.AreEqual(expectedGeneratorMatrix2[0], matrix2.generatorMatrix[0]);
            CollectionAssert.AreEqual(expectedGeneratorMatrix2[1], matrix2.generatorMatrix[1]);
            CollectionAssert.AreEqual(expectedGeneratorMatrix2[2], matrix2.generatorMatrix[2]);
            CollectionAssert.AreEqual(expectedGeneratorMatrix2[3], matrix2.generatorMatrix[3]);

            Matrix matrix3 = new Matrix(2, 1);
            matrix3.CreateGeneratorMatrix();

            List<int[]> expectedGeneratorMatrix3 = new List<int[]>();
            expectedGeneratorMatrix3.Add(new int[] { 1, 1, 1, 1 });
            expectedGeneratorMatrix3.Add(new int[] { 1, 1, 0, 0 });

            CollectionAssert.AreEqual(expectedGeneratorMatrix3[0], matrix3.generatorMatrix[0]);
            CollectionAssert.AreEqual(expectedGeneratorMatrix3[1], matrix3.generatorMatrix[1]);

            Matrix matrix4 = new Matrix(3, 1);
            matrix4.CreateGeneratorMatrix();

            List<int[]> expectedGeneratorMatrix4 = new List<int[]>();
            expectedGeneratorMatrix4.Add(new int[] { 1, 1, 1, 1, 1, 1, 1, 1 });
            expectedGeneratorMatrix4.Add(new int[] { 1, 1, 1, 1, 0, 0, 0, 0 });
            expectedGeneratorMatrix4.Add(new int[] { 1, 1, 0, 0, 1, 1, 0, 0 });
            expectedGeneratorMatrix4.Add(new int[] { 1, 0, 1, 0, 1, 0, 1, 0 });

            CollectionAssert.AreEqual(expectedGeneratorMatrix4[0], matrix4.generatorMatrix[0]);
            CollectionAssert.AreEqual(expectedGeneratorMatrix4[1], matrix4.generatorMatrix[1]);
            CollectionAssert.AreEqual(expectedGeneratorMatrix4[2], matrix4.generatorMatrix[2]);
            CollectionAssert.AreEqual(expectedGeneratorMatrix4[3], matrix4.generatorMatrix[3]);
        }
    }
}
