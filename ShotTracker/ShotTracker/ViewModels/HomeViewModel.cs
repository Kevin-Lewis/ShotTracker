using ShotTracker.Models;
using ShotTracker.Views;
using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShotTracker.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public ObservableCollection<ShotEntry> ShotEntries { get; }
        public Command ZonePressedCommand { get; }
        public ShotLocation Location { get; }

        public string Paint { get; set; }

        public string ShortLeft { get; set; }

        public string LeftElbow { get; set; }

        public string FreeThrow { get; set; }

        public string RightElbow { get; set; }

        public string ShortRight { get; set; }

        public string LeftCorner { get; set; }

        public string LeftWing { get; set; }

        public string TopKey { get; set; }

        public string RightWing { get; set; }

        public string RightCorner { get; set; }

        public HomeViewModel()
        {
            Title = "Home";
            ShotEntries = new ObservableCollection<ShotEntry>();
            ZonePressedCommand = new Command<ShotLocation>(OnZoneSelected);

            Task.Run(async () => await LoadItems());
            
        }

        private async Task LoadItems()
        {
            try
            {
                ShotEntries.Clear();
                var items = await DataStore.GetShotEntriesAsync(true);
                foreach (var item in items)
                {
                    ShotEntries.Add(item);
                }
                SetZoneText();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
        }

        private void SetZoneText()
        {
            Paint = $"{ShotEntries.Where(o => o.Location == ShotLocation.Paint).Sum(item => item.Makes)}/{ShotEntries.Where(o => o.Location == ShotLocation.Paint).Sum(item => item.Makes + item.Misses)}";
            ShortLeft = $"{ShotEntries.Where(o => o.Location == ShotLocation.ShortLeft).Sum(item => item.Makes)}/{ShotEntries.Where(o => o.Location == ShotLocation.ShortLeft).Sum(item => item.Makes + item.Misses)}";
            LeftElbow = $"{ShotEntries.Where(o => o.Location == ShotLocation.LeftElbow).Sum(item => item.Makes)}/{ShotEntries.Where(o => o.Location == ShotLocation.LeftElbow).Sum(item => item.Makes + item.Misses)}";
            FreeThrow = $"{ShotEntries.Where(o => o.Location == ShotLocation.FreeThrow).Sum(item => item.Makes)}/{ShotEntries.Where(o => o.Location == ShotLocation.FreeThrow).Sum(item => item.Makes + item.Misses)}";
            RightElbow = $"{ShotEntries.Where(o => o.Location == ShotLocation.RightElbow).Sum(item => item.Makes)}/{ShotEntries.Where(o => o.Location == ShotLocation.RightElbow).Sum(item => item.Makes + item.Misses)}";
            ShortRight = $"{ShotEntries.Where(o => o.Location == ShotLocation.ShortRight).Sum(item => item.Makes)}/{ShotEntries.Where(o => o.Location == ShotLocation.ShortRight).Sum(item => item.Makes + item.Misses)}";
            LeftCorner = $"{ShotEntries.Where(o => o.Location == ShotLocation.LeftCorner).Sum(item => item.Makes)}/{ShotEntries.Where(o => o.Location == ShotLocation.LeftCorner).Sum(item => item.Makes + item.Misses)}";
            LeftWing = $"{ShotEntries.Where(o => o.Location == ShotLocation.LeftWing).Sum(item => item.Makes)}/{ShotEntries.Where(o => o.Location == ShotLocation.LeftWing).Sum(item => item.Makes + item.Misses)}";
            TopKey = $"{ShotEntries.Where(o => o.Location == ShotLocation.TopKey).Sum(item => item.Makes)}/{ShotEntries.Where(o => o.Location == ShotLocation.TopKey).Sum(item => item.Makes + item.Misses)}";
            RightWing = $"{ShotEntries.Where(o => o.Location == ShotLocation.RightWing).Sum(item => item.Makes)}/{ShotEntries.Where(o => o.Location == ShotLocation.RightWing).Sum(item => item.Makes + item.Misses)}";
            RightCorner = $"{ShotEntries.Where(o => o.Location == ShotLocation.RightCorner).Sum(item => item.Makes)}/{ShotEntries.Where(o => o.Location == ShotLocation.RightCorner).Sum(item => item.Makes + item.Misses)}";
            
            OnPropertyChanged(nameof(Paint));
            OnPropertyChanged(nameof(ShortLeft));
            OnPropertyChanged(nameof(LeftElbow));
            OnPropertyChanged(nameof(FreeThrow));
            OnPropertyChanged(nameof(RightElbow));
            OnPropertyChanged(nameof(ShortRight));
            OnPropertyChanged(nameof(LeftCorner));
            OnPropertyChanged(nameof(LeftWing));
            OnPropertyChanged(nameof(TopKey));
            OnPropertyChanged(nameof(RightWing));
            OnPropertyChanged(nameof(RightCorner));
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewShotEntryPage));
        }

        async void OnZoneSelected(ShotLocation location)
        {
            await Shell.Current.GoToAsync($"{nameof(ShotEntriesPage)}?{nameof(ShotEntriesViewModel.Location)}={(int)location}");
        }
    }
}