using System;

namespace FutureSyncSpeakersAPI.Scrapers
{
#pragma warning disable S3925 // "ISerializable" should be implemented correctly
    public class HtmlDocumentFactoryException : Exception
#pragma warning restore S3925 // "ISerializable" should be implemented correctly
    {
        public HtmlDocumentFactoryException() : base()
        {
        }

        public HtmlDocumentFactoryException(string message) : base(message)
        {
        }

        public HtmlDocumentFactoryException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
