using ShotTracker.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShotTracker.ViewModels
{
    [QueryProperty(nameof(ID), nameof(ID))]
    public class ShotEntryDetailViewModel : BaseViewModel
    {
        private int _shotEntryId;
        private int _makes;
        private int _misses;
        private ShotLocation _location;
        private DateTime _date;

        public int Makes
        {
            get => _makes;
            set => SetProperty(ref _makes, value);
        }

        public int Misses
        {
            get => _misses;
            set => SetProperty(ref _misses, value);
        }

        public ShotLocation Location
        {
            get => _location;
            set => SetProperty(ref _location, value);
        }

        public int ID
        {
            get
            {
                return _shotEntryId;
            }
            set
            {
                _shotEntryId = value;
                LoadItemId(value);
            }
        }

        public DateTime Date
        {
            get => _date;
            set => SetProperty(ref _date, value);
        }

        public async void LoadItemId(int itemId)
        {
            try
            {
                var item = await DataStore.GetShotEntryAsync(_shotEntryId);
                ID = item.Id;
                Makes = item.Makes;
                Misses = item.Misses;
                Location = item.Location;
                Date = item.Date;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
