using ShotTracker.ViewModels;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShotTracker.Views
{
    public partial class FilterShotDataPage : ContentPage
    {
        FilterShotDataViewModel _viewModel;
        public FilterShotDataPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new FilterShotDataViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}