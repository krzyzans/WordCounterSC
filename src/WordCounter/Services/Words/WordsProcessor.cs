using WordCounter.Services.Dictionary;
using WordCounter.Services.Files;
using WordCounter.Services.Printer;

namespace WordCounter.Services.Words;

/// <inheritdoc />
internal class WordsProcessor : IWordsProcessor
{
    private readonly IFileProvider filesProvider;
    private readonly IFileProcessor fileProcessor;
    private readonly IPrinter<IWordDictionary> printer;

    public WordsProcessor(IFileProvider filesProvider, IFileProcessor fileProcessor, IPrinter<IWordDictionary> printer)
    {
        this.filesProvider = filesProvider;
        this.fileProcessor = fileProcessor;
        this.printer = printer;
    }

    /// <inheritdoc />
    public async Task CountWords()
    {
        var filesPaths = filesProvider.GetFileDefinitionsPaths();

        var tasks = filesPaths.Select(fileProcessor.ProcessFile);
        await Task.WhenAll(tasks);
    }

    /// <inheritdoc />
    public void PrintResult()
    {
        printer.Print();
    }
}