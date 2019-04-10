using FutureSyncSpeakersAPI.Models;
using FutureSyncSpeakersAPI.Scrapers;
using System;
using System.Linq;
using System.Text;

namespace FutureSyncSpeakersAPI.Providers
{
    public static class TalkProvider
    {
        public static Talk FromSpeaker(Speaker speaker)
        {
            try
            {
                var talkDocument = HtmlDocumentFactory.FromUrl(speaker.TalkUrl);

                var container = talkDocument.DocumentNode.SelectNodes("//div[@class='container']").FirstOrDefault();

                var talk = new Talk
                {
                    Title = container.Descendants("h1").First().InnerText ?? "No Title",
                    TalkUrl = speaker.TalkUrl
                };

                StringBuilder description = new StringBuilder();

                foreach (var paragraph in container.Descendants("p"))
                {
                    string text = paragraph.InnerText;
                    if (!string.IsNullOrWhiteSpace(text))
                        description.AppendLine(text);
                }

                talk.Description = description.ToString();

                if (string.IsNullOrEmpty(talk.Description))
                {
                    throw new TalkProviderException($"Failed to retrieve description for talk: '{speaker.TalkUrl}'");
                }

                return talk;
            }
            catch (Exception ex)
            {
                throw new TalkProviderException(
                    $"FromSpeaker Failed: '{speaker?.Name ?? "Null Speaker"}'",
                    ex);
            }
        }
    }
}
