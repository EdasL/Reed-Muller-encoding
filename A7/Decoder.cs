using System;
using System.Collections.Generic;
using System.Linq;

namespace A7
{
    public class Decoder
    {
        public string message;
        public string decodedMessage;
        public int m;
        public int r;

        public Decoder(string message, int m, int r)
        {
            this.message = message;
            this.m = m;
            this.r = r;
        }

        public void Decode()
        {
            int[] allMessageInBits = this.message.ToCharArray().Select(x => (int)Char.GetNumericValue(x)).ToArray();
            List<int> decodedMessage = new List<int>();
            Matrix initialMatrix = new Matrix(this.m, this.r);
            initialMatrix.CreateGeneratorMatrix();

            int messageSubsetsCount = allMessageInBits.Length / initialMatrix.generatingVectors.Count;
            int[] allVectorsIndexes = this.GetVectorsIndexes();

            for (int z = 0; z < messageSubsetsCount; z++)
            {
                int tempR = this.r;

                int[] messageInBits = new int[initialMatrix.generatingVectors.Count];

                for (int i = 0; i < initialMatrix.generatingVectors.Count; i ++)
                {
                    messageInBits[i] = allMessageInBits[i];
                }

                while (tempR >= 0)
                {
                    Console.WriteLine("Begin: {0}", tempR);
                    List<int> decodedTempMessage = new List<int>();

                    Console.WriteLine("Message:");
                    foreach (int value in messageInBits)
                    {
                        Console.Write(value);
                    }
                    Console.WriteLine();
                    Console.WriteLine("end of Message");


                    Matrix matrix = new Matrix(this.m, tempR);

                    List<int[]> subsets =  matrix.CreateSubsets(this.GetVectorsIndexes(), true);
                    subsets.Reverse();
                    subsets.Add(new int[] { 0 });
                    subsets.RemoveAll(subset => subset.Length != tempR);

                    subsets.ForEach(subset =>
                    {
                        List<int> allL = new List<int>();

                        Console.WriteLine("all L:");
                        foreach (int index in allVectorsIndexes)
                        {
                            if (!subset.Contains(index))
                            {
                                allL.Add(index);
                                Console.Write("{0} ,", index);
                            }
                        }
                        Console.WriteLine();
                        Console.WriteLine("end of all L");

                        List<int[]> allT = matrix.GetGeneratingVariables((int)Math.Pow(2, this.m - tempR) - 1, this.m - tempR);

                        if(allT.Count == 0)
                        {
                            decodedTempMessage.Add(0);
                            tempR--;

                            return;
                        }

                        Console.WriteLine("all T:");
                        allT.ForEach(t =>
                        {
                            foreach (int tValue in t)
                            {
                                Console.Write("{0} ,", tValue);
                            }

                            Console.WriteLine();
                        });
                        Console.WriteLine();
                        Console.WriteLine("end of all T");

                        List<int[]> allW = new List<int[]>();

                        for (int i = 0; i < allT.Count; i++)
                        {
                            List<int> w = new List<int>();

                            initialMatrix.generatingVectors.ForEach(vector =>
                            {
                                int sameValues = 0;

                                for (int j = 0; j < allT[i].Length; j++)
                                {
                                    if (allT[i][j] == vector[allL[j] - 1]) sameValues++;
                                }

                                w.Add(sameValues == allT[i].Length ? 1 : 0);
                            });

                            allW.Add(w.ToArray());
                        }

                        List<int> wc = new List<int>();

                        allW.ForEach(w =>
                        {
                            Console.WriteLine("w:");
                            foreach ( int value in w ){
                                Console.Write(value);
                            }
                            Console.WriteLine();
                            Console.WriteLine("end of w");


                            int[] multipliedVector = matrix.MultiplyVectors(w, messageInBits);
                            int result = 0;

                            for (int i = 0; i < multipliedVector.Length; i++)
                            {
                                result += multipliedVector[i];
                            }

                            Console.WriteLine("added bit: {0}", result % 2);

                            wc.Add(result % 2);
                        });

                        int decodedMessagesSum = 0;

                        wc.ForEach(bitSuggestion =>
                        {
                            decodedMessagesSum += bitSuggestion;
                        });

                        decodedTempMessage.Add(decodedMessagesSum >= ((double)wc.Count / 2) ? 1 : 0);
                    });

                    decodedTempMessage.ForEach(bitValue => {
                        decodedMessage.Add(bitValue);
                    });


                    for (int i = 0; i < decodedTempMessage.Count; i++)
                    {
                        int bitValue = Math.Abs(messageInBits[(decodedMessage.Count - 1) - i] - decodedTempMessage[i]);
                        messageInBits[(decodedMessage.Count - 1) - i] = bitValue;
                    }

                    tempR--;
                }
            }

            this.decodedMessage = string.Join("", decodedMessage.Select(x => x.ToString()).ToArray());
        }

        public int[] GetVectorsIndexes()
        {
            int[] allVectorsIndexes = new int[this.m];

            for (int i = 0; i < this.m; i++)
            {
                allVectorsIndexes[i] = i + 1;
            }

            return allVectorsIndexes;
        }
    }
}
