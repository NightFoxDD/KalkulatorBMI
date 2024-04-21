using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace KalkulatorBMI
{
    static class FileFunctions
    {
        public static void WriteToFile(List<BMIResult> bmiResults)
        {
            List<string> outputFile = new List<string>();
            foreach (var item in bmiResults)
            {
                outputFile.Add($"{item.Title};{item.Date};{item.Weight};{item.Height};{item.Gender};{item.Score};{item.Result}");
            }
            File.WriteAllLines(App.DbPath, outputFile);
        }
        public static List<BMIResult> ReadFromFile()
        {
            List<BMIResult> bmiResults = new List<BMIResult>();
            List<string> file = File.ReadAllLines(App.DbPath).ToList();
            foreach (string item in file)
            {
                string[] data = item.Split(';');
                if (data.Length == 7)
                {
                    bmiResults.Add(new BMIResult(data[0], DateTime.Parse(data[1]), int.Parse(data[2]), int.Parse(data[3]), data[4], float.Parse(data[5]), data[6]));
                }
            }
            return bmiResults;
        }
    }
}
