using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworks.useCases
{
    public class Perceptron
    {
        public int AmountIn { get; set; }
        public int AmountOut { get; set; }
        public double[,] Networks { get; set; }
        public double Ni { get; set; }

        public Random Random { get; set; } = new Random();
        public Perceptron(int amountIn, int amoutOut, double ni)
        {
            this.AmountIn = amountIn;
            this.AmountOut = amoutOut;
            this.Ni = ni;
            Networks = new double[amountIn+1,amoutOut +1];
            Networks.Initialize();

            this.FillValues();

        }

        public double[] TrainnerExecute(double[] input, double[] values)
        {
            double[] formatInput = input.Concat(Enumerable.Repeat(1.0, 1)).ToArray();
            double[] theta = new double[values.Length];

            for (int j = 0; j < values.Length; j++)
            {
                double uj = 0;
                for (int i = 0; i < formatInput.Length; i++)
                {
                    uj += formatInput[i] * Networks[i,j];
                }
                theta[j] = (1 / (1 + Math.Exp(-uj)));
            }

            for (int j = 0; j < values.Length; j++)
            {
                for (int i = 0; i < formatInput.Length; i++)
                {
                    Networks[i,j] += Ni * (values[j] - theta[j]) * formatInput[i];
                }
            }
            return theta;
        }

        private void FillValues()
        {
            double max = 0.03;
            double min = -0.03;

            for (int i = 0; i <= this.AmountIn; i++)
            {
                for (int j = 0; j <= this.AmountOut; j++)
                {
                    this.Networks[i,j] = min + (max - min) * Random.NextDouble();
                }
            }
        }

    }
}
