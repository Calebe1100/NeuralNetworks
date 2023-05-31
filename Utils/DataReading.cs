using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworks.Utils
{
    public static class DataReading
    {
        public static List<string[]> ReadingAndGenerateInputText(string path)
        {
            List<string[]> lista = new List<string[]>();

            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string linha = sr.ReadLine();
                        string[] itens = linha.Split(',');
                        lista.Add(itens);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro ao ler o arquivo: " + ex.Message);
            }
            lista.RemoveAt(lista.Count - 1);
            return lista;
        }
    }
}
