using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A7
{
    public class Encoder
    {
        public string message;
        public string encodedMessage;
        public int m;
        public int r;
        public int wordsCount;

        public Encoder(string message, int m, int r)
        {
            this.message = message;
            this.m = m;
            this.r = r;
            this.wordsCount = (int)Math.Pow(2, m);
        }

        public void Encode()
        {
            List<int[]> bitviseIntValues = GetGeneratingVariables(this.wordsCount - 1);

            int vectorsCount = this.m + 1;

            List<int[]> genratedVectorsMatrix = new List<int[]>();

            // Populate initial vectors
            for (int i = 0; i <= this.m; i ++)
            {
                genratedVectorsMatrix.Add(this.CreateVectorIntArray(bitviseIntValues, i));
            }

            // Populate product of vectors
            int[] allVectorsIndexes = new int[this.m];

            for (int i = 0; i < this.m; i ++)
            {
                allVectorsIndexes[i] = i + 1;
            }

            foreach(int index in allVectorsIndexes)
            {
                Console.Write(index);
            }

            List<int[]> allPossibleSubestsOfIndexes = this.CreateSubsets(allVectorsIndexes);

            Console.WriteLine("All subsets: ");

            foreach (var possibleSubset in allPossibleSubestsOfIndexes)
            {
                int[] multipliedVector = genratedVectorsMatrix[0];

                Console.WriteLine("Subset: ");
                foreach (var index in possibleSubset)
                {
                    Console.Write(index);
                    multipliedVector = this.MultiplyVectors(multipliedVector, genratedVectorsMatrix[index]);
                }
                Console.WriteLine();

                genratedVectorsMatrix.Add(multipliedVector);
            }

            genratedVectorsMatrix.ForEach(vector => {
                Console.WriteLine("Matrix vector:");
                foreach(int value in vector)
                {
                    Console.Write(value);
                }
            });

            int[] messageInBits = this.message.ToCharArray().Select(x => (int)Char.GetNumericValue(x)).ToArray();
            Console.WriteLine("Bits:");
            foreach (int bit in messageInBits)
            {
                Console.Write(bit);
            }
            
            List<int[]> messageIntValues = this.AppendBits(messageInBits, genratedVectorsMatrix.Count);
            Console.WriteLine("Messages appended: {0}", messageIntValues.Count);
            foreach (int[] bit in messageIntValues)
            {
                Console.WriteLine("Message:");
                foreach (int value in bit)
                {
                    Console.Write(value);
                }
            }

            List<int> encodedMessage = this.MultiplyMessageWithGeneratorMatrix(messageIntValues, genratedVectorsMatrix);

            this.encodedMessage = string.Join("", encodedMessage.Select(x => x.ToString()).ToArray());
        }

        public List<int> MultiplyMessageWithGeneratorMatrix(List<int[]> message, List<int[]> generatorMatrix)
        {
            List<int> MultipliedMessage = new List<int>();

            for (int i = 0; i < message.Count; i ++)
            {
                for (int j = 0; j < this.wordsCount; j ++)
                {
                    int result = 0;

                    for (int z = 0; z < message[i].Length; z++)
                    {

                        result += (message[i][z] * generatorMatrix[z][j]);
                    }

                    MultipliedMessage.Add(result % 2);
                }
            }

            return MultipliedMessage;
        }

        public List<int[]> GetGeneratingVariables(int maxDecimalvalue)
        {
            int[] decimalValues = new int[maxDecimalvalue + 1];

            for (int i = 0; i <= maxDecimalvalue; i ++)
            {
                decimalValues[i] = i;
            }

            List<int[]> allBits = new List<int[]>();

            foreach (int decimalValue in decimalValues)
            {
                string s = Convert.ToString(decimalValue, 2);

                int[] bits = s.PadLeft(this.m, '0') // Add 0's from left
                              .Select(c => int.Parse(c.ToString())) // convert each char to int
                              .ToArray(); // Convert IEnumerable from select to Array

                allBits.Add(bits);
            }

            return allBits;
        }

        public List<int[]> AppendBits(int[] message, int vectorsCount)
        {
            int messageSubsetsCount = (int)Math.Ceiling(((double)message.Length) / vectorsCount);

            Console.WriteLine("Message subsets: {0}", messageSubsetsCount);
            Console.WriteLine("Vectors count: {0}", vectorsCount);
            Console.WriteLine("Message length: {0}", message.Length);

            int[] appendedBits = new int[messageSubsetsCount * vectorsCount];
            message.CopyTo(appendedBits, 0);

            if(message.Length < messageSubsetsCount * vectorsCount)
            {
                for (int i = message.Length - 1; i < messageSubsetsCount * vectorsCount; i ++)
                {
                    appendedBits[i] = 0;
                }
            }

            List<int[]> appendedBitsList = new List<int[]>();

            for (int i = 0; i < messageSubsetsCount; i ++)
            {
                int[] result = new int[vectorsCount];

                for (int j = 0; j < vectorsCount; j ++)
                {
                    result[j] = appendedBits[i * vectorsCount + j];
                }

                appendedBitsList.Add(result);
            }

            return appendedBitsList;
        }

        public int[] CreateVectorIntArray(List<int[]> generatingValues, int vectorIndex)
        {
            int[] vector = new int[this.wordsCount];

            for(int i = 0; i < this.wordsCount; i++)
            {
                if (vectorIndex == 0) {
                    vector[i] = 1;
                } else {
                    bool isValueAtIndexZero = generatingValues[i][vectorIndex - 1] == 0;

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

            List<int[]> orderedSubsets = subsets.OrderBy(subset => subset.Length).ToList();

            return orderedSubsets;
        }
    }
}
