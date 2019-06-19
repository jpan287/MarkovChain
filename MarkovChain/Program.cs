using System;
using System.Collections.Generic;

namespace MarkovChain
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] rawInput = Console.ReadLine().Split(" ");
            List<string> inputs = new List<string>();
            inputs.Add("");
            for (int i = 0; i < rawInput.Length; i++)
            {
                inputs.Add(rawInput[i]);
            }
            inputs.Add("   end\\");

            List<string> words = new List<string>();
            List<int> counts = new List<int>();
            double[][] probabilities;
            
            for (int i = 0; i < inputs.Count; i++)
            {
                if (!words.Contains(inputs[i]))
                {
                    words.Add(inputs[i]);
                    counts.Add(0);
                }
                else
                {
                    for (int j = 0; j < words.Count; j++)
                    {
                        if (words[j] == inputs[i])
                        {
                            counts[j]++;
                        }
                    }
                }
            }
            words.Add("");

            probabilities = new double[words.Count][];
            for (int i = 0; i < words.Count; i++)
            {
                probabilities[i] = new double[words.Count];
            }

            for (int i = 0; i < inputs.Count - 1; i++)
            {
                for (int j = 0; j < words.Count; j++)
                {
                    if (inputs[i] == words[j])
                    {
                        for (int k = 0; k < words.Count; k++)
                        {
                            if (inputs[i + 1] == words[k])
                            {
                                probabilities[j][k]++;
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
            while (words[currWord] != "   end\\")
            {
                Console.Write(words[currWord] + " ");
                for (int i = 0; i < words.Count; i++)
                {
                    if (random.NextDouble() < probabilities[currWord][i])
                    {
                        currWord = i;
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
