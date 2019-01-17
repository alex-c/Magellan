using System;
using System.Runtime.Serialization;

namespace Magellan
{
    /// <summary>
    /// Generic exception class for exceptions from the Magellan library.
    /// </summary>
    public class MagellanException : Exception
    {
        public MagellanException() { }

        public MagellanException(string message) : base(message) { }

        public MagellanException(string message, Exception innerException) : base(message, innerException) { }

        protected MagellanException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
