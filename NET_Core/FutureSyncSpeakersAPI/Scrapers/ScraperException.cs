using System;

namespace FutureSyncSpeakersAPI.Scrapers
{
#pragma warning disable S3925 // "ISerializable" should be implemented correctly
    public class ScraperException : Exception
#pragma warning restore S3925 // "ISerializable" should be implemented correctly
    {
        public ScraperException() : base()
        {
        }

        public ScraperException(string message) : base(message)
        {
        }

        public ScraperException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
