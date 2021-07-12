using ShotTracker.Models;
using ShotTracker.ViewModels;
using ShotTracker.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShotTracker.Views
{
    public partial class ShotEntryItemsPage : ContentPage
    {
        ShotEntryItemsViewModel _viewModel;

        public ShotEntryItemsPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new ShotEntryItemsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}