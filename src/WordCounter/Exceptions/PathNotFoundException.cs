namespace WordCounter.Exceptions
{
    /// <summary>
    /// Exception class, thrown when Path do not exist
    /// </summary>
    internal class PathNotFoundException : CustomException
    {
        public PathNotFoundException(string path)
            : base($"Path not found: {path}")
        {
            
        }
    }
}
