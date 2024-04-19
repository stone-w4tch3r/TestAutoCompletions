using System.Text;

namespace Core;

internal class ReadableSearcher
{
    internal static CompletionsModel SearchCompletions(InputModel inputModel)
    {
        var completionsDict = inputModel.UserWords
            .ToDictionary(
                userWord => userWord,
                userWord => inputModel.DictWordsWithWeights
                    .Where(wordWithWeight => wordWithWeight.Key.StartsWith(userWord))
                    .OrderByDescending(wordWithWeight => wordWithWeight.Value)
                    .ThenBy(wordWithWeight => wordWithWeight.Key)
                    .Take(10)
                    .Select(wordWithWeight => wordWithWeight.Key)
                    .ToArray()
            );

        return new(completionsDict);
    }
}