using System;

namespace FutureSyncSpeakersAPI.Providers
{
#pragma warning disable S3925 // "ISerializable" should be implemented correctly
    public class TalkProviderException : Exception
#pragma warning restore S3925 // "ISerializable" should be implemented correctly
    {
        public TalkProviderException() : base()
        {
        }

        public TalkProviderException(string message) : base(message)
        {
        }

        public TalkProviderException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
