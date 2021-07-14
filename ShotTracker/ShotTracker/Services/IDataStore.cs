using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShotTracker.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddShotEntryAsync(T item);
        Task<bool> UpdateShotEntryAsync(T item);
        Task<bool> DeleteShotEntryAsync(T item);
        Task<T> GetShotEntryAsync(int id);
        Task<IEnumerable<T>> GetShotEntriesAsync(bool forceRefresh = false);
    }
}
