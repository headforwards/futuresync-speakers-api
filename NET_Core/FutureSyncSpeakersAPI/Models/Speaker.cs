﻿namespace FutureSyncSpeakersAPI.Models
{
    public class Speaker
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Track { get; set; }
        public Talk Talk { get; set; }
    }
}
