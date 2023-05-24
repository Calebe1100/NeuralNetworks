using NeuralNetworks.useCases;
using System;

namespace NeuralNetworks
{
    public static class Controller
    {
        public static double[][][] Base { get; set; } =
            new double[][][] {
               new double[][] { new double[] { 0, 0 }, new double[] { 0 } },
                new double[][]{ new double[]  { 0 ,1 }, new double[] { 1 } },
                new double[][]{ new double[] { 1 ,0 }, new double[] { 1 } },
                new double[][]{ new double[] { 1 ,1 }, new double[] { 0 } }
            };
        public static void Main()
        {

            Perceptron perceptron = new Perceptron(2, 1, 0.3);

            for (int e = 0; e < 1000; e++)
            {
                double periodError = 0;
                for (int a = 0; a < Base.Length; a++)
                {
                    double sampleError = 0;
                    double[] inputX = Base[a][0];
                    double[] inputY = Base[a][1];

                    double[] theta = perceptron.TrainnerExecute(inputX, inputY);

                    for (int i = 0; i < inputY.Length; i++)
                    {
                        sampleError = Math.Abs(inputY[i] - theta[i]);
                    periodError += sampleError;
                }
                    }
                    Console.WriteLine("Epoca: " + e + " - erro:" + periodError);
            }
        }
    }
}
