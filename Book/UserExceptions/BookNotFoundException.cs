using System;
using System.Runtime.Serialization;

namespace Book.UserExceptions
{
    [Serializable]
    public class BookNotFoundException : ApplicationException
    {
        public BookNotFoundException() { }

        public BookNotFoundException(string message) : base(message) { }

        public BookNotFoundException(string message, Exception ex) : base(message, ex) { }

        protected BookNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }

    }
}
