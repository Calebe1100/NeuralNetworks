using NeuralNetworks.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworks.Utils
{
    internal class FormatIrisData
    {
        public List<Sample> SampleListFormatted { get; set; }

        public FormatIrisData(List<string[]> dataReading)
        {
            List<Sample> sampleList = Initialize(dataReading.Count, dataReading[0].Length);



            Sample sample;
            for (int i = 0; i < dataReading.Count; i++)
            {
                sample = new Sample(4, 1);
                for (int j = 0; j < dataReading[i].Length; j++)
                {
                    if (j <= 3)
                    {
                        sample.CordX[j] = Double.Parse(dataReading[i][j], CultureInfo.InvariantCulture);
                    }

                    if (j > 3)
                    {

                        sample.CordY = GetOutputValueByPlantType(dataReading[i][j]);
                    }
                }
                sampleList.Add(sample);
            }
            this.SampleListFormatted = sampleList;
        }

        private double[] GetOutputValueByPlantType(string value)
        {
            switch (value)
            {
                case "Iris-setosa":
                    return new double[] { 0, 0, 1 };

                case "Iris-versicolor":
                    return new double[] { 0, 1, 0 };
                case "Iris-virginica":
                    return new double[] { 1, 0, 0 };
                default:
                    return new double[] {0, 0, 0 }; 
            }
        }

        private List<Sample> Initialize(int count, int length)
        {
            return new List<Sample>(count);
            //for (int i = 0; i < count; i++)
            //{
            //    for (int j = 0; j < length; j++)
            //    {
            //        values[]
            //    }
            //}
        }
    }
}
