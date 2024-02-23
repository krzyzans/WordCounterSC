using System.Text;

namespace WordCounter.Services.Dictionary;

/// <inheritdoc />
internal class WordDictionary : IWordDictionary
{
    /// <summary>
    /// Synchronization object
    /// </summary>
    private readonly object sync = new();

    private readonly IDictionary<string, int> wordsCounter = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

    /// <inheritdoc />
    public void Add(string word)
    {
        lock (sync)
        {
            if (!wordsCounter.TryAdd(word, 1))
            {
                wordsCounter[word]++;
            }
        }
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