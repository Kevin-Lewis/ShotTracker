using ShotTracker.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShotTracker.Services
{
    public class DataStore : IDataStore<ShotEntry>
    {
        public Task<bool> AddShotEntryAsync(ShotEntry item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteShotEntryAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ShotEntry>> GetShotEntriesAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        public Task<ShotEntry> GetShotEntryAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateShotEntryAsync(ShotEntry item)
        {
            throw new NotImplementedException();
        }
    }
}
