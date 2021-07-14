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
        }

        public Task<List<ShotEntry>> GetShotEntriesAsync()
        {
            return database.Table<ShotEntry>().ToListAsync();
        }

        public Task<ShotEntry> GetShotEntryAsync(int id)
        {
            return database.Table<ShotEntry>()
                            .Where(i => i.Id == id)
                            .FirstOrDefaultAsync();
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