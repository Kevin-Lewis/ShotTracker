using ShotTracker.Models;
using ShotTracker.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShotTracker.ViewModels
{
    [QueryProperty(nameof(Location), nameof(Location))]
    public class ShotEntryItemsViewModel : BaseViewModel
    {
        private ShotEntryItem _selectedItem;
        private string _location;

        public ObservableCollection<ShotEntryItem> Items { get; set; }
        public string Location
        {
            get => _location;
            set
            {
                _location = value;
                Items = new ObservableCollection<ShotEntryItem>(DataStore.GetItemsAsync(true).Result.Where(o => o.Location == (ShotLocation)int.Parse(_location)));
                OnPropertyChanged(nameof(Items));
            }
        }
        public Command AddItemCommand { get; }
        public Command<ShotEntryItem> ItemTapped { get; }
        
        public void OnAppearing()
        {
            Title = "Shot Entry";
            IsBusy = true;
            SelectedItem = null;
        }

        public ShotEntryItem SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        async void OnItemSelected(ShotEntryItem item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ShotEntryItemDetailViewModel.ID)}={item.Id}");
        }
    }
}