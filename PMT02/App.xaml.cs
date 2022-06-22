using PMT02.Data;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PMT02
{
   
    public partial class App : Application
    {
        static SqliteHelper db;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage (new MainPage());
        }

        public static SqliteHelper SQLiteDB
        {
            get
            {
                if (db == null)
                {
                    db = new SqliteHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "dbdatos.db3"));
                   
                }
                return db;
            }
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
