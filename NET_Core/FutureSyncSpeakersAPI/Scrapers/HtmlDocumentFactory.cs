using System;
using HtmlAgilityPack;

namespace FutureSyncSpeakersAPI.Scrapers
{
    public static class HtmlDocumentFactory
    {
        public static HtmlDocument FromUrl(string url)
        {
            var web = new HtmlWeb();
            return web.Load(url);
        }

        public static HtmlDocument FromPath(string path)
        {
            var doc = new HtmlDocument();
            doc.Load(path);
            return doc;
        }
    }
}
