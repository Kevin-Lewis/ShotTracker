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
            Routing.RegisterRoute(nameof(ShotEntryItemsPage), typeof(ShotEntryItemsPage));
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
