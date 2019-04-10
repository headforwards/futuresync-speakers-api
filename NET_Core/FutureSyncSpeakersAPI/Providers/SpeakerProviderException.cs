using System;

namespace FutureSyncSpeakersAPI.Providers
{
#pragma warning disable S3925 // "ISerializable" should be implemented correctly
    public class SpeakerProviderException : Exception
#pragma warning restore S3925 // "ISerializable" should be implemented correctly
    {
        public SpeakerProviderException() : base()
        {
        }

        public SpeakerProviderException(string message) : base(message)
        {
        }

        public SpeakerProviderException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
