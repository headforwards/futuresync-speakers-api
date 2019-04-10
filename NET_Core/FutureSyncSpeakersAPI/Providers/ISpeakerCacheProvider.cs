using FutureSyncSpeakersAPI.Models;
using System.Collections.Generic;

namespace FutureSyncSpeakersAPI.Providers
{
    public interface ISpeakerCacheProvider
    {
        IEnumerable<Speaker> Get();
        IEnumerable<Speaker> Update();
        string CachePath { get; }
    }
}
