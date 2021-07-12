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
        public ObservableCollection<ShotEntryItem> ShotEntryItems { get; }
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
            Title = "Browse";
            ShotEntryItems = new ObservableCollection<ShotEntryItem>();
            ZonePressedCommand = new Command<ShotLocation>(OnZoneSelected);

            LoadItems();
        }

        private async Task LoadItems()
        {
            try
            {
                ShotEntryItems.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    ShotEntryItems.Add(item);
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
            Paint = $"{ShotEntryItems.Where(o => o.Location == ShotLocation.Paint).Sum(item => item.Makes)}/{ShotEntryItems.Where(o => o.Location == ShotLocation.Paint).Sum(item => item.Makes + item.Misses)}";
            ShortLeft = $"{ShotEntryItems.Where(o => o.Location == ShotLocation.ShortLeft).Sum(item => item.Makes)}/{ShotEntryItems.Where(o => o.Location == ShotLocation.ShortLeft).Sum(item => item.Makes + item.Misses)}";
            LeftElbow = $"{ShotEntryItems.Where(o => o.Location == ShotLocation.LeftElbow).Sum(item => item.Makes)}/{ShotEntryItems.Where(o => o.Location == ShotLocation.LeftElbow).Sum(item => item.Makes + item.Misses)}";
            FreeThrow = $"{ShotEntryItems.Where(o => o.Location == ShotLocation.FreeThrow).Sum(item => item.Makes)}/{ShotEntryItems.Where(o => o.Location == ShotLocation.FreeThrow).Sum(item => item.Makes + item.Misses)}";
            RightElbow = $"{ShotEntryItems.Where(o => o.Location == ShotLocation.RightElbow).Sum(item => item.Makes)}/{ShotEntryItems.Where(o => o.Location == ShotLocation.RightElbow).Sum(item => item.Makes + item.Misses)}";
            ShortRight = $"{ShotEntryItems.Where(o => o.Location == ShotLocation.ShortRight).Sum(item => item.Makes)}/{ShotEntryItems.Where(o => o.Location == ShotLocation.ShortRight).Sum(item => item.Makes + item.Misses)}";
            LeftCorner = $"{ShotEntryItems.Where(o => o.Location == ShotLocation.LeftCorner).Sum(item => item.Makes)}/{ShotEntryItems.Where(o => o.Location == ShotLocation.LeftCorner).Sum(item => item.Makes + item.Misses)}";
            LeftWing = $"{ShotEntryItems.Where(o => o.Location == ShotLocation.LeftWing).Sum(item => item.Makes)}/{ShotEntryItems.Where(o => o.Location == ShotLocation.LeftWing).Sum(item => item.Makes + item.Misses)}";
            TopKey = $"{ShotEntryItems.Where(o => o.Location == ShotLocation.TopKey).Sum(item => item.Makes)}/{ShotEntryItems.Where(o => o.Location == ShotLocation.TopKey).Sum(item => item.Makes + item.Misses)}";
            RightWing = $"{ShotEntryItems.Where(o => o.Location == ShotLocation.RightWing).Sum(item => item.Makes)}/{ShotEntryItems.Where(o => o.Location == ShotLocation.RightWing).Sum(item => item.Makes + item.Misses)}";
            RightCorner = $"{ShotEntryItems.Where(o => o.Location == ShotLocation.RightCorner).Sum(item => item.Makes)}/{ShotEntryItems.Where(o => o.Location == ShotLocation.RightCorner).Sum(item => item.Makes + item.Misses)}";
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        async void OnZoneSelected(ShotLocation location)
        {
            await Shell.Current.GoToAsync($"{nameof(ShotEntryItemsPage)}?{nameof(ShotEntryItemsViewModel.Location)}={(int)location}");
        }
    }
}