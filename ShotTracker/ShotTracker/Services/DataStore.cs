using ShotTracker.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShotTracker.Services
{
    class DataStore : IDataStore
    {
        public async Task<FilterSetting> GetFilterSettingAsync(int id)
        {
            return await App.Database.GetFilterSettingAsync(id);
        }

        public async Task<bool> UpdateFilterSettingAsync(FilterSetting setting)
        {
            int result = await App.Database.UpdateShotDataFilter(setting);
            return await Task.FromResult(result > 0 ? true : false);
        }
        public async Task<bool> AddFilterSettingAsync(FilterSetting setting)
        {
            int result = await App.Database.SaveShotDataFilter(setting);
            return await Task.FromResult(result > 0 ? true: false);
        }

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

        public async Task<ShotEntry> GetShotEntryAsync(int id)
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
