using ShotTracker.Models;
using ShotTracker.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShotTracker.Views
{
    public partial class NewItemPage : ContentPage
    {
        public ShotEntryItem Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewShotEntryItemViewModel();
        }
    }
}