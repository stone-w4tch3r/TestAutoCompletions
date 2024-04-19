namespace Core;

internal class ReadableSearcher
{
    internal static CompletionsModel SearchCompletions(InputModel inputModel)
    {
        var completionsDict = inputModel.UserWords
            .ToDictionary(
                userWord => userWord,
                userWord => inputModel.DictWordsWithWeights
                    .Tap(x => Console.WriteLine(x + userWord))
                    .Where(wordWithWeight => wordWithWeight.Key.StartsWith(userWord))
                    .Tap(x => Console.WriteLine(x))
                    .OrderByDescending(wordWithWeight => wordWithWeight.Value)
                    .ThenBy(wordWithWeight => wordWithWeight.Key)
                    .TakeNotMoreThan(10)
                    .Select(wordWithWeight => wordWithWeight.Key)
                    .ToArray()
            );

        return new(completionsDict);
    }
}