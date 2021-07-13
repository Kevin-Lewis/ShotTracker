using ShotTracker.ViewModels;
using ShotTracker.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ShotTracker
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ShotEntriesPage), typeof(ShotEntriesPage));
            Routing.RegisterRoute(nameof(ShotEntryDetailPage), typeof(ShotEntryDetailPage));
            Routing.RegisterRoute(nameof(NewShotEntryPage), typeof(NewShotEntryPage));
        }

    }
}
