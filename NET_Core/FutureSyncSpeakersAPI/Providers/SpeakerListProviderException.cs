using System;

namespace FutureSyncSpeakersAPI.Providers
{
#pragma warning disable S3925 // "ISerializable" should be implemented correctly
    public class SpeakerListProviderException : Exception
#pragma warning restore S3925 // "ISerializable" should be implemented correctly
    {
        public SpeakerListProviderException() : base()
        {
        }

        public SpeakerListProviderException(string message) : base(message)
        {
        }

        public SpeakerListProviderException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
