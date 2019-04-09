using FutureSyncSpeakersAPI.Scrapers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FutureSyncSpeakersAPI.Tests.Scrapers
{
    [TestClass]
    public class HtmlDocumentFactoryTests
    {
        [TestMethod]
        public void ReturnsHtmlDocumentFromUrl()
        {
            var result = HtmlDocumentFactory.FromUrl("https://futuresync.co.uk/");

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ReturnsHtmlDocumentFromPath()
        {
            var result = HtmlDocumentFactory.FromPath("./Samples/futuresync.html");

            Assert.IsNotNull(result);
        }
    }
}
