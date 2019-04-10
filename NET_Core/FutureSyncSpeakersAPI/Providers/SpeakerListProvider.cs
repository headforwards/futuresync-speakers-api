using FutureSyncSpeakersAPI.Models;
using FutureSyncSpeakersAPI.Scrapers;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FutureSyncSpeakersAPI.Providers
{
    public static class SpeakerListProvider
    {
        public static IEnumerable<Speaker> AllSpeakers(HtmlDocument htmlDocument)
        {
            try
            {
                var scraper = new Scraper(htmlDocument);

                var speakers = SpeakerProvider
                    .FromHtmlNodes(scraper.Speakers)
                    .ToList();

                speakers.Add(SpeakerProvider.FromHtmlNode(scraper.KeyNote));

                return speakers;
            }
            catch (Exception ex)
            {
                throw new SpeakerListProviderException(
                    "AllSpeakers (htmlDocument) failed",
                    ex);
            }
        }

        public static IEnumerable<Speaker> AllSpeakers()
        {
            try
            {
                return AllSpeakers(HtmlDocumentFactory.FromUrl(Constants.FutureSyncUrl));
            }
            catch (Exception ex)
            {
                throw new SpeakerListProviderException(
                    "AllSpeakers failed",
                    ex);
            }
        }
    }
}
