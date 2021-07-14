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

        public Color PaintBackground { get { return GetBackgroundColor(Paint); } }
        public Color ShortLeftBackground { get { return GetBackgroundColor(ShortLeft); } }
        public Color LeftElbowBackground { get { return GetBackgroundColor(LeftElbow); } }
        public Color FreeThrowBackground { get { return GetBackgroundColor(FreeThrow); } }
        public Color RightElbowBackground { get { return GetBackgroundColor(RightElbow); } }
        public Color ShortRightBackground { get { return GetBackgroundColor(ShortRight); } }
        public Color LeftCornerBackground { get { return GetBackgroundColor(LeftCorner); } }
        public Color LeftWingBackground { get { return GetBackgroundColor(LeftWing); } }
        public Color TopKeyBackground { get { return GetBackgroundColor(TopKey); } }
        public Color RightWingBackground { get { return GetBackgroundColor(RightWing); } }
        public Color RightCornerBackground { get { return GetBackgroundColor(RightCorner); } }

        public HomeViewModel()
        {
            Title = "Home";
            ShotEntries = new ObservableCollection<ShotEntry>();
            ZonePressedCommand = new Command<ShotLocation>(OnZoneSelected);
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
            Task.Run(async () => await LoadItems());
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

            OnPropertyChanged(nameof(PaintBackground));
            OnPropertyChanged(nameof(ShortLeftBackground));
            OnPropertyChanged(nameof(LeftElbowBackground));
            OnPropertyChanged(nameof(FreeThrowBackground));
            OnPropertyChanged(nameof(RightElbowBackground));
            OnPropertyChanged(nameof(ShortRightBackground));
            OnPropertyChanged(nameof(LeftCornerBackground));
            OnPropertyChanged(nameof(LeftWingBackground));
            OnPropertyChanged(nameof(TopKeyBackground));
            OnPropertyChanged(nameof(RightWingBackground));
            OnPropertyChanged(nameof(RightCornerBackground));
        }

        private Color GetBackgroundColor(string text)
        {
            double x = double.Parse(text.Split('/')[0]);
            double y = double.Parse(text.Split('/')[1]);

            if (y > 0)
            {
                double percentage = (x / y) * 100;
                switch (percentage)
                {
                    case var expression when percentage == 100:
                        return Color.FromHex("#087300");
                    case var expression when percentage > 90:
                        return Color.FromHex("#459600");
                    case var expression when percentage > 80:
                        return Color.FromHex("#82B900");
                    case var expression when percentage > 70:
                        return Color.FromHex("#BEDC00");
                    case var expression when percentage > 60:
                        return Color.FromHex("#FBFF00");
                    case var expression when percentage > 50:
                        return Color.FromHex("#FDD100");
                    case var expression when percentage > 40:
                        return Color.FromHex("#FFA200");
                    case var expression when percentage > 30:
                        return Color.FromHex("#FF7A00");
                    case var expression when percentage > 20:
                        return Color.FromHex("#FF5100");
                    case var expression when percentage > 10:
                        return Color.FromHex("#FF2900");
                    default:
                        return Color.FromHex("#FF0000");
                }
            }
            else
            {
                return Color.FromHex("#202020");
            }

        }

        async void OnZoneSelected(ShotLocation location)
        {
            await Shell.Current.GoToAsync($"{nameof(ShotEntriesPage)}?{nameof(ShotEntriesViewModel.Location)}={(int)location}");
        }
    }
}