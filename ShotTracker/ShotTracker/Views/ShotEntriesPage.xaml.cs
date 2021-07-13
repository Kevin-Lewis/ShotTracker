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
    public partial class ShotEntriesPage : ContentPage
    {
        ShotEntriesViewModel _viewModel;

        public ShotEntriesPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new ShotEntriesViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}