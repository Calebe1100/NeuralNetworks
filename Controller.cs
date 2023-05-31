using NeuralNetworks.Entities;
using NeuralNetworks.useCases;
using NeuralNetworks.Utils;
using System;
using System.Collections.Generic;

namespace NeuralNetworks
{
    public static class Controller
    {
        public static void Main()
        {

            var dataReading = DataReading.ReadingAndGenerateInputText("../../Files/iris.data");

            FormatIrisData generateFormatted = new FormatIrisData(dataReading);

            List<Sample> sampleFormattedList = generateFormatted.SampleListFormatted;

            Perceptron perceptron = new Perceptron(4, 3, 0.5);

            for (int e = 0; e < 1000; e++)
            {
                double periodError = 0;
                for (int a = 0; a < sampleFormattedList.Count; a++)
                {
                    double sampleError = 0;
                    double[] inputX = sampleFormattedList[a].CordX;
                    double[] inputY = sampleFormattedList[a].CordY;

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
