using FutureSyncSpeakersAPI.Models;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FutureSyncSpeakersAPI.Providers
{
    public static class SpeakerProvider
    {
        public static Speaker FromHtmlNode(HtmlNode htmlNode)
        {
            try
            {
                var speaker = new Speaker
                {
                    Name = htmlNode.Descendants("h2").First().InnerText,
                    Description = htmlNode.Descendants("p").First().InnerText,
                    ImageUrl = htmlNode.Descendants("img").First().Attributes["src"].Value,
                    TalkUrl = htmlNode.Descendants("a").First().Attributes["href"].Value,
                    IsKeyNote = htmlNode.Attributes["class"].Value.Contains("speaker--keynote")
                };
                speaker.Talk = TalkProvider.FromSpeaker(speaker);
                return speaker;
            }
            catch (Exception ex)
            {
                throw new SpeakerProviderException(
                    $"FromHtmlNode failed with the error: '{ex.Message}'",
                    ex);
            }
        }

        public static IEnumerable<Speaker> FromHtmlNodes(HtmlNodeCollection htmlNodes)
        {
            try
            {
                List<Speaker> speakers = new List<Speaker>();

                foreach (var htmlNode in htmlNodes)
                {
                    var speaker = FromHtmlNode(htmlNode);
                    if (speaker != null)
                    {
                        speaker.Talk = TalkProvider.FromSpeaker(speaker);
                        speakers.Add(speaker);
                    }
                }

                return speakers;
            }
            catch (Exception ex)
            {
                throw new SpeakerProviderException(
                    $"FromHtmlNodes failed with the error: '{ex.Message}'",
                    ex);
            }
        }
    }
}
