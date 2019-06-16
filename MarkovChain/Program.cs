using System;
using System.Collections.Generic;

namespace MarkovChain
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            List<string> words = new List<string>();
            List<int> counts = new List<int>();
            double[][] probabilities;
            for (int i = 0; i < inputs.Length; i++)
            {
                if (!words.Contains(inputs[i]))
                {
                    words.Add(inputs[i]);
                    counts.Add(0);
                }
                counts[i]++;
            }
            probabilities = new double[words.Count][];
            for (int i = 0; i < words.Count; i++)
            {
                probabilities[i] = new double[words.Count];
            }
            for (int i = 0; i < inputs.Length - 1; i++)
            {
                for (int j = 0; j < words.Count; j++)
                {
                    if (inputs[i] == words[j])
                    {
                        for (int k = 0; k < words.Count; k++)
                        {
                            if (inputs[i + 1] == words[k])
                            {
                                probabilities[0][k]++;
                                break;
                            }
                        }
                        break;
                    }
                }
            }
            for (int i = 0; i < probabilities.Length; i++)
            {
                for (int j = 0; j < probabilities[i].Length; j++)
                {
                    probabilities[i][j] /= probabilities.Length;
                }
            }

            int currWord = 0;
            Random random = new Random();
            while (true)
            {
                Console.Write(words[currWord]);
                for (int i = 0; i < words.Count; i++)
                {
                    if (random.NextDouble() < probabilities[currWord][i])
                    {
                        currWord = i;
                    }
                }
            }
        }
    }
}
