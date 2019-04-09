using System;
using FutureSyncSpeakersAPI.Scrapers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FutureSyncSpeakersAPI.Tests.Scrapers
{
    [TestClass]
    public class ScraperTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_null_htmlDocument()
        {
           _ = new Scraper(null);
        }

        [TestMethod]
        public void Ctor_Success()
        {
            var htmlDocument = HtmlDocumentFactory.FromPath("./Samples/futuresync.html");

            var scraper = new Scraper(htmlDocument);

            Assert.AreSame(htmlDocument, scraper.HtmlDocument, "HtmlDocument property not set");
        }
    }
}
