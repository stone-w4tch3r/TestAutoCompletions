using System.Text;

namespace Core;

internal class FastSearcher
{
    internal static CompletionsModel SearchCompletions(InputModel inputModel)
    {
        var startsToWordsCache = new Dictionary<string, List<string>>();
        foreach (var word in inputModel.DictWordsWithWeights.Keys)
        {
            var sb = new StringBuilder();
            var maxUserWordLength = inputModel.UserWords.Max(x => x.Length);
            for (var index = 0; index < maxUserWordLength; index++)
            {
                var c = word[index];
                sb.Append(c);
                var start = sb.ToString();
                if (!startsToWordsCache.ContainsKey(start))
                    startsToWordsCache[start] = [];
                startsToWordsCache[start].Add(word);
            }
        }
        
        var completionsDict = inputModel.UserWords
            .ToDictionary(
                userWord => userWord,
                userWord => startsToWordsCache[userWord]
                    .OrderByDescending(x => inputModel.DictWordsWithWeights[x])
                    .ThenBy(x => x)
                    .Take(10)
                    .ToArray()
            );

        return new(completionsDict);
    }
}