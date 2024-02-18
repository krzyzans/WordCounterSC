namespace WordCounter.Services.Files
{
    /// <summary>
    /// File definition, covers implementation of stream reader and EOF
    /// </summary>
    internal interface IFileDefinition : IDisposable
    {
        internal bool EOF { get; }

        internal Task<char[]> ReadPartSize();
    }
}
