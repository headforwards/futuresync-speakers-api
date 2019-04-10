using System;

namespace FutureSyncSpeakersAPI.Providers
{
#pragma warning disable S3925 // "ISerializable" should be implemented correctly
    public class SpeakerCacheProviderException : Exception
#pragma warning restore S3925 // "ISerializable" should be implemented correctly
    {
        public SpeakerCacheProviderException() : base()
        {
        }

        public SpeakerCacheProviderException(string message) : base(message)
        {
        }

        public SpeakerCacheProviderException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
