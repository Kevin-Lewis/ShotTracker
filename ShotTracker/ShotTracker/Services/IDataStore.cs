using ShotTracker.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShotTracker.Services
{
    public interface IDataStore
    {
        Task<bool> AddShotEntryAsync(ShotEntry item);
        Task<bool> UpdateShotEntryAsync(ShotEntry item);
        Task<FilterSetting> GetFilterSettingAsync(int id);
        Task<bool> AddFilterSettingAsync(FilterSetting setting);
        Task<bool> UpdateFilterSettingAsync(FilterSetting setting);
        Task<bool> DeleteShotEntryAsync(ShotEntry item);
        Task<ShotEntry> GetShotEntryAsync(int id);
        Task<IEnumerable<ShotEntry>> GetShotEntriesAsync(bool forceRefresh = false);
    }
}
