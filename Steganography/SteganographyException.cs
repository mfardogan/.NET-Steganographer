using System;

namespace Steganography
{

    [Serializable]
    public class SteganographyException : Exception
    {
        public SteganographyException() { }
        public SteganographyException(string message) : base(message) { }
        public SteganographyException(string message, Exception inner) : base(message, inner) { }
        protected SteganographyException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
