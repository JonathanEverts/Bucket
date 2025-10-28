namespace BucketClassLibrary.Models.Exceptions
{
    public class EmptyContainerException : Exception
    {
        public EmptyContainerException() { }
        public EmptyContainerException(string message) : base(message) { }
        public EmptyContainerException(string message, Exception innerException) : base(message, innerException) { }
    }
}
