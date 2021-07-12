using ShotTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShotTracker.Services
{
    public class MockDataStore : IDataStore<ShotEntryItem>
    {
        readonly List<ShotEntryItem> items;

        public MockDataStore()
        {
            items = new List<ShotEntryItem>()
            {
                new ShotEntryItem { Id = Guid.NewGuid().ToString(), Makes = 0, Misses = 0, Location = (ShotLocation)0 },
                new ShotEntryItem { Id = Guid.NewGuid().ToString(), Makes = 10, Misses = 5, Location = (ShotLocation)1 },
                new ShotEntryItem { Id = Guid.NewGuid().ToString(), Makes = 22, Misses = 32, Location = (ShotLocation)2 },
                new ShotEntryItem { Id = Guid.NewGuid().ToString(), Makes = 3, Misses = 7, Location = (ShotLocation)3 },
                new ShotEntryItem { Id = Guid.NewGuid().ToString(), Makes = 1, Misses = 0, Location = (ShotLocation)4 },
                new ShotEntryItem { Id = Guid.NewGuid().ToString(), Makes = 0, Misses = 3, Location = (ShotLocation)5 },
                new ShotEntryItem { Id = Guid.NewGuid().ToString(), Makes = 300, Misses = 333, Location = (ShotLocation)6 },
                new ShotEntryItem { Id = Guid.NewGuid().ToString(), Makes = 997, Misses = 1006, Location = (ShotLocation)7 },
                new ShotEntryItem { Id = Guid.NewGuid().ToString(), Makes = 2453, Misses = 3005, Location = (ShotLocation)8 },
                new ShotEntryItem { Id = Guid.NewGuid().ToString(), Makes = 5, Misses = 2, Location = (ShotLocation)9 },
                new ShotEntryItem { Id = Guid.NewGuid().ToString(), Makes = 10000, Misses = 999, Location = (ShotLocation)10 }
            };
        }

        public async Task<bool> AddItemAsync(ShotEntryItem item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(ShotEntryItem item)
        {
            var oldItem = items.Where((ShotEntryItem arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((ShotEntryItem arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<ShotEntryItem> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<ShotEntryItem>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}