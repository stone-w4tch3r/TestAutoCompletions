namespace Core;

public record InputModel(
    Dictionary<string, int> DictWordsWithWeights,
    string[] UserWords
);

public record OutputModel(
    Dictionary<string, string[]> Completions
);