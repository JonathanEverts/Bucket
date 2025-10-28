namespace BucketClassLibrary.Models.Exceptions
{
    public class BucketSizeException : Exception
    {
        public BucketSizeException() { }
        public BucketSizeException(string message) : base(message) { }
        public BucketSizeException(string message, Exception innerException) : base(message, innerException) { }
    }
}
