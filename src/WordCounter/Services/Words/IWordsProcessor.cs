namespace WordCounter.Services.Words
{
    /// <summary>
    /// Main service of application
    /// Responsible for manage tasks and printing result on the console
    /// </summary>
    internal interface IWordsProcessor
    {
        /// <summary>
        /// Main method
        /// Manage tasks and start process for files
        /// </summary>
        public Task CountWords();

        /// <summary>
        /// Responsible for printing result after calculation
        /// </summary>
        public void PrintResult();
    }
}
