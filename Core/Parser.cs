namespace Core;

internal static class Parser
{
    internal static InputModel Parse(string input)
    {
        var lines = SplitByNewLine(input);
        
        var dictLength = int.Parse(lines[0]);
        
        var dictWordsWithWeights = new Dictionary<string, int>();
        for (var i = 1; i <= dictLength; i++)
        {
            var line = lines[i];
            var parts = line.Split(" ");

            var word = parts[0];
            var weight = int.Parse(parts[1]);
            dictWordsWithWeights[word] = weight;
        }

        var userWordsLength = int.Parse(lines[dictLength + 1]);
        var userWords = new string[userWordsLength];
        for (var i = 0; i < userWordsLength; i++)
            userWords[i] = lines[dictLength + 2 + i];

        return new(dictWordsWithWeights, userWords);
    }

    private static string[] SplitByNewLine(string str) => 
        str.Split(["\n", "\r"], StringSplitOptions.RemoveEmptyEntries);
}