using System;

namespace GameCore.WcfService.Exceptions
{
    public class PrimaryKeyViolationException : Exception
    {
        public PrimaryKeyViolationException(string message) : base(message) { }
        public PrimaryKeyViolationException(string message, Exception innerException) : base(message, innerException) { }
    }
}