using System;
using System.Collections.Generic;
using System.Text;

namespace MarkovChain
{
    public class Network
    {
        Neuron[] neurons;
        string input;
        string[] inputs;
        double[][] probabilities;
        public Network(string Input)
        {
            input = Input;
            inputs = input.Split(' ');
            neurons = new Neuron[inputs.Length];
        }

        public void CreateNetwork()
        {
            for (int i = 0; i < inputs.Length; i++)
            {
                neurons[i] = new Neuron(inputs[i]);
            }

            
        }

        
    }
}
