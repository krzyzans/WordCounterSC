namespace WordCounter.Services.Files
{
    /// <summary>
    /// Processor responsibility for process specific file
    /// </summary>
    internal interface IFileProcessor
    {
        internal Task ProcessFile(string fileDefinitionPath);
    }
}
