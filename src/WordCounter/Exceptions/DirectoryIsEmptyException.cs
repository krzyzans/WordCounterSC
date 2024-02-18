namespace WordCounter.Exceptions
{
    //Exception class, thrown in case directory from configuration is empty
    internal class DirectoryIsEmptyException : CustomException
    {
        public DirectoryIsEmptyException(string directory)
            : base($"Directory is empty: {directory}")
        {
            
        }
    }
}
