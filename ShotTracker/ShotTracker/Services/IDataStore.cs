using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShotTracker.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddShotEntryAsync(T item);
        Task<bool> UpdateShotEntryAsync(T item);
        Task<bool> DeleteShotEntryAsync(string id);
        Task<T> GetShotEntryAsync(string id);
        Task<IEnumerable<T>> GetShotEntriesAsync(bool forceRefresh = false);
    }
}
