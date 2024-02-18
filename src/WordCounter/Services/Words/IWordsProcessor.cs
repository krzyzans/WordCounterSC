namespace WordCounter.Services.Words
{
    internal interface IWordsProcessor
    {
        public Task CountWords();
        public void PrintResult();
    }
}
