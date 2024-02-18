namespace WordCounter.Configuration
{
    /// <summary>
    /// Configuration class for binding
    /// </summary>
    internal class MainConfiguration
    {
        internal static string Section = "MainConfiguration";

        /// <summary>
        /// Size of section to read from file
        /// </summary>
        public int SectionSize { get; set; }
        
        /// <summary>
        /// Directory where files to processing are stored
        /// </summary>
        public string FilesDirectory { get; set; } = string.Empty;
    }
}
