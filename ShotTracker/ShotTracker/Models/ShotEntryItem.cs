using System;

namespace ShotTracker.Models
{
    public class ShotEntryItem
    {
        public string Id { get; set; }
        public int Makes { get; set; }
        public int Misses { get; set; }
        public ShotLocation Location { get; set; }
    }
}