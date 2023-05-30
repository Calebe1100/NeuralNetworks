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
        public static List<string> ReadingAndGenerateInputText(string path)
        {
            List<string> lista = new List<string>();

            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string linha = sr.ReadLine();
                        string[] itens = linha.Split(',');
                        foreach (string item in itens)
                        {
                            lista.Add(item.Trim());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro ao ler o arquivo: " + ex.Message);
            }

            return lista;
        }
    }
}
