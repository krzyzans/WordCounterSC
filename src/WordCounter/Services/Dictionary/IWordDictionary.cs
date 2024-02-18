namespace WordCounter.Services.Dictionary
{
    /// <summary>
    /// Covers logic responsible for storing results in dictionary
    /// </summary>
    internal interface IWordDictionary
    {
        internal string Add(string word);
    }
}
