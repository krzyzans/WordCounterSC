namespace WordCounter.Exceptions
{
    /// <summary>
    /// Base exception in case of catch only user defined exceptions
    /// </summary>
    internal abstract class CustomException : Exception
    {
        public CustomException(string message)
            : base(message)
        {
            
        }
    }
}
