using System;
using System.Runtime.Serialization;

namespace Book.UserExceptions
{
    [Serializable]
    public class DuplicateBookException : ApplicationException
    {
        public DuplicateBookException() { }

        public DuplicateBookException(string message) : base(message) { }

        public DuplicateBookException(string message, Exception ex) : base(message, ex) { }

        protected DuplicateBookException(SerializationInfo info, StreamingContext context) : base (info, context) { }

    }
}
