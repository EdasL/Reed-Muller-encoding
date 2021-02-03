using System;
using System.Collections;
using System.Collections.Generic;

namespace A7
{
    class Encoder
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

        private void Encode()
        {
            BitArray generatingVariables = GetGeneratingVariables();
            int[,] bitviseIntValues = ConvertBitArrayToIntArray(generatingVariables);

            int vectorsCount = this.m + 1;

            List<int[]> genratedVectorsMatrix = new List<int[]>();

            for (int i = 0; i <= this.m; i ++)
            {
                genratedVectorsMatrix.Add(this.CreateVectorIntArray(bitviseIntValues, i));
            }
        }

        private BitArray GetGeneratingVariables()
        {
            int[] decimalValues = new int[this.wordsCount - 1];

            for (int i = 1; i <= this.wordsCount; i ++)
            {
                decimalValues[i - 1] = 1;
            }

            return new BitArray(decimalValues);
        }

        private int[,] ConvertBitArrayToIntArray(BitArray bitArray)
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

        private int[] CreateVectorIntArray(int[,] generatingValues, int vectorIndex)
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
    }
}
