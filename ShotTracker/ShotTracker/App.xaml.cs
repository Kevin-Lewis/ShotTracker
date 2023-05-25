using ShotTracker.Data;
using ShotTracker.Services;
using ShotTracker.Views;
using System;
using System.IO;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace ShotTracker
{
    public partial class App : Application
    {
        static ShotEntryDatabase database;

        public static ShotEntryDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new ShotEntryDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ShotEntries.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();
            DependencyService.Register<DataStore>();
            MainPage = new AppShell();
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
