using FutureSyncSpeakersAPI.Providers;
using FutureSyncSpeakersAPI.Scrapers;
using HtmlAgilityPack;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace FutureSyncSpeakersAPI.Tests.Providers
{
    [TestClass]
    public class SpeakerProviderTests
    {
        private HtmlDocument htmlDocument;
        private Scraper scraper;

        [TestInitialize]
        public void Init()
        {
            htmlDocument = HtmlDocumentFactory.FromPath(Constants.SampleFutureSyncFilePath);
            scraper = new Scraper(htmlDocument);
        }

        [TestMethod]
        public void SpeakerProvider_FromHtmlNode()
        {
            var speakerNode = scraper.KeyNote;

            var speaker = SpeakerProvider.FromHtmlNode(speakerNode);

            Assert.IsNotNull(
                speaker,
                "Expected speaker object to be returned");
        }

        [TestMethod]
        public void SpeakerProvider_FromHtmlNode_KeyNote()
        {
            var speakerNode = scraper.KeyNote;

            var speaker = SpeakerProvider.FromHtmlNode(speakerNode);

            Assert.IsTrue(
                speaker.IsKeyNote,
                "Expected speaker to be keynote");
        }

        [TestMethod]
        [ExpectedException(typeof(SpeakerProviderException))]
        public void SpeakerProvider_FromHtmlNode_Invalid_HtmlNode()
        {
            var speaker = SpeakerProvider.FromHtmlNode(null);

            Assert.IsNull(
                speaker,
                "Expected null object");
        }

        [TestMethod]
        public void SpeakerProvider_FromHtmlNodes()
        {
            var htmlNodes = scraper.Speakers;

            var speakers = SpeakerProvider.FromHtmlNodes(htmlNodes);

            Assert.IsTrue(
                speakers?.Any() ?? false,
                "Expected speakers to be returned");
        }

        [TestMethod]
        [ExpectedException(typeof(SpeakerProviderException))]
        public void SpeakerProvider_FromHtmlNodes_Invalid_HtmlNodes()
        {
            _ = SpeakerProvider.FromHtmlNodes(null);
        }
    }
}
