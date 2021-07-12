using ShotTracker.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace ShotTracker.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ShotEntryItemDetailViewModel();
        }
    }
}