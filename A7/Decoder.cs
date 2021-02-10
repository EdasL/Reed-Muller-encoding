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
            Matrix initialMatrix = new Matrix(this.m, this.r);
            initialMatrix.CreateGeneratorMatrix();

            int messageSubsetsCount = allMessageInBits.Length / initialMatrix.generatingVectors.Count;
            int[] allVectorsIndexes = this.GetVectorsIndexes();

            for (int z = 0; z < messageSubsetsCount; z++)
            {
                int tempR = this.r;
                List<int> decodedMessage = new List<int>();

                int[] messageInBits = new int[initialMatrix.generatingVectors.Count];

                for (int i = 0; i < initialMatrix.generatingVectors.Count; i ++)
                {
                    messageInBits[i] = allMessageInBits[(initialMatrix.generatingVectors.Count * z) + i];
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
                    matrix.CreateGeneratorMatrix();

                    List<int[]> subsets =  matrix.CreateSubsets(this.GetVectorsIndexes(), true);
                    subsets.Reverse();

                    int keptSubsetsLength = tempR;
                    if (tempR == 0)
                    {
                        subsets.Add(new int[] { 0 });
                        keptSubsetsLength = 1;
                    }

                    subsets.RemoveAll(subset => subset.Length != keptSubsetsLength);

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

                                if (tempR == this.m)
                                {
                                    sameValues++;
                                } else
                                {
                                    for (int j = 0; j < allT[i].Length; j++)
                                    {

                                        if (allT[i][j] == vector[allL[j] - 1]) sameValues++;
                                    }
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

                        Console.WriteLine("wc count/2: {0}", (double)wc.Count / 2);
                        decodedTempMessage.Add(decodedMessagesSum > ((double)wc.Count / 2) ? 1 : 0);
                    });

                    int wordsCount = (int)Math.Pow(2, this.m);

                    int[] initialVector = new int[wordsCount];
                    for (int i = 0; i < wordsCount; i++)
                    {
                        initialVector[i] = 0;
                    }


                    int[] productOfVectors = new int[wordsCount];
                    initialVector.CopyTo(productOfVectors, 0);

                    int addedValues = 0;
                    decodedTempMessage.ForEach(bitValue => {
                        int[] vector = new int[wordsCount];

                        if (bitValue != 1)
                        {
                            initialVector.CopyTo(vector, 0);
                        }
                        else
                        {
                            matrix.generatorMatrix[(matrix.generatorMatrix.Count - 1) - addedValues].CopyTo(vector, 0);
                        }

                        Console.WriteLine("Bit: {0}", bitValue);

                        Console.WriteLine("Vector:");
                        foreach (int value in vector)
                        {
                            Console.Write(value);
                        }
                        Console.WriteLine();

                        for (int i = 0; i < wordsCount; i ++)
                        {
                            int result = productOfVectors[i] + vector[i];

                            productOfVectors[i] = result % 2;
                        }

                        decodedMessage.Add(bitValue);
                        addedValues++;
                    });

                    Console.WriteLine("Product of vectors:");
                    for (int i = 0; i < wordsCount; i++)
                    {
                        Console.Write(productOfVectors[i]);
                        int result = Math.Abs(messageInBits[i] - productOfVectors[i]);

                        messageInBits[i] = result;
                    }
                    Console.WriteLine();

                    tempR--;
                }

                decodedMessage.Reverse();
                this.decodedMessage += string.Join("", decodedMessage.Select(x => x.ToString()).ToArray());
            }
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
