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
                    dictionaryCounter.Add(word);
                    word = string.Empty;
                }
            }
        }
        if (fileDefinitionEof && !string.IsNullOrEmpty(word))
        {
            dictionaryCounter.Add(word);
            word = string.Empty;
        }

        return word;
    }
}