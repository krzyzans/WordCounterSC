namespace WordCounter.Services.Dictionary
{
    /// <summary>
    /// Covers logic responsible for storing results in dictionary
    /// </summary>
    internal interface IWordDictionary
    {
        /// <summary>
        /// Method for secure concurrent add element to dictionary
        /// </summary>
        /// <param name="word">Key to add</param>
        internal string Add(string word);
    }
}
