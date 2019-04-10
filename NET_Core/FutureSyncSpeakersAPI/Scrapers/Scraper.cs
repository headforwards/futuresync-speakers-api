using System;
using System.Linq;
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

        public HtmlNode KeyNote
        {
            get
            {
                return HtmlDocument
                    .DocumentNode
                    .SelectNodes("//div[@class='speaker speaker--keynote']")
                    .FirstOrDefault();
            }
        }

        public HtmlNodeCollection Speakers
        {
            get
            {
                return HtmlDocument
                    .DocumentNode
                    .SelectNodes("//div[@class='speaker']");
            }
        }
    }
}
