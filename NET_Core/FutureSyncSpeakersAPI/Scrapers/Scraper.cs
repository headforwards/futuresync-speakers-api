using System;
using HtmlAgilityPack;

namespace FutureSyncSpeakersAPI.Scrapers
{
    public class Scraper
    {
        public HtmlDocument HtmlDocument { get; }

        public Scraper(HtmlDocument htmlDocument)
        {
            HtmlDocument = htmlDocument ?? throw new ArgumentNullException(nameof(htmlDocument));
        }
    }
}
