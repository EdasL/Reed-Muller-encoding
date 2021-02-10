using System;
using System.Collections.Generic;
using System.Linq;

namespace A7
{
    public class Encoder
    {
        public string message;
        public string encodedMessage;
        public List<int> encodedMessageBits;
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
            Matrix matrix = new Matrix(this.m, this.r);
            matrix.CreateGeneratorMatrix();

            int[] messageInBits = this.message.ToCharArray().Select(x => (int)Char.GetNumericValue(x)).ToArray();
            List<int[]> messageIntValues = this.AppendBits(messageInBits, matrix.generatorMatrix.Count);
            this.encodedMessageBits = matrix.MultiplyMessageWithGeneratorMatrix(messageIntValues);
            this.encodedMessage = string.Join("", this.encodedMessageBits.Select(x => x.ToString()).ToArray());
        }

        public List<int[]> AppendBits(int[] message, int vectorsCount)
        {
            int messageSubsetsCount = (int)Math.Ceiling(((double)message.Length) / vectorsCount);

            int[] appendedBits = new int[messageSubsetsCount * vectorsCount];
            message.CopyTo(appendedBits, 0);

            if(message.Length < messageSubsetsCount * vectorsCount)
            {
                for (int i = message.Length; i < messageSubsetsCount * vectorsCount; i ++)
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
                    result[j] = appendedBits[(i * vectorsCount) + j];
                }

                appendedBitsList.Add(result);
            }

            return appendedBitsList;
        }
    }
}
