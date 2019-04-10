using FutureSyncSpeakersAPI.Models;
using FutureSyncSpeakersAPI.Providers;
using FutureSyncSpeakersAPI.Scrapers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace FutureSyncSpeakersAPI.Tests.Providers
{
    [TestClass]
    public class TalkProviderTests
    {
        private Speaker speaker;

        [TestInitialize]
        public void Init()
        {
            var htmlDocument = HtmlDocumentFactory.FromPath(Constants.SampleFutureSyncFilePath);
            var scraper = new Scraper(htmlDocument);

            speaker = SpeakerProvider.FromHtmlNode(scraper.KeyNote);
        }

        [TestMethod]
        public void TalkProvider_Success()
        {
            var talk = TalkProvider.FromSpeaker(speaker);

            Assert.IsNotNull(
                talk,
                "Expected Talk object to be returned (requires internet connection)");

            Assert.IsFalse(
                string.IsNullOrEmpty(talk.Title),
                "Talk title not set");

            Assert.IsFalse(
                string.IsNullOrEmpty(talk.Description),
                "Talk description not set");

            Assert.IsFalse(
                 string.IsNullOrEmpty(talk.TalkUrl),
                 "Talk description not set");
        }

        [TestMethod]
        [ExpectedException(typeof(TalkProviderException))]
        public void TalkProvider_Error()
        {
            _ = TalkProvider.FromSpeaker(null);
        }
    }
}
