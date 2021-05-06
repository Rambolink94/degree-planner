using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using Degree_Planner.Data;
using System.IO;

namespace Degree_Planner
{
    public partial class App : Application
    {
        static TermDatabase database;
        public static bool shownNotifications;

        public static TermDatabase Database
        {
            get
            {
                if(database == null)
                {
                    string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Database.db3");
                    database = new TermDatabase(path);
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            shownNotifications = false;
            MainPage = new NavigationPage(new Pages.MainPage());
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
