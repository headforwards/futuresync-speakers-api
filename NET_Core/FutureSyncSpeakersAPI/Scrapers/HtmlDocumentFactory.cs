using HtmlAgilityPack;
using System;

namespace FutureSyncSpeakersAPI.Scrapers
{
    public static class HtmlDocumentFactory
    {
        public static HtmlDocument FromUrl(string url)
        {
            try
            {
                var web = new HtmlWeb();
                return web.Load(url);
            }
            catch (Exception ex)
            {
                throw new HtmlDocumentFactoryException(
                    $"FromUrl failed with the arguments: path='{url}'",
                    ex);
            }
        }

        public static HtmlDocument FromPath(string path)
        {
            try
            {
                var doc = new HtmlDocument();
                doc.Load(path);
                return doc;
            }
            catch (Exception ex)
            {
                throw new HtmlDocumentFactoryException(
                    $"FromPath failed with the arguments: path='{path}'",
                    ex);
            }
        }
    }
}
