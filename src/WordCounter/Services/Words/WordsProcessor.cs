using WordCounter.Services.Dictionary;
using WordCounter.Services.Files;
using WordCounter.Services.Printer;

namespace WordCounter.Services.Words;

/// <summary>
/// Main service of application
/// Responsible for manage tasks and printing result on the console
/// </summary>
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

    /// <summary>
    /// Main method
    /// Manage tasks and start process for files
    /// </summary>
    public async Task CountWords()
    {
        var filesPaths = filesProvider.GetFileDefinitionsPaths();

        var tasks = filesPaths.Select(fileProcessor.ProcessFile);
        await Task.WhenAll(tasks);
    }

    /// <summary>
    /// Responsible for printing result after calculation
    /// </summary>
    public void PrintResult()
    {
        printer.Print();
    }
}