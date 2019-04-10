using FutureSyncSpeakersAPI.Providers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace FutureSyncSpeakersAPI.Tests.Providers
{
    [TestClass]
    public class SpeakerCacheProviderTests
    {
        private ISpeakerCacheProvider speakerCacheProvider;

        [TestMethod]
        public void Init()
        {
            speakerCacheProvider = new SpeakerCacheProvider(Constants.CacheFileName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SpeakerCacheProvider_Empty_Cache_Path()
        {
            _ = new SpeakerCacheProvider(null);
        }
    }
}
