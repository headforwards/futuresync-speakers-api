using FutureSyncSpeakersAPI.Models;
using FutureSyncSpeakersAPI.Scrapers;
using System;
using System.Linq;
using System.Text;

namespace FutureSyncSpeakersAPI.Providers
{
    public static class TalkProvider
    {
        public static Talk FromTalkUrl(string url)
        {
            try
            {
                var talkDocument = HtmlDocumentFactory.FromUrl(url);

                var container = talkDocument.DocumentNode.SelectNodes("//div[@class='container']").FirstOrDefault();

                var talk = new Talk
                {
                    Title = container.Descendants("h1").First().InnerText ?? "No Title",
                    TalkUrl = url
                };

                StringBuilder description = new StringBuilder();

                foreach (var paragraph in container.Descendants("p"))
                {
                    string text = paragraph.InnerText;
                    if (!string.IsNullOrWhiteSpace(text))
                        description.AppendLine(text);
                }

                talk.Description = description.ToString().Trim();

                if (string.IsNullOrEmpty(talk.Description))
                {
                    throw new TalkProviderException($"Failed to retrieve description for talk: '{url}'");
                }

                return talk;
            }
            catch (Exception ex)
            {
                throw new TalkProviderException(
                    $"FromTalkUrlFailed: '{url ?? "Null Url"}'",
                    ex);
            }
        }
    }
}
