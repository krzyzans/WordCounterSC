using WordCounter.Services.Dictionary;

namespace WordCounter.Services.Files;

/// <inheritdoc />
internal class FileProcessor : IFileProcessor
{
    private readonly IFileProvider filesProvider;
    private readonly IWordDictionary dictionaryCounter;

    public FileProcessor(IFileProvider filesProvider, IWordDictionary dictionaryCounter)
    {
        this.filesProvider = filesProvider;
        this.dictionaryCounter = dictionaryCounter;
    }

    /// <inheritdoc />
    public async Task ProcessFile(string fileDefinitionPath)
    {
        using var fileDefinition = filesProvider.GetFileDefinition(fileDefinitionPath);
        var word = string.Empty;

        do
        {
            char[] readContent = await fileDefinition.ReadPartSize();

            word = UpdateWordCounts(readContent, fileDefinition.EOF, word);
        } while (!fileDefinition.EOF);
    }


    private string UpdateWordCounts(char[] part, bool fileDefinitionEof, string word)
    {
        var words = new List<string>();

        foreach (var c in part)
        {
            if (char.IsLetterOrDigit(c))
            {
                word += c;
            }
            else
            {
                if (!string.IsNullOrEmpty(word))
                {
                    word = dictionaryCounter.Add(word);
                }
            }
        }
        if (fileDefinitionEof && !string.IsNullOrEmpty(word))
        {
            word = dictionaryCounter.Add(word);
        }

        return word;
    }
}