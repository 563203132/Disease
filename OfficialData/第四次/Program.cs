using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DiseaseProcess
{
    class Program
    {
        static string _rootPath = @"C:\Users\vic.li\Documents\Visual Studio 2017\Projects\ConsoleApp1\DiseaseProcess\";

        static void Main(string[] args)
        {
            var diseases = File.ReadAllLines(string.Format($"{_rootPath}diseases.txt"));
            var symbolDiseases = new StringBuilder();
            var normalDiseases = new StringBuilder();
            foreach(var disease in diseases)
            {
                var temp = disease.Trim();

                int count = 0;
                Regex regex = new Regex(@"^[\u4E00-\u9FA5]{0,}$");
                for (int i = 0; i < temp.Length; i++)
                {
                    if (regex.IsMatch(temp[i].ToString()))
                    {
                        count++;
                    }
                }

                if (temp.Length != count)
                {
                    symbolDiseases.AppendLine(disease);
                }
                else
                {
                    normalDiseases.AppendLine(disease);
                }
            }

            File.WriteAllText($"{_rootPath}symbolDiseases.txt", symbolDiseases.ToString());
            File.WriteAllText($"{_rootPath}normalDiseases.txt", normalDiseases.ToString());
        }
    }
}
