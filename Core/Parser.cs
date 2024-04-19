namespace Core;

internal static class Parser
{
    internal static InputModel Parse(string input)
    {
        var lines = SplitByNewLine(input);

        int dictLength;
        try
        {
            dictLength = int.Parse(lines[0]);
        }
        catch (Exception)
        {
            throw new ParsingException("First line must be a valid dictionary length", 0, lines[0]);
        }


        var dictWordsWithWeights = new Dictionary<string, int>();
        for (var i = 1; i <= dictLength; i++)
        {
            var line = lines[i];
            var parts = line.Split(" ");
            if (!IsDictLineValid(parts))
                throw new ParsingException("Invalid dictionary line", i, line);

            var word = parts[0];
            var weight = int.Parse(parts[1]);
            dictWordsWithWeights[word] = weight;
        }

        int userWordsLength;
        try
        {
            userWordsLength = int.Parse(lines[dictLength + 1]);
        }
        catch (Exception)
        {
            throw new ParsingException("Invalid user words length", dictLength + 1, lines[dictLength + 1]);
        }

        var userWords = new string[userWordsLength];
        for (var i = 0; i < userWordsLength; i++)
            userWords[i] = lines[dictLength + 2 + i];

        return new(dictWordsWithWeights, userWords);
    }

    private static bool IsDictLineValid(string[] parts) => 
        parts.Length == 2 && int.TryParse(parts[1], out _);

    private static string[] SplitByNewLine(string str) => 
        str.Split(["\n", "\r"], StringSplitOptions.RemoveEmptyEntries);

    private class ParsingException(string message, int lineNumber, string line) : Exception(message)
    {
        private int LineNumber { get; } = lineNumber;

        private string Line { get; } = line;

        public override string Message => $"{base.Message}, line {LineNumber}: '{Line}'";
    }
}