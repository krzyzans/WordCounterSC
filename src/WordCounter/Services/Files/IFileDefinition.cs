namespace WordCounter.Services.Files
{
    /// <summary>
    /// File definition, covers implementation of stream reader and EOF
    /// </summary>
    internal interface IFileDefinition : IDisposable
    {
        internal bool EOF { get; }

        /// <summary>
        /// Method read file in partial and in case is needed sets EOF
        /// </summary>
        internal Task<char[]> ReadPartSize();
    }
}
