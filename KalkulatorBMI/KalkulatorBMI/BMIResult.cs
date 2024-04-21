using System;

namespace KalkulatorBMI
{
    public class BMIResult
    {
        private static int LastId;
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public string Gender { get; set; }
        public float Score { get; set; }
        public string Result { get; set; }

        public BMIResult(int iD, string title, DateTime date, int weight, int height, string gender, float score, string result)
        {
            ID = iD;
            Title = title;
            Date = date;
            Weight = weight;
            Height = height;
            Gender = gender;
            Score = score;
            Result = result;
        }

        public BMIResult(string title, DateTime date, int weight, int height, string gender, float score, string result)
        {
            Title = title;
            Date = date;
            Weight = weight;
            Height = height;
            Gender = gender;
            Score = score;
            Result = result;
        }
        public BMIResult() { }
        public void SetLastID()
        {
            LastId = ID;
        }
    }
}
