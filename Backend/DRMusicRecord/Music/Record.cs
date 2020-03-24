using System;

namespace Music
{
    public class Record
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public TimeSpan Duration { get; set; }
        public int YearOfPublication { get; set; }
    }
}
