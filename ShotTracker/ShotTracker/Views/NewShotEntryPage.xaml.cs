using ShotTracker.Models;
using ShotTracker.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShotTracker.Views
{
    public partial class NewShotEntryPage : ContentPage
    {
        public NewShotEntryPage()
        {
            InitializeComponent();
            BindingContext = new NewShotEntryViewModel();
        }
    }
}