using FutureSyncSpeakersAPI.Providers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FutureSyncSpeakersAPI.Tests.Providers
{
    [TestClass]
    public class TalkProviderTests
    {
        [TestMethod]
        public void TalkProvider_Success()
        {
            var talk = TalkProvider.FromTalkUrl(Constants.KeynoteUrl);

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
                 "Talk url not set");
        }

        [TestMethod]
        [ExpectedException(typeof(TalkProviderException))]
        public void TalkProvider_Error()
        {
            _ = TalkProvider.FromTalkUrl(null);
        }
    }
}
