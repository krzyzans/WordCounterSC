using Microsoft.Extensions.Options;
using WordCounter.Configuration;
using WordCounter.Exceptions;

namespace WordCounter.Services.Files;

/// <inheritdoc />
internal class FileProvider : IFileProvider
{
    private readonly MainConfiguration mainConfiguration;

    public FileProvider(IOptions<MainConfiguration> configuration)
    {
        this.mainConfiguration = configuration.Value;
    }

    public IReadOnlyList<string> GetFileDefinitionsPaths()
    {
        if (!Directory.Exists(mainConfiguration.FilesDirectory)) throw new PathNotFoundException(mainConfiguration.FilesDirectory);

        var files = Directory.GetFiles(mainConfiguration.FilesDirectory, "*.txt");

        if (files == null || !files.Any()) throw new DirectoryIsEmptyException(mainConfiguration.FilesDirectory);

        return files;
    }

    public IFileDefinition GetFileDefinition(string file)
    {
        return new FileDefinition(file, mainConfiguration.SectionSize);
    }
}