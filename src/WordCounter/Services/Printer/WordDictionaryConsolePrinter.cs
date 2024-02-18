using WordCounter.Services.Dictionary;

namespace WordCounter.Services.Printer;

/// <summary>
/// Console printer implementation for IWordDictionary
/// </summary>
internal class WordDictionaryConsolePrinter : IPrinter<IWordDictionary>
{
    private readonly IWordDictionary wordDictionary;

    public WordDictionaryConsolePrinter(IWordDictionary wordDictionary)
    {
        this.wordDictionary = wordDictionary;
    }

    /// <summary>
    /// Prints word dictionary on console
    /// </summary>
    public void Print()
    {
        Console.WriteLine(wordDictionary);
    }
}