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
                OnPropertyChanged(nameof(OverallPercentage));
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
                }               
            }
        }

        public string OverallPercentage
        {
            get
            {
                if (ShotEntries.Count == 0)
                {
                    return string.Empty;
                }
                return $"{Math.Round((double)(ShotEntries.Sum(item => item.Makes) / (double)ShotEntries.Sum(item => item.Makes + item.Misses)) * 100)}%";
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
                if (_selectedShotEntry is null)
                {
                    Task.Run(() => ShotEntries = new ObservableCollection<ShotEntry>(DataStore.GetShotEntriesAsync(true).Result.Where(o => o.Location == (ShotLocation)int.Parse(_location))));
                }                
            }
        }

        private async void OnAddShotEntry(object obj)
        {
            await Shell.Current.GoToAsync($"{nameof(NewShotEntryPage)}?{nameof(NewShotEntryViewModel.LocationQueryString)}={Location}");
        }

        async void OnShotEntrySelected(ShotEntry entry)
        {
            if (entry == null)
                return;

            await Shell.Current.GoToAsync($"{nameof(ShotEntryDetailPage)}?{nameof(ShotEntryDetailViewModel.ID)}={entry.Id}");
        }
    }
}