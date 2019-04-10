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
                    ImageUrl = $"https://futuresync.co.uk{htmlNode.Descendants("img").First().Attributes["src"].Value}",
                    Track = htmlNode.ParentNode.SelectSingleNode("preceding-sibling::h1[1]").InnerText
                };

                speaker.Talk = TalkProvider.FromTalkUrl(htmlNode.Descendants("a").First().Attributes["href"].Value);

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
