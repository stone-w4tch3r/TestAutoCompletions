namespace Core;

internal record InputModel(
    Dictionary<string, int> DictWordsWithWeights,
    string[] UserWords
);

internal record CompletionsModel(
    Dictionary<string, string[]> Completions
);