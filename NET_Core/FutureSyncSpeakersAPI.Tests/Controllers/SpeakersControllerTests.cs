using FutureSyncSpeakersAPI.Controllers;
using FutureSyncSpeakersAPI.Models;
using FutureSyncSpeakersAPI.Providers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using System;
using System.Collections.Generic;
using System.IO;

namespace FutureSyncSpeakersAPI.Tests.Controllers
{
    [TestClass]
    public class SpeakersControllerTests
    {
        [TestMethod]
        public void SpeakersController_Get_Success()
        {
            IHostingEnvironment environment = Substitute.For<IHostingEnvironment>();

            var currentDir = Directory.GetCurrentDirectory();

            environment.ContentRootPath.Returns(currentDir);

            var controller = new SpeakersController(environment);

            var speakers = controller.Get();

            Assert.IsNotNull(
                speakers,
                "Expected list of speakers (requires internet connection)");

            var expectedCachePath = Path.Combine(
                currentDir,
                "Data",
                Constants.CacheFileName);

            Assert.AreEqual(
                expectedCachePath,
                controller.SpeakerCacheProvider.CachePath);
        }

        [TestMethod]
        [ExpectedException(typeof(SpeakerCacheProviderException))]
        public void SpeakersController_Get_Error()
        {
            IHostingEnvironment environment = Substitute.For<IHostingEnvironment>();
            environment.ContentRootPath.Returns(Directory.GetCurrentDirectory());
            ISpeakerCacheProvider speakerCacheProvider = Substitute.For<ISpeakerCacheProvider>();
            speakerCacheProvider.Get().Throws(new SpeakerCacheProviderException("error"));
            var controller = new SpeakersController(environment)
            {
                SpeakerCacheProvider = speakerCacheProvider
            };

            _ = controller.Get();
        }
    }
}
