using KalkulatorBMI.Pages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace KalkulatorBMI
{
    public partial class MainPage : ContentPage
    {
        string tmp_gender, tmp_result, tmp_score, tmp_height, tmp_weight;
        public MainPage()
        {
            InitializeComponent();
            //if (!File.Exists(App.DbPath))
            //{
            //    //string serializedResultList = JsonConvert.SerializeObject(new List<BMIResult>());
            //    //File.WriteAllText(App.DbPath, serializedResultList);
            //}
        }

        private void TI_GoToSavedData_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Page_SavedData());
        }
        private async void Btn_CalculateBMI(object sender, EventArgs e)
        {
            if (!RB_Female.IsChecked && !RB_Male.IsChecked)
            {
                await DisplayAlert("Błąd", "Wybierz płeć.", "OK");
                return;
            }

            if (!int.TryParse(E_Weight.Text, out int weight) || !int.TryParse(E_Height.Text, out int height) || weight < 20 || height < 100)
            {
                await DisplayAlert("Błąd", "Podano błęny wzrost lub błędną masę ciała.", "OK");
                return;
            }


            string gender = "";
            if (RB_Female.IsChecked)
            {
                gender = "kobieta";
            }
            if (RB_Male.IsChecked)
            {
                gender = "mężczyzna";
            }

            float score = float.Parse(weight.ToString()) / ((float.Parse(height.ToString()) / 100) * (float.Parse(height.ToString()) / 100));

            string result = "";
            if (score < 16)
            {
                result = "wygłodzenie";
            }
            if (score >= 16 && score < 19)
            {
                result = "niedowaga";
            }
            else if (score >= 19 && score < 24)
            {
                result = "waga prawidłowa";
            }
            else if ((score >= 24 && score <= 30 && gender == "kobieta") || (score >= 25 && score <= 30 && gender == "mężczyzna"))
            {
                result = "nadwaga";
            }
            else if (score >= 30 && score <= 40)
            {
                result = "otyłość";
            }
            else if (score >= 40)
            {
                result = "skrajna otyłość";
            }

            Lbl_Score.Text = score.ToString("0.00") + " BMI";
            Lbl_Result.Text = "Wynik: " + result + ".";

            Btn_SaveReslt.IsVisible = true;
            Btn_SaveReslt.IsEnabled = true;
            tmp_score = score.ToString("0.00");
            tmp_result = result;
            tmp_gender = gender;
            tmp_height = E_Height.Text;
            tmp_weight = E_Weight.Text;
        }
        private async void Btn_SaveReslt_Clicked(object sender, EventArgs e)
        {
            string title = await DisplayPromptAsync("Tytuł", "Nadaj tytuł", "OK", "ANULUJ", "tytuł");
            if (string.IsNullOrWhiteSpace(title))
            {
                await DisplayAlert("Błąd", "Podaj tytuł zapisu.", "OK");
                return;
            }
            string path = App.DbPath;
            string file = File.ReadAllText(path);

            //List<BMIResult> resultList = JsonConvert.DeserializeObject<List<BMIResult>>(file);
            List<BMIResult> resultList = FileFunctions.ReadFromFile();
            if (resultList.Count > 0)
            {
                resultList[resultList.Count - 1].SetLastID();
            }

            resultList.Add(new BMIResult(title, DateTime.Now, int.Parse(tmp_height), int.Parse(tmp_weight), tmp_gender, float.Parse(tmp_score), tmp_result));
            FileFunctions.WriteToFile(resultList);
            
            //string serializedResultList = JsonConvert.SerializeObject(resultList);
            
            Btn_SaveReslt.IsVisible = false;
            Btn_SaveReslt.IsEnabled = false;

            await DisplayAlert("Informacja", "Pomyślnie dodano nowy zapis.", "OK");
        }
       
    }
}
