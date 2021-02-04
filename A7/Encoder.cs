using System;
using System.Collections;
using System.Collections.Generic;

namespace A7
{
    public class Encoder
    {
        public string message;
        public int m;
        public int r;
        public int wordsCount;
        public List<int[]> encodedMessage;

        public Encoder(string message, int m, int r)
        {
            this.message = message;
            this.m = m;
            this.r = r;
            this.wordsCount = (int)Math.Pow(2, m);
        }

        public void Encode()
        {
            BitArray generatingVariables = GetGeneratingVariables(this.wordsCount - 1);
            int[,] bitviseIntValues = ConvertBitArrayToIntArray(generatingVariables);

            int vectorsCount = this.m + 1;

            List<int[]> genratedVectorsMatrix = new List<int[]>();

            // Populate initial vectors
            for (int i = 0; i <= this.m; i ++)
            {
                genratedVectorsMatrix.Add(this.CreateVectorIntArray(bitviseIntValues, i));
            }

            // Populate product of vectors
            int[] allVectorsIndexes = new int[this.r];

            for (int i = 1; i <= this.m; i ++)
            {
                allVectorsIndexes[i] = i;
            }

            List<int[]> allPossibleSubestsOfIndexes = this.CreateSubsets(allVectorsIndexes);

            foreach(var possibleSubset in allPossibleSubestsOfIndexes)
            {
                int[] multipliedVector = this.CreateVectorIntArray(bitviseIntValues, 0);

                foreach (var index in possibleSubset)
                {
                    multipliedVector = this.MultiplyVectors(multipliedVector, genratedVectorsMatrix[index]);
                }

                genratedVectorsMatrix.Add(multipliedVector);
            }


        }

        public BitArray GetGeneratingVariables(int maxDecimalvalue)
        {
            int[] decimalValues = new int[maxDecimalvalue];

            for (int i = 1; i <= this.wordsCount; i ++)
            {
                decimalValues[i - 1] = 1;
            }

            return new BitArray(decimalValues);
        }

        public int[,] ConvertBitArrayToIntArray(BitArray bitArray)
        {
            int[,] bitviseIntValues = new int[this.wordsCount - 1, this.m - 1];

            for(int i = 0; i < this.wordsCount; i ++)
            {
                for (int j = i * m; j <= j + m ; j ++)
                {
                    int addedValuesCount = 0;

                    bitviseIntValues[i, addedValuesCount] = bitArray[j] ? 1 : 0;

                    addedValuesCount++;
                }
            }

            return bitviseIntValues;
        }

        public int[] CreateVectorIntArray(int[,] generatingValues, int vectorIndex)
        {
            int[] vector = new int[this.wordsCount];

            for(int i = 0; i < this.wordsCount; i++)
            {
                if (vectorIndex == 0) {
                    vector[i] = 1;
                } else {
                    bool isValueAtIndexZero = generatingValues[i, vectorIndex - 1] == 0;

                    vector[i] = isValueAtIndexZero ? 1 : 0;
                }
            }

            return vector;
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

        public List<int[]> CreateSubsets(int[] originalArray)
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

            subsets.RemoveAll(subset => subset.Length == 1);
            subsets.RemoveAll(subset => subset.Length > this.r);

            return subsets;
        }
    }
}
