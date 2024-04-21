using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KalkulatorBMI
{
    public partial class App : Application
    {
        public static string DbPath
        {
            get
            {
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "BMIDatabase.txt");
            }
        }
        public App()
        {
            InitializeComponent();
            if (!File.Exists(DbPath))
            {
                File.Create(DbPath);
            }
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
