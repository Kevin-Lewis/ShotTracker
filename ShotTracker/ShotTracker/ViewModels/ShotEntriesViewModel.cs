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
    public class ShotEntriesViewModel : BaseViewModel
    {
        private ShotEntry _selectedShotEntry;
        private string _location;

        public ShotEntriesViewModel()
        {
            AddShotEntryCommand = new Command(OnAddShotEntry);
        }

        public ObservableCollection<ShotEntry> ShotEntries { get; set; }
        public string Location
        {
            get => _location;
            set
            {               
                if (_location != value)
                {
                    _location = value;
                    ShotEntries = new ObservableCollection<ShotEntry>(DataStore.GetShotEntriesAsync(true).Result.Where(o => o.Location == (ShotLocation)int.Parse(_location)));
                    OnPropertyChanged(nameof(ShotEntries));
                }               
            }
        }
        public Command AddShotEntryCommand { get; set; }
        
        public void OnAppearing()
        {
            Title = "Shot Entry";
            IsBusy = true;
            SelectedShotEntry = null;
        }

        public ShotEntry SelectedShotEntry
        {
            get => _selectedShotEntry;
            set
            {
                _selectedShotEntry = value;
                OnShotEntrySelected(value);
                OnPropertyChanged(nameof(SelectedShotEntry));
            }
        }

        private async void OnAddShotEntry(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewShotEntryPage));
        }

        async void OnShotEntrySelected(ShotEntry item)
        {
            if (item == null)
                return;

            await Shell.Current.GoToAsync($"{nameof(ShotEntryDetailPage)}?{nameof(ShotEntryDetailViewModel.ID)}={item.Id}");
        }
    }
}