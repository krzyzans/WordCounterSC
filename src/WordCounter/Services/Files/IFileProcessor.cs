namespace WordCounter.Services.Files
{
    /// <summary>
    /// Processor responsibility for process specific file
    /// </summary>
    internal interface IFileProcessor
    {
        /// <summary>
        /// Core method, read file partially and update information in dictionary
        /// </summary>
        /// <param name="fileDefinitionPath"></param>
        internal Task ProcessFile(string fileDefinitionPath);
    }
}
