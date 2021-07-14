using ShotTracker.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace ShotTracker.Views
{
    public partial class ShotEntryDetailPage : ContentPage
    {
        public ShotEntryDetailPage()
        {
            InitializeComponent();
            BindingContext = new ShotEntryDetailViewModel(this);
        }
    }
}