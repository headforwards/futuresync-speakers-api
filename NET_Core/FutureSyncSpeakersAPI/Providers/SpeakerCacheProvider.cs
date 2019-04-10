using FutureSyncSpeakersAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace FutureSyncSpeakersAPI.Providers
{
    public class SpeakerCacheProvider : ISpeakerCacheProvider
    {
        public string CachePath { get; }

        public SpeakerCacheProvider(string cachePath)
        {
            if (string.IsNullOrEmpty(cachePath))
            {
                throw new ArgumentException("cachePath is empty", nameof(cachePath));
            }

            CachePath = cachePath;
        }

        public IEnumerable<Speaker> Get()
        {
            if (!File.Exists(CachePath))
            {
                UpdateCache();
            }

            var json = File.ReadAllText(CachePath);

            return JsonConvert.DeserializeObject<IEnumerable<Speaker>>(json);
        }

        private void UpdateCache()
        {
            var speakersToCache = SpeakerListProvider.AllSpeakers();

            var jsonToCache = JsonConvert.SerializeObject(speakersToCache, Formatting.Indented);

            Directory.CreateDirectory(Path.GetDirectoryName(CachePath));

            File.WriteAllText(CachePath, jsonToCache);
        }

        public IEnumerable<Speaker> Update()
        {
            UpdateCache();

            return Get();
        }
    }
}
