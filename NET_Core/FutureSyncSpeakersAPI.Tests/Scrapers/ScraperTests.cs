using FutureSyncSpeakersAPI.Scrapers;
using HtmlAgilityPack;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace FutureSyncSpeakersAPI.Tests.Scrapers
{
    [TestClass]
    public class ScraperTests
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
        [ExpectedException(typeof(ArgumentNullException))]
        public void Scraper_Ctor_Null_Args()
        {
            _ = new Scraper(null);
        }

        [TestMethod]
        public void Scraper_Ctor_Success()
        {
            Assert.AreSame(
                htmlDocument,
                scraper.HtmlDocument,
                "HtmlDocument property not set");
        }

        [TestMethod]
        public void Scraper_KeyNote()
        {
            Assert.IsNotNull(
                scraper.KeyNote,
                "Failed to retrieve KeyNote HtmlNode");
        }

        [TestMethod]
        public void Scraper_Speakers()
        {
            Assert.IsTrue(
                scraper.Speakers?.Any() ?? false,
                "Failed to retrieve speakers");
        }
    }
}
