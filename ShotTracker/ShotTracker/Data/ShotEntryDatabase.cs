using ShotTracker.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShotTracker.Data
{
    public class ShotEntryDatabase
    {
        readonly SQLiteAsyncConnection database;

        public ShotEntryDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<ShotEntry>().Wait();
            database.CreateTableAsync<FilterSetting>().Wait();
        }

        public Task<List<ShotEntry>> GetShotEntriesAsync()
        {
            return database.Table<ShotEntry>().ToListAsync();
        }

        public Task<ShotEntry> GetShotEntryAsync(int id)
        {
            return database.Table<ShotEntry>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }
        public Task<FilterSetting> GetFilterSettingAsync(int id)
        {
            return database.Table<FilterSetting>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }
        public Task<int> SaveShotDataFilter(FilterSetting setting)
        {
            return database.InsertAsync(setting);
        }

        public Task<int> UpdateShotDataFilter(FilterSetting setting)
        {
            return database.UpdateAsync(setting);
        }

        public Task<int> SaveShotEntryAsync(ShotEntry entry)
        {
            return database.InsertAsync(entry);
        }

        public Task<int> UpdateShotEntryAsync(ShotEntry entry)
        {
            return database.UpdateAsync(entry);
        }

        public Task<int> DeleteShotEntryAsync(ShotEntry entry)
        {
            return database.DeleteAsync(entry);
        }
    }
}