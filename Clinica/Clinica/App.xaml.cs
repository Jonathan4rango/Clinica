using Clinica.Bd;
using Clinica.View;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Clinica
{
    public partial class App : Application
    {

        static DataBase DataB;
        public static DataBase DB
        {

            get
            {
                if (DataB == null)
                {
                    DataB = new DataBase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DBMOTORSOFT.db"));
                }
                return DataB;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Login());
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
