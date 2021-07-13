using SQLite;
using System;

namespace ShotTracker.Models
{
    public class ShotEntry
    {
        [PrimaryKey, AutoIncrement]
        public string Id { get; set; }
        public int Makes { get; set; }
        public int Misses { get; set; }
        public string TextResult
        {
            get
            {
                return $"{Makes}/{Makes + Misses}";
            }
        }
        public ShotLocation Location { get; set; }
        public DateTime Date {get; set;}
    }
}