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
        private ObservableCollection<ShotEntry> _shotEntries;
        private ShotEntry _selectedShotEntry;
        private string _location;

        public ShotEntriesViewModel()
        {
            AddShotEntryCommand = new Command(OnAddShotEntry);
            ShotEntries = new ObservableCollection<ShotEntry>();
        }

        public ObservableCollection<ShotEntry> ShotEntries
        {
            get => _shotEntries;
            set
            {
                _shotEntries = value;
                OnPropertyChanged(nameof(ShotEntries));
            }
        }
        public string Location
        {
            get => _location;
            set
            {               
                if (_location != value)
                {
                    _location = value;
                    Task.Run(() => ShotEntries = new ObservableCollection<ShotEntry>(DataStore.GetShotEntriesAsync(true).Result.Where(o => o.Location == (ShotLocation)int.Parse(_location))));                    
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