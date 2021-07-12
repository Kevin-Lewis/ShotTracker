using ShotTracker.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShotTracker.ViewModels
{
    [QueryProperty(nameof(ID), nameof(ID))]
    public class ShotEntryItemDetailViewModel : BaseViewModel
    {
        private string _itemId;
        private int _makes;
        private int _misses;
        private ShotLocation _location;

        public string Id { get; set; }

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

        public string ID
        {
            get
            {
                return _itemId;
            }
            set
            {
                _itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(_itemId);
                Id = item.Id;
                Makes = item.Makes;
                Misses = item.Misses;

                Location = item.Location;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
