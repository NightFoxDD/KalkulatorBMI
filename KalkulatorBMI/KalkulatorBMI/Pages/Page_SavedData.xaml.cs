using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KalkulatorBMI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page_SavedData : ContentPage
    {
        public Page_SavedData()
        {
            InitializeComponent();
            listViewBMI.ItemsSource = FileFunctions.ReadFromFile();
        }
        //public void Load()
        //{
        //    string path = App.DbPath;

        //    if (File.Exists(path))
        //    {
        //        string text = File.ReadAllText(path);


        //        List<BMIResult> results = JsonConvert.DeserializeObject<List<BMIResult>>(text);

                
        //    }
        //}

        private void Btn_Delete(object sender, EventArgs e)
        {
            BMIResult delete = ((Button)sender).BindingContext as BMIResult;
            List<BMIResult> results = FileFunctions.ReadFromFile();
            foreach (var item in results)
            {
                if(item.ID == delete.ID)
                {
                    results.Remove(item);
                    break;
                }
            }
            listViewBMI.ItemsSource = results;
            FileFunctions.WriteToFile(results);
        }
    }
}