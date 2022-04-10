using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microcharts;
using ShotTracker.Models;
using SkiaSharp;
using Entry = Microcharts.ChartEntry;

namespace ShotTracker.ViewModels
{
    public class ChartViewModel : BaseViewModel
    {
        private List<ShotEntry> _shotEntries;
        public ChartViewModel()
        {
            Title = "Analytics";
            ShootingProgressChart = new LineChart();
            Task.Run(() => LoadShotEntries());         
        }

        public LineChart ShootingProgressChart { get; set; }

        public List<ShotEntry> ShotEntries
        {
            get
            {
                return _shotEntries;
            }
            set
            {
                _shotEntries = value;
                OnPropertyChanged(nameof(ShotEntries));
            }
        }

        public List<Entry> GetShootingProgressChartData()
        {
            DateTime day1 = new DateTime(DateTime.Today.Ticks);
            float val1 = (float)(ShotEntries.Where(o => (o.Date >= day1)).ToList().Count > 0 ? Math.Round((float)ShotEntries.Where(o => o.Date >= day1).Sum(item => item.Makes) / (float)ShotEntries.Where(o => o.Location == ShotLocation.Paint).Sum(item => item.Makes + item.Misses) * 100) : 0);
            List<Entry> entries = new List<Entry>
            {             
                new Entry(val1)
                {
                    Color=SKColor.Parse("#FF1943"),
                    Label = (DateTime.Now.DayOfWeek - 4).ToString(),
                    ValueLabel = "200"
                },
                new Entry(400)
                {
                    Color = SKColor.Parse("00BFFF"),
                    Label = (DateTime.Now.DayOfWeek - 3).ToString(),
                    ValueLabel = "400"
                },
                new Entry(-100)
                {
                    Color =  SKColor.Parse("#00CED1"),
                    Label = (DateTime.Now.DayOfWeek - 2).ToString(),
                    ValueLabel = "-100"
                },
                new Entry(-100)
                {
                    Color =  SKColor.Parse("#00CED1"),
                    Label = (DateTime.Now.DayOfWeek - 1).ToString(),
                    ValueLabel = "-100"
                },
                new Entry(-100)
                {
                    Color =  SKColor.Parse("#00CED1"),
                    Label = (DateTime.Now.DayOfWeek - 0).ToString(),
                    ValueLabel = "-100"
                },
            };
            return entries;
        }

        private async void LoadShotEntries()
        {
            try
            {
                ShotEntries = new List<ShotEntry>();
                var items = await DataStore.GetShotEntriesAsync(true);
                foreach (var item in items)
                {
                    ShotEntries.Add(item);
                }
                ShootingProgressChart.Entries = GetShootingProgressChartData();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
