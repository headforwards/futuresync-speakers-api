using FutureSyncSpeakersAPI.Scrapers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FutureSyncSpeakersAPI.Tests.Scrapers
{
    [TestClass]
    public class HtmlDocumentFactoryTests
    {
        [TestMethod]
        public void HtmlDocumentFactory_FromUrl()
        {
            var result = HtmlDocumentFactory.FromUrl(Constants.FutureSyncUrl);

            Assert.IsNotNull(
                result,
                "Expected to be able to retrieve document from url (requires web connection)");
        }

        [TestMethod]
        [ExpectedException(typeof(HtmlDocumentFactoryException))]
        public void HtmlDocumentFactory_FromUrl_Invalid()
        {
            _ = HtmlDocumentFactory.FromUrl(Guid.NewGuid().ToString());
        }

        [TestMethod]
        public void HtmlDocumentFactory_FromPath()
        {
            var result = HtmlDocumentFactory.FromPath(Constants.SampleFutureSyncFilePath);

            Assert.IsNotNull(
                result,
                "Expected to be able to retrieve document from path");
        }

        [TestMethod]
        [ExpectedException(typeof(HtmlDocumentFactoryException))]
        public void HtmlDocumentFactory_FromPath_Invalid()
        {
            _ = HtmlDocumentFactory.FromPath(Guid.NewGuid().ToString());
        }
    }
}
