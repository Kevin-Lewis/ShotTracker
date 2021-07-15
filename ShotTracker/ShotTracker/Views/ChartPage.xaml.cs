using Microcharts;
using ShotTracker.Services;
using ShotTracker.ViewModels;
using SkiaSharp;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Entry = Microcharts.ChartEntry;

namespace ShotTracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChartPage : ContentPage
    {
        ChartViewModel _viewModel;
        public ChartPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ChartViewModel();
            ChartProgressDaily.Chart = new LineChart() { Entries = _viewModel.GetChartProgressDailyEntries() };
        }       
    }
}