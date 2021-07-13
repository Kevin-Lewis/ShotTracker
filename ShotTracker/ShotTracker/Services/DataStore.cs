using ShotTracker.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShotTracker.Services
{
    class DataStore : IDataStore<ShotEntry>
    {
        public async Task<bool> AddShotEntryAsync(ShotEntry item)
        {
            await App.Database.SaveShotEntryAsync(item);
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteShotEntryAsync(ShotEntry item)
        {
            await App.Database.DeleteShotEntryAsync(item);
            return await Task.FromResult(true);
        }

        public async Task<IEnumerable<ShotEntry>> GetShotEntriesAsync(bool forceRefresh = false)
        {
            return await App.Database.GetShotEntriesAsync();
        }

        public async Task<ShotEntry> GetShotEntryAsync(string id)
        {
            return await App.Database.GetShotEntryAsync(id);
        }

        public async Task<bool> UpdateShotEntryAsync(ShotEntry item)
        {
            await App.Database.UpdateShotEntryAsync(item);
            return await Task.FromResult(true);
        }
    }
}
