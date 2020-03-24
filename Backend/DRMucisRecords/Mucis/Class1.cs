using System;

namespace Mucis
{
    public class Record
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public TimeSpan Duration { get; set; }
        public int YearOfPublication { get; set; }
        public int NumberOfSongs { get; set; }
    }
}
