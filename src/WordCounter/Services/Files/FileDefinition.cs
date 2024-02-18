namespace WordCounter.Services.Files;

/// <inheritdoc />
internal class FileDefinition : IFileDefinition
{
    private readonly StreamReader reader;
    private readonly int partSize;

    public bool EOF => reader.EndOfStream;

    internal FileDefinition(string file, int partSize)
    {
        this.reader = new StreamReader(File.OpenRead(file));
        this.partSize = partSize;
    }

    /// <inheritdoc />
    public async Task<char[]> ReadPartSize()
    { 
        char[] memoryBuffer = new char[partSize];

        var charsRead = await reader.ReadBlockAsync(memoryBuffer, 0, partSize);

        if (reader.EndOfStream)
        {
            char[] resultTable = new char[charsRead];
            for (int i = 0; i < charsRead; i++)
            {
                resultTable[i] = memoryBuffer[i];
            }

            return resultTable;
        }

        return memoryBuffer;
    }

    public void Dispose()
    {
        reader.Dispose();
    }
}