using System.Text;

namespace WordCounter.Services.Dictionary;

/// <inheritdoc />
internal class WordDictionary : IWordDictionary
{
    /// <summary>
    /// Synchronization object
    /// </summary>
    private readonly object sync = new();

    private readonly Dictionary<string, int> wordsCounter = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

    /// <summary>
    /// Method for secure concurrent add element to dictionary
    /// </summary>
    /// <param name="word">Key to add</param>
    public string Add(string word)
    {
        lock (sync)
        {
            if (!wordsCounter.TryAdd(word, 1))
            {
                wordsCounter[word]++;
            }

            word = "";
        }

        return word;
    }

    /// <summary>
    /// ToString override for presentation or printing
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();

        lock (sync)
        {
            foreach (var keyValueWord in wordsCounter)
            {
                stringBuilder.Append($"{keyValueWord.Value}: {keyValueWord.Key} {Environment.NewLine}");
            }
        }

        return stringBuilder.ToString();
    }

}