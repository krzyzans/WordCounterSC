namespace WordCounter.Services.Files
{
    /// <summary>
    /// Provider for FileDefinition and paths of files
    /// </summary>
    internal interface IFileProvider
    {
        /// <summary>
        /// Returns list of files path (*.txt) in directory
        /// </summary>
        public IReadOnlyList<string> GetFileDefinitionsPaths();

        /// <summary>
        /// Base on parameters and create FileDefinition - more like Factory Method
        /// </summary>
        /// <param name="file"></param>
        public IFileDefinition GetFileDefinition(string file);
    }
}
