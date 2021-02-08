using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A7
{
    public class Matrix
    {
        public List<int[]> generatorMatrix;
        public List<int[]> generatingVectors;
        public int m;
        public int r;
        public int wordsCount;

        public Matrix(int m, int r)
        {
            this.m = m;
            this.r = r;
            this.wordsCount = (int)Math.Pow(2, m);
        }

        public void CreateGeneratorMatrix()
        {
            this.generatingVectors = GetGeneratingVariables(this.wordsCount - 1, this.m);

            int vectorsCount = this.m + 1;

            this.generatorMatrix = new List<int[]>();

            // Populate initial vectors
            for (int i = 0; i <= this.m; i++)
            {
                this.generatorMatrix.Add(this.CreateVectorIntArray(i));
            }

            // Populate product of vectors
            int[] allVectorsIndexes = new int[this.m];

            for (int i = 0; i < this.m; i++)
            {
                allVectorsIndexes[i] = i + 1;
            }

            List<int[]> allPossibleSubestsOfIndexes = this.CreateSubsets(allVectorsIndexes);

            foreach (var possibleSubset in allPossibleSubestsOfIndexes)
            {
                int[] multipliedVector = this.generatorMatrix[0];

                foreach (var index in possibleSubset)
                {
                    multipliedVector = this.MultiplyVectors(multipliedVector, this.generatorMatrix[index]);
                }
                this.generatorMatrix.Add(multipliedVector);
            }
        }

        public List<int> MultiplyMessageWithGeneratorMatrix(List<int[]> message)
        {
            List<int> MultipliedMessage = new List<int>();

            for (int i = 0; i < message.Count; i++)
            {
                for (int j = 0; j < this.wordsCount; j++)
                {
                    int result = 0;

                    for (int z = 0; z < message[i].Length; z++)
                    {

                        result += (message[i][z] * this.generatorMatrix[z][j]);
                    }

                    MultipliedMessage.Add(result % 2);
                }
            }

            return MultipliedMessage;
        }

        public List<int[]> GetGeneratingVariables(int maxDecimalvalue, int valuesToAppend)
        {
            int[] decimalValues = new int[maxDecimalvalue + 1];

            for (int i = 0; i <= maxDecimalvalue; i++)
            {
                decimalValues[i] = i;
            }

            List<int[]> allBits = new List<int[]>();

            foreach (int decimalValue in decimalValues)
            {
                string s = Convert.ToString(decimalValue, 2);

                int[] bits = s.PadLeft(valuesToAppend, '0') // Add 0's from left
                              .Select(c => int.Parse(c.ToString())) // convert each char to int
                              .ToArray(); // Convert IEnumerable from select to Array

                allBits.Add(bits);
            }

            return allBits;
        }

        public List<int[]> CreateSubsets(int[] originalArray, bool includeSingular = false)
        {
            List<int[]> subsets = new List<int[]>();

            for (int i = 0; i < originalArray.Length; i++)
            {
                int subsetCount = subsets.Count;
                subsets.Add(new int[] { originalArray[i] });

                for (int j = 0; j < subsetCount; j++)
                {
                    int[] newSubset = new int[subsets[j].Length + 1];
                    subsets[j].CopyTo(newSubset, 0);
                    newSubset[newSubset.Length - 1] = originalArray[i];
                    subsets.Add(newSubset);
                }
            }

            if(!includeSingular) subsets.RemoveAll(subset => subset.Length == 1);
            subsets.RemoveAll(subset => subset.Length > this.r);

            List<int[]> orderedSubsets = subsets.OrderBy(subset => subset.Length).ToList();

            return orderedSubsets;
        }

        public int[] MultiplyVectors(int[] vectorA, int[] vectorB)
        {
            int[] vector = new int[this.wordsCount];

            for (int i = 0; i < this.wordsCount; i++)
            {
                vector[i] = vectorA[i] * vectorB[i];
            }

            return vector;
        }

        public int[] CreateVectorIntArray(int vectorIndex)
        {
            int[] vector = new int[this.wordsCount];

            for (int i = 0; i < this.wordsCount; i++)
            {
                if (vectorIndex == 0)
                {
                    vector[i] = 1;
                }
                else
                {
                    bool isValueAtIndexZero = this.generatingVectors[i][vectorIndex - 1] == 0;

                    vector[i] = isValueAtIndexZero ? 1 : 0;
                }
            }

            return vector;
        }
    }
}
