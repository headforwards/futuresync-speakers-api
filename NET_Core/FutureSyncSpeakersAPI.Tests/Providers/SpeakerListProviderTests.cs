using FutureSyncSpeakersAPI.Providers;
using FutureSyncSpeakersAPI.Scrapers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace FutureSyncSpeakersAPI.Tests.Providers
{
    [TestClass]
    public class SpeakerListProviderTests
    {
        [TestMethod]
        public void SpeakerListProvider_Success()
        {
            var htmlDocument = HtmlDocumentFactory.FromPath(Constants.SampleFutureSyncFilePath);

            var speakers = SpeakerListProvider.AllSpeakers(htmlDocument);

            Assert.IsTrue(
                speakers.Count(o => o.Track == "keynote") == 1,
                "Expected a single keynote speaker");

            Assert.IsTrue(
                speakers.Any(o => o.Track != "keynote"),
                "Expected speakers who are not keynotes");
        }

        [TestMethod]
        [ExpectedException(typeof(SpeakerListProviderException))]
        public void SpeakerListProvider_FromHtmlDocument_Error()
        {
            _ = SpeakerListProvider.AllSpeakers(null);
        }
    }
}
